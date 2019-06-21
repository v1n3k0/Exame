using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories;
using Exame.Infra.Persistence.Repositories.Base;
using System;
using System.Linq;

namespace Exame.Infra.Persistence.Repositories
{
    public class RepositoryMovimento : RepositoryBase<Movimento>, IRepositoryMovimento
    {
        protected readonly ExameContext _context;

        public RepositoryMovimento(ExameContext context) : base(context)
        {
            _context = context;
        }

        public Movimento ObterPorId(byte mes, short ano, int numeroLancamento, Guid codigoCosif, Guid codigoProduto)
        {
            return _context.Set<Movimento>().Find(mes, ano, numeroLancamento, codigoCosif, codigoProduto);
        }

        public int GerarNumeroLancamento(byte mes, short ano)
        {
            return Listar().OrderByDescending(x => x.NumeroLancamento)
                .FirstOrDefault(x => x.Mes == mes && x.Ano == ano)?.NumeroLancamento + 1 ?? 1;
        }
    }
}
