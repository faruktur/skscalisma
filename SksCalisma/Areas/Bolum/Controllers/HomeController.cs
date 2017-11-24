using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SksCalisma.Areas.Bolum.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Bolum/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}