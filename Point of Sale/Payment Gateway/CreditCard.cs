
using Point_of_Sale.Banking;

namespace Point_of_Sale.Payment_Gateway
{
    internal class CreditCard: IPayment
    {
        public void Payment(double pay) //Make payment using Credit Card
        {
            Console.WriteLine("Enter Credit Card number:"); // Get credit card number
            string cardNumber = Console.ReadLine();
             
            Console.WriteLine("Enter CVV number:");   // Get CVV number
            string cvv = Console.ReadLine();

            Console.WriteLine("Enter the expiration date in MM/YYYY format"); // Get expiration date
            string[] date = Console.ReadLine().Split('/'); // Parse it
            DateOnly expirationDate = new DateOnly(int.Parse(date[1]), int.Parse(date[0]), 01); // Create Date only object

            CreditAccount card = (CreditAccount)Bank.GetAccount(cardNumber); // Get the Account details from bank

            if (card != null) //Account is present
            {
                if(card.ValidateCard(cardNumber, cvv, expirationDate)) // Card details are valid
                {
                    card.MakePayment(pay); // Make payment
                }
                else
                {
                    throw new InvalidDataException("Credit Card not valid!"); // Card details are invalid
                }
            }
            else
            { 
                throw new InvalidDataException("Credit Card not valid!"); // Account is invalid, so is Card
            }            
        }
    }
}
