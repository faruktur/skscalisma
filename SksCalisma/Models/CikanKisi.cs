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
    
    public partial class CikanKisi
    {
        public int cikanKisiID { get; set; }
        public int ogrenciID { get; set; }
        public int bolumID { get; set; }
        public int birimID { get; set; }
        public int calismaYeriID { get; set; }
        public int personelID { get; set; }
        public string cikanKisiAciklama { get; set; }
        public System.DateTime cikanKisiEklemeTarih { get; set; }
        public Nullable<System.DateTime> cikanKisiGuncellemeTarih { get; set; }
        public Nullable<System.DateTime> cikanKisiGorulmeTarih { get; set; }
    
        public virtual Birim Birim { get; set; }
        public virtual Bolum Bolum { get; set; }
        public virtual CalismaYeri CalismaYeri { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public virtual Kullanici Kullanici1 { get; set; }
    }
}
