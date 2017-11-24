using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SksCalisma.Models;
using System.Web.Security;

namespace SksCalisma.Areas.Admin.Controllers
{
    [UserInterface.Controllers.UserAuthorize(Yetki = 3)]
    public class BaseController : Controller
    {
        public kismizamanli2014Entities db = new kismizamanli2014Entities();

        public int kullaniciID()
        {
            HttpCookie authoCookies = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authoCookies.Value);
            return Convert.ToInt32(ticket.UserData);
        }
    }
}