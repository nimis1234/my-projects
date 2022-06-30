using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(AppDbContext appDbContext,ShoppingCart shoppingcart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingcart;
        }
        public void CreateOrder(Order order)
        {

            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();


            var cartItems = _shoppingCart.GetShoppingCartItems();
            
            foreach (var item in cartItems)
            {
                var orderDetails = new OrderDetail
                {
                    
                    PieId = item.Pie.PieId,
                    Amount=item.Amount,
                    Price=item.Pie.Price
                };
               order.OrderDetails.Add(orderDetails);

                //order.OrderDetails.Add(orderDetails);
            }
            _appDbContext.Add(order);
            _appDbContext.SaveChanges();
        }
    }
}
