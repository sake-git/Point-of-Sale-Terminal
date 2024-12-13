using Point_of_Sale.Payment_Gateway;
using System;



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
                    IPayment iPayment = null;

                    paymentMethod enumvalue;

                    Enum.TryParse(method, out enumvalue);

                    switch ((int)enumvalue)
                    {
                        case 1:
                            iPayment = new Cash();
                            break;
                        case 2:
                            iPayment = new Check();
                            break;
                        case 3:
                            iPayment = new CreditCard();
                            break;
                        default:
                            throw new InvalidDataException("Invalid Payment Method!");
                            break;
                    }
                    
                    string message = iPayment.Payment(amount);
                    isPaid = true;
                    Console.WriteLine("Payment Accepted!");
                    Console.WriteLine(message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Transaction Denied!");
                    Console.WriteLine(ex.Message);
                    isPaid = false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Transaction Denied!");
                    Console.WriteLine(ex.Message);
                    isPaid = false;
                }
                Console.WriteLine("Would you like to continue? (y/n)");               
                input = Console.ReadLine();
            }while (input.ToLower() == "y");
        }
    }
}
