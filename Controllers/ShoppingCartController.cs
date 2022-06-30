using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model;
using OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;
        private UserManager<IdentityUser> _userManager;
        public ShoppingCartController(IPieRepository pieRepository, ShoppingCart shoppingCart,UserManager<IdentityUser> userManager)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var ShopppingCartViewModel = new ShoppingCartViewModel
            {
               ShoppingCart= _shoppingCart,
               ShoppingCartTotal=_shoppingCart.GetShoppingCartTotal()

            };
            return View(ShopppingCartViewModel);
        }
        // means after doing a operation redirect to a view
        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var user = _userManager.Users.FirstOrDefault().Id;
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);
            if (selectedPie!=null)
            {
                _shoppingCart.AddToCart(selectedPie, 1, user);
            }
            // return to Action Index
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie= _pieRepository.GetPieById(pieId);
            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }

            return RedirectToAction("Index");
        }
    }
}
