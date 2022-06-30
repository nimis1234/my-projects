using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class ShoppingCartItem
    {
        // its a new table in db
        public int ShoppingCartItemId { get; set; }
        public  Pie Pie {get;set;}
        public int Amount { get; set; }
        
        public string ShopipingCartId { get; set; }
        public string UniqueAddtoId { get; set; }

        
    }
}
