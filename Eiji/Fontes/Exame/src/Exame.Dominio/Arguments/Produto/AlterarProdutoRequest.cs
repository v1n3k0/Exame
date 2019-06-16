using Exame.Dominio.Arguments.Base;

namespace Exame.Dominio.Arguments.Produto
{
    public class AlterarProdutoRequest: RequestBase
    {
        public string Descricao { get; set; }
        public char Status { get; set; }
    }
}
