namespace Point_of_Sale.Banking
{
    internal class CreditAccount : Account   //Credit Account, derived from Account base class
    {
        public string CardNumber { get; private set; }
        public double CreditLimit { get; private set; }
        string cvv;
        DateOnly expiryDate;

        public CreditAccount(string accountHolder, string accountNumber, string cardNum, double creditLimit, string cvv, DateOnly expiryDate) :
            base(accountHolder, accountNumber)
        {
            CardNumber = cardNum;
            this.cvv = cvv;
            this.expiryDate = expiryDate;
            CreditLimit = creditLimit;
        }

        //Validate Card details
        public override bool ValidateAccount()
        {
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
            catch (Exception ex)
            {
                //Invalid date
                throw new InvalidDataException("Invalid Date Format");
            }

            if (this.cvv == cvv || this.expiryDate == expiryDate || this.expiryDate >= new DateOnly())
            {
                return true;
            }
            return false;
        }


        //Make Payment from the account
        public override string MakePayment(double amount)
        {
            if (CreditLimit >= amount)
            {
                //Sufficient balance available, Make payment
                CreditLimit -= amount;
                return $"$ {amount} paid with Credit card {string.Concat(["****", CardNumber.Substring(12)])}";
            }
            else
            {
                //Insufficient balance throw an exception
                throw new InvalidDataException("Insufficient Balance!");
            }
        }


        //Function to Pay to Credit Account-- essentially adding balance
        public override void AddBalance(double amount)
        {
            if (amount > 0) 
            {
                //Valid amount add it to credit 
                CreditLimit += amount;
            }
            else
            {   
                //Throw exception if negative amount is paid
                throw new InvalidDataException("Can't Add negative balance");
            }
        }       
    }
}
