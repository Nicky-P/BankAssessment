using Bank.Interfaces;

namespace Bank.Behaviors
{
    internal class StandardDeposit : IDepositBehavior
    {
        public void Deposit(ref float currentBalance, float depositAmount)
        {
            if (depositAmount >= 0)
            {
                currentBalance += depositAmount;
            }

        }
    }
}
