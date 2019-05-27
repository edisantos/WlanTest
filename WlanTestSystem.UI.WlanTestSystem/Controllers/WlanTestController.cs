using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WlanTestSystem.Application.ModelView;
using WlanTestSystem.Infra.Data.Contexto;

namespace WlanTestSystem.UI.WlanTestSystem.Controllers
{
    //[Authorize]
    public class WlanTestController : Controller
    {
        // GET: WlanTest
        private readonly DataContexto db = new DataContexto();
        public ActionResult Index()
        {
            var result = db.TB_WLAN.ToList();
            return View(result);
        }
        public ActionResult WlanTestRegister()
        {
            return View();
        }

        public ActionResult MagazineRegistro()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MagazineRegistro(MagazineSize model)
        {
            var listar = db.MagazineSize.FirstOrDefault();
            if (ModelState.IsValid)
            {
                model.Data = DateTime.Now;
                model.Operador = User.Identity.Name;
               
                db.MagazineSize.Add(model);
                db.SaveChanges();
                TempData["Size"] = model.Size;
                TempData["Id"] = model.MagazineSizeId;
                ViewBag.Size = model.Size;
                   
;                return RedirectToAction("WlanTestVerification",new { model.MagazineSizeId });

            }
            return View();
        }

        public ActionResult WlanTestVerification(int ? id)
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WlanTestVerification(WlanTestVerification model,string SN)
        {
            var VerificaTeste = db.TB_WLAN.Where(p => p.StatusTest == 1);
            var tbwlan = db.TB_WLAN.Where(p=>p.SN == SN).FirstOrDefault();
            var Total = db.WlanTestVerification.Count();
            var tamanho = db.MagazineSize.Where(p => p.MagazineSizeId == model.MagazineSizeId).FirstOrDefault();
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
                else

                {
                    if (VerificaTeste != null)
                    {
                        if (ModelState.IsValid)
                        {
                            model.TEST_END_TIME = tbwlan.Data;
                            model.MAC = tbwlan.MAC;
                            model.WIFI_MAC = tbwlan.WIFI_MAC;
                            model.BT_MAC = tbwlan.BT_MAC;
                            model.RESULT = "P";
                            model.VEND_CODE = tbwlan.VEND_CODE;
                            model.MagazineSizeId = model.MagazineSizeId;
                            db.WlanTestVerification.Add(model);
                            db.SaveChanges();
                            ViewBag.Count = Total;
                            ViewBag.Size = tamanho.Size;
                            ViewBag.ID = tamanho.MagazineSizeId;
                            ModelState.Clear();
                        }
                        else
                        {
                            StringBuilder strB = new StringBuilder(500);
                            foreach (ModelState modelState in ModelState.Values)
                            {
                                foreach (ModelError error in modelState.Errors)
                                {
                                    strB.Append(error.ErrorMessage + ".");
                                }
                            }
                            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                            return Content(strB.ToString());
                        }
                    }
                    else
                    {
                        ViewBag.MsgError = "Não já registro";
                    }
                }
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Content("Sorry, an error occured." + ex.Message);
            }
            
            
            return View();
        }
        public JsonResult ContarRegistros()
        {
            var Total = db.WlanTestVerification.Count();
           
            return Json(Total, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
       
        public JsonResult GetListaMagazizePartialView()
        {
            var result = db.WlanTestVerification.ToList();
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Listar()
        {
            var result = db.WlanTestVerification.ToList();
            return View(result);
        }
        public ActionResult ListarMagazine(WlanTestVerification model)
        {
            var result = db.WlanTestVerification.ToList();
            return PartialView(result);
        }
    }
}