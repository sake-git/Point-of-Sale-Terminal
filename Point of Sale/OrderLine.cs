using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale
{
    internal class OrderLine
    {
        public Product Item { get; set; }
        public int Quantity { get; set; }
        public double OrderLinePrice { get; set; }

        public OrderLine(Product product, int quantity)
        {
            Item = product;
            Quantity = quantity;
            OrderLinePrice = product.Price * quantity;
        }
    }
}
