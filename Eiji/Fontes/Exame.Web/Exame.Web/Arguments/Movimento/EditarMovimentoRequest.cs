using Exame.Web.Arguments.Base;
using System;

namespace Exame.Web.Arguments.Movimento
{
    public class EditarMovimentoRequest : RequestBase
    {
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public Guid CodigoProduto { get; set; }
        public Guid CodigoCosif { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public int Valor { get; set; }
    }
}
