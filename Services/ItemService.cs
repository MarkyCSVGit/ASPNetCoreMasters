using Services.DTO;
using AutoMapper;
using DomainModels;

namespace Services
{
    public class ItemService
    {
        private readonly IMapper _mapper;
        public ItemService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }   
        public List<ItemDTO> GetAll()
        {
            var collectionToReturn = new List<ItemDTO>();
            return collectionToReturn;
        }

        public void Save(ItemDTO itemDTO)
        {
            var itemToReturn =
                 _mapper.Map<Item>(itemDTO);
        }

    }
}