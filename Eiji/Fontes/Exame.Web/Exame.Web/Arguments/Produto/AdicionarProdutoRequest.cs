using Exame.Dominio.Arguments.Base;

namespace Exame.Dominio.Arguments.Produto
{
    public class AdicionarProdutoRequest : RequestBase
    {
        public string Descricao { get; set; }
    }
}
