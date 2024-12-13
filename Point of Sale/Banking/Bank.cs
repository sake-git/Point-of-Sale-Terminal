namespace Point_of_Sale.Banking
{
    internal class Bank
    {
        //List of Bank accounts
        public static List<Account> accounts = new List<Account>()
        {
            new CreditAccount("Jane Doe","00001","001122334455",500,"123",new DateOnly(2025,06,01)),
            new CreditAccount("John Doe","00002","112233445566",5,"234",new DateOnly(2024,06,01)),
            new CreditAccount("Janet Doe","00003","223344556677",100,"345",new DateOnly(2025,03,01)),
            new CheckingAccount("Jeremy Doe","00004","123456",300),
            new CheckingAccount("Jelena Doe","00005","123456",250)
        };

        //Get the request Account. 
        public static Account GetAccount(string number)
        {
            return accounts.Where(x =>
            {
                if (x is CreditAccount) //If Object is Credit Account, match with Credit card number
                {
                    CreditAccount card = (CreditAccount)x;
                    if (card.CardNumber == number)
                    {
                        return true;
                    }
                }
                else // If Object is Checking Account, match with Account number
                {
                    CheckingAccount checking = (CheckingAccount)x; 
                    if (checking.AccountNumber == number)
                    {
                        return true;
                    }
                }
                return false;
            }).First();// Credit card numbers & account numbers are unique. If user finds an account, stop the search.
        }
    }
}
