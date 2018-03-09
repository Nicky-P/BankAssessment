namespace Bank.Interfaces
{
    public interface IDepositBehavior
    {
        void Deposit(ref float currentBalance, float depositAmount);
    }
}
