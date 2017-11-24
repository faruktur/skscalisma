using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;

namespace SksCalisma.Areas.Admin.Controllers
{
    public class BolumController : BaseController
    {
        // GET: Admin/Bolum
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                ViewBag.birim = false;
                ViewBag.birimler = new SelectList(db.Birim, "birimID", "birimAd");
            }
            else
            {
                ViewBag.birimID = id;
                ViewBag.birim = true;
                ViewBag.birimler = new SelectList(db.Birim, "birimID", "birimAd", id);
                ViewBag.bolumler = db.Bolum.Where(x => x.birimID == id).ToList();
            } 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kontenjan([Bind(Include = "bolumKontejyanID, bolumKontejyanAkademi, bolumKontejyanIdari, bolumKontejyanEkAkademi, bolumKontejyanEkIdari, bolumKontejyanAkademiNot, bolumKontejyanIdarıNot")]BolumKontejyan bk)
        {
            if (ModelState.IsValid)
            {
                bk.bolumKontejyanGuncellemeTarih = DateTime.Now;
                db.Entry(bk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", bk);
        }

        // POST: Admin/Bolum/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bolumAd,birimID")] SksCalisma.Models.Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                BolumKontejyan bk = new BolumKontejyan()
                {
                    bolumKontejyanAkademi = 0,
                    bolumKontejyanEkAkademi = 0,
                    bolumKontejyanAkademiNot = "",
                    bolumKontejyanEkIdari = 0,
                    bolumKontejyanIdarıNot = "",
                    bolumKontejyanEklemeTarih = DateTime.Now,
                    bolumKontejyanGuncellemeTarih = DateTime.Now,
                    bolumKontejyanIdari = 0
                };
                db.BolumKontejyan.Add(bk);
                bolum.bolumEklemeTarih = DateTime.Now;
                bolum.bolumGuncellemeTarih = DateTime.Now;
                bolum.bolumAkademikCalisan = 0;
                bolum.bolumIdariCalisan = 0;
                bolum.bolumKontejyanID = bk.bolumKontejyanID;
                db.Bolum.Add(bolum);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = bolum.birimID });
            }
            return RedirectToAction("Index", bolum);
        }

        // GET: Admin/Bolum/Edit/5
        [HttpPost]
        public ActionResult GetEditForm(int id)
        {
            var bolum = db.Bolum.Find(id);
            return PartialView("_Edit", bolum);
        }
        [HttpPost]
        public ActionResult GetDeleteForm(int id)
        {
            var bolum = db.Bolum.Find(id);
            return PartialView("_Delete", bolum);
        }
        [HttpPost]
        public ActionResult GetKontForm(int id)
        {
            var bolum = db.Bolum.Find(id);
            ViewBag.bolumID = id;
            return PartialView("_Kontenjan", db.BolumKontejyan.Find(bolum.bolumKontejyanID));
        }
        [HttpPost]
        public ActionResult GetCreateForm(int id)
        {
            SksCalisma.Models.Bolum b = new SksCalisma.Models.Bolum() { birimID = id };
            return PartialView("_Create", b);
        }
        // POST: Admin/Bolum/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bolumID, bolumAd, birimID, bolumKontejyanID, bolumAkademikCalisan, bolumIdariCalisan")] SksCalisma.Models.Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                bolum.bolumGuncellemeTarih = DateTime.Now;
                db.Entry(bolum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = bolum.birimID });
            }
            return View("Index", new { id = bolum.birimID });
        }

        // POST: Admin/Bolum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            SksCalisma.Models.Bolum bolum = db.Bolum.Find(id);
            BolumKontejyan bk = db.BolumKontejyan.Find(bolum.bolumKontejyanID);
            db.Bolum.Remove(bolum);
            db.BolumKontejyan.Remove(bk);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
