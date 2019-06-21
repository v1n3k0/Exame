using Exame.Web.Arguments.Movimento;
using Exame.Web.Models.Base;
using System;

namespace Exame.Web.Models
{
    public class Movimento : EntityBase
    {
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Usuario { get; set; }
        public int Valor { get; set; }
        public Guid CodigoCosif { get; set; }
        public virtual Cosif Cosif { get; set; }
        public Guid CodigoProduto { get; set; }

        public static explicit operator Movimento(MovimentoResponse entidade)
        {
            return new Movimento()
            {
                Mes = entidade.Mes,
                Ano = entidade.Ano,
                NumeroLancamento = entidade.NumeroLancamento,
                Descricao = entidade.Descricao,
                DataMovimento = entidade.DataMovimento,
                Usuario = entidade.Usuario,
                Valor = entidade.Valor,
                CodigoCosif = entidade.CodigoCosif,
                Cosif = entidade.Cosif != null ? (Cosif)entidade.Cosif : null,
                CodigoProduto = entidade.CodigoProduto
            };
        }
    }
}
