using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using entCMS.Common;
using entCMS.Services;
using entCMS.Models;
using System.Data;

namespace entCMS.Manage
{
    public partial class Login : System.Web.UI.Page
    {
        protected string title = "登录";
        protected void Page_Load(object sender, EventArgs e)
        {
            title = "登录_" + ConfigHelper.GetVal("SysTitle");

            var hash = new Hashtable();
            hash["success"] = 0;
            hash["msg"] = "未知错误";
            if (Request.HttpMethod == "POST")
            {
                string json = "";

                string username = Request["username"];
                string userpwd = Request["userpwd"];
                string vcode = Request["vcode"];
                object code = Session["ValidateCode"];
                string ip = Request.UserHostAddress;

                //将验证码去掉，避免了暴力破解
                Session["ValidateCode"] = Guid.NewGuid();
                if (vcode == null || code == null || vcode != code.ToString())
                {
                    hash["msg"] = "验证码错误，请重新输入";
                }
                else
                {
                    cmsUser user = null;
                    LoginState state = UserService.GetInstance().CheckLogin(username, userpwd, ip, out user);
                    switch (state)
                    {
                        case LoginState.LOGIN_UNKNOWN_ERROR:
                            hash["msg"] = "发生未知错误，请联系管理员";
                            break;
                        case LoginState.LOGIN_FAIL_USER_ERROR:
                            hash["msg"] = "用户不存在，请重新输入";
                            break;
                        case LoginState.LOGIN_FAIL_PASSWORD_ERROR:
                            hash["msg"] = "密码错误，请重新输入";
                            break;
                        case LoginState.LOGIN_FAIL_USER_FORBIDDED:
                            hash["msg"] = "您的账号已被禁用，请联系管理员";
                            break;
                        case LoginState.LOGIN_SUCCESS:
                            hash["msg"] = "登录成功，正在跳转...";
                            hash["success"] = 1;
                            hash["obj"] = new { name = username, ip = Request.UserHostAddress };

                            List<cmsUserPurview> purviews = UserPurviewService.GetInstance().GetUserAllPurview(user.Id);
                            Session["Purviews"] = purviews;
                            break;
                    }

                    FormsAuthenticationService.SignIn(username, false);
                }
                json = entCMS.Common.WebUtil.WriteJson(hash);
            }
        }
    }
}