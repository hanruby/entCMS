<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="ImageList.aspx.cs" Inherits="entCMS.Manage.Module.ImageList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    图片列表
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：内容管理<asp:Label ID="lblPosition" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
    <a href="ImageAdd.aspx?node=<%=NodeCode %>" class="btn">添加</a>
    <a href="javascript:void(0);" onclick="return copyto();" class="btn">复制到</a>
    <a href="javascript:void(0);" onclick="return moveto();" class="btn">移动到</a>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <fieldset>
        <legend>查询框</legend>
        <div class="field">
            <label>图片名称</label><span><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></span>
            <label>标签</label><span><asp:TextBox ID="txtTags" runat="server"></asp:TextBox></span>
        </div>
        <div class="field">
            <label>首页显示</label>
            <span>
                <div class="select"><div>
                <asp:DropDownList ID="ddlIndex" runat="server">
                    <asp:ListItem Value="-1" Text="- 请选择 -"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                </asp:DropDownList>
                </div></div>
            </span>
            <label>置顶显示</label>
            <span>
                <div class="select"><div>
                <asp:DropDownList ID="ddlTop" runat="server">
                    <asp:ListItem Value="-1" Text="- 请选择 -"></asp:ListItem>
                    <asp:ListItem Value="1" Text="是"></asp:ListItem>
                    <asp:ListItem Value="0" Text="否"></asp:ListItem>
                </asp:DropDownList>
                </div></div>
            </span>
            <label style="display:none">审核状态</label>
            <span style="display:none">
                <div class="select"><div>
                <asp:DropDownList ID="ddlAudit" runat="server" Visible="false">
                    <asp:ListItem Value="-1" Text="- 请选择 -"></asp:ListItem>
                    <asp:ListItem Value="0" Text="未审核"></asp:ListItem>
                    <asp:ListItem Value="1" Text="已审核"></asp:ListItem>
                    <asp:ListItem Value="2" Text="未通过"></asp:ListItem>
                </asp:DropDownList>
                </div></div>
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
            <asp:TemplateField HeaderStyle-Width="20">
                <HeaderTemplate>
                    <input type="checkbox" id="chkAll" name="chkAll" onclick="checkAll(this);" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input type="checkbox" name="chkId" value='<%#Eval("Id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="20">
                <ItemTemplate>
                    <a href='<%#Eval("SmallPic") %>' class='img' onclick='top.$.fancybox.open({href: this.href, hideOnContentClick: true, live: false});return false;'><%#(string.IsNullOrEmpty(Eval("SmallPic").ToString())?"":"图") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="图片名称" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <%#GetTitle(Container.DataItem) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="推荐" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("enableIndex(this, \""+Eval("Id")+"\", "+Eval("IsAudit")+")") %>;return false;'><%#Convert.ToBoolean(Eval("IsIndex"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="置顶" HeaderStyle-Width="60">
                <ItemTemplate>
                    <a href='javascript:void(0);' onclick='<%#("enableTop(this, \""+Eval("Id")+"\", "+Eval("IsAudit")+")") %>;return false;'><%#Convert.ToBoolean(Eval("isTop"))?"是":"否" %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="点击率" DataField="Hits" HeaderStyle-Width="60" />
            <asp:BoundField HeaderText="添加时间" DataField="AddTime" HeaderStyle-Width="120" Visible="false" />
            <asp:BoundField HeaderText="更新时间" DataField="EditTime" HeaderStyle-Width="120" />
            <asp:TemplateField HeaderText="审核状态" HeaderStyle-Width="60" Visible="false">
                <ItemTemplate>
                    <%#getAuditStatus(Container.DataItem) %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作" HeaderStyle-Width="100">
                <ItemTemplate>
                    <a href='ImageAdd.aspx?node=<%#Eval("NodeCode") %>&id=<%#Eval("Id") %>&action=edit' onclick='<%#("return edit(\""+Eval("Id")+"\");")%>'>编辑</a>
                    <a href='javascript:void(0);' onclick='<%#("return del(\""+Eval("Id")+"\", 1);")%>'>删除</a>
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
        function enableIndex(obj, id, a) {
            if (a == 1) {
                var v = obj.innerHTML;
                $.post(
                    '<%=GetClientUrl("~/Manage/System/Ajax.ashx") %>',
                    { Action: "NewsEnableIndex", Id: id },
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
                alert('图片未审核，不允许首页显示。');
            }
            else if (a == 2) {
                alert('图片审核未通过，不允许首页显示。');
            }
            else {
                alert('图片已删除，不允许首页显示。');
            }
        }

        function enableTop(obj, id, a) {
            if (a == 1) {
                var v = obj.innerHTML;
                $.post(
                    '<%=GetClientUrl("~/Manage/System/Ajax.ashx") %>',
                    { Action: "NewsEnableTop", Id: id },
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
                alert('图片未审核，不允许置顶。');
            }
            else if (a == 2) {
                alert('图片审核未通过，不允许置顶。');
            }
            else {
                alert('图片已删除，不允许置顶。');
            }
        }

        function edit(id) {
            return true;
        }
        function del(id, t) {
            if (confirm('确定要删除吗？')) {
                showProgress();
                $.post(
                    '<%=GetClientUrl("~/Manage/System/Ajax.ashx") %>',
                    { Action: "NewsDelete", Id: id, Type: t },
                    function (data, textStatus) {
                        hideProgress();
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

        function audit(node, id) {
            top.Dialog.open({ Title: '审核', Width: 400, Height: 300, URL: 'Module/NewsAudit.aspx?node' + node + '&id=' + id });
            return false;
        }

        function checkAll(obj) {
            $("input[type=checkbox][name=chkId]").each(function (i, e) {
                $(this).attr("checked", obj.checked);
            });
        }

        function copyto() {
            if ($('input[type=checkbox][name=chkId]:checked').length == 0) {
                alert('请选择需要被复制的数据！');
                return false;
            }
            var id = '';
            $('input[type=checkbox][name=chkId]:checked').each(function (i, e) {
                id += (',' + $(this).val());
            });
            if (id.length > 0) id = id.substring(1);
            top.Dialog.open({ Title: '复制到...', Width: 700, Height: 500, URL: 'Module/NewsCopyTo.aspx?node=<%=NodeCode %>&type=0|3&id=' + id });
            return false;
        }

        function moveto() {
            if ($('input[type=checkbox][name=chkId]:checked').length == 0) {
                alert('请选择需要被移动的数据！');
                return false;
            }
            var id = '';
            $('input[type=checkbox][name=chkId]:checked').each(function (i, e) {
                id += (',' + $(this).val());
            });
            if (id.length > 0) id = id.substring(1);
            top.Dialog.open({ Title: '移动到...', Width: 700, Height: 500, URL: 'Module/NewsMoveTo.aspx?node=<%=NodeCode %>&type=0|3&id=' + id });
            return false;
        }
    </script>
</asp:Content>
