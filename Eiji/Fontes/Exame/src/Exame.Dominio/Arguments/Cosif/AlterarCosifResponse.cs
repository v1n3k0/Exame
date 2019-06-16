using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Produto;

namespace Exame.Dominio.Arguments.Cosif
{
    public class AlterarCosifResponse : ResponseBase
    {
        public ProdutoResponse Produto { get; set; }
        public string Classificacao { get; set; }
        public string Status { get; set; }
    }
}
