using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        public decimal GenerateTotal()
        {
            throw new NotImplementedException();
        }
    }
}
