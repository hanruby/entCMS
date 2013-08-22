<%@ Page Title="" Language="C#" MasterPageFile="~/global/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="entCMS.HengyiLogisticsWeb.global.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <%--<link type="text/css" rel="stylesheet" href="<%=GetClientUrl("~/global/css/cameraslideshow.css")%>" />--%>
    <link type="text/css" rel="stylesheet" href="<%=GetClientUrl("~/Scripts/camera/css/camera.css")%>" />
    <%--<script type="text/javascript" src="<%=GetClientUrl("~/Scripts/jquery.mobile.customized.min.js") %>"></script>--%>
    <script type="text/javascript" src="<%=GetClientUrl("~/Scripts/camera/scripts/jquery.min.js") %>"></script>
    <script type="text/javascript" src="<%=GetClientUrl("~/Scripts/camera/scripts/jquery.easing.1.3.js") %>"></script>
    <script type="text/javascript" src="<%=GetClientUrl("~/Scripts/camera/scripts/camera.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="homebanner">
        <div class="camera_wrap" style="height:290px;">
            <% 
                foreach (entCMS.Models.cmsSlideshow item in Slideshows)
                {
            %>
            <div data-thumb="<%=item.ImgThumb %>" data-src="<%=item.ImgSrc %>">
                <div class="camera_caption fadeFromBottom">
                    <%=item.Title %><em><%=item.Summary %></em>
                </div>
            </div>  
            <%        
                }    
            %>
        </div>
        <script type="text/javascript">
            jQuery(function () {
                jQuery('.camera_wrap').camera({
                    pagination: false,
                    thumbnails: true,
                    loader: 'bar',
                    height: '290px'
                });
            });
        </script>
    </div>
    <div class="clearfix box">
        <div class="container_12">
            <div class="grid home-widget">
                <div class="green">
                    <h2><img src="img/home-widget-icon01.gif" align="absmiddle"/><%=Resources["AboutUs"]%></h2>
                    <div class="top-box">
                        <div class="box-text">
                            <h4><%=Company.ComName %></h4>
                            <p>宁波亨一国际货运代理有限公司是一家...</p>
                            <p></p>
                        </div>
                        <div class="box-button">
                            <a class="button" href="#"><%=Resources["More"] %></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid home-widget">
                <div class="yellow">
                    <h2><img src="img/home-widget-icon02.gif" align="absmiddle"/><%=Resources["LatestNews"]%></h2>
                    <div class="top-box">
                        <div class="box-text">
                            <ul>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                            </ul>
                        </div>
                        <div class="box-button">
                            <a class="button" href="#"><%=Resources["More"] %></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid home-widget">
                <div class="orange">
                    <h2><img src="img/home-widget-icon03.gif" align="absmiddle"/><%=Resources["BusinessScope"] %></h2>
                    <div class="top-box">
                        <div class="box-text">
                            <ul>
                                <li><a href="">空运</a></li>
                                <li><a href="">海运</a></li>
                                <li><a href="">拖卡</a></li>
                                <li><a href="">仓储</a></li>
                                <li><a href="">报关代理</a></li>
                            </ul>
                        </div>
                        <div class="box-button">
                            <a class="button" href="#"><%=Resources["More"] %></a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid home-widget">
                <div class="blue">
                    <h2><img src="img/home-widget-icon04.gif" align="absmiddle"/><%=Resources["ContactUs"]%></h2>
                    <div class="top-box">
                        <div class="box-text">
                            <h4><%=Company.ComName %></h4>
                            <p><%=Resources["CompanyAddr"] %><%=Company.ComAddr%></p>
                            <p><%=Resources["CompanyZipCode"] %><%=Company.ComZipcode%></p>
                            <p><%=Resources["CompanyTel"] %><%=Company.ComTel%></p>
                            <p><%=Resources["CompanyFax"]%><%=Company.ComFax%></p>
                            <p><%=Resources["CompanyEmail"]%><%=Company.ComEmail%></p>
                        </div>
                        <div class="box-button">
                            <%--<a class="button" href="#"><%=Resources["More"] %></a>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
    <%=OnlineInfo %>
</asp:Content>
