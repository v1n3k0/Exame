using Exame.Web.Arguments.Cosif;
using Exame.Web.Enum;
using Exame.Web.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exame.Web.Models
{
    public class Cosif : EntityBase
    {
        public Guid Codigo { get; set; }
        public EnumClassificacaoConta Classificacao { get; set; }
        public EnumStatus Status { get; set; }
        public Guid CodigoProduto { get; set; }
        public Produto Produto { get; set; }
        public List<Movimento> Movimentos { get; set; }

        public static explicit operator Cosif(CosifResponse entidade)
        {
            return new Cosif()
            {
                Codigo = entidade.Codigo,
                Message = string.Concat(
                    System.Enum.TryParse<EnumClassificacaoConta>(entidade.Classificacao, true, out var classificacao)? 
                        string.Empty : "Clssificação Conta não encontrado",
                    System.Enum.TryParse<EnumStatus>(entidade.Status, true, out var status)?
                        string.Empty : "Status não encontrado" 
                        ),
                Classificacao = classificacao,
                Status = status,
                CodigoProduto = entidade.CodigoProduto,
                Produto = entidade.Produto != null ? (Produto)entidade.Produto : null,
                Movimentos = entidade.Movimentos?.Select(x => (Movimento)x).ToList() ?? null
            };
        }
    }
}
