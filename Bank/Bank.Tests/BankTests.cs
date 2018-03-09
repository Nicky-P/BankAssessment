using NUnit.Framework;
using System;
using Assert = NUnit.Framework.Assert;

namespace Bank.Tests
{
    [TestFixture]
    public class BankTests
    {
        [Test]
        public void bankName_Exists_isNotNull()
        {
            Assert.IsNotNull(Bank.Name);
        }

        [TestCase("StandardCheckingAccount")]
        [TestCase("CorporateInvestmentAccount")]
        [TestCase("IndividualInvestmentAccount")]
        public void allAccountType_Creation_IsSuccessful(string accountType)
        {
            BaseAccount baseAccount = Bank.CreateAccount(accountType, Guid.NewGuid());

            Assert.IsNotNull(baseAccount);
        }

        [TestCase("StandardCheckingAccount")]
        [TestCase("CorporateInvestmentAccount")]
        [TestCase("IndividualInvestmentAccount")]
        public void allAccountTypes_RequireOwnerId_OrReturnsNull(string accountType)
        {
            BaseAccount baseAccount = Bank.CreateAccount(accountType, Guid.Empty);
            Assert.IsNull(baseAccount);

            baseAccount = Bank.CreateAccount(accountType, Guid.NewGuid());
            bool isOwnerIdEmpty = baseAccount.OwnerId == Guid.Empty;

            Assert.IsFalse(isOwnerIdEmpty);
            Assert.IsNotNull(baseAccount);
        }

        [Test]
        public void bankListOfAccounts_Manipulation_IsSuccessful()
        {
            Bank.CreateAccount("StandardCheckingAccount", Guid.NewGuid());
            Bank.CreateAccount("CorporateInvestmentAccount", Guid.NewGuid());
            Bank.CreateAccount("IndividualInvestmentAccount", Guid.NewGuid());

            Assert.IsNotEmpty(Bank.Accounts);
        }

        [TestCase("StandardCheckingAccount")]
        [TestCase("CorporateInvestmentAccount")]
        [TestCase("IndividualInvestmentAccount")]
        public void allAccountType_Deposits_UpdateBalance(string accountType)
        {
            BaseAccount baseAccount = Bank.CreateAccount(accountType, Guid.NewGuid());

            Assert.AreEqual(0f, baseAccount.CurrentBalance);

            baseAccount.PerformDeposit(-50f);
            Assert.AreEqual(0f, baseAccount.CurrentBalance);

            baseAccount.PerformDeposit(50f);
            Assert.AreEqual(50f, baseAccount.CurrentBalance);
        }

        [TestCase("StandardCheckingAccount")]
        [TestCase("CorporateInvestmentAccount")]
        [TestCase("IndividualInvestmentAccount")]
        public void allAccountType_Withdraws_UpdateBalance(string accountType)
        {
            BaseAccount baseAccount = Bank.CreateAccount(accountType, Guid.NewGuid());

            baseAccount.PerformDeposit(50f);
            Assert.AreEqual(50f, baseAccount.CurrentBalance);

            baseAccount.PerformWithdraw(-25f);
            Assert.AreEqual(50f, baseAccount.CurrentBalance);

            baseAccount.PerformWithdraw(51f);
            Assert.AreEqual(50f, baseAccount.CurrentBalance);

            baseAccount.PerformWithdraw(25f);
            Assert.AreEqual(25f, baseAccount.CurrentBalance);
        }

        [Test]
        public void individualInvestmentAccount_WithdrawOverOneThousand_fails()
        {
            BaseAccount baseAccount = Bank.CreateAccount("IndividualInvestmentAccount", Guid.NewGuid());

            baseAccount.PerformDeposit(5000f);
            Assert.AreEqual(5000f, baseAccount.CurrentBalance);

            baseAccount.PerformWithdraw(2000);
            Assert.AreEqual(5000f, baseAccount.CurrentBalance);
        }

        [Test]
        public void baseAccountType_TransferToSameAccountType_UpdatesBalances()
        {
            BaseAccount standardCheckingAccount = Bank.CreateAccount("StandardCheckingAccount", Guid.NewGuid());
            BaseAccount corporateInvestmentAccount = Bank.CreateAccount("CorporateInvestmentAccount", Guid.NewGuid());

            Assert.AreEqual(0f, standardCheckingAccount.CurrentBalance);
            Assert.AreEqual(0f, corporateInvestmentAccount.CurrentBalance);
            standardCheckingAccount.PerformTransfer(500f, corporateInvestmentAccount.AccountNumber);
            Assert.AreEqual(0f, standardCheckingAccount.CurrentBalance);
            Assert.AreEqual(0f, corporateInvestmentAccount.CurrentBalance);

            standardCheckingAccount.PerformDeposit(5000f);
            Assert.AreEqual(5000f, standardCheckingAccount.CurrentBalance);
            Assert.AreEqual(0f, corporateInvestmentAccount.CurrentBalance);

            standardCheckingAccount.PerformTransfer(500f, 99999999);
            Assert.AreEqual(5000f, standardCheckingAccount.CurrentBalance);
            Assert.AreEqual(0f, corporateInvestmentAccount.CurrentBalance);

            standardCheckingAccount.PerformTransfer(500f, corporateInvestmentAccount.AccountNumber);
            Assert.AreEqual(4500f, standardCheckingAccount.CurrentBalance);
            Assert.AreEqual(500f, corporateInvestmentAccount.CurrentBalance);
        }

    }
}
