namespace Point_of_Sale.Banking
{
    internal class CreditAccount : Account    //Credit Account, derived from Account base class
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
        public bool ValidateCard(string cardNum, string cvv, DateOnly expiryDate)
        {

            if (CardNumber == cardNum && this.cvv == cvv ||
                this.expiryDate == expiryDate || this.expiryDate >= new DateOnly())
            {
                return true;
            }
            return false;
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

        //Make Payment from the account
        public override void MakePayment(double amount)
        {
            if (CreditLimit >= amount)
            {
                //Sufficient balance available, Make payment
                CreditLimit -= amount; 
            }
            else
            {  
                //Insufficient balance throw an exception
                throw new InvalidDataException("Insufficient Balance!");
            }
        }
    }
}
