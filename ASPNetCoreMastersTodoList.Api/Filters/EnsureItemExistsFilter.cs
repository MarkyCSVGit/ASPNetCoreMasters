using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;

namespace ASPNetCoreMastersTodoList.Api.Filters
{
    public class EnsureItemExistsFilter : IActionFilter
    {
        private readonly ItemExistService _service;

        public EnsureItemExistsFilter(ItemExistService service)
        {
            _service = service;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var itemId = (int)context.ActionArguments["itemId"];
            if (!_service.DoesItemExist(itemId))
            {
                context.Result = new NotFoundResult();
            }
        }
    }

    public class EnsureItemsExistFilterAttribute : TypeFilterAttribute
    {
        public EnsureItemsExistFilterAttribute() : base(typeof(EnsureItemExistsFilter))
        {
        }
    }
}
