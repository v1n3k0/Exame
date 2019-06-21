using Exame.Web.Arguments.Base;
using System;

namespace Exame.Web.Arguments.Cosif
{
    public class EditarCosifRequest : RequestBase
    {
        public Guid Codigo { get; set; }
        public Guid CodigoProduto { get; set; }
        public string Classificacao { get; set; }
        public string Status { get; set; }
    }
}
