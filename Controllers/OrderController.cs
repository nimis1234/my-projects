using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Authorize]
    //only loginned user can add the item to cart
    public class OrderController : Controller
    {
       
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        public OrderController(IOrderRepository orderRepository,ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            
            return View();
        }

        // use httppost method to get data that submit through http post
        [HttpPost]
        public IActionResult Checkout( Order order)
        {
            var item = _shoppingCart.GetShoppingCartItems();
            if(item.Count()==0)
            {
                //modelstate is used to check add error and check valid
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }
            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);
        }
        public IActionResult CheckOutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you!";
                return View();
        }

    }
}
