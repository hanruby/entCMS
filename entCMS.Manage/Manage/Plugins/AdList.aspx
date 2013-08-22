<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="AdList.aspx.cs" Inherits="entCMS.Manage.Plugins.AdList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/dataLoading.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <!-- 图片预览-->
    <script src="../Scripts/jquery.shadow.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ifixpng.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.fancyzoom.js" type="text/javascript"></script>
    <%--<script src="../Scripts/fancyzoom.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('a.img').fancyzoom({ imgDir: '/Manage/Images/fancyzoom/', Speed: 400, showoverlay: false });
            $('a.audit').fancyzoom();
            //$('a.img').fancyZoom({ directory: '/Manage/Images/fancyzoom' });
            //$('a.audit').fancyZoom({ directory: '/Manage/Images/fancyzoom' });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    广告列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：其他管理 >> 广告管理 >> 广告列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href='AdAdd.aspx?node=<%=NodeCode %>' class='btn'>添加</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" 
        OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="标题" DataField="Title" />
            <asp:TemplateField HeaderText="类型">
                <ItemTemplate>
                    <%#getType(Container.DataItem) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="启用" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("enable(this, "+Eval("Id")+")") %>;return false;'><%#Convert.ToBoolean(Eval("Enabled"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="120">
                <ItemTemplate>
                    <a href='AdAdd.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>&action=edit'>编辑</a>
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
    function enable(obj, id) {
        var v = obj.innerHTML;
        $.post(
            "../Ajax.ashx",
            { Action: "EnableAd", Id: id },
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
        if (confirm('确定要删除吗？')) {
            $.post(
                "../Ajax.ashx",
                { Action: "DeleteAd", Id: id },
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
