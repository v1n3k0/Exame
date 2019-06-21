using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories.Base;
using System;

namespace Exame.Dominio.Interfaces.Repositories
{
    public interface IRepositoryCosif : IRepositoryBase<Cosif, Guid>
    {
        Cosif ObterPorId(Guid codigoCosif, Guid codigoProduto);
    }
}
