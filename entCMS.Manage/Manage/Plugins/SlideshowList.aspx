﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="SlideshowList.aspx.cs" Inherits="entCMS.Manage.Plugins.SlideshowList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    幻灯片列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：其他管理 >> 幻灯管理 >> 幻灯片列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href="SlideshowAdd.aspx?node=<%=NodeCode %>" class="btn">添加</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" >
        <Columns>
            <asp:TemplateField HeaderText="图片" HeaderStyle-Width="40">
                <ItemTemplate>
                    <a href="#" onclick="previewImage(this);" data-src='<%#Eval("ImgSrc") %>'>[图片]</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="标题">
                <ItemTemplate>
                    <span title='<%#Eval("Summary") %>'><%#Eval("Title") %></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="链接" DataField="Url" />
            <asp:BoundField HeaderText="目标窗口" DataField="Target" HeaderStyle-Width="60"/>
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
                    <a href='SlideshowAdd.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>&action=edit'>编辑</a>
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
    function previewImage(obj) {
        var img = $(obj).data('src');
        top.$.fancybox.open({ href: img, live: true });
    }
    function changeOrder(id, old, order) {
        if (order == null || isNaN(order) || old == order) {
            return;
        }
        else {
            $.post(
                    "Ajax.ashx",
                    { Action: "SlideshowOrder", Id: id, Order: order },
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
                { Action: "SlideshowEnable", Id: id },
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
    function del(id) {
        if (confirm('删除后不能恢复，确定要删除吗？')) {
            $.post(
                    "Ajax.ashx",
                    { Action: "SlideshowDelete", Id: id },
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
