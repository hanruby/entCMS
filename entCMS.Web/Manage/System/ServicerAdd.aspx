<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="ServicerAdd.aspx.cs" Inherits="entCMS.Manage.ServicerAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
添加客服
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 在线客服 >> 添加客服
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                客服名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入客服名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                QQ：
            </td>
            <td>
                <asp:TextBox ID="txtQQ" runat="server" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                MSN：
            </td>
            <td>
                <asp:TextBox ID="txtMSN" runat="server" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                淘宝旺旺：
            </td>
            <td>
                <asp:TextBox ID="txtTaobao" runat="server" Text="" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                阿里旺旺：
            </td>
            <td>
                <asp:TextBox ID="txtAli" runat="server" Text="" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                Skype：
            </td>
            <td>
                <asp:TextBox ID="txtSkype" runat="server" Text="" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                排序号：
            </td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Text="0" Width="32px">0</asp:TextBox>
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
                <a href='ServicerList.aspx?node=<%=NodeCode %>' class="btn">列表</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
