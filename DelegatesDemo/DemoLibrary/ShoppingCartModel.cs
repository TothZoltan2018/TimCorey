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
        
        public decimal GenerateTotal(MentionDiscount mentionDiscount,
            Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionDiscount(subTotal);

            return calculateDiscountedTotal(Items, subTotal);
        }
    }
}
