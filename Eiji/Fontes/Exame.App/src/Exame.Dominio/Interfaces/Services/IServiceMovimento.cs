using Exame.Dominio.Arguments.Base;
using Exame.Dominio.Arguments.Movimento;
using Exame.Dominio.Interfaces.Services.Base;
using System.Collections.Generic;

namespace Exame.Dominio.Interfaces.Services
{
    public interface IServiceMovimento: IServiceBase
    {
        MovimentoResponse Adicionar(AdicionarMovimentoRequest request);

        MovimentoResponse Editar(EditarMovimentoRequest request);

        MovimentoResponse Obter(ObterMovimentoRequest request);

        ResponseBase Remover(RemoverMovimentoRequest request);

        IEnumerable<MovimentoResponse> Listar();
    }
}
