using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model;
using OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        // we are going to inject both interface to a constructor

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }
        //controller always handles the actions

        //viewResult is used to view the list
        //list is the name of view
        public ViewResult List(string category)
        {
            PieListViewmodel pieListViewModel = new PieListViewmodel();
            if (category == null)
            {
                //view bag is dynamic method and can use to display whatever we want
                //ViewBag.CurrentCategory = "CheeseCake";
                //ViewBag.message = "Can give anything in View Bag";
                //instead of this we can use viewmodel
                //return View(_pieRepository.AllPies.ToList());


                pieListViewModel.pies = _pieRepository.AllPies;
                //pieListViewModel.CurrentCategory = "cheese Cake";
                //data move to the view ie to List
                return View(pieListViewModel);
            }
            else
            pieListViewModel.pies = _pieRepository.AllPies.Where(a => a.Category.CategoryName == category);
            pieListViewModel.CurrentCategory = category;
            //data move to the view ie to List
            return View(pieListViewModel);
        }

        public IActionResult Details(int Id)
        {
            var pie = _pieRepository.GetPieById(Id);
            return View(pie);
        }

    }
}
