using Exame.Dominio.Entities.Base;
using Exame.Dominio.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace Exame.Dominio.Entities
{
    public class Movimento : EntityBase
    {
        public byte Mes { get; private set; }
        public short Ano { get; private set; }
        public int NumeroLancamento { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataMovimento { get; private set; }
        public string Usuario { get; private set; }
        public int Valor { get; private set; }
        public Guid CodigoCosif { get; private set; }
        public virtual Cosif Cosif { get; private set; }
        public Guid CodigoProduto { get; private set; }

        protected Movimento()
        {

        }

        public Movimento(byte mes, short ano, int numeroLacamento, Cosif cosif, string descricao, int valor)
        {
            Mes = mes;
            Ano = ano;
            NumeroLancamento = numeroLacamento;
            Cosif = cosif;
            Descricao = descricao;
            DataMovimento = DateTime.Now;
            Usuario = "TESTE";
            Valor = valor;

            ValidarEntidade();
        }

        public void Alterar(byte mes, short ano, int numeroLacamento, Cosif cosif, string descricao, int valor)
        {
            Mes = mes;
            Ano = ano;
            NumeroLancamento = numeroLacamento;
            Cosif = cosif;
            Descricao = descricao;
            DataMovimento = DateTime.Now;
            Usuario = "TESTE";
            Valor = valor;

            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            new AddNotifications<Movimento>(this).
                IfNull(x => x.Cosif, Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("Cosif")).
                IfNullOrInvalidLength(x => x.Descricao, 3, 50, Message.X0_E_OBRIGATORIA.ToFormat("Descrição")).
                IfNullOrEmpty(x => x.Usuario, Message.X0_E_OBRIGATORIA.ToFormat("Usuario"));

            if (Valor < 0) AddNotification("Valor", Message.A_X0_DEVE_SER_MAIOR_OU_IGUAL_A_X1.ToFormat("Valor", 0));
            if (NumeroLancamento < 1) AddNotification("NumeroLancamento", Message.A_X0_DEVE_SER_MAIOR_OU_IGUAL_A_X1.ToFormat("Numero do Lançamento", 1));
            if (Ano < 1) AddNotification("Ano", Message.A_X0_DEVE_SER_MAIOR_OU_IGUAL_A_X1.ToFormat("Ano", 1));
            if (Mes < 1) AddNotification("Mes", Message.A_X0_DEVE_SER_MAIOR_OU_IGUAL_A_X1.ToFormat("Mês", 1));
        }
    }
}
