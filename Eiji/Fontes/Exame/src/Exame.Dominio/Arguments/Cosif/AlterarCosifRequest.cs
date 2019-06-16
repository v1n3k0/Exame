using Exame.Dominio.Arguments.Base;
using System;

namespace Exame.Dominio.Arguments.Cosif
{
    public class AlterarCosifRequest : RequestBase
    {
        public Guid CodProduto { get; set; }
        public string Classificacao { get; set; }
        public string Status { get; set; }
    }
}
