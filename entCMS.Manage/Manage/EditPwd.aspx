<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="EditPwd.aspx.cs" Inherits="entCMS.Manage.EditPwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function closeDialog() {
            top.Dialog.close();
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    修改密码
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                原始密码：
            </td>
            <td>
                <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" Width="180"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvOldPwd" runat="server" ControlToValidate="txtOldPwd" ErrorMessage="原始密码 不能为空" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                新密码：
            </td>
            <td>
                <asp:TextBox ID="txtNewPwd1" runat="server" TextMode="Password" Width="180"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewPwd1" runat="server" ControlToValidate="txtNewPwd1" ErrorMessage="新密码 不能为空" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                确认新密码：
            </td>
            <td>
                <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password" Width="180"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewPwd2" runat="server" ControlToValidate="txtNewPwd2" ErrorMessage="确认新密码 不能为空" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvNewPwd" runat="server" ControlToValidate="txtNewPwd2" ControlToCompare="txtNewPwd1" Type="String" ErrorMessage="新密码 两次输入不一致" Display="Dynamic" SetFocusOnError="true"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存并关闭</asp:LinkButton>&nbsp;
                <a href='#' onclick='return closeDialog();' class="btn">取消</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
