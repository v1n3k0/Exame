using System;
using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Produto;
using Exame.Dominio.Entities;

namespace Exame.Dominio.Arguments.Cosif
{
    public class CosifResponse : ResponseBase
    {
        public Guid Codigo { get; set; }
        public ProdutoResponse Produto { get; set; }
        public string Classificacao { get; set; }
        public string Status { get; set; }

        public static explicit operator CosifResponse(Entities.Cosif entidade)
        {
            return new CosifResponse()
            {
                Codigo = entidade.Codigo,
                Produto = (ProdutoResponse)entidade.Produto,
                Classificacao = entidade.Classificacao.ToString(),
                Status = entidade.Status.ToString()
            };
        }
    }
}
