<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="FeedbackList.aspx.cs" Inherits="entCMS.Manage.Module.FeedbackList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    反馈列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：内容管理 >> 反馈管理 >> 反馈列表
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset>
        <legend>查询框</legend>
        <div class="field">
            <label>标题</label><span><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></span>
            <label>发送人</label><span><asp:TextBox ID="txtName" runat="server"></asp:TextBox></span>
            <label>公司</label><span><asp:TextBox ID="txtCompany" runat="server"></asp:TextBox></span>
            <label>已回复</label>
            <span>
                <asp:DropDownList ID="ddlReply" runat="server">
                    <asp:ListItem Text="全部" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="是" Value="1"></asp:ListItem>
                    <asp:ListItem Text="否" Value="0"></asp:ListItem>
                </asp:DropDownList>
            </span>
        </div>
        <div class="field">
            <asp:LinkButton ID="btnQuery" runat="server" CssClass="btn" OnClick="btnQuery_Click">查询</asp:LinkButton>
            <asp:LinkButton ID="btnReset" runat="server" CssClass="btn" OnClick="btnReset_Click">重置</asp:LinkButton>
        </div>
    </fieldset>
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="标题" DataField="Title"/>
            <asp:BoundField HeaderText="姓名" DataField="Name" HeaderStyle-Width="80" />
            <asp:BoundField HeaderText="Email" DataField="Email" HeaderStyle-Width="120" />
            <asp:BoundField HeaderText="公司" DataField="Company" HeaderStyle-Width="120" />            
            <asp:BoundField HeaderText="电话" DataField="Phone" HeaderStyle-Width="80" />
            <asp:BoundField HeaderText="传真" DataField="Fax" HeaderStyle-Width="80" />
            <asp:TemplateField HeaderText="已处理" HeaderStyle-Width="60">
                <ItemTemplate>
                    <%#Convert.ToBoolean(Eval("IsReplied")) ? "是" : "否"%></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="100">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("view("+Eval("Id")+")") %>;return false;'>查看</a>
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
    function view(id) {
        top.Dialog.open({ Title: '查看留言', URL: 'Module/FeedbackShow.aspx?node=<%=NodeCode %>&id=' + id, Width: 600, Height: 600 });
    }

    function del(id) {
        if (confirm('删除后不能恢复，确定要删除吗？')) {
            $.post(
                "../System/Ajax.ashx",
                { Action: "FeedbackDelete", Id: id },
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
