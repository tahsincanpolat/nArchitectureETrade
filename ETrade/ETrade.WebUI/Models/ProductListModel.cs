using ETrade.Entities;

namespace ETrade.WebUI.Models
{
    public class ProductListModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; } 
    }

    public class PageInfo
    {
        public int TotalItems { get; set; } // 100
        public int ItemsPerPage { get; set; }  // 10
        public int CurrentPage { get; set; }  
        public string CurrentCategory { get; set; }  



        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);  
        }
    }
}
