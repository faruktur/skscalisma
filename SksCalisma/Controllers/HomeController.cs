using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Web.Security;
using UserInterface.Controllers;
using System.Threading.Tasks;
using System.Collections;

namespace SksCalisma.Controllers
{
    
    public class HomeController : Controller
    {
        private kismizamanli2014Entities db = new kismizamanli2014Entities();
        public ActionResult Index()
        {
            HttpCookie authoCookies = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authoCookies != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authoCookies.Value);
                int id = Convert.ToInt32(ticket.UserData);
                var k = db.Kullanici.SingleOrDefault(x => x.kullaniciID == id);
                if (k.kullaniciTipID == 1)
                    return RedirectToAction("Index", "Ogrenci", new { area = "Ogrenci" });
                else if (k.kullaniciTipID == 2)
                    return RedirectToAction("Personel", "Home");
                else if (k.kullaniciTipID == 3)
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult OgrenciKayit()
        {
            ViewBag.OkulID = new SelectList(db.Okul, "okulID", "okulAd");
            ViewBag.OkulBolumID = new SelectList(db.OkulBolum, "okulBolumID", "okulBolumAd");
            ViewBag.SinifID = new SelectList(db.Sinif, "sinifID", "sinifAd");
            ViewBag.OgrenimTurID = new SelectList(db.OgrenimTur, "ogrenimTurID", "ogrenimTurAd");
            ViewBag.OgrenimTipID = new SelectList(db.OgrenimTip, "ogrenimTipID", "ogrenimTipAd");
            return View();
        }

       

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult OgrenciKayit(OgrenciViewModel ogr)
        {
          if(ModelState.IsValid)
            {
                try
                {
                    string[] iban;
                    string[] tel;
                    iban = ogr.ogrenci.ogrenciIBAN.Split(' ');
                    tel = ogr.ogrenci.ogrenciTelNo.Split(' ');
                    ogr.ogrenci.ogrenciIBAN = "";
                    ogr.ogrenci.ogrenciTelNo = "";
                    foreach (var item in iban)
                    {
                        ogr.ogrenci.ogrenciIBAN += item;
                    }
                    foreach (var item in tel)
                    {
                        ogr.ogrenci.ogrenciTelNo += item;
                    }
                    ogr.kullanici.kullaniciTipID = 1;
                    ogr.kullanici.kullaniciEklemeTarihi = DateTime.Now;
                    ogr.kullanici.kullaniciGuncellemeTarihi = DateTime.Now;
                    db.Kullanici.Add(ogr.kullanici);
                    db.SaveChanges();
                    
                 
                    ogr.ogrenci.kullaniciID = ogr.kullanici.kullaniciID;
                    ogr.ogrenci.ogrenciEklemeTarih = DateTime.Now;
                    ogr.ogrenci.ogrenciAktiflik = true;
                    ogr.ogrenci.ogrenciAnketPuan = 0;
                    ogr.ogrenci.aileSgkID = 2;
                    ogr.ogrenci.engelDurumID = 3;
                    ogr.ogrenci.calismaTipID = 2;
                  
                    db.Ogrenci.Add(ogr.ogrenci);
                    db.SaveChanges();
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

                    return RedirectToAction("Index");
            }
          else
            {
                ViewBag.OkulID = new SelectList(db.Okul, "okulID", "okulAd");
                ViewBag.OkulBolumID = new SelectList(db.OkulBolum, "okulBolumID", "okulBolumAd");
                ViewBag.SinifID = new SelectList(db.Sinif, "sinifID", "sinifAd");
                ViewBag.OgrenimTurID = new SelectList(db.OgrenimTur, "ogrenimTurID", "ogrenimTurAd");
                ViewBag.OgrenimTipID = new SelectList(db.OgrenimTip, "ogrenimTipID", "ogrenimTipAd");
                return View(ogr);
            }
        }
        public JsonResult Bolumler(int okulID)
        {
            var a = db.OkulBolum.Where(x => x.okulID == okulID).Select(x => new { okulBolumID = x.okulBolumID, okulBolumAd = x.okulBolumAd }).ToList();
            return Json(new { bt = a }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult doesUserNameExist(string veri)
        {

               var ogr = db.Ogrenci.SingleOrDefault(x=>x.ogrenciMail == veri);
               var user = db.Kullanici.SingleOrDefault(x => x.kullaniciMail == veri);
            return Json(user == null);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Kullanici model)
        {
            if (db.Kullanici.Any(x => x.kullaniciMail == model.kullaniciMail && x.kullaniciSifre == model.kullaniciSifre) && model.kullaniciMail != "" && model.kullaniciSifre != "")
            {
                var user = db.Kullanici.Single(x => x.kullaniciMail.Equals(model.kullaniciMail) && x.kullaniciSifre.Equals(model.kullaniciSifre));
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.kullaniciMail, DateTime.Now, DateTime.Now.AddMinutes(30), true, user.kullaniciID.ToString());
                string encToken = FormsAuthentication.Encrypt(ticket);
                HttpCookie authoCookies = new HttpCookie(FormsAuthentication.FormsCookieName, encToken);
                authoCookies.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(authoCookies);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("LoginUser", "E-mail adresi veya şifre hatalı!");
            }
            ModelState.Remove("kullaniciSifre");
            return View(model);
        }
        [UserAuthorize(Yetki = 2)]
        public ActionResult Personel()
        {
            HttpCookie authoCookies = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authoCookies.Value);
            int id = Convert.ToInt32(ticket.UserData);
            Personel p = db.Personel.SingleOrDefault(x => x.kullaniciID == id);
            var yetkiler = db.PersonelYetki.Where(x => x.personelID == p.personelID).Select(x => x.YetkiTip).ToList();
            return View(yetkiler);
        }

        public JsonResult TcKontrol(string tcKimlikNo)
        {
            
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);
 
                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;
 
                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);
 
                returnvalue = ((BTCNO* 100) + (Q1* 10) + Q2 == TcNo);
            }


            return Json(new { sonuc = returnvalue }, JsonRequestBehavior.AllowGet);
        }
        }


    }

