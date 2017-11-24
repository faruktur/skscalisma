using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SksCalisma.Models
{
    [MetadataType(typeof(BirimMetadata))]
    public partial class Birim
    {
    }
    [MetadataType(typeof(BirimKontejyanMetadata))]
    public partial class BirimKontejyan
    {
    }
    [MetadataType(typeof(BolumMetadata))]
    public partial class Bolum
    {
    }
    [MetadataType(typeof(BolumKontejyanMetadata))]
    public partial class BolumKontejyan
    {
    }
    [MetadataType(typeof(PersonelMetadata))]
    public partial class Personel
    {
    }
    [MetadataType(typeof(KullaniciMetadata))]
    public partial class Kullanici
    {
    }
    [MetadataType(typeof(YetkiTipMetadata))]
    public partial class YetkiTip
    {
    }
    [MetadataType(typeof(AnketSoruMetadata))]
    public partial class AnketSoru
    {
    }
    [MetadataType(typeof(OgrenciMetadata))]
    public partial class Ogrenci
    {
    }
    [MetadataType(typeof(AnketSecenekMetadata))]
    public partial class AnketSecenek
    {
    }
    [MetadataType(typeof(OkulMetadata))]
    public partial class Okul
    {
    }
    [MetadataType(typeof(IlanMetadata))]
    public partial class Ilan
    {
    }
    [MetadataType(typeof(AileSgkMetadata))]
    public partial class AileSgk
    {
    }
}