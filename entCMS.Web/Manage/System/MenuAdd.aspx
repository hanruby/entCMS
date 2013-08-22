<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="MenuAdd.aspx.cs" Inherits="entCMS.Manage.MenuAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
系统栏目添加
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 系统栏目 >> 添加
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidCode" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" width="100%" class="detail">
        <tr>
            <td class="col">
                上级栏目：
            </td>
            <td>
                <div class="select"><div>
                <asp:DropDownList ID="ddlParentNode" runat="server">
                </asp:DropDownList>
                </div></div>
            </td>
        </tr>
        <tr>
            <td class="col">
                栏目名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" CssClass="input" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入栏目名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                链接地址：
            </td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                同级栏目排序：
            </td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Text="0" Width="32px"></asp:TextBox><span class="tips">排序越小越靠前</span>
                <asp:CompareValidator ID="cvOrder" runat="server" ControlToValidate="txtOrder" ValueToCompare="0" Type="Integer" Operator="GreaterThanEqual" ErrorMessage="请输入正整数" Display="Dynamic"></asp:CompareValidator>
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
            <td>
            </td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>&nbsp;
                <a href='MenuList.aspx?node=<%=NodeCode %>' class="btn">列表</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
