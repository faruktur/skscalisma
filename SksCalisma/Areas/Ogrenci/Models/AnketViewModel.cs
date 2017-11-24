using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SksCalisma.Models;
using System.Web.Mvc;

namespace SksCalisma.Areas.Ogrenci.Models
{
    public class AnketViewModel
    {
        public AnketSoru soru { get; set; }
        public SelectList secenekler { get; set; }
        public AnketCevap cevap { get; set; }
    }
}