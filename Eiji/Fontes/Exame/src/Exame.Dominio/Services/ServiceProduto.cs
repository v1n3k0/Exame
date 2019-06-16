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
        private IRepositoryProduto _repository { get; set; }

        protected ServiceProduto()
        {

        }

        public ServiceProduto(IRepositoryProduto repositoryProduto)
        {
            _repository = repositoryProduto;
        }

        public ProdutoResponse Adicionar(AdicionarProdutoRequest request)
        {
            if(request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarProdutoRequest"));
                return null;
            }

            var produto = new Produto(request.Descricao, EnumStatus.Ativo);

            AddNotifications(produto);

            if (IsInvalid())
                return null;

            produto = _repository.Adicionar(produto);

            return (ProdutoResponse)produto;
        }

        public ProdutoResponse Alterar(AlterarProdutoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarProdutoRequest"));
                return null;
            }

            Produto produto =_repository.ObterPorId(request.Codigo);

            if(produto == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            try
            {
                EnumStatus status = (EnumStatus)System.Enum.Parse(typeof(EnumStatus), request.Status);
                produto.Alterar(request.Descricao, status);
            }
            catch (ArgumentException e)
            {
                AddNotification("Status", string.Concat(Message.DADOS_NAO_ENCONTRADOS, e.Message));
            }            

            AddNotifications(produto);

            if (IsInvalid())
                return null;

            produto = _repository.Editar(produto);

            return (ProdutoResponse)produto;
        }

        public IEnumerable<ProdutoResponse> Listar()
        {
            return _repository.Listar().ToList().Select(x => (ProdutoResponse)x).ToList();
        }

        public ProdutoResponse Obter(Guid codigo)
        {
            Produto produto = _repository.ObterPorId(codigo);

            if (produto == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return (ProdutoResponse)produto;
        }

        public ResponseBase Remover(Guid codigo)
        {
            Produto produto = _repository.ObterPorId(codigo);

            if(produto == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repository.Remover(produto);

            return new ResponseBase();
        }
    }
}
