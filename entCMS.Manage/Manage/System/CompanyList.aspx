<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="entCMS.Manage.CompanyList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    公司信息列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：系统管理 >> 公司信息 >> 公司信息列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href="CompanyAdd.aspx?node=<%=NodeCode %>" class="btn">添加</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" 
        OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="语言" DataField="LangName" />
            <asp:BoundField HeaderText="名称" DataField="ComName" />
            <asp:BoundField HeaderText="地址" DataField="ComAddr" />
            <asp:BoundField HeaderText="邮编" DataField="ComZipcode" />
            <asp:BoundField HeaderText="电话" DataField="ComTel" />
            <asp:BoundField HeaderText="传真" DataField="ComFax" />
            <asp:BoundField HeaderText="邮箱" DataField="ComEmail" />
            <asp:BoundField HeaderText="网址" DataField="ComUrl" />
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="100">
                <ItemTemplate>
                    <a href='CompanyAdd.aspx?node=<%=NodeCode %>&id=<%#Eval("Id") %>&action=edit'>编辑</a>
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
    <script type="text/javascript">
        function del(id) {
            if (confirm('信息删除后不能恢复，确定要删除吗？')) {
                $.post(
                    "Ajax.ashx",
                    { Action: "CompanyDelete", Id: id },
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
