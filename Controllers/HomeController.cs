using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model;
using OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfTheWeek
            };
            //either this way you can assign or the below way
            //homeViewModel.PiesOfTheWeek = _pieRepository.PiesOfTheWeek;


            return View(homeViewModel);
        }
    }
}
