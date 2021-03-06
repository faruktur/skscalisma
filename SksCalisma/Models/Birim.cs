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
    
    public partial class Birim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Birim()
        {
            this.Bolum = new HashSet<Bolum>();
            this.CalismaYeri = new HashSet<CalismaYeri>();
            this.CikanKisi = new HashSet<CikanKisi>();
            this.EklenenKisi = new HashSet<EklenenKisi>();
            this.Mulakat = new HashSet<Mulakat>();
            this.Personel = new HashSet<Personel>();
        }
    
        public int birimID { get; set; }
        public string birimAd { get; set; }
        public int birimTipID { get; set; }
        public int birimKontejyanID { get; set; }
        public Nullable<int> birimAkademikCalisan { get; set; }
        public Nullable<int> birimIdariCalisan { get; set; }
        public System.DateTime birimEklemeTarih { get; set; }
        public Nullable<System.DateTime> birimGuncellemTarih { get; set; }
    
        public virtual BirimKontejyan BirimKontejyan { get; set; }
        public virtual BirimTip BirimTip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bolum> Bolum { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CalismaYeri> CalismaYeri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CikanKisi> CikanKisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EklenenKisi> EklenenKisi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mulakat> Mulakat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personel> Personel { get; set; }
    }
}
