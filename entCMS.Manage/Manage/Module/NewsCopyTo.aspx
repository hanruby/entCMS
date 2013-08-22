<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="NewsCopyTo.aspx.cs" Inherits="entCMS.Manage.Module.NewsCopyTo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
复制到...
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：内容管理 >> 内容复制到...
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
                    <asp:TableCell Width="20"><input type="checkbox" id="chkAll_C" name="chkAll_C" /></asp:TableCell>
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

    function check() {
        if ($(".C:checked").length == 0) {
            alert("请选择要移动到的栏目！");
            return false;
        }
        return true;
    }

    $(function () {
        $('#chkAll_C').click(function () {
            var b = $('#chkAll_C').prop('checked');
            $('.C').each(function (i, e) {
                if ($(this).is(":disabled") == false) {
                    $(this).prop('checked', b);
                    selectCatalog($(this).get(0));
                }
            });
        });
        var hidCatalog = document.getElementById('<%=hidCatalog.ClientID %>');
        var c_val = hidCatalog.value;
        $('.C').each(function (i, e) {
            if (c_val.indexOf(',' + $(this).val() + ',') >= 0) {
                $(this).prop('checked', 'checked');
            }
        });
    });
</script>
</asp:Content>
