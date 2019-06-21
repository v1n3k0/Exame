using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories;
using Exame.Infra.Persistence.Repositories.Base;
using System;

namespace Exame.Infra.Persistence.Repositories
{
    public class RepositoryCosif : RepositoryBase<Cosif, Guid>, IRepositoryCosif
    {
        protected readonly ExameContext _context;

        public RepositoryCosif(ExameContext context) : base(context)
        {
            _context = context;
        }

        public Cosif ObterPorId(Guid codigoCosif, Guid codigoProduto)
        {
            return _context.Set<Cosif>().Find(codigoCosif, codigoProduto);
        }
    }
}
