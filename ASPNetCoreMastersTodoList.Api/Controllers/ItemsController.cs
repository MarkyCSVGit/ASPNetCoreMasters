using Microsoft.AspNetCore.Mvc;
using Services;
using ASPNetCoreMastersTodoList.Api.BindingModels;
using AutoMapper;
using Services.DTO;

namespace ASPNetCoreMastersTodoList.Api.Controllers
{
    //[Route("api/Items")]
    //[ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;
        private readonly IMapper _mapper;
        public ItemsController(ItemService itemService, IMapper mapper)
        {
            _itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public List<ItemDTO> Get(ItemDTO itemDTO)
        {
            return _itemService.GetAll();
        }
        

        [HttpPost]
        public IActionResult Post(ItemCreateBindingModel itemBindingModel)
        {
            
            var itemToReturn =
                _mapper.Map<ItemDTO>(itemBindingModel);

            _itemService.Save(itemToReturn);

            return NoContent();
        }

    }
}
