using System;
using System.Collections.Generic;

namespace BAnkingAppAdmin
{
    public class Program
    {
        public static void BankingOptions(int option, Account account)
        {
            if (option == 1)
            {
                Console.WriteLine("Enter the amount to be deposited");
                double depositedAmount = double.Parse(Console.ReadLine());
                Console.WriteLine("The Current Balance after Deposite is" + Account.Deposite(account, depositedAmount));
            }
            if (option == 2)
            {
                Console.WriteLine("Enter the amount to be withdrawn");
                double withdrawnAmount = double.Parse(Console.ReadLine());
                double balanceAfterWithdrawal = Account.Withdraw(account, withdrawnAmount);
                if (balanceAfterWithdrawal == -1)
                {
                    Console.WriteLine("You have ensuffient balance to maintain Minimum Balance after this Withdrawal");
                }
                else
                {
                    Console.WriteLine("The Current Balance after Withdrawal is" + balanceAfterWithdrawal);
                }

            }
            if (option == 3)
            {
                PrintAccountDetails(account);
            }
        }
        public static void PrintAccountDetails(Account account)
        {
            int accountId;
            string accountName;
            string accountBankName;
            double accountBalance;
            double accountAadharNumber;
            Account.PrintDetailsOut(account, out accountId, out accountAadharNumber, out accountName, out accountBankName, out accountBalance);
            Console.WriteLine("The account number is: {0}", accountId);
            Console.WriteLine("The account Aadhar number is: {0}", accountAadharNumber);
            Console.WriteLine("The account name is: {0}", accountName);
            Console.WriteLine("The account Bank Name is: {0}", accountBankName);
            Console.WriteLine("The account Balance is: {0}", accountBalance);

        }
        public static void BankingOptionsSelection(Account account)
        {
            int userInput = 1;
            while (userInput != 0)
            {
                Console.WriteLine("Enter the Option Number to select an option");
                Console.WriteLine("1. Deposite");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Check details");
                Console.WriteLine("0. Exit");
                userInput = int.Parse(Console.ReadLine());
                if (userInput == 0)
                {
                    break;
                    
                }
                BankingOptions(userInput, account);
            }
            
        }
        public static void HighestBalance(Account[] accounts)
        {
            double highestBalance = 0;
            Account accountHighest = null;
            foreach (Account account in accounts)
            {
                if (Account.Balance(account) > highestBalance)
                {
                    highestBalance = Account.Balance(account);
                    accountHighest = account;
                }
            }
            PrintAccountDetails(accountHighest);

        }
        
        public static Account[] BeginBanking(Account[] accounts) 
        {
            Console.WriteLine("Enter the account number to perform functions");
            int userAccountInput = int.Parse(Console.ReadLine());
            while(userAccountInput != -1)
            {
                if (userAccountInput == 0)
                {
                    accounts = AccountManager.AdminOptions(accounts);
                    return accounts;
                }
                else
                {
                    foreach (Account account in accounts)
                    {
                        if (Account.GetAccountId(account) == userAccountInput)
                        {
                            BankingOptionsSelection(account);
                        }
                    }
                    return accounts;
                }
            }
            
            return accounts;
        }
        static void Main(string[] args)
        {
            //List<Account> account = new List<Account>();
            Account[] accounts = { new Account(1,123456789009, "Pratik", "SBI", 2000),
                                  new Account(2, 908765432112,"Ravi", "HDFC",600),
                                  new Account(3, 234567890123,"Suresh", "ICICI", 400000),
                                  new Account(4, 345678901234,"Tarun", "UBI",600)};
            
            
          
            accounts = SerialDeserial.DesrializeData();
            Console.WriteLine("The Highest Account Balance is of");
            HighestBalance(accounts);
            Account[] accountsUpdated = BeginBanking(accounts);
            SerialDeserial.SerializeData(accountsUpdated);
        }
    }
}

