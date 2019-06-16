using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Movimento;
using Exame.Dominio.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace Exame.Dominio.Services
{
    public class ServiceMovimento : Notifiable, IServiceMovimento
    {
        public ResponseBase Adicionar(AdicionarMovimentoRequest request)
        {
            throw new NotImplementedException();
        }

        public AlterarMovimentoResponse Alterar(AlterarMovimentoRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovimentoResponse> Listar()
        {
            throw new NotImplementedException();
        }

        public MovimentoResponse Obter(Guid codigo)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Remover(Guid codigo)
        {
            throw new NotImplementedException();
        }
    }
}
