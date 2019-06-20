using System;

namespace Exame.Dominio.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Codigo { get; set; }

        protected EntityBase()
        {
            Codigo = Guid.NewGuid();
        }
    }
}
