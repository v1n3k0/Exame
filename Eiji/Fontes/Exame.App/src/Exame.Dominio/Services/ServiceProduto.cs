using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Produto;
using Exame.Dominio.Entities;
using Exame.Dominio.Enum;
using Exame.Dominio.Interfaces.Repositories;
using Exame.Dominio.Interfaces.Services;
using Exame.Dominio.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exame.Dominio.Services
{
    public class ServiceProduto : Notifiable, IServiceProduto
    {
        private readonly IRepositoryProduto _repositoryProduto;

        protected ServiceProduto()
        {

        }

        public ServiceProduto(IRepositoryProduto repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }

        public ProdutoResponse Adicionar(AdicionarProdutoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarProdutoRequest"));
                return null;
            }

            var produto = new Produto(request.Descricao, EnumStatus.Ativo);

            AddNotifications(produto);

            if (IsInvalid())
                return null;

            produto = _repositoryProduto.Adicionar(produto);

            return (ProdutoResponse)produto;
        }

        public ProdutoResponse Editar(EditarProdutoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarProdutoRequest"));
                return null;
            }

            Produto produto = _repositoryProduto.ObterPorId(request.Codigo);

            if (produto == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (!System.Enum.TryParse<EnumStatus>(request.Status, true, out var status))
            {
                AddNotification("Status", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            produto.Alterar(request.Descricao, status);

            AddNotifications(produto);

            if (IsInvalid())
                return null;

            produto = _repositoryProduto.Editar(produto);

            return (ProdutoResponse)produto;
        }

        public IEnumerable<ProdutoResponse> Listar()
        {
            return _repositoryProduto.Listar().ToList().Select(x => (ProdutoResponse)x).ToList();
        }

        public ProdutoResponse Obter(Guid codigo)
        {
            Produto produto = _repositoryProduto.ObterPorId(codigo);

            if (produto == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return (ProdutoResponse)produto;
        }

        public ResponseBase Remover(Guid codigo)
        {
            Produto produto = _repositoryProduto.ObterPorId(codigo);

            if (produto == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryProduto.Remover(produto);

            return new ResponseBase();
        }
    }
}
