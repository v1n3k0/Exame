using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Movimento;
using Exame.Dominio.Entities;
using Exame.Dominio.Interfaces.Repositories;
using Exame.Dominio.Interfaces.Services;
using Exame.Dominio.Resources;
using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Exame.Dominio.Services
{
    public class ServiceMovimento : Notifiable, IServiceMovimento
    {
        private readonly IRepositoryMovimento _repositoryMovimento;
        private readonly IRepositoryCosif _repositoryCosif;
        private readonly IRepositoryProduto _repositoryProduto;

        protected ServiceMovimento()
        {

        }

        public ServiceMovimento(IRepositoryMovimento repositoryMovimento, IRepositoryCosif repositoryCosif, 
            IRepositoryProduto repositoryProduto)
        {
            _repositoryMovimento = repositoryMovimento;
            _repositoryCosif = repositoryCosif;
            _repositoryProduto = repositoryProduto;
        }

        public MovimentoResponse Adicionar(AdicionarMovimentoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarMovimentoRequest"));
                return null;
            }

            Cosif cosif = _repositoryCosif.ObterPorId(request.CodigoCosif, request.CodigoProduto );

            if (cosif == null)
            {
                AddNotification("CodigoCosif", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            Produto produto = _repositoryProduto.ObterPorId(request.CodigoProduto);

            if (produto == null)
            {
                AddNotification("CodigoProduto", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var numeroLancamento = _repositoryMovimento.GerarNumeroLancamento(request.Mes, request.Ano);

            var movimento = new Movimento(request.Mes, request.Ano, numeroLancamento, cosif, produto, request.Descricao,
                request.Valor);

            AddNotifications(movimento);

            if (IsInvalid())
                return null;

            movimento = _repositoryMovimento.Adicionar(movimento);

            return (MovimentoResponse)movimento;
        }

        public MovimentoResponse Editar(EditarMovimentoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarMovimentoRequest"));
                return null;
            }

            Movimento movimento = _repositoryMovimento.ObterPorId(request.CodigoMovimento, request.Mes, request.Ano, 
                request.NumeroLancamento, request.CodigoCosif, request.CodigoProduto);

            if (movimento == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            Cosif cosif = _repositoryCosif.ObterPorId(request.CodigoCosif, request.CodigoProduto);

            if (cosif == null)
            {
                AddNotification("CodigoCosif", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            movimento.Alterar(request.Mes, request.Ano, request.NumeroLancamento, request.Descricao,
                request.Valor);

            AddNotifications(movimento);

            if (IsInvalid())
                return null;

            movimento = _repositoryMovimento.Editar(movimento);

            return (MovimentoResponse)movimento;
        }

        public IEnumerable<MovimentoResponse> Listar()
        {
            return _repositoryMovimento.Listar().ToList().Select(x => (MovimentoResponse)x).ToList();
        }

        public MovimentoResponse Obter(ObterMovimentoRequest request)
        {
            Movimento movimento = _repositoryMovimento.ObterPorId(request.CodigoMovimento, request.Mes, request.Ano,
                request.NumeroLancamento, request.CodigoCosif, request.CodigoProduto);

            if (movimento == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return (MovimentoResponse)movimento;
        }

        public ResponseBase Remover(RemoverMovimentoRequest request)
        {
            Movimento movimento = _repositoryMovimento.ObterPorId(request.CodigoMovimento, request.Mes, request.Ano,
                request.NumeroLancamento, request.CodigoCosif, request.CodigoProduto);

            if (movimento == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryMovimento.Remover(movimento);

            return new ResponseBase();
        }
    }
}
