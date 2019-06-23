using Exame.Dominio.Entities;
using Exame.Dominio.Entities.Procedure;
using Exame.Dominio.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;

namespace Exame.Dominio.Interfaces.Repositories
{
    public interface IRepositoryMovimento : IRepositoryBase<Movimento>
    {
        Movimento ObterPorId(byte mes, short ano, int numeroLancamento, Guid codigoCosif, Guid codigoProduto);
        int GerarNumeroLancamento(byte mes, short ano);

        IEnumerable<MovimentoProduto> ListarMovimentoProduto();
    }
}
