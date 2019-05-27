using System;
using System.ComponentModel.DataAnnotations;

namespace WlanTestSystem.Application.ModelView
{
    public class TB_WLAN
    {
        [Key]
        public int WlanId { get; set; }

        [Display(Name ="SN")]
        public string SN { get; set; }
        public DateTime Data { get; set; }
        public string MAC { get; set; }
        public string WIFI_MAC { get; set; }
        public string BT_MAC { get; set; }
        public int StatusTest { get; set; }
        public string VEND_CODE { get; set; }
    }
}
