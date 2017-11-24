using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SksCalisma.Areas.Admin.Controllers
{
    public class MuhasebeController : BaseController
    {
        // GET: Admin/Muhasebe
        public ActionResult Index()
        {
            return View(db.Muhasebe.ToList().First());
        }
    }
}