using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SksCalisma.Models;
using System.Web.Script.Serialization;
using System.Linq;
using System.Data.Entity;
using Newtonsoft.Json;
using System;

namespace UserInterface.Controllers
{
    public class UserAuthorize : AuthorizeAttribute
    {
        public int Yetki { get; set; }
        public int PersonelYetki { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            kismizamanli2014Entities db = new kismizamanli2014Entities();
            HttpCookie authoCookies = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authoCookies != null)
            {
                if (this.Yetki == 0) return true;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authoCookies.Value);
                int id = Convert.ToInt32(ticket.UserData);
                var k = db.Kullanici.SingleOrDefault(x => x.kullaniciID == id);
                if (k.kullaniciTipID == this.Yetki)
                {
                    if (this.PersonelYetki != 0)
                    {
                        var personel = db.Personel.SingleOrDefault(x => x.kullaniciID == id);
                        if (personel == null)
                        {
                            return false;
                        }
                        else
                        {
                            var p = db.PersonelYetki.SingleOrDefault(x => x.personelID == personel.personelID && x.yetkiTipID == this.PersonelYetki);
                            if (p != null)
                                return true;
                            else
                                return false;
                        }
                    }
                    return true;
                }
            }
            httpContext.Response.Redirect("/Home/Login");
            return false;
        }
    }
}