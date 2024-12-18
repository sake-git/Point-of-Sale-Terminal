using Point_of_Sale.Banking;
using Point_of_Sale.ErrorLogging;

namespace Point_of_Sale
{
    public enum paymentMethod
    {
<<<<<<< HEAD
        Cash=1,
=======
        Cash = 1,
>>>>>>> 171c15114862875d1958709e932ae4a2e336e51b
        Check,
        Credit
    }
    internal class Program
<<<<<<< HEAD
    {        
        static void Main(string[] args)
        {
            
            bool isPaid = false;
            string input;
=======
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
                    if (productIndex >= Product.Products.Count)
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
>>>>>>> 171c15114862875d1958709e932ae4a2e336e51b
            //FileOperations.ReadProductsFromFile("Product.txt");
            do
            {
                try
                {
<<<<<<< HEAD
                    Console.WriteLine("Enter Amount");
                    double amount = double.Parse(Console.ReadLine());
                   
                    Console.WriteLine("How would you like to pay today?");
                    foreach(string name in Enum.GetNames(typeof(paymentMethod)))
                    {
                        Console.WriteLine($"{(int)Enum.Parse(typeof(paymentMethod),name)}. {name}");
                    }
                   // Console.WriteLine("\n1. Cash \n2. Check \n3. Credit Card");
                    string method = Console.ReadLine(); 
=======
                    Console.WriteLine("\nHow would you like to pay today?");
                    foreach (string name in Enum.GetNames(typeof(paymentMethod)))
                    {
                        Console.WriteLine($"{(int)Enum.Parse(typeof(paymentMethod), name)}. {name}");
                    }
                    Console.WriteLine("**************************************************");
                    string method = Console.ReadLine();
>>>>>>> 171c15114862875d1958709e932ae4a2e336e51b
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
<<<<<<< HEAD
                            message = Bank.PaymentGateway(amount,(int) enumvalue);
                            break;
                        
                        default:
                            throw new InvalidDataException("Invalid Payment Method!");
                            break;
                    }
                    
                    isPaid = true;
                    Console.WriteLine("Payment Accepted!");
                    Console.WriteLine(message);
                }                
                catch(Exception ex)
                {
                    Console.WriteLine("Transaction Declined!");
                    Logger.LogError(ex);
                    isPaid = false;
                }
                Console.WriteLine("Would you like to continue? (y/n)");               
                input = Console.ReadLine();
            }while (input.ToLower() == "y");

            //FileOperations.SaveProductsToFile("Product.txt"); 
        }
=======
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





>>>>>>> 171c15114862875d1958709e932ae4a2e336e51b
    }
}
