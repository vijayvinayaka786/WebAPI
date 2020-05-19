using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using AuthenticationInWebAPI.Providers;
using AuthenticationInWebAPI.Models;

namespace AuthenticationInWebAPI
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                //AccessDeniedPath = new PathString("/Security/Access"),
                //AuthenticationScheme = "FiverSecurityCookie",
                //AutomaticAuthenticate = true,
                //AutomaticChallenge = true,

                CookieName = "Cookie.Data",
                CookiePath = "/",
                CookieHttpOnly = true,
                CookieSecure = CookieSecureOption.Always,
                ExpireTimeSpan = TimeSpan.FromMinutes(5),
                ///LoginPath = new PathString("/Token"),             
                //SlidingExpiration = true,
                //CookieSecure = CookieSecurePolicy.SameAsRequest,  
                //Events = new CookieAuthenticationEvents
                //{
                //    OnSignedIn = context =>
                //    {
                //        Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                //          "OnSignedIn", context.Principal.Identity.Name);
                //        return Task.CompletedTask;
                //    },
                //    OnSigningOut = context =>
                //    {
                //        Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                //          "OnSigningOut", context.HttpContext.User.Identity.Name);
                //        return Task.CompletedTask;
                //    },
                //    OnValidatePrincipal = context =>
                //    {
                //        Console.WriteLine("{0} - {1}: {2}", DateTime.Now,
                //          "OnValidatePrincipal", context.Principal.Identity.Name);
                //        return Task.CompletedTask;
                //    },
                //},  

            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}
