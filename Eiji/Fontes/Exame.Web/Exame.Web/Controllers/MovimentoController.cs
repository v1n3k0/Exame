using Exame.Web.Models;
using Exame.Web.Service;
using System;
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

             var produtos = new SelectList(
                apiProduto.GetListar().OrderBy(x => x.Descricao),
                "Codigo",
                "Descricao"
                );
            
            ViewBag.Produtos = produtos;

            var movimento = new Movimento();

            return View(movimento);
        }

        [HttpPost]
        public ActionResult Create(Movimento movimento)
        {
            var apiMovimento = new ServiceMovimento();

            apiMovimento.AdicionarMovimento(movimento);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult getCosifs(Guid codigoProduto)
        {
            var apiCosif = new ServiceCosif();

            var Cosifs = new SelectList(
                apiCosif.GetListar().Where(x => x.CodigoProduto.Equals(codigoProduto)).Select(x => new
                {
                    Codigo = x.Codigo,
                    Descricao = $"{x.Codigo} - ({x.Status})"
                }),
                "Codigo",
                "Descricao"
                );

            return Json(Cosifs, JsonRequestBehavior.AllowGet);
        }
    }
}