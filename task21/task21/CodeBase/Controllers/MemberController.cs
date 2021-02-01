using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using Umbraco.Web.Mvc;
using CodeBase.Models;
using CodeBase.ViewModels.Models;
using System.Web.Routing;

namespace task21.Controllers
{
    public class MemberController : SurfaceController
    {

        public const string Name = "member";


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SubmitLogin(LoginModel model, string returnUrl = null)
        {
            if (!Membership.ValidateUser(model.Username, model.Password))
                ModelState.AddModelError("", Umbraco.GetDictionaryValue("Frontend.Account.Login.MemberPasswordError"));
            if (!ModelState.IsValid) return CurrentUmbracoPage();

            //Microsoft.Identity
            FormsAuthentication.SetAuthCookie(model.Username, false);
            //UrlHelper myHelper = new UrlHelper(HttpContext.Request.RequestContext);
            if (!string.IsNullOrWhiteSpace(returnUrl))
                //return Redirect(returnUrl);
                return Redirect("/en/home");
            return CurrentUmbracoPage();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SubmitLogout()
        {
            TempData.Clear();
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToCurrentUmbracoPage();
        }
    }


}
