using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAnkingAppAdmin
{
    public class AccountManager
    {
        public static Account[] AdminOptions(Account[] accounts)
        {
            int userInput = -1;
            while (userInput != 0)
            {
                Console.WriteLine("0. Exit Admin" +
                "\n1. Create new Account" +
                "\n2. Display Accounts" +
                "\n3.Find Account by Id" +
                "\n4. Update an Account" +
                "\n5. Remove an Account by ID" +
                "\n6. Clear All Accounts"
                );
                userInput = int.Parse(Console.ReadLine());
                switch (userInput)

                {
                    case 0: break;
                    case 1: accounts = CreateAccount(accounts); break;
                    case 2: DisplayAllAccounts(accounts); break;
                    case 3: AccountById(accounts); break;
                    case 4: accounts = UpdateAccount(accounts); break;
                    case 5: RemoveAccount(accounts); break;
                }
            }
            return accounts;
        }
        public static Account[] CreateAccount(Account[] accounts)
        {
            Console.WriteLine("Enter a bank account Number");
            int accountId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter a bank account Aadhar Number");
            double accountAadhar = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a bank account Name");
            string accountName = (Console.ReadLine());
            Console.WriteLine("Enter a bank account Bank Name");
            string accountBank = Console.ReadLine();
            Console.WriteLine("Enter a bank account Balance");
            double accountBalance = double.Parse(Console.ReadLine());

            Account accountNew = new Account(accountId, accountAadhar, accountName, accountBank, accountBalance);
            Array.Resize(ref accounts, accounts.Length + 1);
            accounts[accounts.Length - 1] = accountNew;
            return accounts;
        }

        public static void DisplayAllAccounts(Account[] accounts)
        {
            foreach (Account account in accounts)
            {
                Program.PrintAccountDetails(account);
            }

        }

        public static void AccountById(Account[] accounts)
        {
            Console.WriteLine("Enter the account number to perform functions");
            int userAccountInput = int.Parse(Console.ReadLine());
            foreach (Account account in accounts)
            {

                if (Account.GetAccountId(account) == userAccountInput)
                {
                    Program.PrintAccountDetails(account);

                }
            }
        }

        public static Account[] UpdateAccount(Account[] accounts)
        {
            Console.WriteLine("Enter the account number to perform functions");

            Console.WriteLine(
                "1. Update Account Name" +
                "\n2. Update Account Aadhar Number" +
                "\n3. Update Bank Name" +
                "\n4. Update Bank Balance"
                );
            int userAccountInput = int.Parse(Console.ReadLine());
            foreach (Account account in accounts)
            {

                if (Account.GetAccountId(account) == userAccountInput)
                {
                    Console.WriteLine("Select the field to be updated");
                    int option = -1;
                    switch (option)
                    {
                        case 1: Console.WriteLine("Enter the New name"); account.SetAccountName(Console.ReadLine()); break;
                        case 2: Console.WriteLine("Enter the New aadhar number"); account.SetAccountAadhar(double.Parse(Console.ReadLine())); break;
                        case 3: Console.WriteLine("Enter the New bank Name"); account.SetBankName(Console.ReadLine()); break;
                        case 4: Console.WriteLine("Enter the New Bank Balance"); account.SetAccountBalance(double.Parse(Console.ReadLine())); break;
                    }
                }
            }
            return accounts;
        }
        public static void RemoveAccount(Account[] accounts)
        {
            Console.WriteLine("Enter the account number to perform functions");
            int userAccountInput = int.Parse(Console.ReadLine());
            foreach (Account account in accounts)
            {
                if (Account.GetAccountId(account) == userAccountInput)
                {
                    //accounts = RemoveAccount(accounts[0]);
                }
            }
        }
    }
}
