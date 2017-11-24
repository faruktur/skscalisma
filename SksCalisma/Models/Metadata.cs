using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace SksCalisma.Models
{
    public class BirimMetadata
    {
        [Display(Name = "Birim Adı"), Required]
        public string birimAd { get; set; }
        [Display(Name = "Akademik Çalışan Sayısı")]
        public int birimAkademikCalisan { get; set; }
        [Display(Name = "İdari Çalışan Sayısı")]
        public int birimIdariCalisan { get; set; }
        [Display(Name ="Birim Tipi"),Required]
        public int birimTipID { get; set; }
    }

    public class BolumMetadata
    {
        [Display(Name = "Bölüm Adı"), Required]
        public string bolumAd { get; set; }
        [Display(Name = "Akademik Çalışan Sayısı")]
        public int bolumAkademikCalisan { get; set; }
        [Display(Name = "İdari Çalışan Sayısı")]
        public int bolumIdariCalisan { get; set; }
    }

    public class BirimKontejyanMetadata
    {
        [Display(Name = "Akademik Kontenjan"), Required]
        public int birimKontejyanAkademi { get; set; }
        [Display(Name = "İdari Kontenjan"), Required]
        public int birimKontejyanIdari { get; set; }
        [Display(Name = "Ek Akademik Kontenjan"), Required]
        public int birimKontejyanEkAkademi { get; set; }
        [Display(Name = "Ek İdari Kontenjan"), Required]
        public int birimKontejyanEkIdari { get; set; }
        [Display(Name = "Ek Akademik Kontenjan Not")]
        public int birimKontejyanEkAkademiNot { get; set; }
        [Display(Name = "Ek İdari Kontenjan Not")]
        public int birimKontejyanEkIdariNot { get; set; }
    }

    public class BolumKontejyanMetadata
    {
        [Display(Name = "Akademik Kontenjan"), Required]
        public int bolumKontejyanAkademi { get; set; }
        [Display(Name = "İdari Kontenjan"), Required]
        public int bolumKontejyanIdari { get; set; }
        [Display(Name = "Ek Akademik Kontenjan"), Required]
        public int bolumKontejyanEkAkademi { get; set; }
        [Display(Name = "Ek İdari Kontenjan"), Required]
        public int bolumKontejyanEkIdari { get; set; }
        [Display(Name = "Ek Akademik Kontenjan Not")]
        public int bolumKontejyanAkademiNot { get; set; }
        [Display(Name = "Ek İdari Kontenjan Not")]
        public int bolumKontejyanIdarıNot { get; set; }
    }

    public class PersonelMetadata
    {
        [Display(Name = "TC Kimlik No"), Required]
        public string personelTC { get; set; }
        [Display(Name = "Ad"), Required]
        public string personelAd { get; set; }
        [Display(Name = "Soyad"), Required]
        public string personelSoyad { get; set; }
        [Display(Name = "Dahili No"), Required]
        public string personelDahiliNo { get; set; }
        [Display(Name = "Unvan")]
        public string personelUnvan { get; set; }
        [Display(Name = "Birim")]
        public int birimID { get; set; }
        [Display(Name = "Bölüm")]
        public int bolumID { get; set; }
    }

    public class KullaniciMetadata
    {
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Lütfen geçerli bir e-mail adresi giriniz.")]
        [Remote("IsUserMailExist", "Validation", ErrorMessage = "Bu mail zaten kayıtlı.")]
        public string kullaniciMail { get; set; }
        [Display(Name = "Şifre"), Required]
        public string kullaniciSifre { get; set; }
    }

    public class YetkiTipMetadata
    {
        [Display(Name = "Yetki")]
        public string yetkiTipAd { get; set; }
    }
    public class AnketSoruMetadata
    {
        [Display(Name = "Soru")]
        public string anketSoruIcerik { get; set; }
    }
    public class OgrenciMetadata
    {
      
        [Display(Name ="TC",Prompt ="TC"),Required(ErrorMessage ="Bu alanın girilmesi zorunludur."), Remote("IsUserTcExist", "Validation", ErrorMessage = "TC zaten kayıtlı.")]
        public string ogrenciTC { get; set; }
        [Display(Name = "Öğrenci No", Prompt = "Öğrenci No"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public string ogrenciNumara { get; set; }
        [Display(Name = "Ad", Prompt = "Ad"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public string ogrenciAd { get; set; }
        [Display(Name = "Soyad", Prompt = "Soyad"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public string ogrenciSoyad { get; set; }
        [Display(Name = "Doğum Tarihi", Prompt = "Doğum Tarihi"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public System.DateTime ogrenciDogumTarih { get; set; }
        [Display(Name = "E-Mail", Prompt = "E-mail"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur."), Remote("IsOgrenciMailExist", "Validation", ErrorMessage = "Bu mail zaten kayıtlı.Başka bir mail deneyin yada şifremi unuttum kısmından şifrenizi mail adresinize gönderin.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Lütfen geçerli bir e-mail adresi giriniz.")]
        public string ogrenciMail { get; set; }
        [Display(Name = "Telefon No", Prompt = "Telefon No"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public string ogrenciTelNo { get; set; }
        [Display(Name = "IBAN", Prompt = "IBAN"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public string ogrenciIBAN { get; set; }
        [Display(Name = "Not Ortalaması", Prompt = "Not Ortalaması"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        
        public decimal ogrenciNotOrt { get; set; }
        [Display(Name = "Okul", Prompt = "Okul"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public int okulID { get; set; }
        [Display(Name = "Bölüm", Prompt = "Bölüm"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public int okulBolumID { get; set; }
        [Display(Name = "Sınıf", Prompt = "Sınıf"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public int sinifID { get; set; }
        [Display(Name = "Öğrenim Türü", Prompt = "Öğrenim Türü"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public int ogrenimTurID { get; set; }
        [Display(Name = "Öğrenim Tipi", Prompt = "Öğrenim Tipi"), Required(ErrorMessage = "Bu alanın girilmesi zorunludur.")]
        public int ogrenimTipID { get; set; }
        [Display(Name = "Çalışma Tipi", Prompt = "Çalışma Tipi")]
        public int calismaTipID { get; set; }
    }
    public class AnketSecenekMetadata
    {
        [Display(Name = "Seçenek")]
        public string anketSecenekIcerik { get; set; }
        [Display(Name = "Puan")]
        public string anketSecenekPuan { get; set; }
    }
    public class OkulMetadata
    {
        [Display(Name = "Okul Tipi")]
        public int okulTipID { get; set; }
    }
    public class IlanMetadata
    {
        [Display(Name = "Çalışma Tipi")]
        public int calismaTipID { get; set; }
        [Display(Name = "Çalışacak Kişi Sayısı")]
        public int ilanCalisanSayisi { get; set; }
        [Display(Name = "Öğrenim Tipi")]
        public int ogrenimTipID { get; set; }
        [Display(Name = "İşin Özel Niteliği")]
        public string ilanMetni { get; set; }
    }

    public class AileSgkMetadata
    {
        [Display(Name = "Aile SGK Durumu")]
        public string aileSgkAd { get; set; }
        [Display(Name = "Aile SGK Kodu")]
        public string aileSgkKod { get; set; }
    }
}