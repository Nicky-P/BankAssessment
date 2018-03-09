namespace Bank.Interfaces
{
    public interface IWithdrawBehavior
    {
        void Withdraw(ref float currentBalance, float withdrawAmount);
    }
}
