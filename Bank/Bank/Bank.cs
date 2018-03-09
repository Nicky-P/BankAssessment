using Bank.Accounts;
using System;
using System.Collections.Generic;

namespace Bank
{
    public static class Bank
    {
        public const string Name = "Generic Bank Name";
        public static List<BaseAccount> Accounts = new List<BaseAccount>();

        public static int GetAvailableAccountNumber()
        {
            {
                _accountNumber++;
                return _accountNumber;
            }
        }
        private static int _accountNumber; // using incrementing int for simplicity

        public static BaseAccount CreateAccount(string accountType, Guid accountId)
        {
            if (accountId == Guid.Empty)
            {
                return null;
            }

            var account = AccountFactory(accountType, accountId);

            if (account != null)
            {
                Accounts.Add(account);
            }

            return account;
        }

        private static BaseAccount AccountFactory(string accountType, Guid accountId)
        {
            if (string.IsNullOrWhiteSpace(accountType))
            {
                return null;
            }

            switch (accountType)
            {
                case "StandardCheckingAccount":
                    return new StandardCheckingAccount(accountId);
                case "CorporateInvestmentAccount":
                    return new CorporateInvestmentAccount(accountId);
                case "IndividualInvestmentAccount":
                    return new IndividualInvestmentAccount(accountId);
                default: return null;
            }
        }
    }
}
