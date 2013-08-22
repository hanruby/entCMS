<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="entCMS.Manage.UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
用户列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 用户管理 >> 用户列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href="UserAdd.aspx?node=<%=NodeCode %>" class="btn">添加</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset title="查询">
        <legend>查询框</legend>
        <div class="field">
            <label>登录名</label><span><asp:TextBox ID="txtLogin" runat="server"></asp:TextBox></span>
            <label>姓名</label><span><asp:TextBox ID="txtName" runat="server"></asp:TextBox></span>
        </div>
        <div class="field">
            <label>部门</label><span><asp:TextBox ID="txtDept" runat="server"></asp:TextBox></span>
            <label>角色</label><span><asp:DropDownList ID="ddlRole" runat="server"></asp:DropDownList></span>
        </div>
        <div class="field">
            <asp:LinkButton ID="btnQuery" runat="server" CssClass="btn" OnClick="btnQuery_Click">查询</asp:LinkButton>
            <asp:LinkButton ID="btnReset" runat="server" CssClass="btn" OnClick="btnReset_Click">重置</asp:LinkButton>
        </div>
    </fieldset>
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" 
        OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="登录名" DataField="UName" />
            <asp:BoundField HeaderText="姓名" DataField="Name" />
            <asp:BoundField HeaderText="部门" DataField="DeptName" />
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="180">
                <ItemTemplate>
                    <a href='UserAdd.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>&action=edit'>编辑</a>
                    <a href='javascript:void(0);' onclick='<%#("del("+Eval("Id")+")") %>;return false;'>删除</a>
                    <a href='UserRole.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>' onclick='return UserRole(<%#Eval("Id") %>);'>角色分配</a>
                    <a href='UserPurview.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>' onclick='return UserPurview(<%#Eval("Id") %>);'>权限分配</a>
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
        function del(id) {
            if (confirm('用户删除后不能恢复，确定要删除吗？')) {
                $.post(
                "Ajax.ashx",
                { Action: "UserDelete", Id: id },
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
        function UserRole(id) {
            top.Dialog.open({ Title: '角色分配', Width: 600, Height: 480, URL: 'System/UserRole.aspx?node=<%=NodeCode %>&id=' + id });
            return false;
            //return top.tipswindow('角色分配', 'iframe:System/UserRole.aspx?node=<%=NodeCode %>&id=' + id, '600', '480', 'true', '', 'true', '', 1);
        }
        function UserPurview(id) {
            top.Dialog.open({ Title: '权限分配', Width: 600, Height: 480, URL: 'System/UserPurview.aspx?node=<%=NodeCode %>&id=' + id });
            return false;
            //return top.tipswindow('权限分配', 'iframe:System/UserPurview.aspx?node=<%=NodeCode %>&id=' + id, '600', '480', 'true', '', 'true', '', 1);
        }
    </script>
</asp:Content>
