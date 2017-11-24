using System.Web.Mvc;

namespace SksCalisma.Areas.Birim
{
    public class BirimAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Birim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Birim_default",
                "Birim/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "SksCalisma.Areas.Birim.Controllers" }
            );
        }
    }
}