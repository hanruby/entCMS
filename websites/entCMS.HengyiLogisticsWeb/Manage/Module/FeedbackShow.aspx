<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="FeedbackShow.aspx.cs" Inherits="entCMS.Manage.Module.FeedbackShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    查看信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：内容管理 >> 反馈管理 >> 查看信息
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存并关闭</asp:LinkButton>
    <asp:LinkButton ID="btnClose" runat="server" CssClass="btn" OnClientClick="top.Dialog.close();return false;">取消</asp:LinkButton>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">标题：</td>
            <td><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">内容：</td>
            <td><asp:Literal ID="ltlContent" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">姓名：</td>
            <td><asp:Literal ID="ltlName" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">电子邮箱：</td>
            <td><asp:Literal ID="ltlEmail" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">公司：</td>
            <td><asp:Literal ID="ltlCompany" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">地址：</td>
            <td><asp:Literal ID="ltlAddress" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">电话：</td>
            <td><asp:Literal ID="ltlPhone" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">传真：</td>
            <td><asp:Literal ID="ltlFax" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">留言时间：</td>
            <td><asp:Literal ID="ltlTime" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td class="col">处理状态：</td>
            <td><asp:CheckBox ID="chkReply" runat="server" Text="已处理" /></td>
        </tr>
        <tr>
            <td class="col">回复内容：</td>
            <td><asp:TextBox ID="txtReply" runat="server" MaxLength="1000" TextMode="MultiLine" Width="350" Height="150"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn" OnClick="btnSave_Click">保存并关闭</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn" OnClientClick="top.Dialog.close();return false;">取消</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
