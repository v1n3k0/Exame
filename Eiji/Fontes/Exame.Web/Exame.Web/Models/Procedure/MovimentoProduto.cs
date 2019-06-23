using System;
using System.ComponentModel.DataAnnotations;
using Exame.Web.Arguments.Movimento;

namespace Exame.Web.Models.Procedure
{
    public class MovimentoProduto
    {
        [Display(Name = "Mês")]
        public byte Mes { get; set; }

        [Display(Name = "Ano")]
        public short Ano { get; set; }

        [Display(Name = "Codigo Produto")]
        public Guid CodigoProduto { get; set; }

        [Display(Name = "Descrição Produto")]
        public string DescricaoProduto { get; set; }

        [Display(Name = "Numero de Lancamento")]
        public int NumeroLancamento { get; set; }

        [Display(Name = "Descrição Movimento")]
        public string DescricaoMovimento { get; set; }

        [Display(Name = "Valor")]
        public int Valor { get; set; }

        public static explicit operator MovimentoProduto(MovimentoProdutoResponse entidade)
        {
            return new MovimentoProduto() {
                Mes = entidade.Mes,
                Ano = entidade.Ano,
                CodigoProduto = entidade.CodigoProduto,
                DescricaoProduto = entidade.DescricaoProduto,
                NumeroLancamento = entidade.NumeroLancamento,
                DescricaoMovimento = entidade.DescricaoMovimento,
                Valor = entidade.Valor
            };
        }
    }
}