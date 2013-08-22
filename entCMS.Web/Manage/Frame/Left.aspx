<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="entCMS.Manage.Frame.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        body{ margin:0;padding:0; font-size:12px; }
        a:link { font-size: 12px; text-decoration: none; color: #000000; }
        a:visited { font-size: 12px; text-decoration: none; color: #43860c; }
        a:hover { font-size: 12px; text-decoration: none; color: #FF0000; }
        
        .clear { clear:both; }
        
        .lefttop { border-left: 0px solid #3877AE; background: url("../images/frame/tbg.jpg"); width: 196px; height: 53px; line-height:53px; }
        .langs{background-color:#dddddd; width:196px;}
        .langs a{color:#43860c; text-decoration:underline;}
        .tabs { width: 196px; }
        .hd{ border-left: 0px solid #3877AE;background-color:#dddddd; padding:0px 8px;}
        .hd h3 { float:left; margin:0px; width:80px; text-align:center; line-height:2em; font-size:12px; font-weight:bold; cursor: pointer;}
        .hd h3.cur { background-color: #fff; }
        .tab { padding-top: 6px; }
        
        .dtree { font-size: 12px; white-space: nowrap; }
        .dtree img { border: 0px; vertical-align: middle; }
        .dtree a { color: #333; text-decoration: none; }
        .dtree a.node, .dtree a.nodeSel { white-space: nowrap; padding: 1px 2px 1px 2px; }
        .dtree a.node:hover, .dtree a.nodeSel:hover { color: #333; text-decoration: underline; }
        .dtree a.nodeSel { background-color: #c0d2ec; }
        .dtree .clip { /*overflow: hidden;*/ }
        
        select
        {
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            border-radius: 4px;
            padding: 2px;
            font-family: "宋体",Sans-Serif;
            background: url("../images/inputbg.gif") repeat-x scroll center top #FFFFFF;
            height: 26px;
            line-height: 26px;
        }
        /*
         * select控件样式（兼容IE6、IE7、Firefox 2.0）
         * http://blog.sina.com.cn/s/blog_6540a3c501011zaf.html
         */
        .select { margin: 0; padding: 0; border:1px solid #cccccc; float: left; display: inline; }
        .select div { border:1px solid #f9f9f9; float: left; }
        .select>div { overflow: hidden; }
        * html .select div select { display:block; float: left; margin: -2px; }
        .select div>select { display:block; float:none; margin: -2px; padding: 0px; }
        .select:hover { border:1px solid #666; }
    </style>
    <script src="../Scripts/jquery-1.9.0.min.js" type="text/javascript"></script>
    <script src="../Scripts/tree.js" type="text/javascript"></script>
    <script type="text/javascript">
        function gohome() {
            //alert($('#MainFrame', top.document)[0].contentWindow);
            $('#MainFrame', top.document)[0].contentWindow.location.href = 'Main.aspx';
        }
    </script>
</head>
<body style="padding: 0;">
    <form id="form1" runat="server">
    <div class="lefttop"><a id='gohome' href='<%=GetClientUrl("~/Manage/Frame/Main.aspx")%>' target="MainFrame" style='display:none'>后台首页</a></div>
    <div class="langs">
        <table width="100%">
            <tr>
                <td>语言：</td>
                <td>
                    <div class="select" style="float:left;"><div>
                    <asp:DropDownList ID="ddlLanguage" runat="server" 
                        OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    </div></div>
                    <div style="line-height:22px;padding:2px;margin-left:5px;float:left;"><a href="<%=GetClientUrl("~/Manage/System/LanguageList.aspx") %>" target="MainFrame">设置</a></div>
                </td>
            </tr>
        </table>
    </div>
    <div class="tabs">
        <div class="hd">
            <h3>内容管理</h3>
            <h3>系统管理</h3>
            <div class="clear"></div>
        </div>
        <div class="tab" style='display:none'>
            <asp:Literal ID="ltlCTree" runat="server"></asp:Literal>
        </div>
        <div class="tab" style='display:none'>
            <asp:Literal ID="ltlSTree" runat="server"></asp:Literal>
        </div>
    </div>
    
    </form>
    <script type="text/javascript">
        $(function () {
            $('h3').each(function (i, e) {
                $(this).click(function () {
                    $('h3').removeClass('cur');
                    $('h3:eq(' + i + ')').addClass('cur');

                    $('.tab').css('display', 'none');
                    $('.tab:eq(' + i + ')').css('display', '');
                });
            });

            $('h3:first').addClass('cur');
            $('.tab:first').css('display', '');
        });
    </script>
</body>
</html>