#region SonarLint Disabled 放置區域
#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
#pragma warning disable S2259 // Null pointers should not be dereferenced

#endregion

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AuthorizationCheckService
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        private readonly EndpointDataSource _endpointDataSource;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpointDataSource"></param>
        public AuthorizeCheckOperationFilter(EndpointDataSource endpointDataSource)
        {
            _endpointDataSource = endpointDataSource;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var Descriptor = _endpointDataSource.Endpoints.FirstOrDefault(x =>
          x.Metadata.GetMetadata<ControllerActionDescriptor>() == context.ApiDescription.ActionDescriptor);

            var Authorize = Descriptor.Metadata.GetMetadata<AuthorizeAttribute>() != null;

            var AllowAnonymous = Descriptor.Metadata.GetMetadata<AllowAnonymousAttribute>() != null;

            if (!Authorize || AllowAnonymous)
                return;

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new()
                {
                    [
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"}
                        }
                    ] = new List<string>()
                }
            };
        }
    }
}
