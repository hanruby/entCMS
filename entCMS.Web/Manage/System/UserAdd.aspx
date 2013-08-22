<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="UserAdd.aspx.cs" Inherits="entCMS.Manage.UserAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
用户添加
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 用户管理 >> 添加
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                用户名：
            </td>
            <td>
                <asp:TextBox ID="txtUser" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txtUser" ErrorMessage="请输入用户名" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                登录密码：
            </td>
            <td>
                <asp:TextBox ID="txtPwd" runat="server" Width="350" TextMode="Password"></asp:TextBox>
                <%--<asp:RequiredFieldValidator ID="rfvPwd" runat="server" ControlToValidate="txtPwd" ErrorMessage="请输入登录密码" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                <asp:HiddenField ID="hidPwd" runat="server" />
                <span>留空表示不修改原先密码</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                姓名：
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                部门：
            </td>
            <td>
                <asp:TextBox ID="txtDept" runat="server" Width="350"></asp:TextBox>
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
            <td></td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>&nbsp;
                <a href='UserList.aspx?node=<%=NodeCode %>' class="btn">列表</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">

</asp:Content>
