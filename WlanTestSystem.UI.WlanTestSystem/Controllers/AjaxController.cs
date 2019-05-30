using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WlanTestSystem.Application.ModelView;
using WlanTestSystem.Infra.Data.Contexto;

namespace WlanTestSystem.UI.WlanTestSystem.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        private readonly DataContexto db = new DataContexto();
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public JsonResult GetCliente(MagazineSize model)
        {         

            var result = db.MagazineSize.FirstOrDefault();
            return Json(result.Size,result.Operador,JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult ListaAll()
        {
            List<WlanTestVerification> model = db.WlanTestVerification.ToList();
            return PartialView("ListaAll", model);
        }
        public PartialViewResult Top3()
        {
            List<WlanTestVerification> model = db.WlanTestVerification.OrderByDescending(x => x.WlanTesteVerificationId).Take(3).ToList(); ;
            return PartialView("ListaAll", model);
        }
        public PartialViewResult Bottom3()
        {
            List<WlanTestVerification> model = db.WlanTestVerification.OrderBy(x => x.WlanTesteVerificationId).Take(3).ToList(); ;
            return PartialView("ListaAll", model);
        }
    }
}