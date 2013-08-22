<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="entCMS.Manage.UserRole" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
用户角色分配（当前用户：<asp:Label ID="lblUser" runat="server"></asp:Label>）
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 用户管理 >> 角色分配
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存并关闭</asp:LinkButton>
    <asp:LinkButton ID="btnClose" runat="server" CssClass="btn" OnClientClick="return top.Dialog.close();">取消</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
<asp:Panel ID="pnlPurview" runat="server" ScrollBars="Vertical" Height="420">
    <br />
    <table width="90%">
        <tr>
            <td class="HeaderRow" style="text-align:left;">
                <asp:CheckBox ID="chkAll" runat="server" Text="可选的角色列表" AutoPostBack="true" oncheckedchanged="chkAll_CheckedChanged" />
            </td>
        </tr>
        <tr class="Row" style="text-align:left;">
            <td><asp:CheckBoxList ID="cblRoles" runat="server" Width="100%" RepeatDirection="Horizontal" RepeatColumns="4"></asp:CheckBoxList></td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>