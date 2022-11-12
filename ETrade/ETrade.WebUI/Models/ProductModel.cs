using ETrade.Entities;
using System.ComponentModel.DataAnnotations;

namespace ETrade.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60,MinimumLength = 5,ErrorMessage = "Ürün ismi minimum 5 maksimum 60 karakter olabilir")]
        public string Name { get; set; }
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Ürün açıklaması minimum 10 maksimum 100 karakter olabilir")]
        public string Description { get; set; }
        public List<Image> Images { get; set; }
        [Required]
        [Range(10000,40000)]
        public decimal Price { get; set; }
        public List<Category> SelectedCategories { get; set; }

        public ProductModel()
        {
            Images = new List<Image>();
        }

    }
}
