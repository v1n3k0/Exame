using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Cosif;
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
    public class ServiceCosif : Notifiable, IServiceCosif
    {
        private readonly IRepositoryCosif _repositoryCosif;
        private readonly IRepositoryProduto _repositoryProduto;

        protected ServiceCosif()
        {

        }

        public ServiceCosif(IRepositoryCosif repositoryCosif, IRepositoryProduto repositoryProduto)
        {
            _repositoryCosif = repositoryCosif;
            _repositoryProduto = repositoryProduto;
        }

        public CosifResponse Adicionar(AdicionarCosifRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarProdutoRequest"));
                return null;
            }

            Produto produto = _repositoryProduto.ObterPorId(request.CodigoProduto);

            if (produto == null)
            {
                AddNotification("CodigoProduto", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (!System.Enum.TryParse<Enum.EnumClassificacaoConta>(request.Classificacao, true, out var classificacaoConta))
            {
                AddNotification("Classificação da Conta", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var cosif = new Cosif(produto, classificacaoConta, Enum.EnumStatus.Ativo);

            AddNotifications(cosif);

            if (IsInvalid())
                return null;

            cosif = _repositoryCosif.Adicionar(cosif);

            return (CosifResponse)cosif;
        }

        public CosifResponse Editar(EditarCosifRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarProdutoRequest"));
                return null;
            }

            Cosif cosif = _repositoryCosif.ObterPorId(request.Codigo, request.CodigoProduto);

            if (cosif == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            Produto produto = _repositoryProduto.ObterPorId(request.CodigoProduto);

            if (produto == null)
            {
                AddNotification("CodigoProduto", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (!System.Enum.TryParse<Enum.EnumStatus>(request.Status, true, out var status))
            {
                AddNotification("Status", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            if (!System.Enum.TryParse<Enum.EnumClassificacaoConta>(request.Classificacao, true, out var classificacaoConta))
            {
                AddNotification("Classificação da Conta", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            cosif.Alterar(classificacaoConta, status);

            AddNotifications(cosif);

            if (IsInvalid())
                return null;

            cosif = _repositoryCosif.Editar(cosif);

            return (CosifResponse)cosif;
        }

        public IEnumerable<CosifResponse> Listar()
        {
            return _repositoryCosif.Listar().ToList().Select(x => (CosifResponse)x).ToList();
        }

        public CosifResponse Obter(ObterCosifRequest request)
        {
            Cosif cosif = _repositoryCosif.ObterPorId(request.CodigoCosif, request.CodigoProduto);

            if (cosif == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return (CosifResponse)cosif;
        }

        public ResponseBase Remover(RemoverCosifRequest request)
        {
            Cosif cosif = _repositoryCosif.ObterPorId(request.CodigoCosif, request.CodigoProduto);

            if (cosif == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryCosif.Remover(cosif);

            return new ResponseBase();
        }
    }
}
