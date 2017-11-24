using System.Web.Mvc;

namespace SksCalisma.Areas.Personel
{
    public class PersonelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Personel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Personel_default",
                "Personel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "SksCalisma.Areas.Personel.Controllers" }
            );
        }
    }
}