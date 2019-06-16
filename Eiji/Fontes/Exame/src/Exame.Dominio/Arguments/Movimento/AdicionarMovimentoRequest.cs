using Exame.Dominio.Arguments.Base;
using System;

namespace Exame.Dominio.Arguments.Movimento
{
    public class AdicionarMovimentoRequest : RequestBase
    {
        public byte Mes { get; set; }
        public ushort Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public Guid CodCosif { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public int Valor { get; set; }
    }
}
