using System;
using System.ComponentModel.DataAnnotations;

namespace WlanTestSystem.Application.ModelView
{
    public class WlanTestVerification
    {
        [Key]
        public int WlanTesteVerificationId { get; set; }
        public string SN { get; set; }
        public DateTime TEST_END_TIME { get; set; }
        public string MAC { get; set; }
        public string WIFI_MAC { get; set; }
        public string BT_MAC { get; set; }
        public string RESULT { get; set; }
        public string VEND_CODE { get; set; }
        public bool StatusWlan { get; set; }
        public int MagazineSizeId { get; set; }

        public virtual MagazineSize MagazineSize { get; set; }
        
       
    }
}