using Csharp_Bootcamp_301_DataAccessLayer.Abstract;
using Csharp_Bootcamp_301_DataAccessLayer.Context;
using Csharp_Bootcamp_301_DataAccessLayer.Repositories;
using Csharp_Bootcamp_301_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Bootcamp_301_DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<object> GetProductsWithCategory()
        {
            var context = new CampContext();
            var values = context.Products.Select(s => new
            {
                ProductID = s.ProductID,
                ProductName = s.ProductName,
                ProductPrice = s.ProductPrice,
                ProductDescription = s.ProductDescription,
                ProductStock = s.ProductStock,
                CategoryName = s.Category.CategoryName
            }).ToList();

            return values.Cast<object>().ToList();
        }
    }
}
