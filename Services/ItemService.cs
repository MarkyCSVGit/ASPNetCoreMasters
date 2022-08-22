using Services.DTO;
using AutoMapper;
using DomainModels;
using Repositories;

namespace Services
{
    public class ItemService: IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository,IMapper mapper)
        {
            _itemRepository = itemRepository;
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

        public IEnumerable<ItemDTO> GetAllByFilter(ItemByFilterDTO filterDto) => _itemRepository.All()
                .Where(x => filterDto.Id == x.Id || x.Text == filterDto.Text)
                .Select(x => new ItemDTO { Id = x.Id, Text = x.Text});

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