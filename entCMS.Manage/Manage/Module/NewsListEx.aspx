<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="NewsListEx.aspx.cs" Inherits="entCMS.Manage.Module.NewsListEx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/dataLoading.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.tooltip.js" type="text/javascript"></script>
    <!-- 图片预览-->
    <script src="../Scripts/jquery.shadow.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ifixpng.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.fancyzoom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('a.img').fancyzoom({ imgDir: '/Manage/Images/fancyzoom/', Speed: 400, showoverlay: false });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
文章列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：内容管理<asp:Label ID="lblPosition" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href="NewsAdd.aspx?node=<%=NodeCode %>" class="btn">添加</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset>
        <legend>查询框</legend>
        <div class="field">
            <label>标题</label><span><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></span>
            <label>来源</label><span><asp:TextBox ID="txtSource" runat="server"></asp:TextBox></span>
            <label>作者</label><span><asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox></span>
            <label>标签</label><span><asp:TextBox ID="txtTags" runat="server"></asp:TextBox></span>
        </div>
        <div class="field">
            <label>首页显示</label>
            <span>
                <asp:DropDownList ID="ddlIndex" runat="server">
                    <asp:ListItem Value="-1" Text="- 请选择 -"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                </asp:DropDownList>
            </span>
            <label>置顶显示</label>
            <span>
                <asp:DropDownList ID="ddlTop" runat="server">
                    <asp:ListItem Value="-1" Text="- 请选择 -"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                </asp:DropDownList>
            </span>
            <label>审核状态</label>
            <span>
                <asp:DropDownList ID="ddlAudit" runat="server">
                    <asp:ListItem Value="-1" Text="- 请选择 -"></asp:ListItem>
                    <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                    <asp:ListItem Value="1" Text="已审核"></asp:ListItem>
                    <asp:ListItem Value="2" Text="未通过"></asp:ListItem>
                    <asp:ListItem Value="3" Text="已删除"></asp:ListItem>
                </asp:DropDownList>
            </span>
        </div>
        <div class="field">    
            <label>添加时间</label><span><asp:TextBox ID="txtAddTime1" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'});"></asp:TextBox> - <asp:TextBox ID="txtAddTime2" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'});"></asp:TextBox></span>
            <label>更新时间</label><span><asp:TextBox ID="txtEditTime1" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'});"></asp:TextBox> - <asp:TextBox ID="txtEditTime2" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm'});"></asp:TextBox></span>
        </div>
        <div class="field">
            <asp:LinkButton ID="btnQuery" runat="server" CssClass="btn" OnClick="btnQuery_Click">查询</asp:LinkButton>
            <asp:LinkButton ID="btnReset" runat="server" CssClass="btn" OnClick="btnReset_Click">重置</asp:LinkButton>
        </div>
    </fieldset>
    <asp:GridView ID="gv" runat="server" CssClass="SmartGridView" AutoGenerateColumns="False" Width="100%" 
        OnRowDataBound="gv_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="标题" DataField="Title" />
            <asp:BoundField HeaderText="来源" DataField="Source" HeaderStyle-Width="100" />
            <asp:BoundField HeaderText="作者" DataField="Author" HeaderStyle-Width="100" />
            <asp:BoundField HeaderText="点击率" DataField="Hits" HeaderStyle-Width="60" />
            <asp:BoundField HeaderText="添加时间" DataField="AddTime" HeaderStyle-Width="100" />
            <asp:BoundField HeaderText="更新时间" DataField="EditTime" HeaderStyle-Width="100" />
            <asp:TemplateField HeaderText="首页显示" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("enableIndex(this, \""+Eval("Id")+"\", "+Eval("IsAudit")+")") %>;return false;'><%#Convert.ToBoolean(Eval("IsIndex"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="置顶显示" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("enableTop(this, \""+Eval("Id")+"\", "+Eval("IsAudit")+")") %>;return false;'><%#Convert.ToBoolean(Eval("isTop"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="审核状态" HeaderStyle-Width="60">
                <ItemTemplate>
                    <%#getAuditStatus(Container.DataItem) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="缩略图" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='<%#Eval("SmallPic") %>' class='img'>查看</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="180">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" Visible="false">编辑</asp:LinkButton>
                    <asp:LinkButton ID="btnDel" runat="server" Visible="false">删除</asp:LinkButton><asp:LinkButton ID="btnRst" runat="server" Visible="false">恢复</asp:LinkButton>
                    <asp:LinkButton ID="btnDelete" runat="server" Visible="false">彻底删除</asp:LinkButton>
                    <asp:LinkButton ID="btnAudit" runat="server" Visible="false">审核</asp:LinkButton>
                    <a href='/NewsDetails.aspx?id=<%#Eval("Id") %>' target="_blank">预览</a>
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
        function enableIndex(obj, id, a) {
            if (a == 1) {
                var v = obj.innerHTML;
                $.post(
                    "../Ajax.ashx",
                    { Action: "EnableIndex", Id: id },
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
            else if (a == 0) {
                alert('文章未审核，不允许首页显示。');
            }
            else if (a == 2) {
                alert('文章审核未通过，不允许首页显示。');
            }
            else {
                alert('文章已删除，不允许首页显示。');
            }
        }

        function enableTop(obj, id, a) {
            if (a == 1) {
                var v = obj.innerHTML;
                $.post(
                    "../Ajax.ashx",
                    { Action: "EnableTop", Id: id },
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
            else if (a == 0) {
                alert('文章未审核，不允许置顶。');
            }
            else if (a == 2) {
                alert('文章审核未通过，不允许置顶。');
            }
            else {
                alert('文章已删除，不允许置顶。');
            }
        }

        function edit(id) {
            return true;
        }
        function del(id, t) {
            if (confirm('确定要删除吗？')) {
                $.post(
                    "../Ajax.ashx",
                    { Action: "DeleteNews", Id: id, Type: t },
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
            return false;
        }
        function restore(id) {
            if (confirm('恢复后审批状态修改为“未审批”，确定要恢复吗？')) {
                $.post(
                    "../Ajax.ashx",
                    { Action: "RestoreNews", Id: id},
                    function (data, textStatus) {
                        if (data.result) {
                            alert('恢复成功！点“确定”后刷新页面。');
                            location.href = location.href;
                        }
                        else {
                            alert(data.msg);
                        }
                    },
                    "json"
                );
            }
            return false;
        }

        function audit(node, id) {
            return top.tipswindow('审核', 'iframe:Module/NewsAudit.aspx?node=' + node + '&id=' + id, '400', '300', 'true', '', 'true', '', 0);
        }

    </script>
</asp:Content>
