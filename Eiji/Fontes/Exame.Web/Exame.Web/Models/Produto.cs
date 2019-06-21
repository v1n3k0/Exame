using Exame.Web.Arguments.Produto;
using Exame.Web.Enum;
using Exame.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exame.Web.Models
{
    public class Produto : EntityBase
    {
        public Guid Codigo { get; set; }
        public string Descricao { get; set; }
        public EnumStatus Status { get; set; }
        public List<Cosif> Cosifs { get; set; }

        public static explicit operator Produto(ProdutoResponse entidade)
        {
            return new Produto()
            {
                Codigo = entidade.Codigo,
                Descricao = entidade.Descricao,
                Message = System.Enum.TryParse<EnumStatus>(entidade.Status, true, out var status)? 
                    string.Empty : "Status não encontrado",
                Status = status,
                Cosifs = entidade.Cosifs?.Select(x => (Cosif)x).ToList() ?? null,
            };
        }
    }
}
