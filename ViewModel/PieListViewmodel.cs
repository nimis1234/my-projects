using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModel
{
    public class PieListViewmodel
    {
        public IEnumerable<Pie> pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}
