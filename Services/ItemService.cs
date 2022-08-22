using Services.DTO;
using AutoMapper;
using DomainModels;
using Repositories;

namespace Services
{
    public class ItemService: IItemService
    {
        //private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public ItemService(IMapper mapper)
        {
            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }   
        public IEnumerable<ItemDTO> GetAll()
        {
            var collectionToReturn = new List<ItemDTO>();
            return collectionToReturn;
        }

        public void Save(ItemDTO itemDTO)
        {
            var itemToReturn =
                 _mapper.Map<Item>(itemDTO);
        }

        public IEnumerable<ItemDTO> GetItem(int itemId)
        {
            
            var collectionToReturn = new List<ItemDTO>();
            return collectionToReturn;
        }

        public IEnumerable<ItemDTO> GetItemByFilter(Dictionary<string, string> filters)
        {
            if (filters == null)
            {
                throw new ArgumentNullException(nameof(filters));
            }

            var collectionToReturn = new List<ItemDTO>();
            return collectionToReturn;
        }

        public ItemDTO Get(int itemId)
        {
            throw new NotImplementedException();
        }

        public void Add(ItemDTO itemDto)
        {
            throw new NotImplementedException();
        }

        public void Update(ItemDTO itemDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}