using prmToolkit.NotificationPattern;
using System;

namespace Exame.Dominio.Entities.Base
{
    public abstract class EntityBase : Notifiable
    {
        public Guid Codigo { get; private set; }

        protected EntityBase()
        {
            Codigo = Guid.NewGuid();
        }
    }
}
