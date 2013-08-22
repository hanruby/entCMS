<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="Extend.aspx.cs" Inherits="entCMS.Manage.Extend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    推广接口
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
<script type="text/javascript">
    document.writeln("<style type=\"text/css\">");
    document.writeln(".Optimization li{float:left;width:206px;display:inline;text-align:center;margin:5px}");
    document.writeln(".Optimization li a{float:left;width:200px;border:#CCC 1px solid;padding:2px}");
    document.writeln(".Optimization li a span{float:left;width:200px}");
    document.writeln(".Optimization li a:hover{background:#eef8fe;border:#6fa0bf 1px solid}");
    document.writeln("</style>");
    document.writeln("<ul class=\"Optimization\">");
    document.writeln("<li><a href=\"https://www.google.com/webmasters/tools/submit-url?hl=zh-CN&amp;continue=/addurl\" target=\"_blank\"><img src=\"images/google.jpg\" width=\"200\" height=\"80\" alt=\"谷歌推广入口\" /><span>谷歌推广入口</span></a></li>");
    document.writeln("<li><a href=\"http://www.baidu.com/search/url_submit.html\" target=\"_blank\"><img src=\"images/baidu.jpg\" width=\"200\" height=\"80\" alt=\"百度推广入口\" /><span>百度推广入口</span></a></li>");
    document.writeln("<li><a href=\"http://www.bing.com/toolbox/submit-site-url\" target=\"_blank\"><img src=\"images/bing.jpg\" width=\"200\" height=\"80\" alt=\"必应推广入口\" /><span>必应推广入口</span></a></li>");
    document.writeln("<li><a href=\"http://tellbot.youdao.com/report\" target=\"_blank\"><img src=\"images/youdao.jpg\" width=\"200\" height=\"80\" alt=\"有道推广入口\" /><span>有道推广入口</span></a></li>");
    document.writeln("<li><a href=\"http://www.soso.com/help/usb/urlsubmit.shtml\" target=\"_blank\"><img src=\"images/soso.jpg\" width=\"200\" height=\"80\" alt=\"搜搜推广入口\" /><span>搜搜推广入口</span></a></li>");
    document.writeln("<li><a href=\"http://info.so.360.cn/site_submit.html\" target=\"_blank\"><img src=\"images/360.jpg\" width=\"200\" height=\"80\" alt=\"360推广入口\" /><span>360推广入口</span></a></li>");
    document.writeln("</ul>");
</script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
