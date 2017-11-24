using System.Web.Mvc;

namespace SksCalisma.Areas.Bolum
{
    public class BolumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Bolum";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Bolum_default",
                "Bolum/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "SksCalisma.Areas.Bolum.Controllers" }
            );
        }
    }
}