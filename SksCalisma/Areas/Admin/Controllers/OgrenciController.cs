using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;
using System.Data.Entity.Validation;

namespace SksCalisma.Areas.Admin.Controllers
{
    public class OgrenciController : BaseController
    {
        // GET: Admin/Ogrenci
        public ActionResult Index()
        {
            ViewBag.Ogrenciler = db.Ogrenci.Include(b => b.Okul).Include(b => b.OkulBolum).Include(b => b.Kullanici).Include(b => b.AileSgk).Include(b => b.EngelDurum).Include(b => b.OgrenimTip).Include(b => b.OgrenimTur).Include(b => b.Sinif).ToList();
            ViewBag.AileSgkID = new SelectList(db.AileSgk, "aileSgkID", "aileSgkAd");
            ViewBag.EngelDurumID = new SelectList(db.EngelDurum, "engelDurumID", "engelDurumIcerik");
            ViewBag.OkulTipID = new SelectList(db.OkulTip, "okulTipID", "okulTipAd");
            ViewBag.SinifID = new SelectList(db.Sinif, "sinifID", "sinifAd");
            ViewBag.OgrenimTurID = new SelectList(db.OgrenimTur, "ogrenimTurID", "ogrenimTurAd");
            ViewBag.OgrenimTipID = new SelectList(db.OgrenimTip, "ogrenimTipID", "ogrenimTipAd");
            return View();
        }
        public JsonResult okullar(int okulTipID)
        {
            var a = db.Okul.Where(x => x.okulTipID == okulTipID).Select(x => new { okulID = x.okulID, okulAd = x.okulAd });
            return Json(new { bt = a }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult bolumler(int okulID)
        {
            var a = db.OkulBolum.Where(x => x.okulID == okulID).Select(x => new { okulBolumID = x.okulBolumID, okulBolumAd = x.okulBolumAd});
            return Json(new { bt = a }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OgrenciViewModel ogr)
        {
            if (ModelState.IsValid)
            {
                ogr.kullanici.kullaniciTipID = 1;
                ogr.kullanici.kullaniciEklemeTarihi = DateTime.Now;
                db.Kullanici.Add(ogr.kullanici);
                db.SaveChanges();
                ogr.ogrenci.ogrenciMail = ogr.kullanici.kullaniciMail;
                ogr.ogrenci.kullaniciID = ogr.kullanici.kullaniciID;
                ogr.ogrenci.ogrenciEklemeTarih = DateTime.Now;
                ogr.ogrenci.ogrenciAktiflik = false;
                ogr.ogrenci.ogrenciAnketPuan = 0;
                ogr.ogrenci.aileSgkID = 2;
                ogr.ogrenci.engelDurumID = 3;
                ogr.ogrenci.calismaTipID = 2;
                ogr.ogrenci.Okul = db.Okul.Find(ogr.ogrenci.okulID);
                db.Ogrenci.Add(ogr.ogrenci);
                db.SaveChanges(); ;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", ogr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.OgrenciViewModel p)
        {
            if (ModelState.IsValid)
            {
                p.ogrenci.ogrenciMail = p.kullanici.kullaniciMail;
                p.kullanici.kullaniciGuncellemeTarihi = DateTime.Now;
                p.ogrenci.ogrenciGuncellemeTarih = DateTime.Now;
                p.ogrenci.Okul = db.Okul.Find(p.ogrenci.okulID);
                db.Entry(p.kullanici).State = EntityState.Modified;
                db.Entry(p.ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AileSgkID = new SelectList(db.AileSgk, "aileSgkID", "aileSgkAd");
            ViewBag.EngelDurumID = new SelectList(db.EngelDurum, "engelDurumID", "engelDurumIcerik");
            ViewBag.OkulTipID = new SelectList(db.OkulTip, "okulTipID", "okulTipAd", p.ogrenci.Okul.okulTipID);
            ViewBag.OkulID = new SelectList(db.Okul.Where(x => x.okulTipID == p.ogrenci.Okul.okulTipID), "okulID", "okulAd", p.ogrenci.okulID);
            ViewBag.OkulBolumID = new SelectList(db.OkulBolum.Where(x => x.okulID == p.ogrenci.okulID), "okulBolumID", "okulBolumAd", p.ogrenci.okulBolumID);
            ViewBag.SinifID = new SelectList(db.Sinif, "sinifID", "sinifAd", p.ogrenci.sinifID);
            ViewBag.OgrenimTurID = new SelectList(db.OgrenimTur, "ogrenimTurID", "ogrenimTurAd", p.ogrenci.ogrenimTurID);
            ViewBag.OgrenimTipID = new SelectList(db.OgrenimTip, "ogrenimTipID", "ogrenimTipAd", p.ogrenci.ogrenimTipID);
            return RedirectToAction("Index", p);
        }

        [HttpPost]
        public ActionResult GetEditForm(int id)
        {
            Models.OgrenciViewModel p = new Models.OgrenciViewModel();
            p.ogrenci = db.Ogrenci.Single(x => x.ogrenciID== id);
            p.kullanici = db.Kullanici.Single(x => x.kullaniciID == p.ogrenci.kullaniciID);
            ViewBag.AileSgkID = new SelectList(db.AileSgk, "aileSgkID", "aileSgkAd");
            ViewBag.EngelDurumID = new SelectList(db.EngelDurum, "engelDurumID", "engelDurumIcerik");
            ViewBag.OkulTipID = new SelectList(db.OkulTip, "okulTipID", "okulTipAd", p.ogrenci.Okul.okulTipID);
            ViewBag.OkulID = new SelectList(db.Okul.Where(x => x.okulTipID == p.ogrenci.Okul.okulTipID), "okulID", "okulAd", p.ogrenci.okulID);
            ViewBag.OkulBolumID = new SelectList(db.OkulBolum.Where(x => x.okulID == p.ogrenci.okulID), "okulBolumID", "okulBolumAd", p.ogrenci.okulBolumID);
            ViewBag.SinifID = new SelectList(db.Sinif, "sinifID", "sinifAd", p.ogrenci.sinifID);
            ViewBag.OgrenimTurID = new SelectList(db.OgrenimTur, "ogrenimTurID", "ogrenimTurAd", p.ogrenci.ogrenimTurID);
            ViewBag.OgrenimTipID = new SelectList(db.OgrenimTip, "ogrenimTipID", "ogrenimTipAd", p.ogrenci.ogrenimTipID);
            return PartialView("_Edit", p);
        }

        [HttpPost]
        public ActionResult GetDetailsForm(int id)
        {
            Models.OgrenciViewModel p = new Models.OgrenciViewModel();
            p.ogrenci = db.Ogrenci.Single(x => x.ogrenciID == id);
            p.kullanici = db.Kullanici.Single(x => x.kullaniciID == p.ogrenci.kullaniciID);
            return PartialView("_Details", p);
        }

        [HttpPost]
        public ActionResult GetDeleteForm(int id)
        {
            Models.OgrenciViewModel p = new Models.OgrenciViewModel();
            p.ogrenci = db.Ogrenci.Single(x => x.ogrenciID == id);
            p.kullanici = db.Kullanici.Single(x => x.kullaniciID == p.ogrenci.kullaniciID);
            return PartialView("_Delete", p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            SksCalisma.Models.Ogrenci p = db.Ogrenci.Find(id);
            Kullanici k = db.Kullanici.Find(p.kullaniciID);
            db.Ogrenci.Remove(p);
            db.Kullanici.Remove(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}