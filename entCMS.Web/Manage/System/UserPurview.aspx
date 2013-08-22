<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="UserPurview.aspx.cs" Inherits="entCMS.Manage.UserPurview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
用户权限分配（当前用户：<asp:Label ID="lblUser" runat="server"></asp:Label>）
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 用户管理 >> 权限分配
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存并关闭</asp:LinkButton>
    <asp:LinkButton ID="btnClose" runat="server" CssClass="btn" OnClientClick="return top.Dialog.close();">取消</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
<asp:Panel ID="pnlPurview" runat="server" ScrollBars="Vertical" Height="420">
    <table width="100%">
        <tr>
            <td width="50%" valign="top">
                <asp:HiddenField ID="hidCatalog" runat="server" Value="," />
                <asp:Table ID="tblCatalogs" runat="server" CssClass="SmartGridView" Width="100%">
                    <asp:TableHeaderRow CssClass="HeaderRow">
                        <asp:TableCell Width="20"><input type="checkbox" id="chkAll_C" name="chkAll_C" /></asp:TableCell>
                        <asp:TableCell><b>内容管理权限</b></asp:TableCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </td>
            <td valign="top">
                <asp:HiddenField ID="hidMenu" runat="server" Value="," />
                <asp:Table ID="tblMenus" runat="server" CssClass="SmartGridView" Width="100%">
                    <asp:TableHeaderRow CssClass="HeaderRow">
                        <asp:TableCell Width="20"><input type="checkbox" id="chkAll_S" name="chkAll_S" /></asp:TableCell>
                        <asp:TableCell><b>系统管理权限</b></asp:TableCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </td>
        </tr>
    </table>
</asp:Panel>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
<script type="text/javascript">
    function selectCatalog(obj) {
        var hidCatalog = document.getElementById('<%=hidCatalog.ClientID %>');
        var val = hidCatalog.value;

        if (!obj.checked) {
            if (val.indexOf(',' + obj.value + ',') >= 0)
                val = val.replace(',' + obj.value + ',', '');
        }
        else {
            if (val.indexOf(',' + obj.value + ',') == -1)
                val += (',' + obj.value + ',');
        }
        hidCatalog.value = val;
    }
    function selectMenu(obj) {
        var hidMenu = document.getElementById('<%=hidMenu.ClientID %>');
        var val = hidMenu.value;

        if (!obj.checked) {
            if (val.indexOf(',' + obj.value + ',') >= 0)
                val = val.replace(',' + obj.value + ',', '');
        }
        else {
            if (val.indexOf(',' + obj.value + ',') == -1)
                val += (',' + obj.value + ',');
        }
        hidMenu.value = val;
    }
    $(function () {
        $('#chkAll_C').click(function () {
            var b = $('#chkAll_C').attr('checked');
            $('.C').each(function (i, e) {
                $(this).attr('checked', b);
                selectCatalog($(this).get(0));
            });
        });
        $('#chkAll_S').click(function () {
            var b = $('#chkAll_S').attr('checked');
            $('.S').each(function (i, e) {
                $(this).attr('checked', b);
                selectMenu($(this).get(0));
            });
        });
        var hidCatalog = document.getElementById('<%=hidCatalog.ClientID %>');
        var c_val = hidCatalog.value;
        $('.C').each(function (i, e) {
            if (c_val.indexOf(',' + $(this).val() + ',') >= 0) {
                $(this).attr('checked', 'checked');
            }
        });


        var hidMenu = document.getElementById('<%=hidMenu.ClientID %>');
        var s_val = hidMenu.value;
        $('.S').each(function (i, e) {
            if (s_val.indexOf(',' + $(this).val() + ',') >= 0) {
                $(this).attr('checked', 'checked');
            }
        });
    });
</script>
</asp:Content>
