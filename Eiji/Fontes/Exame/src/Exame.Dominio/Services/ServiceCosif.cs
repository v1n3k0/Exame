using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Cosif;
using Exame.Dominio.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace Exame.Dominio.Services
{
    public class ServiceCosif : Notifiable, IServiceCosif
    {
        public ResponseBase Adicionar(AdicionarCosifRequest request)
        {
            throw new NotImplementedException();
        }

        public AlterarCosifResponse Alterar(AlterarCosifRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CosifResponse> Listar()
        {
            throw new NotImplementedException();
        }

        public CosifResponse Obter(Guid codigo)
        {
            throw new NotImplementedException();
        }

        public ResponseBase Remover(Guid request)
        {
            throw new NotImplementedException();
        }
    }
}
