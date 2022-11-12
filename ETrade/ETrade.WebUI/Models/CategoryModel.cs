using ETrade.Entities;

namespace ETrade.WebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
