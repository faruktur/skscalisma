﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SksCalisma.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class kismizamanli2014Entities : DbContext
    {
        public kismizamanli2014Entities()
            : base("name=kismizamanli2014Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AileSgk> AileSgk { get; set; }
        public virtual DbSet<AnketCevap> AnketCevap { get; set; }
        public virtual DbSet<AnketSecenek> AnketSecenek { get; set; }
        public virtual DbSet<AnketSoru> AnketSoru { get; set; }
        public virtual DbSet<AsilListe> AsilListe { get; set; }
        public virtual DbSet<Birim> Birim { get; set; }
        public virtual DbSet<BirimFiyat> BirimFiyat { get; set; }
        public virtual DbSet<BirimKontejyan> BirimKontejyan { get; set; }
        public virtual DbSet<BirimTip> BirimTip { get; set; }
        public virtual DbSet<BirimTur> BirimTur { get; set; }
        public virtual DbSet<Bolum> Bolum { get; set; }
        public virtual DbSet<BolumKontejyan> BolumKontejyan { get; set; }
        public virtual DbSet<CalisanYoklama> CalisanYoklama { get; set; }
        public virtual DbSet<CalismaTip> CalismaTip { get; set; }
        public virtual DbSet<CalismaYeri> CalismaYeri { get; set; }
        public virtual DbSet<CikanKisi> CikanKisi { get; set; }
        public virtual DbSet<EklenenKisi> EklenenKisi { get; set; }
        public virtual DbSet<EngelDurum> EngelDurum { get; set; }
        public virtual DbSet<Ilan> Ilan { get; set; }
        public virtual DbSet<IsTakip> IsTakip { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<KullaniciTip> KullaniciTip { get; set; }
        public virtual DbSet<Muhasebe> Muhasebe { get; set; }
        public virtual DbSet<Mulakat> Mulakat { get; set; }
        public virtual DbSet<MulakatSoru> MulakatSoru { get; set; }
        public virtual DbSet<Ogrenci> Ogrenci { get; set; }
        public virtual DbSet<OgrenciBasvuru> OgrenciBasvuru { get; set; }
        public virtual DbSet<OgrenciCalisma> OgrenciCalisma { get; set; }
        public virtual DbSet<OgrenimTip> OgrenimTip { get; set; }
        public virtual DbSet<OgrenimTur> OgrenimTur { get; set; }
        public virtual DbSet<Okul> Okul { get; set; }
        public virtual DbSet<OkulBolum> OkulBolum { get; set; }
        public virtual DbSet<OkulTip> OkulTip { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<PersonelYetki> PersonelYetki { get; set; }
        public virtual DbSet<PuantajAyBelirle> PuantajAyBelirle { get; set; }
        public virtual DbSet<PuantajGirmeSure> PuantajGirmeSure { get; set; }
        public virtual DbSet<PuantajYetki> PuantajYetki { get; set; }
        public virtual DbSet<ResmiTatilGun> ResmiTatilGun { get; set; }
        public virtual DbSet<Sinif> Sinif { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<YasalKesinti> YasalKesinti { get; set; }
        public virtual DbSet<YetkiTip> YetkiTip { get; set; }
    }
}
