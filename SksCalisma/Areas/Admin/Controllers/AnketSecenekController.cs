using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;

namespace SksCalisma.Areas.Admin.Controllers
{
    public class AnketSecenekController : BaseController
    {
        // GET: Admin/AnketSecenek
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.soru = false;
                ViewBag.Sorular = new SelectList(db.AnketSoru, "anketSoruID", "anketSoruIcerik");
            }
            else
            {
                ViewBag.soru = true;
                ViewBag.soruID = id;
                ViewBag.Sorular = new SelectList(db.AnketSoru, "anketSoruID", "anketSoruIcerik", id);
                ViewBag.secenekler = db.AnketSecenek.Where(x => x.anketSoruID == id).ToList();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnketSecenek secenek)
        {
            if (ModelState.IsValid)
            {
                db.AnketSecenek.Add((secenek));
                db.SaveChanges();
                return RedirectToAction("Index", new { id = secenek.anketSoruID });
            }
            return RedirectToAction("Index", secenek);
        }
        [HttpPost]
        public ActionResult GetEditForm(int id)
        {
            return PartialView("_Edit", db.AnketSecenek.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnketSecenek secenek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secenek).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = secenek.anketSoruID });
            }
            return RedirectToAction("Index", new { id = secenek.anketSoruID, secenek });
        }

        [HttpPost]
        public ActionResult GetDeleteForm(int id)
        {
            return PartialView("_Delete", db.AnketSecenek.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var secenek = db.AnketSecenek.Find(id);
            db.AnketSecenek.Remove(secenek);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = secenek.anketSoruID });
        }
    }
}