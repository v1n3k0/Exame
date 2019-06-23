using Exame.Web.Models.Procedure;
using System;

namespace Exame.Web.Arguments.Movimento
{
    public class MovimentoProdutoResponse
    {
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public Guid CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int NumeroLancamento { get; set; }
        public string DescricaoMovimento { get; set; }
        public int Valor { get; set; }

        public static explicit operator MovimentoProdutoResponse(MovimentoProduto entidade)
        {
            return new MovimentoProdutoResponse()
            {
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