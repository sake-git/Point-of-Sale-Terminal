
using Point_of_Sale.Banking;

namespace Point_of_Sale.Payment_Gateway
{
    internal class CreditCard: IPayment
    {
        public string Payment(double pay) //Make payment using Credit Card
        {
            // Get credit card number
            Console.WriteLine("Enter Credit Card number:"); 
            string cardNumber = Console.ReadLine();

            // Get CVV number
            Console.WriteLine("Enter CVV number:");   
            string cvv = Console.ReadLine();

            // Get expiration date from user. In case any exception during parsing of date throw invalid date exception
            DateOnly expirationDate;
            Console.WriteLine("Enter the expiration date in MM/YYYY format"); 
            try 
            {
                // Parse it
                string[] date = Console.ReadLine().Split('/');                 
                expirationDate = new DateOnly(int.Parse(date[1]), int.Parse(date[0]), 01); 
            }
            catch(Exception ex)
            {
                //Invalid date
                throw new InvalidDataException("Invalid Date Format");
            }

            // Get the Account details from bank
            CreditAccount card = (CreditAccount)Bank.GetAccount(cardNumber); 

            if (card != null) //Account is present
            {
                if(card.ValidateCard(cardNumber, cvv, expirationDate)) // Card details are valid
                {
                    // Make payment
                    card.MakePayment(pay); 
                    return $"$ {pay} paid using Credit card {string.Concat(["****", cardNumber.Substring(12)])}";
                }
                else
                {
                    // Card details are invalid
                    throw new InvalidDataException("Credit Card not valid!"); 
                }
            }
            else
            { 
                // Account is invalid, so is Card
                throw new InvalidDataException("Credit Card not valid!"); 
            }            
        }
    }
}
