using Exame.Dominio.Arguments.Base;
using System;

namespace Exame.Dominio.Arguments.Movimento
{
    public class AdicionarMovimentoRequest : RequestBase
    {
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public Guid CodigoCosif { get; set; }
        public string Descricao { get; set; }
        public int Valor { get; set; }
    }
}
