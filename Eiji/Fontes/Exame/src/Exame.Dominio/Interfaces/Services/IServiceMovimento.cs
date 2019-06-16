using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Movimento;
using Exame.Dominio.Interfaces.Services.Base;
using System;
using System.Collections.Generic;

namespace Exame.Dominio.Interfaces.Services
{
    public interface IServiceMovimento: IServiceBase
    {
        MovimentoResponse Adicionar(AdicionarMovimentoRequest request);

        MovimentoResponse Editar(EditarMovimentoRequest request);

        MovimentoResponse Obter(Guid codigo);

        ResponseBase Remover(Guid codigo);

        IEnumerable<MovimentoResponse> Listar();
    }
}
