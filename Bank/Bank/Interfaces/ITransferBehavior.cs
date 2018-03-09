namespace Bank.Interfaces
{
    public interface ITransferBehavior
    {
        void Transfer(ref float transferAccountCurrentBalance, float transferAmount, int receiverAccountId);
    }
}
