using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public class MockCategoryRepository: ICategoryRepository
    {

        //mocking database data
        public IEnumerable<Category> AllCategories =>
        new List<Category>
        { 
            new Category { CategoryId =1, CategoryName="Fruit Pie",Description="All-Fruit"},
            new Category { CategoryId =2, CategoryName="Fruit Pie",Description="All-Fruit"},
            new Category { CategoryId =3, CategoryName="Fruit Pie",Description="All-Fruit"},
            new Category { CategoryId =4, CategoryName="Fruit Pie",Description="All-Fruit"}
        };

        //adding data to Allcategory list without connecting to code
        public List<Category> AllcategoriesList()
        {
            var list = new List<Category>
            {
                new Category {CategoryId =1,Description="test1"},
                new Category {CategoryId =2,Description="test2"}
            };
            return list;
        }
        //public IEnumerable<Category> AllCategories()
        //{
        //    var categoriesList = new List<Category>();
        //    var categories = new Category { CategoryId =1, CategoryName="Fruit Pie",Description="All-Fruit"};
        //    categoriesList.Add(categories);
        //    return categoriesList;

        //}
    }
}
