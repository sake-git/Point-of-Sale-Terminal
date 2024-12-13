﻿namespace Point_of_Sale.Banking
{
    internal class CheckingAccount : Account //Checking Account, derived from Account base class
    {
        public string RoutingNumber { get; }
        public double Balance { get; set; }

        List<string> checks = new List<string>(); // List to track check numbers
        public CheckingAccount(string accountHolder, string accountNumber, string routingNumber, double balance) :
            base(accountHolder, accountNumber)
        {
            RoutingNumber = routingNumber;
            Balance = balance;
            AddCheck(["111111", "222222", "333333", "444444", "555555"]);
        }

        //Function to add check when new checks are issue for the account
        public void AddCheck(string[] checkArray) 
        {
            foreach (string check in checkArray)
            {
                checks.Add(check);
            }
        }

        //Function to remove check when it's processed
        public void RemoveCheck(string check)
        {
            checks.Remove(check);
        }


        //Validate the check number 
        public bool ValidateCheck(string checkNumber)
        {
            string check = checks.Find(x => x == checkNumber);
            if (check != null)
            {
                return true;
            }
            return false;
        }

        //Add Balance to the Account
        public override void AddBalance(double amount)
        {
            if (amount > 0)
            {
                //Valid amount add it to credit 
                Balance += amount;
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
            if (Balance >= amount)
            {    
                //Sufficient balance available, Make payment
                Balance -= amount; 
            }
            else
            {   
                //Insufficient balance throw an exception
                throw new InvalidDataException("Insufficient Balance!");
            }
        }
    }
}
