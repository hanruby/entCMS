<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="RoleAdd.aspx.cs" Inherits="entCMS.Manage.RoleAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
角色添加
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 角色管理 >> 添加
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                角色名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入角色名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                排序号：
            </td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Text="0" Width="32px"></asp:TextBox>
                <asp:CompareValidator ID="cvOrder" runat="server" ControlToValidate="txtOrder" ValueToCompare="0" Type="Integer" Operator="GreaterThanEqual" ErrorMessage="请输入正整数"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                是否启用：
            </td>
            <td>
                <asp:CheckBox ID="chkEnabled" runat="server" Text="启用" Checked="true" />
            </td>
        </tr>
        <tr>
            <td class="col">
                权限分配：
            </td>
            <td>
                <asp:Panel ID="pnlPurview" runat="server" ScrollBars="Vertical" Height="400">
                    <table width="100%">
                        <tr>
                            <td width="50%" valign="top" style="vertical-align:top;">
                                <asp:HiddenField ID="hidCatalog" runat="server" Value="," />
                                <asp:Table ID="tblCatalogs" runat="server" CssClass="SmartGridView" Width="100%">
                                    <asp:TableRow CssClass="HeaderRow">
                                        <asp:TableCell Width="20"><input type="checkbox" id="chkAll_C" name="chkAll_C" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Left"><b>内容管理权限</b></asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </td>
                            <td valign="top" style="vertical-align:top;">
                                <asp:HiddenField ID="hidMenu" runat="server" Value="," />
                                <asp:Table ID="tblMenus" runat="server" CssClass="SmartGridView" Width="100%">
                                    <asp:TableRow CssClass="HeaderRow">
                                        <asp:TableCell Width="20"><input type="checkbox" id="chkAll_S" name="chkAll_S" /></asp:TableCell>
                                        <asp:TableCell HorizontalAlign="Left"><b>系统管理权限</b></asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>&nbsp;
                <a href='RoleList.aspx?node=<%=NodeCode %>' class="btn">列表</a>
            </td>
        </tr>
    </table>
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
