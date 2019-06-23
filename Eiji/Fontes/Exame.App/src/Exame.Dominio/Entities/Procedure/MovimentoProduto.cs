using System;

namespace Exame.Dominio.Entities.Procedure
{
    public class MovimentoProduto
    {
        public byte Mes { get; set; }
        public short Ano { get; set; }
        public Guid CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int NumeroLancamento { get; set; }
        public string DescricaoMovimento { get; set; }
        public int Valor { get; set; }
    }
}
