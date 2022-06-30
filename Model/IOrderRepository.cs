using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
    }
}
