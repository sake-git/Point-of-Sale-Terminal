using System.ComponentModel.Design;

namespace Point_of_Sale.Banking
{
    internal class Bank
    {
        //List of Bank accounts
        public static List<Account> accounts = new List<Account>()
        {
            new CreditAccount("Jane Doe","000010000101","0000100001000011",500,"123",new DateOnly(2025,06,01)),
            new CreditAccount("John Doe","000010000102","0000100001000012",5,"123",new DateOnly(2024,06,01)),
            new CreditAccount("Janet Doe","000010000103","0000100000100013",100,"123",new DateOnly(2025,03,01)),
            new CheckingAccount("Jeremy Doe","000010000104","123456789",300),
            new CheckingAccount("Jelena Doe","000010000105","123456789",250)
        };

        //Get the request Account. 
        public static Account GetAccount(string number)
        {
            var accountList = accounts.Where(x =>
            {
                if (x is CreditAccount)
                {
                    //Object is Credit Account, match with Credit card number
                    CreditAccount card = (CreditAccount)x;
                    if (card.CardNumber == number)
                    {
                        return true;
                    }
                }
                else
                {
                    // Object is Checking Account, match with Account number
                    CheckingAccount checking = (CheckingAccount)x;
                    if (checking.AccountNumber == number)
                    {
                        return true;
                    }
                }
                return false;
            });

            if (accountList.Count() == 0) 
            {
                throw new Exception("Invalid account");
            }
            
            Account account = accountList.First();


            if (account.ValidateAccount())
            {
                return account;
            }
            else
            {
                throw new Exception("Invalid Details");
            }              
           
        }


        public static string PaymentGateway(double amount, int method ) //Make payment using Credit Card
        {
            Account account = null;
            string accountId = null;
            
            if (method == 2)
            {
                // Get Account number
                Console.WriteLine("Enter Account number:");
                accountId = Console.ReadLine();
            }
            else if(method == 3) 
            {
                // Get credit card number
                Console.WriteLine("Enter Credit Card number:");
                accountId = Console.ReadLine();
            }
            else
            {
                throw new InvalidDataException("Invalid Payment Method");
            }

            // Get the Account details from bank
            account = GetAccount(accountId);
            return account.MakePayment(amount);


           /* if (account != null) //Account is present
            {
                // Make payment
                           
                
            }
            else
            {
                // Account is invalid
                throw new InvalidDataException("Account not valid!");
            }*/
        }        
    }
}
