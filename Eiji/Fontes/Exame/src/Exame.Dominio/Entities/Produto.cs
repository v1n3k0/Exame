using Exame.Dominio.Entities.Base;
using Exame.Dominio.Enum;
using Exame.Dominio.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Exame.Dominio.Entities
{
    public class Produto : EntityBase
    {

        public string Descricao { get; private set; }
        public EnumStatus Status { get; private set; }

        protected Produto()
        {

        }

        public Produto(string descricao, EnumStatus status)
        {
            Descricao = descricao;
            Status = status;

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
                IfNull(x => x.Status, Message.X0_E_OBRIGATORIA.ToFormat("Status"));
        }
    }
}
