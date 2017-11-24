using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SksCalisma.Areas.Admin.Models
{
    public class PersonelViewModel
    {
        public SksCalisma.Models.Kullanici kullanici { get; set; }
        public SksCalisma.Models.Personel personel { get; set; }
    }
}