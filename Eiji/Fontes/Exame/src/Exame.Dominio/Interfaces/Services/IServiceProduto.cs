using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Produto;
using Exame.Dominio.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace Exame.Dominio.Interfaces.Services
{
    public interface IServiceProduto : IServiceBase
    {
        ProdutoResponse Adicionar(AdicionarProdutoRequest request);

        ProdutoResponse Editar(EditarProdutoRequest request);

        ProdutoResponse Obter(Guid codigo);

        ResponseBase Remover(Guid codigo);

        IEnumerable<ProdutoResponse> Listar();
    }
}
