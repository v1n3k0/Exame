using Exame.Dominio.Arguments.Base;

namespace Exame.Dominio.Arguments.Produto
{
    public class AlterarProdutoResponse : ResponseBase
    {
        public string Descricao { get; set; }
        public char Status { get; set; }
    }
}
