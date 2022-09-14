namespace DomainModels
{
    public class Item
    {
        public string Text { get; set; } = string.Empty;
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
       
    }
}