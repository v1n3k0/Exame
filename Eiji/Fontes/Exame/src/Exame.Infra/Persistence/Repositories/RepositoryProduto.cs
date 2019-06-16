using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories;
using Exame.Infra.Persistence.Repositories.Base;
using System;

namespace Exame.Infra.Persistence.Repositories
{
    public class RepositoryProduto : RepositoryBase<Produto, Guid>, IRepositoryProduto
    {
        protected readonly ExameContext _context;

        public RepositoryProduto(ExameContext context) : base(context)
        {
            _context = context;
        }
    }
}
