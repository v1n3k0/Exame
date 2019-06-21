using Exame.Web.Arguments.Base;
using System;

namespace Exame.Web.Arguments.Cosif
{
    public class AdicionarCosifRequest: RequestBase
    {
        public Guid CodigoProduto { get; set; }
        public string Classificacao { get; set; }
    }
}
