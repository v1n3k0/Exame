using Exame.Web.Models;
using Exame.Web.Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Exame.Web.Controllers
{
    public class MovimentoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Movimento> movimentos = null;

            var api = new ServiceMovimento();

            movimentos = api.GetListar();

            return View(movimentos);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var apiProduto = new ServiceProduto();
            var apiCosif = new ServiceCosif();

            ViewBag.Produtos = new SelectList(
                apiProduto.GetListar().OrderBy(x => x.Descricao),
                "Codigo",
                "Descricao"
                );

            ViewBag.Cosifs = new SelectList(
                apiCosif.GetListar().Select(x => new
                {
                    Codigo = x.Codigo,
                    Descricao = $"{x.Codigo} - ({x.Status})"
                }),
                "Codigo",
                "Descricao"
                );

            var movimento = new Movimento();

            return View(movimento);
        }

        [HttpPost]
        public ActionResult Create(Movimento movimento)
        {

            return RedirectToAction("Index");
        }
    }
}