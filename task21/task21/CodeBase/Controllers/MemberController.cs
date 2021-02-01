﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using System.Web.Mvc;
using System.Web.Routing;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using CodeBase.Models;
using CodeBase.ViewModels.Models;
using CodeBase.ViewModels;
using CodeBase.Helpers;

namespace task21.Controllers
{
    public class MemberController : SurfaceController
    {

        public const string Name = "member";

        public ActionResult MemberRigistration()
        {
            return PartialView("MemberRigistration", new RegisterModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SubmitRegistration(RegisterModel model, string returnUrl) 
        {
            if (ModelState.IsValid) 
            {
                if (!Util.IsMemberExist(model.Email)) 
                {
                    IMember newMember = Current.Services.MemberService.CreateMember(model.Email, model.Email, model.Name, "Member");

                    try 
                    {
                        Current.Services.MemberService.Save(newMember);
                        Current.Services.MemberService.SavePassword(newMember, model.Password);
                        Current.Services.MemberService.AssignRole(newMember.Id, "All members");

                        if (newMember.Id > 0)
                            return Redirect("/en/profile/login/");
                        else
                            return CurrentUmbracoPage();

                    } 
                    catch (Exception ex) 
                    {
                        ; //add logging ?
                    }
                }
            }
            return CurrentUmbracoPage();
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