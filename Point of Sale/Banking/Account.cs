namespace Point_of_Sale.Banking
{
    //Abstract class Account
    internal abstract class Account
    {
        protected string accountHolder { get; set; }
        public string AccountNumber { get; }
        public Account(string accountHolder, string accountNumber) //Parameterized constructor
        {
            this.accountHolder = accountHolder;
            AccountNumber = accountNumber;
        }

        public abstract void AddBalance(double amount); // Deposit Money in account using this method


        public abstract void MakePayment(double amount); // Make Payments using this method.



    }
}
