//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            this.AnketCevap = new HashSet<AnketCevap>();
            this.AsilListe = new HashSet<AsilListe>();
            this.AsilListe1 = new HashSet<AsilListe>();
            this.CalismaYeri = new HashSet<CalismaYeri>();
            this.CikanKisi = new HashSet<CikanKisi>();
            this.CikanKisi1 = new HashSet<CikanKisi>();
            this.EklenenKisi = new HashSet<EklenenKisi>();
            this.Ilan = new HashSet<Ilan>();
            this.IsTakip = new HashSet<IsTakip>();
            this.IsTakip1 = new HashSet<IsTakip>();
            this.Ogrenci = new HashSet<Ogrenci>();
            this.Ogrenci1 = new HashSet<Ogrenci>();
            this.OgrenciBasvuru = new HashSet<OgrenciBasvuru>();
            this.OgrenciCalisma = new HashSet<OgrenciCalisma>();
            this.Personel = new HashSet<Personel>();
            this.PuantajYetki = new HashSet<PuantajYetki>();
            this.YasalKesinti = new HashSet<YasalKesinti>();
        }
    
        public int kullaniciID { get; set; }
        public string kullaniciMail { get; set; }
        public string kullaniciSifre { get; set; }
        public int kullaniciTipID { get; set; }
        public System.DateTime kullaniciEklemeTarihi { get; set; }
        public Nullable<System.DateTime> kullaniciGuncellemeTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnketCevap> AnketCevap { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsilListe> AsilListe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsilListe> AsilListe1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalismaYeri> CalismaYeri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CikanKisi> CikanKisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CikanKisi> CikanKisi1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EklenenKisi> EklenenKisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilan> Ilan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakip> IsTakip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakip> IsTakip1 { get; set; }
        public virtual KullaniciTip KullaniciTip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogrenci> Ogrenci { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ogrenci> Ogrenci1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OgrenciBasvuru> OgrenciBasvuru { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OgrenciCalisma> OgrenciCalisma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personel> Personel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PuantajYetki> PuantajYetki { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YasalKesinti> YasalKesinti { get; set; }
    }
}
