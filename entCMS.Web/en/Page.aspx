<%@ Page Title="" Language="C#" MasterPageFile="~/en/NestedSite.master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="entCMS.Web.en.Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <%=HtmlContent%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>