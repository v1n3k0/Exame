using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories.Base;
using System;

namespace Exame.Dominio.Interfaces.Repositories
{
    public interface IRepositoryProduto : IRepositoryBase<Produto, Guid>
    {
        Produto ObterPorId(Guid id);
    }
}
