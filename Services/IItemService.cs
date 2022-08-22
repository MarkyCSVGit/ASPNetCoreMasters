using Services.DTO;

namespace Services
{
    public interface IItemService
    {
        public IEnumerable<ItemDTO> GetAll();
        public IEnumerable<ItemDTO> GetItemByFilter(Dictionary<string, string> filters);
        public void Save(ItemDTO itemDTO);
        public IEnumerable<ItemDTO> GetItem(int itemId);
        public ItemDTO Get(int itemId);
        public void Add(ItemDTO itemDto);
        public void Update(ItemDTO itemDTO);
        public void Delete(int id);

    }
}
