<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="entCMS.Manage.Login" %>
<%@ Import Namespace="entCMS.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=title %></title>
    <script type="text/javascript" src="scripts/jquery-1.9.0.min.js"></script>
    <!--[if lte IE 6]>
    <script type="text/javascript" src="scripts/ie6png.js"></script>
    <script type="text/javascript" src="scripts/minmax.js"></script>
    <![endif]-->
    <style type="text/css">
    /********** CSS Document **********/
    html,body{height:100%}
    body{background: url(images/login/body.gif);font-size:12px}
    body, div, dl, dt, dd, ul, ol, li, h1, h2, h3, h4, h5, h6, pre, form, fieldset, input, textarea, p, blockquote, th, td {margin: 0;padding: 0;}
    ol, ul {list-style: none outside none;}
    /********** Index **********/
    .index_clear{margin-top:-204px;width:100%;height:50%;float:left}
    #web_main{margin:auto;clear:both;width:626px;height:303px;padding:105px 0px 0px 0px;background:url(images/login/login.png) no-repeat}
    .login_right{float:right;width:345px;padding:23px 0px 0px 0px}
    .login_right ul li{padding:10px 0px 0px 120px;height:27px}
    .login_right ul li span img{position:absolute}
    .login_right input{height:17px;border:0px none;font-size:14px;font-weight:bold;text-align:left; padding-left:4px; color:#555}
    #username,#userpwd{width:100px}
    #vcode{width:74px}
    .test_bottom{text-align:center;padding-left:60px}
    .test_bottom a{float:left;display:block;width:63px;height:28px;text-decoration:none;outline:0px none;line-height:28px;background-image:url(images/login/login_button.gif);color:#000;margin:10px 15px 10px 15px;cursor:pointer}
    .test_bottom a:hover{position:relative;left:1px;top:1px;background-position:0px -28px}
    .test_bottom a:active{position:relative;left:1px;top:1px;background-position:0px -56px}
    </style>
    <script type="text/javascript" language="javascript">
        //后台登录直接回车提交
        function loginOnKey(e) {
            if (window.event) // IE
            {
                keynum = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                keynum = e.which;
            }
            if (keynum == 13) {
                logOn();
            }
        }
        function request(paras) {
            var url = location.href;
            var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
            var paraObj = {}
            for (i = 0; j = paraString[i]; i++) {
                paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
            }
            var returnValue = paraObj[paras.toLowerCase()];
            if (typeof (returnValue) == "undefined") {
                return "";
            } else {
                return returnValue;
            }
        }

        function logOn() {
            var div = $("#logMsg");
            var loading = $("#loading");
            var username = $("#username").val();
            var userpwd = $("#userpwd").val();
            var vcode = $("#vcode").val();

            if (username == "") {
                div.html("请填写用户名");
                $("#username").focus();
                return false
            }
            if (userpwd == "") {
                div.html("请填写密码");
                $("#userpwd").focus();
                return false
            }
            if (vcode == "") {
                div.html("请填写验证码");
                $("#vcode").focus();
                return false
            }
            if (vcode.length < 4) {
                div.html("验证码必须为4位");
                $("#vcode").focus();
                return false;
            }
            var re = /^[0-9]+[0-9]*$/;
            if (!re.test(vcode)) {
                div.html("验证码必须是纯数字");
                $("#vcode").focus();
                return false;
            }

            div.html("");

            var s = "<img alt='载入中，请稍候...' height='28' width='28' align='absmiddle' src='<%=WebUtil.GetClientUrl(this, "~/Manage/Images/loading.gif") %>' />";
            loading.html(s + "载入中，请稍候...");
            
            $('#btnLogin').attr("disabled","disabled");

            var params = { username: username, userpwd: userpwd, vcode: vcode };
            $.ajax({
                type: "POST",
                url: '<%=WebUtil.GetClientUrl(this, "~/Manage/Login.aspx") %>',
                data: $.param(params),
                success: function (result) {
                    result =  jQuery.parseJSON(result);//JSON.parse(result);//将接受的html类型返回值转成JSON
                    loading.html("");
                    if (result) {
                        div.html(result.msg);
                        if (result.success) {
                            var href = unescape(request("ReturnUrl"));
                            if (href == "/" || href == "") {
                                href = "<%=FormsAuthentication.DefaultUrl%>";
                            }
                            
                            location.href = href;
                        }
                        else {
                            $('#btnLogin').removeAttr("disabled");
                            $('#imgVcode').attr('src', '<%=WebUtil.GetClientUrl(this, "~/Manage/ValidateCode.aspx") %>'+'?t='+(new Date()).getUTCMilliseconds());
                            $('#userpwd').val('');
                            $('#vcode').val('');
                        }
                    }
                    else {
                        div.html("未载入相关数据，请重试");
                        $('#btnLogin').removeAttr("disabled");
                    }
                }
            });
        }
    </script>
</head>
<body>
    <div class="index_clear"></div>
    <div id="web_main">
	    <div class="main">
		    <div class="login_right">
			    <form name="loginForm" id="loginForm" method="post" action="" onkeydown="return loginOnKey(event)">
				    <ul>
					    <li><input name="username" type="text" id="username" autocomplete="off" /></li>
					    <li><input name="userpwd" type="password" id="userpwd" /></li>
					    <li><input name="vcode" type="text" id="vcode" maxlength="4" autocomplete="off" /><span><img id='imgVcode' src="" style='cursor: pointer;' alt="点击刷新" onclick="this.src=this.src+'?';" align="absmiddle" /></span></li>
				    </ul>
				    <div class="test_bottom">
					    <a id="btnLogin" href="#" onclick="javascript:logOn();" class="login_submit">登 录</a>
					    <a href="Login.aspx" class="login_refresh">刷 新</a>
                        <div style="clear:both"></div>
				    </div>
                    <div id="logMsg" style="padding-left:74px;color:Red;"></div>
			    </form>
		    </div>
	    </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#imgVcode').attr('src', '<%=WebUtil.GetClientUrl(this, "~/Manage/ValidateCode.aspx") %>');

            $('#username').focus();
        });
    </script>
</body>
</html>
