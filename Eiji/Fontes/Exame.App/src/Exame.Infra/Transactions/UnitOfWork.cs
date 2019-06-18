using Exame.Infra.Persistence;

namespace Exame.Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExameContext _context;

        public UnitOfWork(ExameContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
