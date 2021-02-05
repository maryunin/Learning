using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using CodeBase.Models;
using CodeBase.ViewModels;
using CodeBase.Helpers;
using CodeBase;
using Autofac;

namespace task21.Controllers
{
    public class MemberController : SurfaceController
    {   
        public const string Name = "member";

        public ActionResult MemberRigistration()
        {
            return PartialView("MemberRigistration", new RegisterModel());
            // circle links, perhaps it should be changed ???
            // Register.cshtml > this action > MemberRigistration.cshtml
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SubmitRegistration(RegisterModel model, string returnUrl) 
        { 
            if (!ModelState.IsValid || Util.IsMemberExist(model.Email))
                return CurrentUmbracoPage();            

            var newMember = Current.Services.MemberService.CreateMember(model.Username, model.Email, model.Name, "Member");

            try
            {
                newMember.IsApproved = false;
                Current.Services.MemberService.Save(newMember);
                Current.Services.MemberService.SavePassword(newMember, model.Password);
                Current.Services.MemberService.AssignRole(newMember.Id, "All members");
                var ticket = new FormsAuthenticationTicket(model.Username, true, 1 * 1440);
                //ticket.UserData
                var t = FormsAuthentication.Encrypt(ticket);
                if (newMember.Id > 0)
                {                                       
                    Task21.Email.Send(model.Email, Url.Action("ConfirmEmail", "Member", 
                        new RouteValueDictionary(new {encriptedTicket = t}), Request.Url.Scheme, null));                    
                    return Content("Please check your email to confirm the entered address.");
                }
                else
                    return CurrentUmbracoPage();
            }
            catch (Exception ex)
            {
                return Content("It seems that something went wrong ...");
            }

            return CurrentUmbracoPage();
        }

        public ActionResult ConfirmEmail(string encriptedTicket) 
        {            
            var ticket = FormsAuthentication.Decrypt(encriptedTicket);
            var member = Current.Services.MemberService.GetByUsername(ticket.Name);

            member.IsApproved = true;
            Current.Services.MemberService.Save(member);            
            
            return Redirect("/en/profile/login/");
        }

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
                return Redirect(returnUrl);
            //return CurrentUmbracoPage();
            return Redirect("/en/home");
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
