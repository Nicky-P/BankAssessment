using Bank.Interfaces;
using System;

namespace Bank
{
    public abstract class BaseAccount
    {
        private IDepositBehavior _depositBehavior;
        private IWithdrawBehavior _withdrawBehavior;
        private ITransferBehavior _transferBehavior;

        public int AccountNumber { get; } = Bank.GetAvailableAccountNumber();
        public float CurrentBalance => _balance;
        private float _balance;
        public readonly Guid OwnerId;

        public BaseAccount(Guid ownerId)
        {
            OwnerId = ownerId;
        }

        #region SetBehaviors

        protected void SetDepositBehavior(IDepositBehavior depositBehavior)
        {
            _depositBehavior = depositBehavior;
        }

        protected void SetWithdrawBehavior(IWithdrawBehavior withdrawBehavior)
        {
            _withdrawBehavior = withdrawBehavior;
        }

        protected void SetTransferBehavior(ITransferBehavior transferBehavior)
        {
            _transferBehavior = transferBehavior;
        }

        #endregion

        #region PerformActions

        public void PerformDeposit(float depositAmount)
        {
            _depositBehavior.Deposit(ref _balance, depositAmount);
        }

        public void PerformWithdraw(float withdrawAmount)
        {
            _withdrawBehavior.Withdraw(ref _balance, withdrawAmount);
        }

        public void PerformTransfer(float transferAmount, int receiverAccountId)
        {
            _transferBehavior.Transfer(ref _balance, transferAmount, receiverAccountId);
        }

        #endregion

    }
}
