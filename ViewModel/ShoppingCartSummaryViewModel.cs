using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModel
{
    public class ShoppingCartSummaryViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
