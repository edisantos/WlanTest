using System;
using System.Collections.Generic;

namespace WlanTestSystem.Application.ModelView
{
    public class MagazineSize
    {
        public int MagazineSizeId { get; set; }
        public DateTime Data { get; set; }
        public string Operador { get; set; }
        public int Size { get; set; }

        public ICollection<WlanTestVerification> WlanTestVerification { get; set; }
    }
}
