using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WlanTestSystem.Application.ModelView;
using WlanTestSystem.Infra.Data.Contexto;

namespace WlanTestSystem.UI.WlanTestSystem.Controllers
{
    public class WlanController : Controller
    {
        // GET: Wlan
        private readonly DataContexto db = new DataContexto();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditarWlan()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditarWlan(WlanTestVerification mod)
        {
            try
            {

                var listar = db.WlanTestVerification.Where(p => p.StatusWlan == false).ToList();

                Domain.Domain domain = new Domain.Domain();
                domain.EditarStatus();
                return View(listar);



            }
            catch (Exception ex)
            {

                TempData["MsgError"] = "Error " + ex.Message;
            }
            return View();
        }
        public ActionResult EditarAll(WlanTestVerification mod)
        {
            if (ModelState.IsValid)
            {

                db.Entry(mod).State = EntityState.Modified;
                //db.Entry(mod).Property(p => p.SN).IsModified = false;
                //db.Entry(mod).Property(p => p.TEST_END_TIME).IsModified = false;
                //db.Entry(mod).Property(p => p.MAC).IsModified = false;
                //db.Entry(mod).Property(p => p.WIFI_MAC).IsModified = false;
                //db.Entry(mod).Property(p => p.BT_MAC).IsModified = false;
                //db.Entry(mod).Property(p => p.RESULT).IsModified = false;
                //db.Entry(mod).Property(p => p.VEND_CODE).IsModified = false;
                //db.Entry(mod).Property(p => p.MagazineSizeId).IsModified = false;
                mod.StatusWlan = true;
                db.SaveChanges();


            }
            return View();
        }
        public void Editar(WlanTestVerification mod)
        {
            var delete = db.WlanTestVerification.Where(p => p.StatusWlan == false);
            if (delete != null)
            {

                if (ModelState.IsValid)
                {

                    db.Entry(mod).State = EntityState.Modified;
                    db.Entry(mod).Property(p => p.SN).IsModified = false;
                    db.Entry(mod).Property(p => p.TEST_END_TIME).IsModified = false;
                    db.Entry(mod).Property(p => p.MAC).IsModified = false;
                    db.Entry(mod).Property(p => p.WIFI_MAC).IsModified = false;
                    db.Entry(mod).Property(p => p.BT_MAC).IsModified = false;
                    db.Entry(mod).Property(p => p.RESULT).IsModified = false;
                    db.Entry(mod).Property(p => p.VEND_CODE).IsModified = false;
                    db.Entry(mod).Property(p => p.MagazineSizeId).IsModified = false;
                    mod.StatusWlan = true;
                    db.SaveChanges();


                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}