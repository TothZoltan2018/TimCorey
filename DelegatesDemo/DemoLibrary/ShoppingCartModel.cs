using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        public delegate void MentionDiscount(decimal subTotalThisNameCanBeAnything);
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        public decimal GenerateTotal(MentionDiscount mentionDiscount)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionDiscount(subTotal);

            if (subTotal > 100)
            {
                return subTotal * 0.80M;
            }
            if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            if (subTotal > 10)
            {
                return subTotal * 0.90M;
            }
            else
            {
                return subTotal;
            }            
        }
    }
}
