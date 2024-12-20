﻿using Point_of_Sale.Banking;
using Point_of_Sale.ErrorLogging;

namespace Point_of_Sale
{
    public enum paymentMethod
    {
        Cash = 1,
        Check,
        Credit
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tWelcome to Mom and Pop's grocery store");
            
            Order order = new Order();
            Console.WriteLine();
            
            do
            {
                //FileOperations.SaveProductsToFile("Product.txt");
                if (Product.Products.Count == 0)
                {
                    FileOperations.ReadProductsFromFile("Product.txt");
                }
                Console.WriteLine("***************************************************************");
                Console.WriteLine("\t\tHere is a list of all our products:");
                Console.WriteLine("***************************************************************");
                Product.DisplayAllProducts();
                Console.WriteLine("***************************************************************");


                int productIndex = 0;
                bool isValid = false;
                do
                {
                    productIndex = GetNumber("Please choose the desired product");
                    if (productIndex > Product.Products.Count)
                    {
                        Console.WriteLine("Invalid product index!");
                        Logger.LogError("Invalid product index!");
                    }
                    else
                    {
                        isValid = true;
                    }
                } while (!isValid);


                Product product = Product.GetProduct(productIndex - 1);

                int quantity = GetNumber("Please enter desired quatity");

                OrderLine orderLineObject = new OrderLine(product, quantity);
                order.AddItemToOrder(orderLineObject);

                Console.WriteLine("Would you like to purchase more items?(y/n)");

            } while (Console.ReadLine().ToLower() == "y");

            order.CalculateTotal();

            order.DisplayBill();

            double amount = order.Total;
            Console.WriteLine($"Total amount due: {amount:c}");

            bool isPaid = false;
            string input = "";
            //FileOperations.ReadProductsFromFile("Product.txt");
            do
            {
                try
                {
                    Console.WriteLine("\nHow would you like to pay today?");
                    foreach (string name in Enum.GetNames(typeof(paymentMethod)))
                    {
                        Console.WriteLine($"{(int)Enum.Parse(typeof(paymentMethod), name)}. {name}");
                    }
                    Console.WriteLine("**************************************************");
                    string method = Console.ReadLine();
                    paymentMethod enumvalue;
                    Enum.TryParse(method, out enumvalue);

                    string message = "";

                    switch ((int)enumvalue)
                    {
                        case 1:
                            message = Cash.Payment(amount);
                            break;
                        case 2:
                        case 3:
                            message = Bank.PaymentGateway(amount, (int)enumvalue);
                            break;

                        default:
                            throw new InvalidDataException("Invalid Payment Method!");
                    }

                    isPaid = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Payment Accepted!");
                    Console.WriteLine(message);
                    Console.ForegroundColor= ConsoleColor.Gray;
                    input = "";
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Transaction Declined!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Logger.LogError(ex);
                    isPaid = false;
                    Console.WriteLine("\nWould you like to choose another payment method?(y/n)");
                    input = Console.ReadLine();
                }
                
            } while (input.ToLower() == "y");

            //FileOperations.SaveProductsToFile("Product.txt"); 
        }

        public static int GetNumber(string message)
        {
            bool isValid = false;
            int number = 0;
            do
            {
                Console.WriteLine(message);
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    if (number > 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Number!");
                        Logger.LogError("Invalid Number!");
                    }

                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid number. Try again");
                    Logger.LogError(ex);
                }
            } while (!isValid);

            return number;
        }





    }
}
