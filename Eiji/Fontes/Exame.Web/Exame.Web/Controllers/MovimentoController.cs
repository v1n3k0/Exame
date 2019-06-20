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
            List<Movimento> movimentos = null;

            var api = new ServiceMovimento();

            movimentos = api.GetListar();

            return View(movimentos);
        }

        [HttpGet]
        public ActionResult Create()
        {
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