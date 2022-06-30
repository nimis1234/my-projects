using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model;
using OnlineShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components
{
    // this is used to view the total items added to shopping cart
    //we are using a inherited class called ViewComponent
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingcart)
        {
            _shoppingCart = shoppingcart;
        }
        // inoder to invoke or call Iviewcomponent we Iviewcomponetresult
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var shoppingcartViewModel = new ShoppingCartSummaryViewModel
            {
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                //ShoppingCart = _shoppingCart
                ShoppingCartItems= items

            };
            return View(shoppingcartViewModel);
        }
    }
}
