using ETrade.Business.Abstract;
using ETrade.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService) // Injection
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(new ProductListModel() { Products = _productService.GetAll() });
        }

 

       
    }
}