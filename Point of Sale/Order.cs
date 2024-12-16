using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_of_Sale
{
    internal class Order
    {
        // Properties
        public List<OrderLine> OrderList { get; set; }
        public static double TaxRate = 0.06;
        private double SalesTaxValue { get; set; }
        private double SubTotalValue { get; set; }
        private double Total { get; set; }

        //Constructor 
        public Order()
        {
            OrderList = new List<OrderLine>();
        }

        // Add Product to OrederList using ProductNumber
        public void AddItemToOrder(OrderLine orderLine)
        {
            OrderList.Add(orderLine);
        }

        // Calculte bill 
        public void CalculateTotal()
        {
            SubTotalValue = 0;

            foreach (OrderLine orderline in OrderList)
            {
                SubTotalValue += orderline.OrderLinePrice;
            }

            SalesTaxValue = TaxRate * SubTotalValue;

            Total = SalesTaxValue + SubTotalValue;

        }

        // Display the Order
        // Make Bill looks nicer to present
        public void DisplayBill()
        {
            Console.WriteLine("Bill:");

            foreach (OrderLine orderLine in OrderList)
            {
                Console.WriteLine($"{orderLine.Item.Name}\t" +
                    $"{orderLine.Item.Price}\t" +
                    $"{orderLine.Quantity}\t" +
                    $"{orderLine.OrderLinePrice}");
            }

            Console.WriteLine($"Subtotal Value: {SubTotalValue}");
            Console.WriteLine($"Sales Tax Value: {SalesTaxValue}");
            Console.WriteLine($"Total: {Total}");
        }
    }
}
