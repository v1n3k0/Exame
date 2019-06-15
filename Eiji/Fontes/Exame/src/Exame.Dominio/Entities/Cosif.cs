using Exame.Dominio.Entities.Base;
using Exame.Dominio.Enum;
using Exame.Dominio.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Exame.Dominio.Entities
{
    public class Cosif : EntityBase
    {
        public Produto Produto { get; set; }
        public EnumClassificacaoConta Classificacao { get; set; }
        public EnumStatus Status { get; set; }

        protected Cosif()
        {

        }

        public Cosif(Produto produto, EnumStatus status)
        {
            Produto = produto;
            Status = status;

            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            new AddNotifications<Cosif>(this).
                IfNull(x => x.Produto, Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("Produto")).
                IfNull(x => x.Status, Message.X0_E_OBRIGATORIA.ToFormat("Status"));
        }
    }
}
