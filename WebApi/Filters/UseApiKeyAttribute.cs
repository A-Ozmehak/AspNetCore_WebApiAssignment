using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = config.GetValue<string>("ApiKey");

        if (!context.HttpContext.Request.Query.TryGetValue("key", out var providedKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        if (!apiKey!.Equals(providedKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        await next();
    }
}

//[AttributeUsage(AttributeTargets.All)]
//public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
//{
//    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
//    {
//        var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
//        var secret = configuration?["ApiKey:Secret"];

//        if (!string.IsNullOrEmpty(secret) && context.HttpContext.Request.Query.TryGetValue("key", out var key))
//        {
//            if (!string.IsNullOrEmpty(key) && secret == key)
//            {
//                await next();
//                return;
//            }
//        }

//        context.Result = new UnauthorizedResult();
//    }
//}