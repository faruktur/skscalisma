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
    
    public partial class MulakatSoru
    {
        public int mulakatSoruID { get; set; }
        public string mulakatSoruIcerik { get; set; }
        public int mulakatID { get; set; }
        public byte mulakatSoruNo { get; set; }
        public System.DateTime mulakatSoruEklemeTarih { get; set; }
        public Nullable<System.DateTime> mulakatSoruGuncellemeTarih { get; set; }
    
        public virtual Mulakat Mulakat { get; set; }
    }
}
