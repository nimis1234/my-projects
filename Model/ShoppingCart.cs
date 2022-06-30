using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class ShoppingCart
    {
        //this is the shoppingcart repository
        private readonly AppDbContext _appDbContext;
        private string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart( AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        /// <summary>
        ///  this method is used to get the session of cart and add thr sessioncarid 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            /// this function is used to get the session 
            /// // for this we need httpcontextaccessor and need to register in startup class
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            // used to get AppDbcontext services
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie, int amount,string Id)
        {

            // check whether already pie itesm added for that particualr shoppingcardId-ie for particular session
            var shoppingCartItem = _appDbContext.ShoppingCartItems.FirstOrDefault(a => a.Pie.PieId == pie.PieId && a.ShopipingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShopipingCartId = ShoppingCartId,
                    Pie = pie,
                    //amount means quatity
                    Amount = 1,
                    UniqueAddtoId=Id
                };
                // add to table
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            //save the changes
            _appDbContext.SaveChanges();

        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.Where(a => a.Pie.PieId == pie.PieId).FirstOrDefault();
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount = shoppingCartItem.Amount - 1;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _appDbContext.SaveChanges();
            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDbContext.ShoppingCartItems.Where(c => c.ShopipingCartId == ShoppingCartId)
                           .Include(s => s.Pie)
                           .ToList());
        }
        public void ClearCart()
        {
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShopipingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(c => c.ShopipingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }
    }
}
