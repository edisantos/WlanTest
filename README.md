https://stackoverflow.com/questions/4730777/mvc-return-partial-view-as-json


Correção

System.InvalidOperationException: Foi detectada uma referência circular ao serializar um objeto do tipo 'System.Data.Entity.DynamicProxies.WlanTestVerification_F4B5766DB4D8CE6CE89D6682EB9C6916188CF901186357510A267550A308E8DB'.

https://www.youtube.com/watch?v=unN107z9HJI


public JsonResult GetListaMagazizePartialView()
        {
            //var result = db.WlanTestVerification.ToList();
            List<WlanTestVerification> w = new List<WlanTestVerification>();
            var result = (from p in w
                          where p.WlanTesteVerificationId > 0
                          select new
                          {
                              WlanTesteVerificationId =        p.WlanTesteVerificationId,
                              Operador = p.MagazineSize.Operador,
                              p.SN,
                              p.TEST_END_TIME,
                              p.MAC,
                              p.WIFI_MAC,
                              p.BT_MAC,
                              p.RESULT,
                              p.VEND_CODE
                          });
            return Json(result,JsonRequestBehavior.AllowGet);
