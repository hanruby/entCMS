<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="entCMS.Manage.Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>对不起，您未登录或者登录超时，请重新登录！</title>
</head>
<body>
<script type="text/javascript">
    var i = 2;
    var timer = window.setInterval("settime()", 1000);
    //window.setTimeout("toload()", 3000);
    function settime() {
        var sec = document.getElementById("sec");
        sec.innerHTML = i;
        if (i == 0) {
            window.clearInterval(timer);
            toload();
        } else {
            i--;
        }
    }
    function toload() {
        top.location.href = '<%=entCMS.Common.WebUtil.GetClientUrl(this, "~/Manage/Login.aspx") %>';
    }
</script>
    <form id="form1" runat="server">
    <div style="text-align:center;border:solid 1px #6699BB;background-color:#D5E2ED;width:600px;margin: 50px auto;padding:50px 10px;">
        <h2><asp:Label ID="lblMsg" runat="server" Text="对不起，您未登录或者登录超时，请重新登录！"></asp:Label></h2>
        <div>页面将在&nbsp;<font color='red' id='sec'>3</font>&nbsp;秒后跳转到后台登录页，如未自动跳转请<a href='<%=entCMS.Common.WebUtil.GetClientUrl(this, "~/Manage/Login.aspx") %>' target="_top">点击这里</a>。</div>
    </div>
    </form>
</body>
</html>