<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="JobList.aspx.cs" Inherits="entCMS.Manage.Module.JobList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    职位列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：内容管理<asp:Label ID="lblPosition" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href="JobAdd.aspx?node=<%=NodeCode %>&type=0|6" class="btn">添加</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" 
        OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="排序" HeaderStyle-Width="60">
                <ItemTemplate>
                    <asp:TextBox ID="txtOrder" runat="server" Width="50" value='<%#Eval("OrderNo") %>' onblur='<%#"changeOrder(" + Eval("Id") + ", "  +Eval("OrderNo") + ", this.value); return false;" %>' style='text-align:center;'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="职位名称" ItemStyle-HorizontalAlign="Left" DataField="Name" />
            <asp:BoundField HeaderText="招聘人数" DataField="Numbers" HeaderStyle-Width="60" />
            <asp:BoundField HeaderText="点击率" DataField="Hits" HeaderStyle-Width="60" />
            <asp:BoundField HeaderText="添加时间" DataField="AddTime" HeaderStyle-Width="120"/>
            <asp:BoundField HeaderText="结束时间" DataField="EndTime" HeaderStyle-Width="120" />
            <asp:TemplateField HeaderText="启用" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0)' onclick='<%#("enable(this, "+Eval("Id")+")") %>;return false;'><%#Convert.ToBoolean(Eval("IsEnabled"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="100">
                <ItemTemplate>
                    <a href='JobAdd.aspx?node=<%#Eval("NodeCode") %>&id=<%#Eval("Id") %>&action=edit'>编辑</a>
                    <a href='javascript:void(0)' onclick='<%#("return del(\""+Eval("Id")+"\", 1);")%>'>删除</a>
                    <!--
                    <a href='NewsDel.aspx?id=<%#Eval("Id") %>&action=del' onclick='<%#("return del(\""+Eval("Id")+"\", 1);")%>' style='display:<%=IsAdmin?"":"none"%>'>彻底删除</a>
                    <a href='#auditBox' class='audit' onclick='<%#("return audit(\""+Eval("NodeCode")+"\",\""+Eval("Id")+"\");")%>' style='display:<%=IsAdmin?"":"none"%>'>审核</a>
                    <a href='/NewsDetails.aspx?id=<%#Eval("Id") %>' target="_blank">预览</a>
                    -->
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
                    { Action: "JobOrder", Id: id, Order: order },
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
                    "../System/Ajax.ashx",
                { Action: "JobEnable", Id: id },
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
            if (confirm('职位删除后不能恢复，确定要删除吗？')) {
                $.post(
                    "../System/Ajax.ashx",
                    { Action: "JobDelete", Id: id },
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
