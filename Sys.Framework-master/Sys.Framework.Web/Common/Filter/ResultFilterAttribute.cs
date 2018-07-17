using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Sys.Framework.Model.Sys;
using Sys.Framework.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Common.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ResultFilterAttribute : System.Web.Mvc.ActionFilterAttribute, IResultFilter
    {
        public string Message { get; set; }
        public bool MustLogin { set; get; }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Result.GetType() == typeof(JsonResult))
            {
                HttpResponseBase response = filterContext.HttpContext.Response;
                JsonResult result = filterContext.Result as JsonResult;
                response.Clear();
                string jsonData = JsonConvert.SerializeObject(result.Data, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                response.Write(jsonData);
            }
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (MustLogin)
            {
                dynamic LoginConfig = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(ConfigurationManager.AppSettings["LoginConfig"]);
                string cookieName = LoginConfig.CookieName;
                string deskey = LoginConfig.DesKey;
                string Domain= LoginConfig.Domain;
                int site = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Site_Id"]);
                var userInfo = SessionHelper.Get("userInfo") as UserInfo;
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                var req = BaseController.CheckAuthority(userInfo.User_Id.ToString(), site, controller, action);


                if (!req)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.Result = new JsonResult()
                        {
                            Data = new { state = -100, message = "无权执行该操作" }
                        };
                    }
                    else
                    {
                        filterContext.Result = new ContentResult()
                        {
                            Content = "{ 'state' = '-100', 'message' = '无权执行该操作' }"
                        };
                    }
                }
            }
            //  filterContext.HttpContext.Response.Write("Action执行之前" + Message + "<br />");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            // filterContext.HttpContext.Response.Write("Action执行之后" + Message + "<br />");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            // filterContext.HttpContext.Response.Write("返回Result之前" + Message + "<br />");
        }

       
    }
}