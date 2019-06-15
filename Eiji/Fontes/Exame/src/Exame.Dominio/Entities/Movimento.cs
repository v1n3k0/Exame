using Exame.Dominio.Entities.Base;
using Exame.Dominio.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;

namespace Exame.Dominio.Entities
{
    public class Movimento : EntityBase
    {
        public byte Mes { get; set; }
        public ushort Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public Cosif Cosif { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Usuario { get; set; }
        public int Valor { get; set; }

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

        private void ValidarEntidade()
        {
            new AddNotifications<Movimento>(this).
                IfNull(x => x.Mes, Message.X0_E_OBRIGATORIA.ToFormat("Mês")).
                IfNull(x => x.Ano, Message.X0_E_OBRIGATORIA.ToFormat("Ano")).
                IfNull(x => x.NumeroLancamento, Message.X0_E_OBRIGATORIA.ToFormat("Numero do Lançamento")).
                IfNull(x => x.Cosif, Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("Cosif")).
                IfNullOrInvalidLength(x => x.Descricao, 3, 50, Message.X0_E_OBRIGATORIA.ToFormat("Descrição")).
                IfNullOrEmpty(x => x.Usuario, Message.X0_E_OBRIGATORIA.ToFormat("Usuario")).
                IfNull(x => x.Valor);
        }
    }
}
