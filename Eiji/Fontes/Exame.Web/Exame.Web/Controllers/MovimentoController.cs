using Exame.Dominio.Arguments.Movimento;
using Exame.Web.Models;
using Exame.Web.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Exame.Web.Controllers
{
    public class MovimentoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<MovimentoResponse> movimentos = null;

            var api = new ServiceMovimento();

            movimentos = api.GetListar();

            return View(movimentos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var apiProduto = new ServiceProduto();
            var apiCosif = new ServiceCosif();

            ViewBag.Produtos = apiProduto.GetListar();
            ViewBag.Cosif = apiCosif.GetListar();

            var movimento = new AdicionarMovimentoRequest();

            return View(movimento);
        }

        [HttpPost]
        public ActionResult Create(AdicionarMovimentoRequest movimento)
        {

            return RedirectToAction("Index");
        }
    }
}