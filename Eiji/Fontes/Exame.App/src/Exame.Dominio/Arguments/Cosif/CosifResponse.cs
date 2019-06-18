using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Movimento;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exame.Dominio.Arguments.Cosif
{
    public class CosifResponse : ResponseBase
    {
        public Guid Codigo { get; set; }
        public string Classificacao { get; set; }
        public string Status { get; set; }
        public List<MovimentoResponse> Movimentos { get; set; }

        public static explicit operator CosifResponse(Entities.Cosif entidade)
        {
            return new CosifResponse()
            {
                Codigo = entidade.Codigo,
                Classificacao = entidade.Classificacao.ToString(),
                Status = entidade.Status.ToString(),
                Movimentos = entidade.Movimentos.Select(x => (MovimentoResponse)x).ToList()
            };
        }
    }
}
