using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories;
using Exame.Infra.Persistence.Repositories.Base;
using System;

namespace Exame.Infra.Persistence.Repositories
{
    public class RepositoryMovimento : RepositoryBase<Movimento, Guid>, IRepositoryMovimento
    {
        protected readonly ExameContext _context;

        public RepositoryMovimento(ExameContext context) : base(context)
        {
            _context = context;
        }
    }
}
