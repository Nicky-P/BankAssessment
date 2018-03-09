using Bank.Behaviors;
using Bank.Interfaces;
using System;

namespace Bank.Accounts
{
    public class IndividualInvestmentAccount : BaseAccount
    {
        public IndividualInvestmentAccount(Guid ownerId) : base(ownerId)
        {
            IDepositBehavior depositBehavior = new StandardDeposit();
            IWithdrawBehavior withdrawBehavior = new WithdrawLimitBehavior(1000);
            ITransferBehavior transferBehavior = new StandardTransferBehavior();

            SetDepositBehavior(depositBehavior);
            SetWithdrawBehavior(withdrawBehavior);
            SetTransferBehavior(transferBehavior);
        }
    }
}
