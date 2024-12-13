

namespace Point_of_Sale.Payment_Gateway
{
    internal static class Cash
    {
        public static double Payment(double pay) //Make Cash payment
        {
            Console.WriteLine("Amount tendered:"); // Ask for Tender
            double amount = double.Parse(Console.ReadLine());
            double change = 0.0;
            if (amount >= pay) // Is amount sufficient to cover payment?
            {
                return amount - pay; //If yes, make payment
            }
            else
            {   // Else throw an exception
                throw new InvalidDataException("Amount insufficient!");
            }
        }
    }
}
