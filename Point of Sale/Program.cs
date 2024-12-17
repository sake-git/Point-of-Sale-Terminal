using Point_of_Sale.Banking;
using Point_of_Sale.ErrorLogging;

namespace Point_of_Sale
{
    public enum paymentMethod
    {
        Cash=1,
        Check,
        Credit
    }
    internal class Program
    {        
        static void Main(string[] args)
        {
            
            bool isPaid = false;
            string input;
            //FileOperations.ReadProductsFromFile("Product.txt");
            do
            {
                try
                {
                    Console.WriteLine("Enter Amount");
                    double amount = double.Parse(Console.ReadLine());
                   
                    Console.WriteLine("How would you like to pay today?");
                    foreach(string name in Enum.GetNames(typeof(paymentMethod)))
                    {
                        Console.WriteLine($"{(int)Enum.Parse(typeof(paymentMethod),name)}. {name}");
                    }
                   // Console.WriteLine("\n1. Cash \n2. Check \n3. Credit Card");
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
    }
}
