using ETrade.Business.Abstract;
using ETrade.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETrade.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            this._categoryService = categoryService; 
        }

        public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel()
            {
                SelectedCategory = RouteData.Values["category"]?.ToString(),
                Categories = _categoryService.GetAll()
            });
        }
    }
}
