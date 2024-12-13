

using Point_of_Sale.Banking;

namespace Point_of_Sale.Payment_Gateway
{
    internal class Check: IPayment
    {        
        public void Payment(double pay) //Make payment using Check
        {
            Console.WriteLine("Enter Account number:"); // Get Account number
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter Check number:"); // Get Check number
            string checkNumber = Console.ReadLine();
            
            CheckingAccount checking = (CheckingAccount)Bank.GetAccount(accountNumber); // Get the Account details from bank

            if (checking != null) //Account is present
            {
                if (checking.ValidateCheck(checkNumber)) //Check is "check" is valid
                {
                    checking.MakePayment(pay); //Make Payment using check
                    checking.RemoveCheck(checkNumber); // Mark it as procssed
                }
                else
                {
                    throw new InvalidDataException("Check not valid!"); // Invalid check
                }
            }
            else
            {
                throw new InvalidDataException("Check not valid!"); // Account not valid, So is check
            } 
        }
    }
}
