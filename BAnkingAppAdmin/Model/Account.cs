using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAnkingAppAdmin
{
    public class Account
    {

        public int _accountId;
        public double _accountAadharnumber;
        public string _accountName;
        public string _accountBankName;
        public double _accountBalance;
        public const int MIN_BALANCE = 500;

        public Account() { }
        public static int GetAccountId(Account account)
        {
            return account._accountId;
        }
        public  void SetAccountAadhar(double aadharNumber)
        {
            this._accountAadharnumber = aadharNumber;
        }
        public void SetAccountName(string name)
        {
            this._accountName = name;
        }
        public void SetBankName(string bankName)
        {
            this._accountBankName=bankName;
        }
        public void SetAccountBalance(double balance)
        {
            this._accountBalance = balance;
        }

        public Account(int accountId, string accountName, string accountBankName, double accountBalance)
        {
            _accountId = accountId;
            _accountName = accountName;
            _accountBalance = accountBalance;
            _accountBankName = accountBankName;
        }
        public Account(int accountId, string accountName, string accountBankName) : this(accountId, accountName, accountBankName, MIN_BALANCE)
        {
        }
        public Account(int accountId, double accountAadharNumber, string accountName, string accountBankName) : this(accountId, accountName, accountBankName)
        {
            _accountAadharnumber = accountAadharNumber;
        }
        public Account(int accountId, double accountAadharNumber, string accountName, string accountBankName, double accountBalance) : this(accountId, accountName, accountBankName, accountBalance)
        {
            _accountAadharnumber = accountAadharNumber;
        }

        public static void PrintDetailsOut(Account account, out int accountId, out double accountAadharNumber, out string accountName, out string accountBankName, out double accountBalance)
        {
            accountId = account._accountId;
            accountAadharNumber = account._accountAadharnumber;
            accountName = account._accountName;
            accountBankName = account._accountBankName;
            accountBalance = account._accountBalance;
        }
        public static double Withdraw(Account account, double withdrawnAmount)
        {
            if ((account._accountBalance - withdrawnAmount) < MIN_BALANCE)
            {
                return -1;
            }
            account._accountBalance = account._accountBalance - withdrawnAmount;
            return account._accountBalance;

        }
        public static double Deposite(Account account, double depositedAmount)
        {

            account._accountBalance += depositedAmount;
            return account._accountBalance;

        }

        public static double Balance(Account account)
        {
            return account._accountBalance;
        }
    }
}
