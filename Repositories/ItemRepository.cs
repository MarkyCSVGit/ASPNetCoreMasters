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

        public async Task<IEnumerable<Item>> All()
        {
            return _dataContext.Items.OrderBy(c => c.Text).ToList();
        }

        public void Save(Item item)
        {}

        public void Delete(int id)
        { }
    }
}
