using Exame.Web.Arguments.Base;
using System;

namespace Exame.Web.Arguments.Produto
{
    public class EditarProdutoRequest: RequestBase
    {
        public Guid Codigo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
    }
}
