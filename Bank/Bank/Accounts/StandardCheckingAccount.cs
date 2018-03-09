using Bank.Behaviors;
using Bank.Interfaces;
using System;

namespace Bank.Accounts
{
    public class StandardCheckingAccount : BaseAccount
    {
        public StandardCheckingAccount(Guid ownerId) : base(ownerId)
        {
            IDepositBehavior depositBehavior = new StandardDeposit();
            IWithdrawBehavior withdrawBehavior = new StandardWithdraw();
            ITransferBehavior transferBehavior = new StandardTransferBehavior();

            SetDepositBehavior(depositBehavior);
            SetWithdrawBehavior(withdrawBehavior);
            SetTransferBehavior(transferBehavior);
        }
    }
}
