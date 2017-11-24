using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SksCalisma.Models;

namespace SksCalisma.Areas.Ogrenci.Models
{
    public class SingleEntity
    {
        
        public AnketSoru soru { get; set; }
        public List<SimpleDropdown> ddl { get; set; }
        public int Selected { get; set; }

    }
}