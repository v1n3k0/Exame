using Exame.Api.Controllers.Base;
using Exame.Dominio.Arguments.Movimento;
using Exame.Dominio.Interfaces.Services;
using Exame.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Exame.Api.Controllers
{
    [RoutePrefix("api/Movimento")]
    public class MovimentoController : ControllerBase
    {
        private readonly IServiceMovimento _serviceMovimento;

        public MovimentoController(IUnitOfWork unitOfWork, IServiceMovimento serviceMovimento) : base(unitOfWork)
        {
            _serviceMovimento = serviceMovimento;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarMovimentoRequest request)
        {
            try
            {
                var response = _serviceMovimento.Adicionar(request);

                return await ResponseAsync(response, _serviceMovimento);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Editar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Editar(EditarMovimentoRequest request)
        {
            try
            {
                var response = _serviceMovimento.Editar(request);

                return await ResponseAsync(response, _serviceMovimento);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Obter")]
        [HttpGet]
        public async Task<HttpResponseMessage> Obter(ObterMovimentoRequest request)
        {
            try
            {
                var response = _serviceMovimento.Obter(request);

                return await ResponseAsync(response, _serviceMovimento);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //[Authorize]
        [Route("Remover")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Remover(RemoverMovimentoRequest request)
        {
            try
            {
                var response = _serviceMovimento.Remover(request);

                return await ResponseAsync(response, _serviceMovimento);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var response = _serviceMovimento.Listar();

                return await ResponseAsync(response, _serviceMovimento);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}