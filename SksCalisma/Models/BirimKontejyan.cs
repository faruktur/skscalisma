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
    
    public partial class BirimKontejyan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BirimKontejyan()
        {
            this.AsilListe = new HashSet<AsilListe>();
            this.Birim = new HashSet<Birim>();
        }
    
        public int birimKontejyanID { get; set; }
        public short birimKontejyanAkademi { get; set; }
        public short birimKontejyanIdari { get; set; }
        public short birimKontejyanEkAkademi { get; set; }
        public short birimKontejyanEkIdari { get; set; }
        public string birimKontejyanEkAkademiNot { get; set; }
        public string birimKontejyanEkIdariNot { get; set; }
        public System.DateTime birimKontejyanEklemeTarih { get; set; }
        public Nullable<System.DateTime> birimKontejyanGuncellemeTarih { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AsilListe> AsilListe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Birim> Birim { get; set; }
    }
}
