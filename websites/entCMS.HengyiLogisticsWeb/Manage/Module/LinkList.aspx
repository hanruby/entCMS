<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="LinkList.aspx.cs" Inherits="entCMS.Manage.Module.LinkList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
链接列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：内容管理 >> 链接管理 >> 链接列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href='LinkAdd.aspx?node=<%=NodeCode %>' class='btn'>添加</a>
    <a href='LinkGroupAdd.aspx?node=<%=NodeCode %>' class='btn'>添加类别</a>
    <a href='LinkGroupList.aspx?node=<%=NodeCode %>' class='btn'>类别列表</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset>
        <legend>查询框</legend>
        <div class="field">
            <label>名称</label><span><asp:TextBox ID="txtName" runat="server"></asp:TextBox></span>
            <label>地址</label><span><asp:TextBox ID="txtUrl" runat="server"></asp:TextBox></span>
            <label>类别</label><span><div class="select"><div><asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList></div></div></span>
        </div>
        <div class="field">
            <asp:LinkButton ID="btnQuery" runat="server" CssClass="btn" OnClick="btnQuery_Click">查询</asp:LinkButton>
            <asp:LinkButton ID="btnReset" runat="server" CssClass="btn" OnClick="btnReset_Click">重置</asp:LinkButton>
        </div>
    </fieldset>
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" 
        OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="排序" HeaderStyle-Width="60">
                <ItemTemplate>
                    <asp:TextBox ID="txtOrder" runat="server" Width="50" value='<%#Eval("OrderNo") %>' onblur='<%#"changeOrder(" + Eval("Id") + ", "  +Eval("OrderNo") + ", this.value); return false;" %>' style='text-align:center;'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="名称" DataField="Name" HeaderStyle-Width="200"/>
            <asp:BoundField HeaderText="地址" DataField="Url" />
            <asp:BoundField HeaderText="类别" DataField="TypeName" HeaderStyle-Width="100" NullDisplayText="默认"/>
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="100">
                <ItemTemplate>
                    <a href='LinkAdd.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>&action=edit'>编辑</a>
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
    <anp:AspNetPager ID="pager" runat="server" PageSize="20" OnPageChanged="pager_PageChanged">
    </anp:AspNetPager>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
<script type="text/javascript">
    function changeOrder(id, old, order) {
        if (order == null || isNaN(order) || old == order) {
            return;
        }
        else {
            $.post(
                "../System/Ajax.ashx",
                { Action: "LinkOrder", Id: id, Order: order },
                function (data, textStatus) {
                    if (data.result) {
                        location.href = location.href;
                    }
                    else {
                        alert(data.msg);
                    }
                },
                "json"
            );
        }
    }

    function del(id) {
        if (confirm('删除后不能恢复，确定要删除吗？')) {
            $.post(
                "../System/Ajax.ashx",
                { Action: "LinkDelete", Id: id },
                function (data, textStatus) {
                    if (data.result) {
                        alert('删除成功！点“确定”后刷新页面。');
                        location.href = location.href;
                    }
                    else {
                        alert(data.msg);
                    }
                },
                "json"
            );
        }
    }
</script>
</asp:Content>
