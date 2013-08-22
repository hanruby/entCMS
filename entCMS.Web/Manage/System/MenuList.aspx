<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="entCMS.Manage.MenuList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
系统栏目列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 系统栏目 >> 列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href='MenuAdd.aspx?node=<%=NodeCode %>' class='btn'>添加</a>
    <a href='javascript:void(0)' class="btn" onclick="top.LeftFrameReload();return false;">刷新左侧栏</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:Table ID="tblMenus" runat="server" Width="100%" CssClass="SmartGridView">
        <asp:TableHeaderRow CssClass="HeaderRow">
            <asp:TableHeaderCell Width="60">排序号</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="30%">栏目名称</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="">链接地址</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="60">启用</asp:TableHeaderCell>
            <asp:TableHeaderCell Width="120">操作</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
<script type="text/javascript">
    function changeOrder(code, old, order) {
        if (order == null || isNaN(order) || old == order) {
            return;
        }
        else {
            $.post(
                "Ajax.ashx",
                { Action: "MenuOrder", Code: code, Order: order },
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

    function enable(obj, code) {
        var v = obj.innerHTML;
        $.post(
            "Ajax.ashx",
            { Action: "MenuEnable", Code: code },
            function (data, textStatus) {
                if (data.result) {
                    if (v == "是") obj.innerHTML = "否";
                    else obj.innerHTML = "是";
                }
                else {
                    alert(data.msg);
                }
            },
            "json"
        );
    }
    function del(code) {
        if (confirm('栏目删除后不能恢复，确定要删除吗？')) {
            $.post(
                "Ajax.ashx",
                { Action: "MenuDelete", Code: code },
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

    $(function () {
        $('.Row').hover(
            function (e) {
                $(this).css('backgroundColor', '#ffff66');
            },
            function (e) {
                $(this).css('backgroundColor', '#f5f5f5');
            }
        );
    });
</script>
</asp:Content>
