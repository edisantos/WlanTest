using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WlanTestSystem.Application.ModelView;
using WlanTestSystem.Infra.Data.Contexto;

namespace WlanTestSystem.UI.WlanTestSystem.Controllers
{
    public class TesteController : Controller
    {
        private DataContexto db = new DataContexto();

        // GET: Teste
        public ActionResult Index()
        {
            var wlanTestVerification = db.WlanTestVerification.Include(w => w.MagazineSize);
            return View(wlanTestVerification.ToList());
        }

        // GET: Teste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WlanTestVerification wlanTestVerification = db.WlanTestVerification.Find(id);
            if (wlanTestVerification == null)
            {
                return HttpNotFound();
            }
            return View(wlanTestVerification);
        }

        // GET: Teste/Create
        public ActionResult Create()
        {
            ViewBag.MagazineSizeId = new SelectList(db.MagazineSize, "MagazineSizeId", "Operador");
            return View();
        }

        // POST: Teste/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WlanTesteVerificationId,SN,TEST_END_TIME,MAC,WIFI_MAC,BT_MAC,RESULT,VEND_CODE,StatusWlan,MagazineSizeId")] WlanTestVerification wlanTestVerification)
        {
            if (ModelState.IsValid)
            {
                db.WlanTestVerification.Add(wlanTestVerification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MagazineSizeId = new SelectList(db.MagazineSize, "MagazineSizeId", "Operador", wlanTestVerification.MagazineSizeId);
            return View(wlanTestVerification);
        }

        // GET: Teste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WlanTestVerification wlanTestVerification = db.WlanTestVerification.Find(id);
            if (wlanTestVerification == null)
            {
                return HttpNotFound();
            }
            ViewBag.MagazineSizeId = new SelectList(db.MagazineSize, "MagazineSizeId", "Operador", wlanTestVerification.MagazineSizeId);
            return View(wlanTestVerification);
        }

        // POST: Teste/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WlanTesteVerificationId,SN,TEST_END_TIME,MAC,WIFI_MAC,BT_MAC,RESULT,VEND_CODE,StatusWlan,MagazineSizeId")] WlanTestVerification wlanTestVerification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wlanTestVerification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MagazineSizeId = new SelectList(db.MagazineSize, "MagazineSizeId", "Operador", wlanTestVerification.MagazineSizeId);
            return View(wlanTestVerification);
        }

        // GET: Teste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WlanTestVerification wlanTestVerification = db.WlanTestVerification.Find(id);
            if (wlanTestVerification == null)
            {
                return HttpNotFound();
            }
            return View(wlanTestVerification);
        }

        // POST: Teste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WlanTestVerification wlanTestVerification = db.WlanTestVerification.Find(id);
            db.WlanTestVerification.Remove(wlanTestVerification);
            db.SaveChanges();
            return RedirectToAction("Index");
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
