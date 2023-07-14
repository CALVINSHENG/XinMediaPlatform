#region SonarLint Disabled 放置區域
#pragma warning disable S1075 //[URI 不應該被硬編碼]
#pragma warning disable S125 // Sections of code should not be commented out
#pragma warning disable CS1587 // XML 註解沒有放置在有效的語言項目前
#pragma warning disable S3878 // Arrays should not be created for params parameters
#endregion

#region 命名空間管理區
using AuthorizationCheckService;
using XinMedia.Services.Interface;
using MicroServiceCoreLibrary.Helper;
using MicroServiceCoreLibrary.Models;
using MicroServiceCoreResposity.DbAccess.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System.Reflection;
using System.Text;
using XinMedia.Services.BackEnd;
using XinMedia.Services.FrontEnd;
#endregion

var builder = WebApplication.CreateBuilder(args);

#region MongoDB Setting
/* 
* 編輯作者：ADD BY 軒宇 AT 2022/12/22
* 說　　明：紀錄 log 到 MongoDb 的設置(官方)
* 備　　註：
* 引　　用：https://ithelp.ithome.com.tw/articles/10304772?sc=iThelpR
*			https://gitee.com/zxmlovelyboy/mongo-db-log
* ░░░░░░░░░
* 修改歷程：
* 2022/12/06	初版	軒宇
* 2022/12/22	V1		CALVIN		
*/
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();
#endregion

#region 加入Http3 UDP 通訊協議(須編輯更新該微服務的Port號；包Container會發生錯誤，先停用)

///*
//* 編輯作者：REMARK BY CALVIN AT 2023/03/28
//* 說明：使用 W3C 日誌記錄並檢查客戶端使用的協議版本
//*/
//builder.Services.AddW3CLogging(logging =>
//{
//	logging.LoggingFields = W3CLoggingFields.All;
//	logging.LogDirectory = @"C:\logs";
//	logging.FlushInterval = TimeSpan.FromSeconds(2);
//});

///*
//* 編輯作者：REMARK BY CALVIN AT 2023/03/28
//* 說明：配置 Kestrel 以偵聽 HTTP/1、HTTP/2 和 HTTP/3。
//* 備註：支持舊協議很重要，因為並非所有客戶端都支持新協議。 
//*			此外，HTTP/3 需要安全連接，因此您必須使用 UseHttps
//*/
//builder.WebHost.ConfigureKestrel((context, options) =>
//{
//	options.ListenAnyIP(7136, listenOptions =>
//	{
//		listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
//		listenOptions.UseHttps();
//	});
//});

#endregion

// Add services to the container.
builder.Services.AddControllers();

#region 設定CORS存取
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins",
		builder =>
		{
			builder.AllowAnyOrigin();
			builder.AllowAnyHeader();
			builder.AllowAnyMethod();
		});
});
#endregion

#region 取得Token設定值(AuthorizationService專責區，其他微服務無須添加)
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
#endregion

#region 驗證註冊
builder.Services.AddAuthentication(opt =>
{
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
	.AddJwtBearer(options =>
	{
		var tokenSettings = builder.Configuration.GetSection("TokenSettings").Get<TokenSettings>();
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,                //是否驗證 JWT 的過期時間
			ValidateIssuerSigningKey = true,

			ValidIssuer = tokenSettings.Issuer,     //JWT 簽名者
			ValidAudience = tokenSettings.Audience, //JWT 接收者
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Key!)),
		};
	});
#endregion

