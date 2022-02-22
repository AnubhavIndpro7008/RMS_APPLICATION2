using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private Uri RediredtUri

        {

            get

            {

                var uriBuilder = new UriBuilder(Request.Url);

                uriBuilder.Query = null;

                uriBuilder.Fragment = null;

                uriBuilder.Path = Url.Action("FacebookCallback");

                return uriBuilder.Uri;

            }

        }


        [AllowAnonymous]

        public ActionResult Facebook()

        {

            var fb = new FacebookClient();

            var loginUrl = fb.GetLoginUrl(new

            {


                client_id = "2598434023633067",

                client_secret = "cd880d7f7ba8739aec828c238784931c",

                redirect_uri = RediredtUri.AbsoluteUri,

                response_type = "code",

                scope = "email"



            });
            return Redirect(loginUrl.AbsoluteUri);


        }




        public ActionResult FacebookCallback(string code)

        {

            var fb = new FacebookClient();

            dynamic result = fb.Post("oauth/access_token", new

            {

                client_id = "522922975826201",

                client_secret = "4de6473e789d5b71396c912c9d3d2a9c",

                redirect_uri = RediredtUri.AbsoluteUri,

                code = code

            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;

            fb.AccessToken = accessToken;

            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");

            string email = me.email;

            TempData["email"] = me.Email;

            TempData["first_name"] = me.F_name;

            TempData["lastname"] = me.L_name;

            FormsAuthentication.SetAuthCookie(email, false);

            return RedirectToAction("Index", "Home");

        }
    }
}