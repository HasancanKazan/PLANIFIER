using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Planifier.WebAPI.Authentication.Providers;

[assembly: OwinStartup(typeof(Planifier.WebAPI.Authentication.Startup))]

namespace Planifier.WebAPI.Authentication
{
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                HttpConfiguration httpConfiguration = new HttpConfiguration();

                ConfigureOAuth(app);

                WebApiConfig.Register(httpConfiguration);
                app.UseWebApi(httpConfiguration);
            }

            private void ConfigureOAuth(IAppBuilder appBuilder)
            {
                OAuthAuthorizationServerOptions oAuthAuthorizationServerOptions = new OAuthAuthorizationServerOptions()
                {
                    TokenEndpointPath = new Microsoft.Owin.PathString("/token"),
                    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                    AllowInsecureHttp = true,
                    Provider = new SimpleAuthorizationServerProvider()
                };

                appBuilder.UseOAuthAuthorizationServer(oAuthAuthorizationServerOptions);
                appBuilder.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            }
        }
    }
