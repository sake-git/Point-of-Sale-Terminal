

namespace Point_of_Sale.Payment_Gateway
{
    internal class Cash: IPayment
    {
        public string Payment(double pay) //Make Cash payment
        {
            Console.WriteLine("Amount tendered:"); // Ask for Tender
            double amount = double.Parse(Console.ReadLine());
            double change = 0.0;
            if (amount >= pay) 
            {
                // sufficient amount to cover payment
                return $"${(amount - pay).ToString()} returned"; //If yes, make payment
            }
            else
            {   // Decline payment
                throw new InvalidDataException("Amount insufficient!");
            }
        }
    }
}
