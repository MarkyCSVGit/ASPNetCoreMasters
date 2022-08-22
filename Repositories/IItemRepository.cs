using DomainModels;


namespace Repositories
{
    public interface IItemRepository
    {
       
        Task<IEnumerable<Item>> All();

        void Save(Item item);

        void Delete(int id);    

        
    }
}
