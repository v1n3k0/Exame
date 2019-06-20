using Exame.Dominio.Interfaces.Arguments;
using Exame.Dominio.Resources;

namespace Exame.Dominio.Arguments.Base
{
    public class ResponseBase : IResponse
    {
        public string Mensagem { get; set; }

        public ResponseBase()
        {
            Mensagem = Message.OPERACAO_REALIZADA_COM_SUCESSO;
        }
    }
}
