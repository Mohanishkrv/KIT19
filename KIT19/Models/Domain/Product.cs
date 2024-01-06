namespace KIT19.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }

        public string ProductSize{ get; set; }
        public int Price {  get; set; }
        public DateTime MfgDate { get; set; }
        public string Category { get; set; }
    }
}
