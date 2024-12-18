using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Bootcamp_301_EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductStock {  get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
