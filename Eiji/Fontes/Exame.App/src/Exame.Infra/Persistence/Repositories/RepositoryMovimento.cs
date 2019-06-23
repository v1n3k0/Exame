using Exame.Dominio.Entities;
using Exame.Dominio.Entities.Procedure;
using Exame.Dominio.Interfaces.Repositories;
using Exame.Infra.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        public IEnumerable<MovimentoProduto> ListarMovimentoProduto()
        {
            SqlParameter parameter = new SqlParameter("@Listar", System.Data.SqlDbType.Text);
            parameter.Value = 1;
            return _context.Database.SqlQuery<MovimentoProduto>("exec ListarMovimentoProduto", parameter);
        }
    }
}
