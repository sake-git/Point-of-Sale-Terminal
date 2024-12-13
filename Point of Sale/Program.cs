using Point_of_Sale.Payment_Gateway;



namespace Point_of_Sale
{
    public enum paymentMethod
    {
        cash,
        check,
        credit
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
                    Console.WriteLine("\n1. Cash \n2. Check \n3. Credit Card");
                    int method = int.Parse(Console.ReadLine());
                    IPayment iPayment = null;

                    switch (method)
                    {
                        case 1:
                            double change = Cash.Payment(amount);
                            Console.WriteLine($"Here is you change: {change}");
                            isPaid = true;
                            break;
                        case 2:
                            iPayment = new Check();
                            iPayment.Payment(amount);                            
                            isPaid = true;
                            break;
                        case 3:
                            iPayment = new CreditCard();
                            iPayment.Payment(amount);
                            isPaid = true;
                            break;
                        default:
                            throw new InvalidDataException("Invalid Payment Method!");
                            break;
                    }

                    Console.WriteLine("Payment Accepted!");
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
