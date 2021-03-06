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
    
    public partial class Ilan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilan()
        {
            this.Mulakat = new HashSet<Mulakat>();
            this.OgrenciBasvuru = new HashSet<OgrenciBasvuru>();
        }
    
        public int ilanID { get; set; }
        public int personelID { get; set; }
        public int calismaTipID { get; set; }
        public string ilanMetni { get; set; }
        public System.DateTime ilanEklemeTarih { get; set; }
        public Nullable<System.DateTime> ilanGüncellemeTarih { get; set; }
        public short ilanCalisanSayisi { get; set; }
        public int ogrenimTipID { get; set; }
        public string ilanCalisanGun { get; set; }
    
        public virtual CalismaTip CalismaTip { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual OgrenimTip OgrenimTip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mulakat> Mulakat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OgrenciBasvuru> OgrenciBasvuru { get; set; }
    }
}
