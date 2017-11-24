using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;

namespace SksCalisma.Areas.Birim.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Birim/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Kontenjan()
        {
            int id = kullaniciID();
            var personel = db.Personel.Single(x => x.kullaniciID == id);
            return View(db.Bolum.Where(x => x.birimID == personel.birimID).ToList());
        }

        [HttpPost]
        public ActionResult Kontenjan(List<SksCalisma.Models.Bolum> model)
        {
            foreach (var item in model)
            {
                db.Entry(item.BolumKontejyan).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Kontenjan");
        }
    }
}