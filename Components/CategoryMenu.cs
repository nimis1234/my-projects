using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model;
using OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository CategoryRepository)
        {
            _categoryRepository = CategoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            //either you can use categoryrepositorydirectly
            //or by using a vioewmodel

            //var result = _categoryRepository.AllCategories.OrderBy(a=>a.CategoryId);
            //var categoryMenuViewModel = new CategoryMenuViewModel();
            //categoryMenuViewModel.categories = result;
            var categories = _categoryRepository.AllCategories.OrderBy(a => a.CategoryId);
            return View(categories);
        }
    }
}
