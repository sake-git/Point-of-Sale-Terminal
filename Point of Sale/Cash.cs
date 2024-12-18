namespace Point_of_Sale
{
    internal static class Cash
    {
        public static string Payment(double pay) //Make Cash payment
        {
            Console.WriteLine("Amount tendered:"); // Ask for Tender
            double amount = double.Parse(Console.ReadLine());
            double change = 0.0;
            if (amount >= pay)
            {
                // sufficient amount to cover payment
                return $"${Math.Round((amount - pay) , 2).ToString()} returned"; //If yes, make payment
            }
            else
            {   // Decline payment
                throw new InvalidDataException("Amount insufficient!");
            }
        }
    }
}
