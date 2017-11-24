using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using SksCalisma.Models;
using SksCalisma.Areas.Ogrenci.Models;
using System.Collections;
using PagedList;

namespace SksCalisma.Areas.Ogrenci.Controllers
{

    public class BasvuruController : BaseController
    {
        kismizamanli2014Entities db = new kismizamanli2014Entities();
        public int ogrid()
        {
            int userid = kullaniciID();
            var ogrenci = db.Ogrenci.SingleOrDefault(x => x.kullaniciID == userid);
            return ogrenci.ogrenciID;
        }


        public List<String> gunfonk(string veri)
        {
            char[] cg = new char[10];
            for (int i = 0; i < 10; i++)
            {
                cg = veri.ToCharArray();

            }
          
            List<string> gunler = new List<string>();
            for (int i = 0; i < 5; i++)
            {

            if(cg[i]=='1')
            {
                if(cg[i+5]=='1')
                { 
                gunler.Add("Sabah Öğlen");
                }
                else
                {
                    gunler.Add("Sabah");
                }
            }
            else
            {
                gunler.Add("Öğlen");
            }

            }

            return gunler;
        }

        [HttpGet]
        public ActionResult DetayGetir(int id)
        {
            IlanViewModel model = new IlanViewModel();
            var item = db.Ilan.FirstOrDefault(x => x.ilanID == id);
                     model.ilanID = item.ilanID;
                     model.ilanCalisanGun = item.ilanCalisanGun;
                     model.ilanCalisanSayisi = item.ilanCalisanSayisi;
                     model.ilanEklemeTarih = item.ilanEklemeTarih;
                     model.ilanMetni = item.ilanMetni;
                     model.ilanGüncellemeTarih = item.ilanGüncellemeTarih;
                     model.isChecked = false;
                     model.gunvesaat = gunfonk(item.ilanCalisanGun);
            return PartialView("IlanDetay", model);
        }

        
        [HttpGet]
        public ActionResult Index(int? page)
        {
            List<IlanViewModel> model = new List<IlanViewModel>();
            IlanMainModel main = new IlanMainModel();
            IlanMainModel sepet = new IlanMainModel();
            var ilanlist = db.Ilan.ToList();
            int ID=kullaniciID();

            var pageNumber = page ?? 1;
            foreach (var item in ilanlist)
            {

                    model.Add(new IlanViewModel
                {
                    ilanID = item.ilanID,
                    ilanCalisanGun = item.ilanCalisanGun,
                    ilanCalisanSayisi = item.ilanCalisanSayisi,
                    ilanEklemeTarih = item.ilanEklemeTarih,
                    ilanMetni = item.ilanMetni,
                    ilanGüncellemeTarih = item.ilanGüncellemeTarih,
                    isChecked = false,
                    gunvesaat = gunfonk(item.ilanCalisanGun),
                    fakulte = db.Personel.FirstOrDefault(x => x.kullaniciID == item.personelID).Birim.birimAd,
                    bolum = db.Personel.FirstOrDefault(x => x.kullaniciID == item.personelID).Bolum.bolumAd

                });
            }
            if(Request.IsAjaxRequest())
            {
               
                main.list = model.ToPagedList(pageNumber, 2);

                return PartialView("_Index", main);
            }


            main.list = model.ToPagedList(pageNumber, 2);

            return View(main);
        }
        
        [HttpPost]
        public ActionResult Index(SepetViewModel model)
        {
            if(ModelState.IsValid)
            {
            List<OgrenciBasvuru> basvuru = new List<OgrenciBasvuru>();
            
            foreach (var item in model.ilan)
            {
              
                    basvuru.Add(new OgrenciBasvuru
                    {
                        ogrenciID = kullaniciID(),
                        ilanID = item.ilanID,
                        ogrenciBasvuruMulakatPuan = 0,
                        ogrenciBasvuruEklemeTarih = DateTime.Now,
                        ogrenciBasvuruGuncellemeTarih = DateTime.Now,
                        ogrenciBasvuruSayisi = 0,
                        
                           
                    });
               


            }
            foreach (var item in basvuru)
            {
                db.OgrenciBasvuru.Add(item);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
            }



            return RedirectToAction("Index",model);
        }

        public ActionResult Basvurularim()
        {
            int id = kullaniciID();
            var basvurular = db.OgrenciBasvuru.Where(x => x.ogrenciID == id).ToList();
            return View(basvurular);
        }
       
        [HttpPost]
        public void Delete(int id)
        {
            var ilan = db.OgrenciBasvuru.FirstOrDefault(x => x.ogrenciBasvuruID == id);
            db.OgrenciBasvuru.Remove(ilan);
            db.SaveChanges();
        }
      
        [HttpPost]
        public ActionResult IlanGetir(int[] sepet,int id)
        {
            // SEÇİLEN İLANLAR SEPET DİZİSİNDE VE EKLENECEK OLAN İLANIN İD Sİ PARAMETRE OLARAK GELİYOR
            // EKLENECEK İLAN SEPETTE VAR İSE LİSTEYE EKLEMEYECEK
            // YOK İSE SEPETTEKİ İLANLARLA BİRLİKTE PARTİALVİEWE DÖNDÜRÜLÜYOR
            List<Ilan> ilanlar = new List<Ilan>();
            if(sepet != null)
            { 
            foreach (var item in sepet)
            {
                ilanlar.Add(db.Ilan.Find(item));
            }
                if(sepet.Contains(id)==false)
                {
                    ilanlar.Add(db.Ilan.Find(id));
                }
              
            }
            else
            {
                ilanlar.Add(db.Ilan.Find(id));
            }
            
            SepetViewModel model = new SepetViewModel();
            model.ilan = ilanlar;
            return PartialView("IlanSepet", model);
        }

    }
}