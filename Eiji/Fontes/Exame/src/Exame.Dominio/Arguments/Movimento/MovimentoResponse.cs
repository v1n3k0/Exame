using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Cosif;

namespace Exame.Dominio.Arguments.Movimento
{
    public class MovimentoResponse: ResponseBase
    {
        public byte Mes { get; set; }
        public ushort Ano { get; set; }
        public int NumeroLancamento { get; set; }
        public CosifResponse Cosif { get; set; }
        public string Descricao { get; set; }
        public string Usuario { get; set; }
        public int Valor { get; set; }
    }
}
