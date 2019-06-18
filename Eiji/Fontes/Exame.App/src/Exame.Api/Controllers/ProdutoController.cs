using Exame.Api.Controllers.Base;
using Exame.Dominio.Arguments.Produto;
using Exame.Dominio.Interfaces.Services;
using Exame.Infra.Transactions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Exame.Api.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly IServiceProduto _serviceProduto;

        public ProdutoController(IUnitOfWork unitOfWork, IServiceProduto serviceProduto) : base(unitOfWork)
        {
            _serviceProduto = serviceProduto;
        }

        [Route("Adicionar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Adicionar(AdicionarProdutoRequest request)
        {
            try
            {
                var response = _serviceProduto.Adicionar(request);

                return await ResponseAsync(response, _serviceProduto);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Editar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Editar(EditarProdutoRequest request)
        {
            try
            {
                var response = _serviceProduto.Editar(request);

                return await ResponseAsync(response, _serviceProduto);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("Obter")]
        [HttpGet]
        public async Task<HttpResponseMessage> Obter(Guid id)
        {
            try
            {
                var response = _serviceProduto.Obter(id);

                return await ResponseAsync(response, _serviceProduto);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        //[Authorize]
        [Route("Remover")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Remover(Guid id)
        {
            try
            {
                var response = _serviceProduto.Remover(id);

                return await ResponseAsync(response, _serviceProduto);
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
                var response = _serviceProduto.Listar();

                return await ResponseAsync(response, _serviceProduto);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}