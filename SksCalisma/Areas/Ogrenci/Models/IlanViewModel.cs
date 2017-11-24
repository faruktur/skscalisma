using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SksCalisma.Models;
using SksCalisma.Areas.Ogrenci.Models;

namespace SksCalisma.Areas.Ogrenci.Models
{
    public class IlanViewModel : SksCalisma.Models.Ilan
    {      
        public  bool isChecked { get; set; }
        public  List<String> gunvesaat { get; set; }
        public string bolum { get; set; }
        public string fakulte { get; set; }
    }
}