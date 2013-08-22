<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="ServicerList.aspx.cs" Inherits="entCMS.Manage.ServicerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
客服列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 在线客服 >> 客服列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href="ServicerAdd.aspx?node=<%=NodeCode %>" class="btn">添加</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" >
        <Columns>
            <asp:BoundField HeaderText="客服名称" DataField="Name" />
            <asp:BoundField HeaderText="QQ" DataField="QQ" />
            <asp:BoundField HeaderText="MSN" DataField="MSN" />
            <asp:BoundField HeaderText="淘宝旺旺" DataField="TaobaoWW" />
            <asp:BoundField HeaderText="阿里旺旺" DataField="AliWW" />
            <asp:BoundField HeaderText="Skype" DataField="Skype" />
            <asp:TemplateField HeaderText="排序号" HeaderStyle-Width="60">
                <ItemTemplate>
                    <asp:TextBox ID="txtOrder" runat="server" Width="50" value='<%#Eval("OrderNo") %>' onblur='<%#"changeOrder(" + Eval("Id") + ", "  +Eval("OrderNo") + ", this.value); return false;" %>' style='text-align:center;'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="启用" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("enable(this, "+Eval("Id")+")") %>;return false;'><%#Convert.ToBoolean(Eval("IsEnabled"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="100">
                <ItemTemplate>
                    <a href='ServicerAdd.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>&action=edit'>编辑</a>
                    <a href='javascript:void(0);' onclick='<%#("del("+Eval("Id")+")") %>;return false;'>删除</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle CssClass="Row" />
        <SelectedRowStyle CssClass="SelectedRow" />
        <HeaderStyle CssClass="HeaderRow" />
        <AlternatingRowStyle CssClass="AlternatingRow" />
        <PagerStyle CssClass="PagerRow" />
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
