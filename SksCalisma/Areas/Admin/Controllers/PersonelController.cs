using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;

namespace SksCalisma.Areas.Admin.Controllers
{
    public class PersonelController : BaseController
    {
        // GET: Admin/Personel
        public ActionResult Index()
        {
            ViewBag.Personeller = db.Personel.Include(b => b.Birim).Include(b => b.Bolum).Include(b => b.Kullanici).ToList();
            ViewBag.yetkiTipID = new SelectList(db.YetkiTip, "yetkiTipID", "yetkiTipAd", "");
            ViewBag.birimID = new SelectList(db.Birim, "birimID", "birimAd");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.PersonelViewModel p)
        {
            if (ModelState.IsValid)
            {
                p.kullanici.kullaniciTipID = 2;
                p.kullanici.kullaniciEklemeTarihi = DateTime.Now;
                db.Kullanici.Add(p.kullanici);
                p.personel.personelEklemeTarih = DateTime.Now;
                p.personel.kullaniciID = p.kullanici.kullaniciID;
                db.Personel.Add(p.personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.PersonelViewModel p)
        {
            if (ModelState.IsValid)
            {
                p.kullanici.kullaniciTipID = 2;
                p.kullanici.kullaniciGuncellemeTarihi = DateTime.Now;
                p.personel.personelGuncellemeTarih = DateTime.Now;
                db.Entry(p.kullanici).State = EntityState.Modified;
                db.Entry(p.personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.birimID = new SelectList(db.Birim, "birimID", "birimAd", p.personel.birimID);
            ViewBag.bolumID = new SelectList(db.Bolum.Where(x => x.birimID == p.personel.birimID), "bolumID", "bolumAd", p.personel.bolumID);
            return RedirectToAction("Index", p);
        }

        public JsonResult bolumler(int birimID)
        {
            var a = db.Bolum.Where(x => x.birimID == birimID).Select(x => new { bolumID = x.bolumID, bolumAd = x.bolumAd });
            return Json(new { bt = a }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetYetkiForm(int id)
        {
            var personelYetki = db.PersonelYetki.Where(x => x.personelID == id);
            ViewBag.yetkiler = personelYetki.ToList();
            ViewBag.yetkiTipID = new SelectList(db.YetkiTip.Where(x => !personelYetki.Select(z => z.yetkiTipID).Contains(x.yetkiTipID)), "yetkiTipID", "yetkiTipAd");
            ViewBag.birimID = new SelectList(db.Birim, "birimID", "birimAd");
            return PartialView("_Yetki", new PersonelYetki() { personelID = id });
        }
        [HttpPost]
        public ActionResult GetEditForm(int id)
        {
            Models.PersonelViewModel p = new Models.PersonelViewModel();
            p.personel = db.Personel.Single(x => x.personelID == id);
            p.kullanici = db.Kullanici.Single(x => x.kullaniciID == p.personel.kullaniciID);
            ViewBag.birimID = new SelectList(db.Birim, "birimID", "birimAd",p.personel.birimID);
            ViewBag.bolumID = new SelectList(db.Bolum.Where(x => x.birimID == p.personel.birimID), "bolumID", "bolumAd", p.personel.bolumID);
            return PartialView("_Edit", p);
        }

        [HttpPost]
        public ActionResult GetDetailsForm(int id)
        {
            Models.PersonelViewModel p = new Models.PersonelViewModel();
            p.personel = db.Personel.Single(x => x.personelID == id);
            p.kullanici = db.Kullanici.Single(x => x.kullaniciID == p.personel.kullaniciID);
            return PartialView("_Details", p);
        }

        [HttpPost]
        public ActionResult GetDeleteForm(int id)
        {
            Models.PersonelViewModel p = new Models.PersonelViewModel();
            p.personel = db.Personel.Single(x => x.personelID == id);
            p.kullanici = db.Kullanici.Single(x => x.kullaniciID == p.personel.kullaniciID);
            return PartialView("_Delete", p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            SksCalisma.Models.Personel p = db.Personel.Find(id);
            Kullanici k = db.Kullanici.Find(p.kullaniciID);
            db.Personel.Remove(p);
            db.Kullanici.Remove(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Yetki(PersonelYetki py)
        {
            if (ModelState.IsValid)
            {
                py.Personel = db.Personel.Find(py.personelID);
                py.YetkiTip = db.YetkiTip.Find(py.yetkiTipID);
                db.PersonelYetki.Add(py);
                db.SaveChanges();
                return PartialView("_YetkiListItem", py);
            }
            return RedirectToAction("Index", py);
        }

        [HttpPost]
        public void YetkiKaldir(int yetkiTipID, int personelID)
        {
            db.PersonelYetki.Remove(db.PersonelYetki.Single(x => x.personelID == personelID && x.yetkiTipID == yetkiTipID));
            db.SaveChanges();
        }
    }
}