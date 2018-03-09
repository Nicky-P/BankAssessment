using Bank.Interfaces;

namespace Bank.Behaviors
{
    internal class WithdrawLimitBehavior : IWithdrawBehavior
    {
        private readonly float _withdrawLimit;

        public WithdrawLimitBehavior(float withdrawLimit)
        {
            _withdrawLimit = withdrawLimit;
        }

        public void Withdraw(ref float currentBalance, float withdrawAmount)
        {
            if (withdrawAmount > 0 && withdrawAmount <= _withdrawLimit && withdrawAmount <= currentBalance)
            {
                currentBalance -= withdrawAmount;
            }
        }
    }
}
