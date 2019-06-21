using System;

namespace Exame.Dominio.Arguments.Movimento
{
    public class ObterMovimentoRequest
    {
        public Guid CodigoMovimento { get; set; }
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public Guid CodigoCosif { get; set; }
        public Guid CodigoProduto { get; set; }
    }
}
