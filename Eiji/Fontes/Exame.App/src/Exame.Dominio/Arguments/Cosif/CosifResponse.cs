using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Movimento;
using Exame.Dominio.Resources;
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
            var cosif = new CosifResponse();
            if (entidade != null)
            {
                cosif.Codigo = entidade.Codigo;
                cosif.Classificacao = entidade.Classificacao.ToString();
                cosif.Status = entidade.Status.ToString();
                cosif.Movimentos = entidade.Movimentos?.Select(x => (MovimentoResponse)x).ToList() ?? null;
            }
            else
            {
                cosif.Mensagem = Message.DADOS_NAO_ENCONTRADOS;
            }
            return cosif;
        }
    }
}
