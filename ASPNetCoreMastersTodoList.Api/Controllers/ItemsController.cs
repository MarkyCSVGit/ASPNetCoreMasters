using Microsoft.AspNetCore.Mvc;
using Services;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;
        public ItemsController(ItemService itemService)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
        }

        [HttpGet]
        public IEnumerable<string> Get() =>
            _itemService.GetAll();

    }
}
