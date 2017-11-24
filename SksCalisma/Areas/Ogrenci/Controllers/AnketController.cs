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
using SksCalisma.Areas.Ogrenci.Models;
namespace SksCalisma.Areas.Ogrenci.Controllers
{
    public class AnketController : BaseController
    {

        kismizamanli2014Entities db = new kismizamanli2014Entities();
        public int ogrid()
        {
            int userid = kullaniciID();
            var ogrenci = db.Ogrenci.SingleOrDefault(x => x.kullaniciID == userid);
            return ogrenci.ogrenciID;
        }
        public ActionResult Index()
        {
            List<AnketViewModel> list = new List<AnketViewModel>();
            var sorular = db.AnketSoru.ToList();
            foreach (var item in sorular)
            {
                int id=kullaniciID();
                var cevap = db.AnketCevap.SingleOrDefault(x => x.AnketSecenek.anketSoruID == item.anketSoruID && x.kullaniciID == id);
                if (cevap == null) // daha önce bu soruya cevap vermişse dropdown da o seçili olacak cevap vermemişse boş seçili olacak
                    list.Add(new AnketViewModel() { soru = item, cevap = new AnketCevap() { kullaniciID = kullaniciID() }, secenekler = new SelectList(db.AnketSecenek.Where(x => x.anketSoruID == item.anketSoruID),
                        "anketSecenekID", "anketSecenekIcerik")});
                else
                    list.Add(new AnketViewModel() { soru = item, cevap = cevap, secenekler = new SelectList(db.AnketSecenek.Where(x => x.anketSoruID == item.anketSoruID),
                        "anketSecenekID", "anketSecenekIcerik", cevap.anketSecenekID)});

            }
            return View(list);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Index(List<AnketViewModel> model)
        {
            foreach (var item in model)
            {
                if (item.cevap.anketSecenekID != 0)
                {
                    if (item.cevap.anketCevapID == 0)
                        db.AnketCevap.Add(item.cevap);
                    else
                        db.Entry(item.cevap).State = EntityState.Modified;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }



        public ActionResult Cevapla()
        {
            MainModel main = new MainModel();
            List<SimpleDropdown> dropdownlist = new List<SimpleDropdown>();
            List<SingleEntity> selist = new List<SingleEntity>();
            var secenekler = db.AnketSecenek.ToList();
            var sorular = db.AnketSoru.ToList();
            foreach (var item in secenekler)
            {
                dropdownlist.Add(new SimpleDropdown { Text = item.anketSecenekIcerik, Value = item.anketSecenekID.ToString(), SoruID = item.anketSoruID });
            }
            SingleEntity se;

            foreach (var item in sorular)
            {
                se = new SingleEntity();
                se.ddl = new List<SimpleDropdown>();
                se.soru = new AnketSoru();
                se.soru = item;
                for (int i = 0; i < dropdownlist.Count; i++)
                {
                    if (dropdownlist[i].SoruID == item.anketSoruID) se.ddl.Add(dropdownlist[i]);
                    se.Selected = Convert.ToInt32(dropdownlist[i].Value);

                }
                main.main_model_list = selist;
                main.main_model_list.Add(se);

            }





            return View(main);
        }
        [HttpPost]
        public ActionResult Cevapla(MainModel main)
        {
            int ID = kullaniciID();
            if (ModelState.IsValid)
            {
                AnketCevap cevap;
           
                for (int i = 0; i < main.main_model_list.Count; i++)
                {
                    cevap = new AnketCevap();
                    cevap.kullaniciID = ID;
                    cevap.anketSecenekID = Convert.ToInt32(main.main_model_list[i].Selected);
                    db.AnketCevap.Add(cevap);
                }
                db.SaveChanges();
                return Redirect("~/Ogrenci/Ogrenci/Index");
            }
            else
            {
            }

            return View();
        }
        public ActionResult Duzenle()
        {
            EditMainModel main = new EditMainModel();
            List<SimpleDropdown> dropdownlist = new List<SimpleDropdown>();
            List<EditModel> selist = new List<EditModel>();
            var secenekler = db.AnketSecenek.ToList();
            var cevaplar = db.AnketCevap.ToList();
            foreach (var item in secenekler)
            {
                dropdownlist.Add(new SimpleDropdown { Text = item.anketSecenekIcerik, Value = item.anketSecenekID.ToString(), SoruID = item.anketSoruID });
            }
            EditModel se;
            
            foreach (var item in cevaplar)
            {
                se = new EditModel();
                se.ddl = new List<SimpleDropdown>();
                se.cevap = new AnketCevap();
                se.cevap = item;
                
                for (int i = 0; i < dropdownlist.Count; i++)
                {
                    if (dropdownlist[i].SoruID == item.AnketSecenek.anketSoruID)
                    {

                        if (item.AnketSecenek.anketSecenekID == Convert.ToInt32(dropdownlist[i].Value))
                        {
                            dropdownlist[i].Selected = true;
                            se.ddl.Add(dropdownlist[i]);
                            
                        }
                        else
                        { 
                              se.ddl.Add(dropdownlist[i]);
                              
                        }
                        se.Selected = Convert.ToInt32(dropdownlist[i].Value);
                        
                    }

                }

                main.modellist = selist;
                main.modellist.Add(se);
                
            }


            return View(main);
        }
        [HttpPost]
        public ActionResult Duzenle(EditMainModel main)
        {
            if (ModelState.IsValid)
            {
                AnketCevap cevap;
                // Boş kalmaması için örnek
                for (int i = 0; i < main.modellist.Count; i++)
                {
                    if(main.modellist[i].cevap.anketCevapID==0)
                    {
                        cevap = new AnketCevap();
                        cevap.kullaniciID = kullaniciID();
                        cevap.anketSecenekID = main.modellist[i].Selected;
                        db.AnketCevap.Add(cevap);
                    }
                    else
                    { 
                    cevap = new AnketCevap();
                    cevap = db.AnketCevap.Find(main.modellist[i].cevap.anketCevapID);
                    cevap.anketSecenekID = main.modellist[i].Selected;
                    cevap.kullaniciID = 1024;
                    }
                }
                db.SaveChanges();
                return Redirect("~/Ogrenci/Ogrenci/Profil");
            }
            else
            {


                return Json(new { result = false });
            }




           
        }
    }
}