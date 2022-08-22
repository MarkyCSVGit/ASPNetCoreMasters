using DomainModels;


namespace Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _dataContext;

        public ItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public IQueryable<Item> All()
        {
            return _dataContext.Items.AsQueryable();
        }

        public void Save(Item item)
        {}

        public void Delete(int id)
        { }
    }
}
