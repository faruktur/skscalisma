using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Security;
using UserInterface.Controllers;
using SksCalisma.Areas.Ogrenci.Models;

namespace SksCalisma.Areas.Ogrenci.Models
{
    public class SimpleDropdown : SelectListItem 
    {
        public int SoruID; // soruID
    }
}