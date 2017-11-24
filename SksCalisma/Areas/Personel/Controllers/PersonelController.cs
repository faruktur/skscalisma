using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;
using Newtonsoft.Json;

namespace SksCalisma.Areas.Personel.Controllers
{
    public class PersonelController : Controller
    {
        private kismizamanli2014Entities db = new kismizamanli2014Entities();

        // GET: Personel/Personel
        public ActionResult Anasayfa()
        {
            ViewBag.pageId = "home";
            return View();
        }
        public JsonResult getBolumByBirim(int birimID)
        {
            var result = db.Bolum.Where(b => b.birimID == birimID).ToList();
            var str = JsonConvert.SerializeObject(result, Formatting.Indented,
 new JsonSerializerSettings
 {
     ReferenceLoopHandling = ReferenceLoopHandling.Serialize
 });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult KontenjanBelirle()
        {
            //db.Birim.Add(new Birim() { 
            //birimAd="ozanBirim"
            //});
            //db.SaveChanges();

            //db.BölümmKontejyan.Add(new BirimKontejyan()
            //{
            //    birimKontejyanAkademi = birimakademikont,
            //    birimKontejyanIdari = birimidarikont
            //});
            //db.SaveChanges();


            ViewBag.pageId = "kontenjan";
            return View();

        }
        public ActionResult KontenjanTakip()
        {
            ViewBag.pageId = "kontenjan";
            return View();
        }

        public ActionResult İlanOlustur()
        {
            ViewBag.pageId = "ilan";
            return View();
        }
        public ActionResult İlanListele()
        {
            ViewBag.pageId = "ilan";
            return View();
        }
        public ActionResult İlanDuzenle()
        {
            ViewBag.pageId = "ilan";
            return View();
        }

        public ActionResult İlanArsiv()
        {
            ViewBag.pageId = "ilan";
            return View();
        }
        public ActionResult Calisanlar()
        {
            ViewBag.pageId = "Calisan";
            return View();
        }
        public ActionResult HazirlaOnayla()
        {
            ViewBag.pageId = "Puantaj";
            return View();
        }
    }
}