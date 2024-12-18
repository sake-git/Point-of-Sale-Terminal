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
        public double SalesTaxValue { get; set; }
        public double SubTotalValue { get; set; }
        public double Total { get; set; }

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

            SalesTaxValue = Math.Round(TaxRate * SubTotalValue , 2);

            Total = SalesTaxValue + SubTotalValue;

        }

        // Display the Order
        // Make Bill looks nicer to present
        public void DisplayBill()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\n**************************************************");
            Console.WriteLine("\t\t\tBill");
            Console.WriteLine("**************************************************");
            Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}" , "Item", "Unit Price" , "Quatity" , "SubTotal");
            foreach (OrderLine orderLine in OrderList)
            {

                Console.WriteLine("{0,-15} {1,-15} {2,-10} {3,-10}",$"{orderLine.Item.Name}", $"{orderLine.Item.Price:c}", $"{orderLine.Quantity}" , $"{orderLine.OrderLinePrice:c}");
            }
            Console.WriteLine("**************************************************");
            Console.WriteLine($"Subtotal Value: {SubTotalValue:C}");
            Console.WriteLine($"Sales Tax Value: {SalesTaxValue:C}");
            Console.WriteLine($"Total: {Total:C}");
            Console.WriteLine("**************************************************\n");

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
