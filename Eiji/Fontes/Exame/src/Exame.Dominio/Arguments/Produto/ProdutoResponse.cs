using Exame.Dominio.Arguments.Base;

namespace Exame.Dominio.Arguments.Produto
{
    public class ProdutoResponse : ResponseBase
    {
        public string Descricao { get; set; }
        public char Status { get; set; }
    }
}
