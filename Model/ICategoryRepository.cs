using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        
    }
}
