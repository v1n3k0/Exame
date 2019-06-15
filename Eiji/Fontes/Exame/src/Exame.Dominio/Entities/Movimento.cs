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
        public ushort Ano { get; private set; }
        public int NumeroLancamento { get; private set; }
        public Cosif Cosif { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataMovimento { get; private set; }
        public string Usuario { get; private set; }
        public int Valor { get; private set; }

        protected Movimento()
        {

        }

        public Movimento(byte mes, ushort ano, int numeroLacamento, Cosif cosif, string descricao, string usuario, int valor)
        {
            Mes = mes;
            Ano = ano;
            NumeroLancamento = numeroLacamento;
            Cosif = cosif;
            Descricao = descricao;
            DataMovimento = new DateTime();
            Usuario = usuario;
            Valor = valor;

            ValidarEntidade();
        }

        public void Alterar(byte mes, ushort ano, int numeroLacamento, Cosif cosif, string descricao, string usuario, int valor)
        {
            Mes = mes;
            Ano = ano;
            NumeroLancamento = numeroLacamento;
            Cosif = cosif;
            Descricao = descricao;
            DataMovimento = new DateTime();
            Usuario = usuario;
            Valor = valor;

            ValidarEntidade();
        }

        private void ValidarEntidade()
        {
            new AddNotifications<Movimento>(this).
                IfTrue(x => x.Mes < 1, Message.A_X0_DEVE_SER_MAIOR_OU_IGUAL_A_X1.ToFormat("Mês", 1)).
                IfTrue(x => x.Ano < 1, Message.A_X0_DEVE_SER_MAIOR_OU_IGUAL_A_X1.ToFormat("Ano", 1)).
                IfNull(x => x.NumeroLancamento, Message.X0_E_OBRIGATORIA.ToFormat("Numero do Lançamento")).
                IfNull(x => x.Cosif, Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("Cosif")).
                IfNullOrInvalidLength(x => x.Descricao, 3, 50, Message.X0_E_OBRIGATORIA.ToFormat("Descrição")).
                IfNullOrEmpty(x => x.Usuario, Message.X0_E_OBRIGATORIA.ToFormat("Usuario")).
                IfTrue(x => x.Valor < 0, Message.A_X0_DEVE_SER_MAIOR_OU_IGUAL_A_X1.ToFormat("Valor", 0));
        }
    }
}
