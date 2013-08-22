<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="NewsMoveTo.aspx.cs" Inherits="entCMS.Manage.Module.NewsMoveTo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
移动到...
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：内容管理 >> 内容移动到...
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" OnClientClick="return check();">保存并关闭</asp:LinkButton>
    <asp:LinkButton ID="btnClose" runat="server" CssClass="btn" OnClientClick="return top.Dialog.close();">取消</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
<table width="100%">
    <tr>
        <td width="50%" valign="top">
            <asp:HiddenField ID="hidCatalog" runat="server" Value="," />
            <asp:Table ID="tblCatalogs" runat="server" CssClass="SmartGridView" Width="100%">
                <asp:TableHeaderRow CssClass="HeaderRow">
                    <asp:TableCell Width="20"></asp:TableCell>
                    <asp:TableCell><b>内容栏目</b></asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
<script type="text/javascript">
    function selectCatalog(obj) {
        var hidCatalog = document.getElementById('<%=hidCatalog.ClientID %>');
        hidCatalog.value = obj.value;
    }

    function check() {
        if ($(".C:checked").length == 0) {
            alert("请选择要移动到的栏目！");
            return false;
        }
        return true;
    }
</script>
</asp:Content>
