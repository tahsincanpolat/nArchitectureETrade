using ETrade.Business.Abstract;
using ETrade.Entities;
using ETrade.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class ShopController : Controller
    {

        private IProductService _productService;


        public ShopController(IProductService productService)
        {
            _productService = productService;   
        }

       [Route("products/{category?}")] // {category} => slug products/elektronik
       public IActionResult List(string category,int page=1)
       {
            const int pageSize = 3;

            var products = new ProductListModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    ItemsPerPage = pageSize,
                    CurrentCategory = category,
                    CurrentPage = page
                },
                Products = _productService.GetProductsByCategory(category,page,pageSize)
            };

            return View(products);
       } 

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails(id.Value);

            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });  
        }


    }
}
