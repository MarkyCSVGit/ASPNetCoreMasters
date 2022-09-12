using Microsoft.AspNetCore.Mvc;
using Services;
using ASPNetCoreMastersTodoList.Api.BindingModels;
using AutoMapper;
using Services.DTO;
using ASPNetCoreMastersTodoList.Api.Filters;
using Microsoft.AspNetCore.Authorization;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    [Route("items")]
    [Authorize(Policy = "CanEditItems")]
    [ApiController]
    [EnsureItemsExistFilterAttribute]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public ItemsController(ILogger<ItemsController> logger, IItemService itemService, IMapper mapper)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public IActionResult GetAll()
        {

            var itemEntities = _itemService.GetAll();
            var itemToReturn = _mapper.Map<IEnumerable<ItemDTO>>(itemEntities);
            return Ok(itemToReturn);
        }

        [HttpGet("{itemId}")]
        public IActionResult Get(int itemId)
        {
            var itemEntities = _itemService.Get(itemId);
            if (itemEntities == null)
            {
                _logger.LogInformation(
                    $"Item with id {itemId} wasn't found.");
                return NotFound();
            }

            var itemToReturn = _mapper.Map<IEnumerable<ItemDTO>>(itemEntities);

            return Ok(itemToReturn);

        }

        [HttpGet("filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            //var itemEntities = _itemService.GetAllByFilter(ItemByFilterDTO filter);
            var dto = new ItemByFilterDTO();

            var itemToReturn = _mapper.Map<IEnumerable<ItemDTO>>(dto);

            return Ok(itemToReturn);
        }


        [HttpPost]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {

            var itemToReturn =
                _mapper.Map<ItemDTO>(itemCreateModel);

            _itemService.Add(itemToReturn);

            return NoContent();
        }


        [HttpPut]
        [Route("items/{itemId}")]
        public IActionResult Put(int id, [FromBody] ItemUpdateBindingModel itemUpdateModel)
        {
            
            return NoContent();
        }


        [HttpDelete]
        [Route("items/{itemId}")]
        public IActionResult Delete(int itemId)
        { 
            return NoContent();
        }


     
    }
}
