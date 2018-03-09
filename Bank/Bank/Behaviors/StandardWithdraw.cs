using Bank.Interfaces;

namespace Bank.Behaviors
{
    internal class StandardWithdraw : IWithdrawBehavior
    {
        public void Withdraw(ref float currentBalance, float withdrawAmount)
        {
            if (withdrawAmount > 0 && withdrawAmount < currentBalance)
            {
                currentBalance -= withdrawAmount;
            }
        }
    }
}
