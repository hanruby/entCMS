<%@ Page Title="" Language="C#" MasterPageFile="~/en/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="entCMS.Web.en.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <script type="text/javascript" src="<%=GetClientUrl("~/Scripts/Tween.js") %>"></script>
    <script type="text/javascript" src="<%=GetClientUrl("~/Scripts/XScroll.js") %>"></script>
    <style type="text/css">
        .sx,#idSlider,#idSlider img { text-align:center; width:220px;height:160px; overflow:hidden;}
        .sx {position:relative;}
        #shang ,#xia {position:absolute; z-index:19; width:24px;height:160px;text-align:center;line-height:160px;background-color:#fff;top:0;text-decoration:none; font-size:12px;opacity:0.5;filter:progid:DXImageTransform.Microsoft.Alpha(Opacity=50);}
        #shang { left:0px;}
        #xia { right:0px;}
        #shang:hover ,#xia:hover{opacity:0.8;filter:progid:DXImageTransform.Microsoft.Alpha(Opacity=80);}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="left">
        <div class="title_box">
            <div class="title">
                <h3>News</h3>
                <span class="more"><a href="<%=GetNodeUrl("0008", false) %>"><img src="images/more.jpg" height="31" width="50" /></a></span>
            </div>
            <div class="box">
                <ul class="list">
                    <%
                        //string newsShowFormat = IsUrlRewrite ? "/NewsShow/" : "/NewsShow.aspx?id="; 
                        System.Data.DataTable dtNews = GetIndexNews("0008", 6, true);
                        for (int i = 0; i < dtNews.Rows.Count; i++)
                        {
                            System.Data.DataRow dr = dtNews.Rows[i];
                            string url = GetNewsUrl("NewsShow.aspx", dr["Id"]);
                    %>
                    <li><a href="<%=url%>"><%=dr["Title"]%></a><span class="date"><%=Convert.ToDateTime(dr["EditTime"]).ToString("yyyy-MM-dd")%></span><div class="clear"></div></li>
                    <% } %>
                </ul>
            </div>
            <div class="box_bottom"></div>
        </div>
    </div>
    <div class="med">
        <div class="title_box">
            <div class="title">
                <h3>Company Profile</h3>
                <span class="more"><a href="<%=GetNodeUrl("00060001", false) %>"><img src="images/more.jpg" height="31" width="50" /></a></span>
            </div>
            <div class="box">
                <%=Company.Summary %>
            </div>
            <div class="box_bottom"></div>
        </div>
    </div>
    <div class="right">
        <div class="title_box">
            <div class="title">
                <h3>Products</h3>
                <span class="more"><a href="<%=GetNodeUrl("0007", false) %>"><img src="images/more.jpg" height="31" width="50" /></a></span>
            </div>
            <div class="box" style="background-color: #eee; text-align:center;">
                <div class="sx">
                    <ul id="idSlider">
                        <%
                            System.Data.DataTable dtProducts = GetIndexNews("0007", 10, true);
                            for (int i = 0; i < dtProducts.Rows.Count; i++)
                            {
                                System.Data.DataRow dr = dtProducts.Rows[i];
                                string url = GetNewsUrl("ProductShow.aspx", dr["Id"]);
                        %>
                            <li><a href="<%=url %>" title="<%=dr["Title"] %>"><img src="<%=dr["SmallPic"] %>" alt="<%=dr["Title"] %>" /></a></li>
                        <% } %>
                    </ul>
                    <a href="javascript:void(0)" id="shang">&lt;&lt;</a>
                    <a href="javascript:void(0)" id="xia">&gt;&gt;</a>                
                </div>
                <script type="text/javascript">
                    var sx = XScroll('idSlider', { direct: 3, how: 3, delay: 5000, auto: false });

                    (function () {
                        var shang = _.id('shang'), xia = _.id('xia');
                        shang.onclick = function () {
                            sx.Prev();
                        }
                        xia.onclick = function () {
                            sx.Next();
                        }
                    })()
                </script>
            </div>
            <div class="box_bottom"></div>
            
        </div>
    </div>
    <div class="clear"></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
    <a id="online_param" href="?t=<%=onlineType %>&u=/&x=<%=onlineX %>&y=<%=onlineY %>&lang=<%=CurrentLanguage.Id %>"></a>
    <script type="text/javascript" src="<%=GetClientUrl("~/Manage/scripts/online.js") %>"></script>
</asp:Content>
