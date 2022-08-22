using Microsoft.AspNetCore.Mvc;
using Services;
using ASPNetCoreMastersTodoList.Api.BindingModels;
using AutoMapper;
using Services.DTO;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("api/Items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public ItemsController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [Route("api/Items")]
        public IActionResult GetAll(ItemDTO itemDTO)
        {

            var itemEntities = _itemService.GetAll();
            var itemToReturn = _mapper.Map<IEnumerable<ItemDTO>>(itemEntities);
            return Ok(itemToReturn);
        }

        [HttpGet]
        [Route("api/items/{itemId}")]
        public IActionResult Get(int itemId)
        {

            var itemEntities = _itemService.GetItem(itemId);
            var itemToReturn = _mapper.Map<IEnumerable<ItemDTO>>(itemEntities);

            return Ok(itemToReturn);

        }

        [HttpGet]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)

        {
            var itemEntities = _itemService.GetItemByFilter(filters);
            var itemToReturn = _mapper.Map<IEnumerable<ItemDTO>>(itemEntities);

            return Ok(itemToReturn);
        }


        [HttpPost]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {

            var itemToReturn =
                _mapper.Map<ItemDTO>(itemCreateModel);

            _itemService.Save(itemToReturn);

            return NoContent();
        }


        [HttpPut]
        [Route("api/items/{itemId}")]
        public IActionResult Put(int id, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            
            return NoContent();
        }


        [HttpDelete]
        [Route("api/items/{itemId}")]
        public IActionResult Delete(int itemId)
        { 
            return NoContent();
        }


     
    }
}
