using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SksCalisma.Areas.Ogrenci.Controllers
{
    [UserInterface.Controllers.UserAuthorize(Yetki = 1)]
    public class BaseController : Controller
    {
        public int kullaniciID()
        {
            HttpCookie authoCookies = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authoCookies.Value);
            return Convert.ToInt32(ticket.UserData);
            
        }
    }
}