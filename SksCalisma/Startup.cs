using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Newtonsoft.Json;

[assembly: OwinStartup(typeof(SksCalisma.Startup))]

namespace SksCalisma
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //auth config, service registration, etc      
            var config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //other config settings, dependency injection/resolver settings, etc
            app.UseWebApi(config);
        }
    }
}
