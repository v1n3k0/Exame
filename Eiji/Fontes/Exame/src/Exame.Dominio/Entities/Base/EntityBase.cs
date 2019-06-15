using prmToolkit.NotificationPattern;
using System;

namespace Exame.Dominio.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        protected EntityBase()
        {
            codigo = Guid.NewGuid();
        }

        public Guid codigo { get; private set; }
    }
}
