using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Cosif;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exame.Dominio.Arguments.Produto
{
    public class ProdutoResponse : ResponseBase
    {
        public Guid Codigo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public IList<CosifResponse> Cosifs { get; set; }

        public static explicit operator ProdutoResponse(Entities.Produto entidade)
        {
            return new ProdutoResponse()
            {
                Codigo = entidade.Codigo,
                Descricao = entidade.Descricao,
                Status = entidade.Status.ToString(),
                Cosifs = entidade.Cosifs.Select(x => (CosifResponse)x).ToList()
            };
        }
    }
}
