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


namespace SksCalisma.Controllers
{
    public class ValidationController : Controller
    {
        // GET: Validation
        kismizamanli2014Entities db = new kismizamanli2014Entities();
      
        [HttpGet]
        public JsonResult IsUserMailExist() //
        {
            string kullaniciMail = Request.QueryString["kullanici.kullaniciMail"];
            bool isExist = false;
            var ogr = db.Kullanici.FirstOrDefault(x=> x.kullaniciMail.Trim() == kullaniciMail.Trim());
               if ( ogr != null)
            {
                isExist = true;
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult IsUserTcExist()
        {
            bool isExist = false;
            string ogrenciTC = Request.QueryString["ogrenci.ogrenciTC"];
            var ogr = db.Ogrenci.FirstOrDefault(x => x.ogrenciTC.Trim() == ogrenciTC.Trim());
            if (ogr != null)
            {
                isExist = true;
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult IsOgrenciMailExist()
        {
            bool isExist = false;
            string ogrenciMail = Request.QueryString["ogrenci.ogrenciMail"];
            var ogr = db.Ogrenci.FirstOrDefault(x => x.ogrenciMail.Trim() == ogrenciMail.Trim());
            if (ogr != null)
            {
                isExist = true;
            }
            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

    }
}