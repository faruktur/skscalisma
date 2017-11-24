using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;
using SksCalisma.Areas;

using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace SksCalisma.Areas.Ogrenci.Controllers
{
    public class OgrenciController : BaseController
    {
        // GET: Ogrenci/Ogrenci
        private kismizamanli2014Entities db = new kismizamanli2014Entities();
        
        public int ogrid()
        {
            int userid = kullaniciID();
            var ogrenci = db.Ogrenci.SingleOrDefault(x => x.kullaniciID == userid);
            return ogrenci.ogrenciID;
        }
        
        public ActionResult OgrenciKayit()
        {

            return View();
        }
        
          
        public JsonResult Bolumler(int okulID)
        {
            var a = db.OkulBolum.Where(x => x.okulID == okulID).Select(x => new { okulBolumID = x.okulBolumID, okulBolumAd = x.okulBolumAd }).ToList();
            return Json(new { bt = a }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
                OgrenciViewModel ogrenci = new OgrenciViewModel();
                ogrenci.ogrenci = db.Ogrenci.Find(ogrid());
                ogrenci.kullanici = db.Kullanici.Find(kullaniciID());
                ViewBag.OkulID = new SelectList(db.Okul.Where(x => x.okulTipID == ogrenci.ogrenci.Okul.okulTipID), "okulID", "okulAd", ogrenci.ogrenci.okulID);
                ViewBag.OkulBolumID = new SelectList(db.OkulBolum.Where(x => x.okulID == ogrenci.ogrenci.okulID), "okulBolumID", "okulBolumAd", ogrenci.ogrenci.okulBolumID);
                ViewBag.SinifID = new SelectList(db.Sinif, "sinifID", "sinifAd", ogrenci.ogrenci.sinifID);
                ViewBag.OgrenimTurID = new SelectList(db.OgrenimTur, "ogrenimTurID", "ogrenimTurAd", ogrenci.ogrenci.ogrenimTurID);
                ViewBag.OgrenimTipID = new SelectList(db.OgrenimTip, "ogrenimTipID", "ogrenimTipAd", ogrenci.ogrenci.ogrenimTipID);

            return View(ogrenci);                   
        }
        [HttpPost]
        public ActionResult Index(OgrenciViewModel p)
        {
            if (ModelState.IsValid)
            {

                try {
                    string[] iban;
                    string[] tel;
                    iban = p.ogrenci.ogrenciIBAN.Split(' ');
                    tel = p.ogrenci.ogrenciTelNo.Split(' ');
                    p.ogrenci.ogrenciIBAN = "";
                    p.ogrenci.ogrenciTelNo = "";
                    foreach (var item in iban)
                    {
                        p.ogrenci.ogrenciIBAN += item;
                    }
                    foreach (var item in tel)
                    {
                        p.ogrenci.ogrenciTelNo += item;
                    }
                    p.kullanici.kullaniciGuncellemeTarihi = DateTime.Now;
                p.ogrenci.ogrenciGuncellemeTarih = DateTime.Now;
                p.ogrenci.Okul = db.Okul.Find(p.ogrenci.okulID);
                    p.kullanici.kullaniciMail = p.kullanici.kullaniciMail.Trim();
                    p.ogrenci.ogrenciMail = p.ogrenci.ogrenciMail.Trim();
                    p.ogrenci.ogrenciTelNo = p.ogrenci.ogrenciTelNo.Trim();
                    p.ogrenci.ogrenciIBAN = p.ogrenci.ogrenciIBAN.Trim();
                    p.ogrenci.ogrenciNumara = p.ogrenci.ogrenciNumara.Trim();

                    db.Entry(p.kullanici).State = EntityState.Modified;
                db.Entry(p.ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                catch (DbEntityValidationException e)
                {

                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Response.Write(string.Format("Entity türü \"{0}\" şu hatalara sahip \"{1}\" Geçerlilik hataları:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Response.Write(string.Format("- Özellik: \"{0}\", Hata: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                        }
                        Response.End();
                    }
                }

            }
            return RedirectToAction("Index");

        }
        public ActionResult SifreDegistir()
        {
           
            Kullanici user = db.Kullanici.Find(kullaniciID());
            return View(user);
        }

        [HttpPost]
        public ActionResult SifreDegistir(Kullanici user)
        {
            if(ModelState.IsValid)
            {
                user.kullaniciGuncellemeTarihi = DateTime.Now;
                var ogr = db.Ogrenci.First(x => x.kullaniciID == user.kullaniciID);
                
                db.Entry(ogr).State = EntityState.Modified;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                return View(user);
            }

            return RedirectToAction("Index");
        }




    }
}