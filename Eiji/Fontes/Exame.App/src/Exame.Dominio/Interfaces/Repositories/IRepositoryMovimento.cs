using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories.Base;
using System;

namespace Exame.Dominio.Interfaces.Repositories
{
    public interface IRepositoryMovimento : IRepositoryBase<Movimento, Guid>
    {
        Movimento ObterPorId(Guid codigo, byte mes, short ano, int numeroLancamento, Guid codigoCosif, Guid codigoProduto);
        int GerarNumeroLancamento(byte mes, short ano);
    }
}
