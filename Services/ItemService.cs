namespace Services
{
    public class ItemService
    {
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

    }
}