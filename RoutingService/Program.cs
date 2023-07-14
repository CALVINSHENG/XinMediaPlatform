#region SonarLint Disabled 放置區域
#pragma warning disable S1075 //[URI 不應該被硬編碼]
#pragma warning disable S125 // Sections of code should not be commented out
#pragma warning disable CS1587 // XML 註解沒有放置在有效的語言項目前
#endregion

#region 命名空間管理區

using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Reflection;

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
//	options.ListenAnyIP(7088, listenOptions =>
//	{
//		listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
//		listenOptions.UseHttps();
//	});
//});

#endregion

builder.Services.AddControllers();

#region 加入xml檔案到swagger

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/* 
 * 編輯作者：REMARK BY CALVIN AT 2022/12/22
 */
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
	var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
	options.IncludeXmlComments(xmlPath);

	#endregion

	#region Swagger文件描述(此區開發人員需依微服務編輯)

	/* 
	 * 編輯作者：ADD BY CALVIN AT 2023/04/28
	 * 說　　明：
	 * 設定Swagger MiddleWare
	 * Step1：
	 * ConfigureServices 加入 Swagger產生器
	 * 加入Swagger產生器到服務集合
	 * 備　　註：
	 * 引　　用：
	 * ░░░░░░░░░
	 * 修改歷程：
	 * 2023/04/28 初版
	*/
	options.SwaggerDoc(name: "v1", new OpenApiInfo
	{
		/*
		 * 編輯作者：REMARK BY CALVIN AT 2022/12/22
		 * 說明：
		 * 1. Version資訊對應Title輸出SwaggerUI後在Title右方接續顯示
		 * 2. Title後可針對此微服務的功能進行前、後端的詳細說明
		 * 3.Title對應微服務交叉文檔映照的Config:{Name}欄位值
		 */
		Version = "v1",
		Title = "RoutingService API",
		Description = "" +
		"<h2><font color=#600030>" +
		"Diversity Development Department MicroService Platform" +
		"</font></h2>" +
		"<h2><font color=#EA0000>" +
		"Web API 路由服務：<br/>" +
		"分流主責前端使用者跟微服務群彼此之間的溝通" +
		"</font></h2>",
		Contact = new OpenApiContact
		{
			Name = "開發說明文件",
			Url = new Uri("https://www.canva.com/design/DAFaajvt_cY/F4UF6cuu4j7NUKH4UEKQRQ/edit?utm_content=DAFaajvt_cY&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton")
		},
		License = new OpenApiLicense
		{
			Name = "開發規範文件",
			Url = new Uri("https://drive.google.com/file/d/16X5voU03YgrfXBFjJgOZsWujlKpPW18w/view?usp=sharing")
		}
	});
});

#endregion

#region 路由服務新增ocelot.json實體路由 JSON 檔案

/* 
	* 編輯作者：ADD BY CALVIN AT 2023/04/28
	* 說　　明：configure our project to use the ocelot.json
	* 備　　註：需先在路由服務新增ocelot.json實體路由 JSON 檔案
	* 引　　用：
	* ░░░░░░░░░
	* 修改歷程：
	* 2023/04/28 初版
*/
builder.Configuration.AddJsonFile(
	"ocelot.json"
	, optional: false
	, reloadOnChange: true);

builder.Services.AddOcelot(builder.Configuration);
/* 
* 編輯作者：ADD BY CALVIN AT 2023/04/28
* 說　　明：註冊MMLib.SwaggerForOcelot套件功能
* 備　　註：註冊微服務文檔
* 引　　用：
* ░░░░░░░░░
* 修改歷程：
* 2023/04/28 初版
*/
builder.Services.AddSwaggerForOcelot(builder.Configuration);

#endregion

builder.Services.AddMvc();

#region 設定CORS存取

/*
 *  編輯作者：ADD BY Shan AT 2023/04/28
 *  說明：前端串聯遭CORS阻擋，允許所有的Header, Origin
 *  備註：
 *  引用：
 *  ░░░░░░░░░
 *  修改歷程：
 *  2023/04/28 初版
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

#region 調用CORS設定存取

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

#region 讀取執行交叉式微服務文檔

/* 
* 編輯作者：ADD BY CALVIN AT 2023/04/28
* 說　　明：SwaggerUI Integration For Ocelot
* 備　　註：讀取執行交叉式微服務文檔
* 引　　用：
* ░░░░░░░░░
* 修改歷程：
* 2023/04/28 初版
*/
app.UseSwaggerForOcelotUI(options =>
{
	options.PathToSwaggerGenerator = "/swagger/docs";
}).UseOcelot().Wait();

#endregion

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
