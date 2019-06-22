using Exame.Web.Arguments.Base;
using Exame.Web.Models;
using System;

namespace Exame.Web.Arguments.Movimento
{
    public class AdicionarMovimentoRequest : RequestBase
    {
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public Guid CodigoProduto { get; set; }
        public Guid CodigoCosif { get; set; }
        public string Descricao { get; set; }
        public int Valor { get; set; }

        public static explicit operator AdicionarMovimentoRequest(Models.Movimento entidade)
        {
            return new AdicionarMovimentoRequest() {
                Mes = entidade.Mes,
                Ano = entidade.Ano,
                CodigoProduto = entidade.CodigoProduto,
                CodigoCosif = entidade.CodigoCosif,
                Descricao = entidade.Descricao,
                Valor = entidade.Valor
            };
        }
    }
}
