using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SksCalisma.Areas.Ogrenci.Models
{
    public class EditModel
    {
        public SksCalisma.Models.AnketCevap cevap { get; set; }
        public List<SimpleDropdown> ddl { get; set; }
        public int Selected { get; set; }
    }
}