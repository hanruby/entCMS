<%@ Page Title="" Language="C#" MasterPageFile="~/cn/NestedSite.master" AutoEventWireup="true" CodeBehind="ImageShow.aspx.cs" Inherits="entCMS.Web.cn.ImageShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="lib_info_detail">
        <div class="title"><%=title %></div>
        <div class="contents">
            <%=content %>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>