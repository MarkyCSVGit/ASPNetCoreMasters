using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http.Extensions;
using System.Diagnostics;

namespace ASPNetCoreMastersTodoList.Api.Filters
{
    public class ActionExecutionTimeFilter :  Attribute, IAsyncActionFilter
    {
       
       
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            context.HttpContext.Items["ActionName"] = context.HttpContext.Request.GetEncodedUrl();
            context.HttpContext.Items["StartTime"] = DateTime.UtcNow;
            Console.WriteLine("Executing OnActionExecuting Start time " + context.HttpContext.Items["StartTime"].ToString());

            ActionExecutedContext executedContext = await next();
          
            DateTime startTime = (DateTime)executedContext.HttpContext.Items["StartTime"];
            Console.WriteLine("Executing OnActionExecuted " + executedContext.HttpContext.Items["ActionName"].ToString() + "-" + (DateTime.UtcNow - startTime).TotalMilliseconds);

        }

    }
}
