<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="LanguageAdd.aspx.cs" Inherits="entCMS.Manage.LanguageAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
语言添加
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 系统设置 >> 语言设置 >> 语言添加
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                语言名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入语言名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                本语名称：
            </td>
            <td>
                <asp:TextBox ID="txtShortName" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvShortName" runat="server" ControlToValidate="txtShortName" ErrorMessage="请输入本语名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                语言代码：
            </td>
            <td>
                <asp:TextBox ID="txtCode" runat="server" Width="350"></asp:TextBox><span class="tips">语言代码添加后不允许被修改</span>
                <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode" ErrorMessage="请输入语言代码" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                首页地址：
            </td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Width="350" Text="/"></asp:TextBox>
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
                是否默认：
            </td>
            <td>
                <asp:CheckBox ID="chkDefault" runat="server" Text="默认" Checked="false" />
                <span>（设为默认会取消原先设置的默认语言。）</span>
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
                备注：
            </td>
            <td>
                <asp:TextBox ID="txtRemark" runat="server" Width="80%" Height="100" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>&nbsp;
                <a href='LanguageList.aspx?node=<%=NodeCode %>' class="btn">列表</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
