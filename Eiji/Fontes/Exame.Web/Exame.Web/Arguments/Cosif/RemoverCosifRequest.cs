using System;

namespace Exame.Dominio.Arguments.Cosif
{
    public class RemoverCosifRequest
    {
        public Guid CodigoCosif { get; set; }
        public Guid CodigoProduto { get; set; }
    }
}
