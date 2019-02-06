using Calculator.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Calculator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalcularTroco(PagamentoContaViewModel pagamentoContaViewModel)
        {
            try
            {
                var calculator = new CalculaTrocoViewModel(pagamentoContaViewModel);

                return Json(calculator.CalcularTroco(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string error = $"Erro valores inválidos. {ex.Message}";
                throw new Exception(error);
            }
        }
    }
}