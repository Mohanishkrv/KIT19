using KIT19.Models.Domain;

namespace KIT19.Models
{
    public class SearchProductViewModel
    {
        public string ProductName { get; set; }
        public string ProductSize { get; set; }
        public int Price { get; set; }
        public DateTime MfgDate { get; set; }
        public string Category { get; set; }
        public List<Product> Products { get; set; }
    }


}