#region 加入xml檔案到swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
	/* 
 * 編輯作者：ADD BY CALVIN AT 2022/12/22
 * 說　　明：加入xml檔案到swagger
 * 備　　註：
 * 引　　用：
 * ░░░░░░░░░
 * 修改歷程：
 * 2022/12/22 初版
*/
	var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
	options.IncludeXmlComments(xmlPath);
	#endregion

	#region 驗證視窗
	//swagger驗證視窗
	options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		In = ParameterLocation.Header,
		Description = "Please enter token",
		Name = "Authorization",
		Type = SecuritySchemeType.Http,
		BearerFormat = "JWT",
		Scheme = "bearer"
	});
	options.OperationFilter<AuthorizeCheckOperationFilter>();
	#endregion

	#region Swagger文件描述(開發規範文件)(此區開發人員需依微服務編輯)
	/* 
	 * 編輯作者：ADD BY CALVIN AT 2022/12/22
	 * 說　　明：
	 * 設定Swagger MiddleWare
	 * Step1：
	 * ConfigureServices 加入 Swagger產生器
	 * 加入Swagger產生器到服務集合
	 * 備　　註：
	 * 引　　用：
	 * ░░░░░░░░░
	 * 修改歷程：
	 * 2022/12/22 初版
	*/
	options.SwaggerDoc(name: "v1", new OpenApiInfo
	{
		/*
		 * 編輯作者：REMARK BY CALVIN AT 2022/12/22
		 * 說明：
		 * 1. Version資訊對應Title輸出SwaggerUI後在Title右方接續顯示
		 * 2. Title後可針對此微服務的功能進行前、後端的詳細說明
		 * 3. Title對應微服務交叉文檔映照的Config:{Name}欄位值
		 */
		Version = "前台區",
		Title = "🗳 多元系統發展部 - 欣傳媒~新生活態度",
		Description = "" +
		"<h2><font color=#600030>" +
		"</font></h2>" +
		"<h2><font color=#EA0000>" +
		"📜 欣傳媒-前台接口資訊<br/>" +
		"</font></h2>" +
		"<h3><font color=#004B97>" +
		"</font></h3>",
		Contact = new OpenApiContact
		{
			Name = "開發環境安裝說明文件",
			Url = new Uri("https://www.canva.com/design/DAFaajvt_cY/F4UF6cuu4j7NUKH4UEKQRQ/edit?utm_content=DAFaajvt_cY&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton")
		},
		License = new OpenApiLicense
		{
			Name = "開發常見問題說明及相關規範文件",
			Url = new Uri("https://drive.google.com/file/d/1woxGSVsttOnOqh-r3DY_qasQDUqx1qOR/view?usp=sharing")
		}
		//TermsOfService = new Uri("https://example.com/terms"),
	});
	options.SwaggerDoc(name: "v2", new OpenApiInfo
	{
		/*
		 * 編輯作者：REMARK BY CALVIN AT 2022/12/22
		 * 說明：
		 * 1. Version資訊對應Title輸出SwaggerUI後在Title右方接續顯示
		 * 2. Title後可針對此微服務的功能進行前、後端的詳細說明
		 * 3. Title對應微服務交叉文檔映照的Config:{Name}欄位值
		 */
		Version = "後台區",
		Title = "🗳 多元系統發展部 - 欣傳媒~新生活態度",
		Description = "" +
		"<h2><font color=#600030>" +
		"</font></h2>" +
		"<h2><font color=#EA0000>" +
		"📜 欣傳媒-後台接口資訊<br/>" +
		"</font></h2>" +
		"<h3><font color=#004B97>" +
		"</font></h3>",
		Contact = new OpenApiContact
		{
			Name = "開發環境安裝說明文件",
			Url = new Uri("https://www.canva.com/design/DAFaajvt_cY/F4UF6cuu4j7NUKH4UEKQRQ/edit?utm_content=DAFaajvt_cY&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton")
		},
		License = new OpenApiLicense
		{
			Name = "開發常見問題說明及相關規範文件",
			Url = new Uri("https://drive.google.com/file/d/1woxGSVsttOnOqh-r3DY_qasQDUqx1qOR/view?usp=sharing")
		}
		//TermsOfService = new Uri("https://example.com/terms"),
	});
	/* 
	 * 編輯作者：ADD BY CALVIN AT 2022/12/22
	 * 說　　明：
	 * 多版本的 Swagger Json
	 * 先定義多個版本的 API 資訊
	 * 備　　註：
	 * 引　　用：
	 * ░░░░░░░░░
	 * 修改歷程：
	 * 2022/12/22 初版
	*/
	//TO DO
});
#endregion

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("roles-policy", policy =>
	{
		policy.RequireRole(new string[] { "管理員", "預設觀看者" });
	});
});

#region 驗證以及端口註冊(此區開發人員需依微服務編輯)
/* 
 * 編輯作者：ADD BY CALVIN AT 2022/12/22
 * 說　　明：Dependency Injection Register
 * 備　　註：
 * 引　　用：
 * ░░░░░░░░░
 * 修改歷程：
 * 2022/12/22 初版
 */
builder.Services.AddScoped<IBackEnd, BackEndBusiness>();
builder.Services.AddScoped<IFrontEnd, FrontEndBusiness>();

#region GraphQL 相關設定
builder.Services.AddScoped<AuthLoginHelper>();
builder.Services.AddScoped<TokenHelper>();
//builder.Services.AddScoped<IAuthLogin, AuthLoginBusiness>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddHttpResultSerializer<MyCustomHttpResultSerializer>();

