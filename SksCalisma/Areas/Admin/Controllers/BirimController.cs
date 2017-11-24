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
    public class BirimController : BaseController
    {
        // GET: Admin/Birim
        public ActionResult Index()
        {
            ViewBag.Birimler = db.Birim.Include(b => b.BirimKontejyan).Include(b => b.BirimTip).ToList();
            ViewBag.birimTurID = new SelectList(db.BirimTur, "birimTurID", "birimTurAd");
            return View();
        }

        public JsonResult birimTipleri(int birimTurId)
        {
            var a = db.BirimTip.Where(x => x.birimTurID == birimTurId).Select(x => new { birimTipID = x.birimTipID, birimTipAd = x.birimTipAd });
            return Json(new { bt = a }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kontenjan(BirimKontejyan bk)
        {
            if (ModelState.IsValid)
            {
                bk.birimKontejyanGuncellemeTarih = DateTime.Now;
                db.Entry(bk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/Birim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "birimID,birimAd,birimTipID")] SksCalisma.Models.Birim birim)
        {
            if (ModelState.IsValid)
            {
                BirimKontejyan bk = new BirimKontejyan()
                {
                    birimKontejyanAkademi = 0,
                    birimKontejyanEkAkademi = 0,
                    birimKontejyanEkAkademiNot = "",
                    birimKontejyanEkIdari = 0,
                    birimKontejyanEkIdariNot = "",
                    birimKontejyanEklemeTarih = DateTime.Now,
                    birimKontejyanGuncellemeTarih = DateTime.Now,
                    birimKontejyanIdari = 0
                };
                db.BirimKontejyan.Add(bk);
                birim.birimEklemeTarih = DateTime.Now;
                birim.birimGuncellemTarih = DateTime.Now;
                birim.birimAkademikCalisan = 0;
                birim.birimIdariCalisan = 0;
                birim.birimKontejyanID = bk.birimKontejyanID;
                db.Birim.Add(birim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (birim.BirimTip != null)
            {
                ViewBag.birimTurID = new SelectList(db.BirimTur, "birimTurID", "birimTurAd", birim.BirimTip.birimTurID);
                ViewBag.birimTipID = new SelectList(db.BirimTip, "birimTipID", "birimTipAd", birim.birimTipID);
            }
            else
            {
                ViewBag.birimTurID = new SelectList(db.BirimTur, "birimTurID", "birimTurAd");
                ViewBag.birimTipID = new SelectList(db.BirimTip, "birimTipID", "birimTipAd");
            }
            return RedirectToAction("Index", birim);
        }

        // GET: Admin/Birim/Edit/5
        [HttpPost]
        public ActionResult GetEditForm(int id)
        {
            var birim = db.Birim.Find(id);
            ViewBag.birimTurID = new SelectList(db.BirimTur, "birimTurID", "birimTurAd",birim.BirimTip.birimTurID);
            ViewBag.birimTipID = new SelectList(db.BirimTip.Where(x => x.birimTurID == birim.BirimTip.birimTurID), "birimTipID", "birimTipAd", birim.birimTipID);
            return PartialView("_Edit", birim);
        }
        [HttpPost]
        public ActionResult GetDeleteForm(int id)
        {
            var birim = db.Birim.Find(id);
            return PartialView("_Delete", birim);
        }
        [HttpPost]
        public ActionResult GetKontForm(int id)
        {
            var birim = db.Birim.Find(id);
            ViewBag.birimID = id;
            return PartialView("_Kontenjan", db.BirimKontejyan.Find(birim.birimKontejyanID));
        }
        // POST: Admin/Birim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "birimID,birimAd,birimTipID,birimKontejyanID,birimAkademikCalisan,birimIdariCalisan")] SksCalisma.Models.Birim birim)
        {
            if (ModelState.IsValid)
            {
                birim.birimGuncellemTarih = DateTime.Now;
                db.Entry(birim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.birimTurID = new SelectList(db.BirimTur, "birimTurID", "birimTurAd");
            //ViewBag.birimTipID = new SelectList(db.BirimTip.Where(x => x.birimTurID == birim.BirimTip.birimTurID), "birimTipID", "birimTipAd", birim.birimTipID);
            return View("Index", birim);
        }

        // POST: Admin/Birim/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var birim = db.Birim.Find(id);
            BirimKontejyan bk = db.BirimKontejyan.Find(birim.birimKontejyanID);
            db.Birim.Remove(birim);
            db.BirimKontejyan.Remove(bk);
            db.SaveChanges();
            return RedirectToAction("Index");
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
