<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="entCMS.Manage.Frame.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/frame.CSS" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.0.min.js" type="text/javascript"></script>
    <script src="../Scripts/calendar.js" type="text/javascript"></script>
    <script type="text/javascript">
        function gohome() {
            //alert($('#MainFrame', top.document)[0].contentWindow);
            //$('#MainFrame', top.document)[0].contentWindow.location.href = 'Main.aspx';
            top.location.href = top.location.href;
        }
        function editpwd() {
            //top.tipswindow('修改密码', 'iframe:EditPwd.aspx', '400', '200', 'true', '', 'true', '', 1);
            top.Dialog.open({ Title: '修改密码', URL: 'EditPwd.aspx', Width: 500, Height: 240 });
            return false;
        }
    </script>
</head>
<body style="overflow: hidden;" scroll="no">
<form id="form1" runat="server">
    <div class="head">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" height="44">
            <tr>
                <td>
                    <font class='logo'><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></font>
                </td>
                <td class="font_text" width='30%'>
                    
                </td>
                <td class="font_text" align="right" width='30%'>
                    <a href='<%=GetClientUrl("~/") %>' target="_blank" class="white">网站首页</a> |
                    <a href='<%=GetClientUrl("Main.aspx") %>' target="MainFrame" class="white">后台首页</a> |
                    <a href="javascript:void(0);" class="white" onclick="return editpwd();">修改密码</a> |
                    <a href="<%=GetClientUrl("~/Manage/Logout.aspx?act=1") %>" target="_top" onclick="return confirm('确定要退出本系统吗？');" class="white">安全退出</a>
                    <%--<br />
                    <span style="font-weight:bold;"><%=TrueName %></span> 您好，欢迎进入网站后台系统--%>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" height="36">
            <tr>
                <td>
                    <table align="left">
                        <tr>
                            <td>语言：</td>
                            <td>
                                <div class="select" style="float:left;"><div>
                                <asp:DropDownList ID="ddlLanguage" runat="server" 
                                    OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                </div></div>
                                <div style="float:left;margin-left:5px;line-height:22px;padding:2px;"><a href="<%=GetClientUrl("~/Manage/System/LanguageList.aspx") %>" target="MainFrame" style="color:#ff6">设置</a></div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="font_text" width='30%'>
                    <script type="text/javascript"> CalConv(); </script>
                </td>
                <td class="font_text" align="right" width='30%'>
                    <span style="font-weight:bold;"><%=TrueName %></span> 您好，欢迎进入网站后台系统
                </td>
            </tr>
        </table>
    </div>
</form>
</body>
</html>
