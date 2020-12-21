using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopWeb.Web.Pages.Basket
{
    public class BasketViewModel
    {
        public int Id { get; set; }
        public List<BasketItemViewModel> Items { get; set; } = new List<BasketItemViewModel>();
        public string BuyerId { get; set; }

        public decimal Total()
        {
            return Math.Round(Items.Sum(x => x.UnitPrice * x.Quantity), 2);
        }
        public decimal Tax(decimal total)
        {
            return total * (decimal)0.06;
        }

        public decimal GrandTotal(decimal total, decimal tax)
        {
            return total + tax;
        }
    }
}
