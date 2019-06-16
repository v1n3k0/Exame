using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories.Base;
using System;

namespace Exame.Dominio.Interfaces.Repositories
{
    public interface IRepositoryMovimento : IRepositoryBase<Movimento, Guid>
    {
    }
}
