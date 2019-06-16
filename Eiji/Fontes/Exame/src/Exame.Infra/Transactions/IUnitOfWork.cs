namespace Exame.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
