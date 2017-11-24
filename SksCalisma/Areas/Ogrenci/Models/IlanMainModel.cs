using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SksCalisma.Areas.Ogrenci.Models
{
    public class IlanMainModel
    {
        public PagedList.IPagedList<IlanViewModel> list { get; set; }
        
    }
}