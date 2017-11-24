using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;

namespace SksCalisma.Areas.Bolum.Controllers
{
    public class IlanController : BaseController
    {
        // GET: Bolum/Ilan
        public ActionResult Index()
        {
            ViewBag.ilanlar = db.Ilan.Where(x => x.personelID == kullaniciID()).ToList();
            return View();
        }

        public ActionResult GetCreateForm()
        {
            ViewBag.calismaTipID = new SelectList(db.CalismaTip, "calismaTipID", "calismaTipAd");
            ViewBag.ogrenimTipID = new SelectList(db.OgrenimTip, "ogrenimTipID", "ogrenimTipAd");
            return PartialView("_Create", new Ilan());
        }
        [HttpPost]
        public ActionResult Create(Ilan ilan)
        {
            ilan.ilanEklemeTarih = DateTime.Now;
            ilan.personelID = kullaniciID();
            db.Ilan.Add(ilan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}