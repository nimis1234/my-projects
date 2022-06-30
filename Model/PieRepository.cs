using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class PieRepository :IPieRepository
    {
        private readonly AppDbContext _appDbContext;
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies
                       .Include(a=>a.Category)
                    ;
            }
            
        }

        public IEnumerable<Pie> PiesOfTheWeek 
        {
            get
            {
                return _appDbContext.Pies.Where(a => a.IsPieOfTheWeek);
            }
           
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.Where(a => a.PieId == pieId).FirstOrDefault();
        }
        //public IEnumerable<Pie> GetAllPieBasedOnCategories()
        //{
        //    throw;
        //}
    }
}
