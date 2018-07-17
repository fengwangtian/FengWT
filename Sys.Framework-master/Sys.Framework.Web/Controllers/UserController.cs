using Sys.Framework.Data.EntityFramework;
using Sys.Framework.Model.Sys;
using Sys.Framework.Service.Enum;
using Sys.Framework.Service.Sys;
using Sys.Framework.Web.Common;
using Sys.Framework.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sys.Framework.Web.Controllers
{
    public class UserController : Controller
    {
        #region 构造函数
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion
        #region 登陆页面
        /// <summary>
        /// 登陆页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        #endregion
        #region 登陆
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
           
            var loginResult = _userService.LoginValidateInfo(user.UserName, user.Password);
            switch (loginResult)
            {
                case LoginValidate.OK:

                    var UserInfo = _userService.GetModel(i => i.User_LoginName == user.UserName);
                    using (var UserRole = new Context())
                    {
                        var User_RoleID = UserRole.Set<UserRoles>().Where(i => i.User_Id == UserInfo.User_Id).FirstOrDefault();

                        UserInfo _userinfo = new UserInfo()
                        {
                            User_Id = UserInfo.User_Id,
                            User_CreateDate = UserInfo.User_CreateDate,
                            User_LoginName = UserInfo.User_LoginName,
                            User_LoginPassword = UserInfo.User_LoginPassword,
                            User_Name = UserInfo.User_Name,
                            User_State = UserInfo.User_State,
                            User_Role = User_RoleID.Role_Id
                        };
                        HttpContext.Session.Add("userInfo", _userinfo);
                        //var cookie = new HttpCookie("userInfo");
                        //cookie.Expires = DateTime.Now.AddMinutes(20);
                        //cookie.Values.Add("User_Id", UserInfo.User_Id);
                        //cookie.Values.Add("User_CreateDate", UserInfo.User_CreateDate.ToShortDateString());
                        //cookie.Values.Add("User_LoginName", UserInfo.User_LoginName);
                        //cookie.Values.Add("User_LoginPassword", UserInfo.User_LoginPassword);
                        //cookie.Values.Add("User_Name", UserInfo.User_Name);
                        //cookie.Values.Add("User_Role", UserInfo.User_State.ToString());
                        //cookie.Values.Add("User_State", User_RoleID.Role_Id);
                        //System.Web.HttpContext.Current.Response.AppendCookie(cookie);
                        if (user.ReturnUrl != null)
                        {
                            return Redirect(user.ReturnUrl);
                        }
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                case LoginValidate.NameNotExist:
                    this.Msg("账户名不存在");
                    return View(user);
                case LoginValidate.PasswordError:
                    this.Msg("密码错误");
                    return View(user);
                default:
                    this.Msg("服务器繁忙，请稍后再试");
                    return View(user);
            }
        }
        #endregion
        #region 获取登陆信息
        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetLogin()
        {
            var data = new LoginData();
            object userInfo = Session["userInfo"];
            //var userInfo = System.Web.HttpContext.Current.Request.Cookies["userInfo"];
            if (userInfo != null)
            {
                data.Data = userInfo;
                data.IsOk = true;
            }
            data.Msg = data.IsOk ? "已登录" : "未登录";
            return Json(data);
        }
        #endregion
        #region 登出
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult LoginOut()
        {
            Session.Remove("userInfo");
            return RedirectToAction(nameof(UserController.Login));
        }
        #endregion
    }
}