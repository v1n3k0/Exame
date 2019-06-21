using Exame.Dominio.Entities.Base;
using Exame.Dominio.Enum;
using Exame.Dominio.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;

namespace Exame.Dominio.Entities
{
    public class Produto : EntityBase
    {
        public Guid Codigo { get; private set; }
        public string Descricao { get; private set; }
        public EnumStatus Status { get; private set; }
        public virtual ICollection<Cosif> Cosifs { get; set; }

        protected Produto()
        {

        }

        public Produto(string descricao, EnumStatus status)
        {
            Codigo = Guid.NewGuid();
            Descricao = descricao;
            Status = status;
            Cosifs = new List<Cosif>();

            ValidarEntidade();
        }

        public void Alterar(string descricao, EnumStatus status)
        {
            Descricao = descricao;
            Status = status;

            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            new AddNotifications<Produto>(this).
                IfNullOrInvalidLength(x => x.Descricao, 3, 30, Message.X0_E_OBRIGATORIA_E_DEVE_CONTER_X1_CARACTERES.ToFormat("Descrição", 1, 30)).
                IfEnumInvalid(x => x.Status, Message.X0_E_OBRIGATORIA.ToFormat("Status"));
        }
    }
}
