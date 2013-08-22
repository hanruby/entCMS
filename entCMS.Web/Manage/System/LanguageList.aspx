<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="LanguageList.aspx.cs" Inherits="entCMS.Manage.LanguageList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    语言列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：系统管理 >> 系统设置 >> 语言列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href="LanguageAdd.aspx?node=<%=NodeCode %>" class="btn">添加</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" 
        OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="语言名称" DataField="Name" />
            <asp:BoundField HeaderText="本语名称" DataField="ShortName" />
            <asp:BoundField HeaderText="语言代码" DataField="Code" />
            <asp:BoundField HeaderText="首页地址" DataField="HomeUrl" />
            <asp:TemplateField HeaderText="排序号" HeaderStyle-Width="60">
                <ItemTemplate>
                    <asp:TextBox ID="txtOrder" runat="server" Width="50" value='<%#Eval("OrderNo") %>' onblur='<%#"changeOrder(" + Eval("Id") + ", "  +Eval("OrderNo") + ", this.value); return false;" %>' style='text-align:center;'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="默认" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("setDefault(this, "+Eval("Id")+")") %>;return false;'><%#Convert.ToBoolean(Eval("IsDefault"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="启用" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("enable(this, "+Eval("Id")+")") %>;return false;'><%#Convert.ToBoolean(Eval("IsEnabled"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="100">
                <ItemTemplate>
                    <a href='LanguageAdd.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>&action=edit'>编辑</a>
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
                "Ajax.ashx",
                { Action: "LangOrder", Id: id, Order: order },
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

        function enable(obj, id) {
            var v = obj.innerHTML;
            $.post(
                "Ajax.ashx",
                { Action: "LangEnable", Id: id },
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

        function setDefault(obj, id) {
            var v = obj.innerHTML;
            $.post(
            "Ajax.ashx",
            { Action: "LangSetDefault", Id: id },
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
        function del(id) {
            if (id == 1) {
                alert('不允许删除系统保留的第一种语言！');
                return;
            }
            if (confirm('语言删除后不能恢复，确定要删除吗？')) {
                $.post(
                "Ajax.ashx",
                { Action: "LangDelete", Id: id },
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