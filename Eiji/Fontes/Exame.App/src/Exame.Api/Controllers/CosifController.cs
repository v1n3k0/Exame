using Exame.Api.Controllers.Base;
using Exame.Dominio.Arguments.Cosif;
using Exame.Dominio.Interfaces.Services;
using Exame.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Exame.Api.Controllers
{
    [RoutePrefix("api/cosif")]
    public class CosifController : ControllerBase
    {
        private readonly IServiceCosif _serviceCosif;

        public CosifController(IUnitOfWork unitOfWork, IServiceCosif serviceCosif) : base(unitOfWork)
        {
            _serviceCosif = serviceCosif;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarCosifRequest request)
        {
            try
            {
                var response = _serviceCosif.Adicionar(request);

                return await ResponseAsync(response, _serviceCosif);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Editar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Editar(EditarCosifRequest request)
        {
            try
            {
                var response = _serviceCosif.Editar(request);

                return await ResponseAsync(response, _serviceCosif);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Obter")]
        [HttpGet]
        public async Task<HttpResponseMessage> Obter(ObterCosifRequest request)
        {
            try
            {
                var response = _serviceCosif.Obter(request);

                return await ResponseAsync(response, _serviceCosif);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //[Authorize]
        [Route("Remover")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Remover(RemoverCosifRequest request)
        {
            try
            {
                var response = _serviceCosif.Remover(request);

                return await ResponseAsync(response, _serviceCosif);
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
                var response = _serviceCosif.Listar();

                return await ResponseAsync(response, _serviceCosif);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}