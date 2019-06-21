using Exame.Web.Arguments.Base;

namespace Exame.Web.Arguments.Produto
{
    public class AdicionarProdutoRequest : RequestBase
    {
        public string Descricao { get; set; }
    }
}
