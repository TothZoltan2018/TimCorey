using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public DateTime BestBefore { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}
 