<%@ Page Title="" Language="C#" MasterPageFile="~/en/NestedSite.master" AutoEventWireup="true" CodeBehind="ImageShow.aspx.cs" Inherits="entCMS.Web.en.ImageShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
        <tbody>
            <tr>
                <td align="center" style="color: #666666; font-size: 16px; height: 35px;">
                    <strong><%=news.Title %></strong>
                </td>
            </tr>
            <tr>
                <td height="5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="line-height: 25px; font-size: 12px; padding-left: 8px; padding-right: 8px">
                    <%=("<img src='"+news.SmallPic.Replace("_s","_b")+"' alt='' width='700' />") %>
                    <br />
                    <%=news.Content %>
                </td>
            </tr>
            <tr>
                <td height="20">
                    &nbsp;
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
