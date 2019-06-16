﻿using Exame.Dominio.Entities.Base;
using Exame.Dominio.Enum;
using Exame.Dominio.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;

namespace Exame.Dominio.Entities
{
    public class Cosif : EntityBase
    {
        public Produto Produto { get; private set; }
        public EnumClassificacaoConta Classificacao { get; private set; }
        public EnumStatus Status { get; private set; }

        protected Cosif()
        {

        }

        public Cosif(Produto produto, EnumClassificacaoConta classificacaoConta, EnumStatus status)
        {
            Produto = produto;
            Classificacao = classificacaoConta;
            Status = status;

            ValidarEntidade();
        }

        public void Alterar(Produto produto, EnumClassificacaoConta classificacaoConta, EnumStatus status)
        {
            Produto = produto;
            Classificacao = classificacaoConta;
            Status = status;

            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            new AddNotifications<Cosif>(this).
                IfNull(x => x.Produto, Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("Produto")).
                IfNull(x => x.Classificacao, Message.X0_E_OBRIGATORIA.ToFormat("Classificação")).
                IfNull(x => x.Status, Message.X0_E_OBRIGATORIA.ToFormat("Status"));
        }
    }
}