//builder.Services.AddGraphQLServer()
//    .AddAuthorization()
//    .AddQueryType(q => q.Name("Query"))
//    .AddType<QueryResolver>()
//    .AddMutationType<MutationResolver>()
//    .AddFiltering()
//    .AddSorting();
#endregion

builder.Services.AddMvc();
#endregion

#region 設定CORS存取

/*
 *  編輯作者：ADD BY Shan AT 2023/03/13
 *  說明：前端串聯遭CORS阻擋，允許所有的Header, Origin
 *  備註：
 *  引用：
 *  ░░░░░░░░░
 *  修改歷程：
 *  2023/03/13 初版
 */
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins", builder =>
	{
		builder.AllowAnyOrigin();
		builder.AllowAnyHeader();
		builder.AllowAnyMethod();
	});
});

#endregion

var app = builder.Build();

#region Swagger JSON文件檔案(此區開發人員需依微服務編輯)

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	/* 
	 * 編輯作者：ADD BY CALVIN AT 2022/12/22
	 * 說　　明：
	 * 設定Swagger MiddleWare
	 * Step2：
	 *			app.UseSwagger()：使用 Swagger Json 檔
	 *			app.UseSwaggerUI()：使用 SwaggerUI
	 *	備　　註：
	 *	●當服務啟動時，訪問 https://localhost:<port>/swagger/v1/swagger.json，
	 *		便能取得 swagger json 檔案
	 *	●訪問 https://localhost:<port>/swagger，就能透過 Swagger UI 探索 Web API
	 *	在這個步驟 Swagger UI 就可以正常的運作
	 * 引　　用：
	 * ░░░░░░░░░
	 * 修改歷程：
	 * 2022/12/22 初版
	*/
	app.UseSwagger();
	/* 
	 * 編輯作者：ADD BY CALVIN AT 2022/12/06
	 * 說　　明：
	 * 設定Swagger JSON
	 * 說明檔位置可以透過以下的設定方式改變
	 *	備　　註：
	 * 引　　用：
	 * ░░░░░░░░░
	 * 修改歷程：
	 * 2022/12/06 初版
	*/
	app.UseSwaggerUI(options =>
	{
		/* 
		 * 編輯作者：ADD BY CALVIN AT 2022/12/06
		 * 說　　明：設定 Swagger UI 訪問 Json 的位置
		 *	備　　註：1.options.SwaggerEndpoint的第二格參數
		 *	　　　　　對應SwaggerUI右上的資訊
		 *	　　　　　2.因應多版本文件
		 * 引　　用：
		 * ░░░░░░░░░
		 * 修改歷程：
		 * 2022/12/06 初版
		*/
		options.SwaggerEndpoint(
			"/swagger/v1/swagger.json"
			, "🧱 欣傳媒-前台顯示開發功能區");
		options.SwaggerEndpoint(
			"/swagger/v2/swagger.json"
			, "🧱 欣傳媒-後台管理開發功能區");
	});
}
#endregion

app.UseHttpsRedirection();

app.UseRouting();

#region 調用CORS設定存取(此區開發人員需依微服務存取權限編輯)

/* 
* 編輯作者：ADD BY CALVIN AT 2023/05/10
* 說　　明：
*						設定 CORS MiddleWare
* 備　　註：		請注意，調用CORS MiddleWare
*						必須放置在app.UseRouting();與app.UseEndpoints之間
*						否則會發生CORS Header 嚴重錯誤
* 引　　用：
* ░░░░░░░░░
* 修改歷程：
* 202305/10 初版
*/
app.UseCors("AllowAllOrigins");

#endregion

app.UseAuthentication();

app.UseAuthorization();

#region GraphQL端點(目前停用)

app.UseEndpoints(endpoints =>
#pragma warning disable S125 // Sections of code should not be commented out
{
	//endpoints.MapGraphQL().WithOptions(new HotChocolate.AspNetCore.GraphQLServerOptions
	//{
	//    EnableSchemaRequests = false,   //是否啟用Schema請求，是否通過SDL附加到端點下載GraphQL Server的架構
	//    EnableGetRequests = false,      //是否能夠處理通過 HTTP GET 請求中的查詢字符串發送的 GraphQL 操作
	//    Tool =
	//    {
	//        Enable = app.Environment.IsDevelopment() //開發期間僅啟用Banana Cake Pop
	//    }
	//});
}
#pragma warning restore S125 // Sections of code should not be commented out
);

#endregion

app.MapControllers();

app.Run();
