using Exame.Web.Arguments.Movimento;
using Exame.Web.Arguments.Produto;
using Exame.Web.Arguments.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exame.Web.Arguments.Cosif
{
    public class CosifResponse : ResponseBase
    {
        public Guid Codigo { get; set; }
        public Guid CodigoProduto { get; set; }
        public string Classificacao { get; set; }
        public string Status { get; set; }
        public ProdutoResponse Produto { get; set; }
        public List<MovimentoResponse> Movimentos { get; set; }

        public static explicit operator CosifResponse(Models.Cosif entidade)
        {
            return new CosifResponse()
            {
                Codigo = entidade.Codigo,
                CodigoProduto = entidade.CodigoProduto,
                Classificacao = entidade.Classificacao.ToString(),
                Status = entidade.Status.ToString(),
                Produto = entidade.Produto != null ? (ProdutoResponse)entidade.Produto : null,
                Movimentos = entidade.Movimentos?.Select(x => (MovimentoResponse)x).ToList() ?? null
            };
        }
    }
}