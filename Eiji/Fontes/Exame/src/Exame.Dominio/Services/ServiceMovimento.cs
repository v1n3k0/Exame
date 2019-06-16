using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Movimento;
using Exame.Dominio.Entities;
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
    public class ServiceMovimento : Notifiable, IServiceMovimento
    {
        private readonly IRepositoryMovimento _repositoryMovimento;
        private readonly IRepositoryCosif _repositoryCosif;

        protected ServiceMovimento()
        {

        }

        public ServiceMovimento(IRepositoryMovimento repositoryMovimento, IRepositoryCosif repositoryCosif)
        {
            _repositoryMovimento = repositoryMovimento;
            _repositoryCosif = repositoryCosif;
        }

        public MovimentoResponse Adicionar(AdicionarMovimentoRequest request)
        {
            if (request == null)
            {
                AddNotification("Adicionar", Message.OBJETO_X0_E_OBRIGATORIO.ToFormat("AdicionarMovimentoRequest"));
                return null;
            }

            Cosif cosif = _repositoryCosif.ObterPorId(request.CodigoCosif);

            if (cosif == null)
            {
                AddNotification("CodigoCosif", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var movimento = new Movimento(request.Mes, request.Ano, request.NumeroLancamento, cosif, request.Descricao,
                request.Usuario, request.Valor);

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

            Movimento movimento = _repositoryMovimento.ObterPorId(request.Codigo);

            if (movimento == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            Cosif cosif = _repositoryCosif.ObterPorId(request.CodigoCosif);

            if (cosif == null)
            {
                AddNotification("CodigoCosif", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            movimento.Alterar(request.Mes, request.Ano, request.NumeroLancamento, cosif, request.Descricao,
                request.Usuario, request.Valor);

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

        public MovimentoResponse Obter(Guid codigo)
        {
            Movimento movimento = _repositoryMovimento.ObterPorId(codigo);

            if (movimento == null)
            {
                AddNotification("Codigo", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            return (MovimentoResponse)movimento;
        }

        public ResponseBase Remover(Guid codigo)
        {
            Movimento movimento = _repositoryMovimento.ObterPorId(codigo);

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
