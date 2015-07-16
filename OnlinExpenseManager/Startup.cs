using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

//add web references
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;


[assembly: OwinStartup(typeof(OnlinExpenseManager.Startup))]

namespace OnlinExpenseManager
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/login.aspx")
            });
        }
    }
}
