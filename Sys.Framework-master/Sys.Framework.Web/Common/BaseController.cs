using Sys.Framework.Data.EntityFramework;
using Sys.Framework.Model.Sys;
using Sys.Framework.Model.View;
using Sys.Framework.Web.Common.Filter;
using Sys.Framework.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sys.Framework.Web.Common
{
    [ResultFilterAttribute]
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            Session["SessionId"] = Session.SessionID;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            string controller = filterContext.RouteData.Values["controller"].ToString().ToLower();
            string action = filterContext.RouteData.Values["action"].ToString().ToLower();

            var userInfo = Session["userInfo"] as UserInfo;
            //var a = System.Web.HttpContext.Current.Request.Cookies["userInfo"];
            if (controller != "User" && userInfo == null)
            {
                filterContext.Result = new RedirectResult("/User/Login?ReturnUrl=" + filterContext.HttpContext.Request.Path);
            }
            else
            {
                ViewData["MyUserInfo"] = userInfo;
                if (userInfo.User_Role != "1")
                {
                    var superAdminControllers = "role_columns";
                    if (superAdminControllers.Contains(controller))
                    {
                        filterContext.Result = new ContentResult() { Content = "无权访问该页" };
                    }
                }
            }

            #region session
            //if (controller != "User" && userInfo == null)
            //{
            //    filterContext.Result = new RedirectResult("/User/Login?ReturnUrl=" + filterContext.HttpContext.Request.Path);
            //}
            //else
            //{
            //    ViewData["MyUserInfo"] = userInfo;
            //    if (userInfo.User_Role != "1")
            //    {
            //        var superAdminControllers = "role_columns";
            //        if (superAdminControllers.Contains(controller))
            //        {
            //            filterContext.Result = new ContentResult() { Content = "无权访问该页" };
            //        }
            //    }
            //}
            #endregion

            base.OnActionExecuting(filterContext);
        }
        public static bool CheckAuthority(string User_Id, int Site_Id, string ControllerName, string ActionName)
        {
            ControllerName = ControllerName.ToLower();
            ActionName = ActionName.ToLower();
            using (Context _context = new Context())
            {
                var dbController = _context.View_Authority.Where(w => w.User_Id == User_Id && w.Site_Id == Site_Id && w.Controller_Name.ToLower() == ControllerName && w.Action_Name.ToLower() == ActionName).ToList();

                if (dbController.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}