using Bank.Interfaces;
using System;
using System.Linq;

namespace Bank.Behaviors
{
    internal class StandardTransferBehavior : ITransferBehavior
    {
        public void Transfer(ref float transferAccountCurrentBalance, float transferAmount, int receiverAccountId)
        {
            if (transferAccountCurrentBalance <= 0 || transferAccountCurrentBalance < transferAmount)
            {
                return;
            }

            BaseAccount recieverAccount;

            try
            {
                recieverAccount = Bank.Accounts.First(x => x.AccountNumber == receiverAccountId);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (recieverAccount != null)
            {
                transferAccountCurrentBalance -= transferAmount;
                recieverAccount.PerformDeposit(transferAmount);
            }
        }
    }
}
