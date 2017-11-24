using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SksCalisma.Models;
using System.ComponentModel.DataAnnotations;

namespace SksCalisma.Models
{
    public class OgrenciViewModel
    {
        public SksCalisma.Models.Kullanici kullanici { get; set; }
        public SksCalisma.Models.Ogrenci ogrenci { get; set; }
    }
}