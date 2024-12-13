

using Point_of_Sale.Banking;

namespace Point_of_Sale.Payment_Gateway
{
    internal class Check: IPayment
    {        
        public string Payment(double pay) //Make payment using Check
        {
            // Get Account number
            Console.WriteLine("Enter Account number:"); 
            string accountNumber = Console.ReadLine();

            // Get Check number
            Console.WriteLine("Enter Check number:"); 
            string checkNumber = Console.ReadLine();

            // Get the Account details from bank
            CheckingAccount checking = (CheckingAccount)Bank.GetAccount(accountNumber); 

            if (checking != null) //Account is present
            {
                if (checking.ValidateCheck(checkNumber)) //Check is "check" is valid
                {
                    //Make Payment using check & mark it as processed
                    checking.MakePayment(pay); 
                    checking.RemoveCheck(checkNumber); 
                    return $"$ {pay} paid using Account number {string.Concat(["****", accountNumber.Substring(8)])} - {checkNumber}";
                }
                else
                {
                    // Invalid check
                    throw new InvalidDataException("Check not valid!"); 
                }
            }
            else
            {
                // Account not valid, So is check
                throw new InvalidDataException("Account number not valid!"); 
            } 
        }
    }
}
