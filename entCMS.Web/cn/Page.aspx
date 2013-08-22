<%@ Page Title="" Language="C#" MasterPageFile="~/cn/NestedSite.master" AutoEventWireup="true"
    CodeBehind="Page.aspx.cs" Inherits="entCMS.Web.cn.Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="title">
        <span class="title_l"><%=Node.NodeName %></span> 
        <span class="title_r">当前位置: 首页 - <%=GetNavStr(" &gt ")%></span>
        <div class="clear"></div>
    </div>
    <div id="lib_article">
        <%=HtmlContent %>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
