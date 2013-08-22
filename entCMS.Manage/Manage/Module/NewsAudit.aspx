<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="NewsAudit.aspx.cs" Inherits="entCMS.Manage.Module.NewsAudit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function TT(s) {
            document.getElementById("<%=txtComment.ClientID %>").value = "";
            if (s == "2") {
                document.getElementById("tr1").style.display = '';
            }
            else {
                document.getElementById("tr1").style.display = 'none';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
文章审核
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：内容管理 >> 文章审核
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <div id="auditBox">
        <table width="100%" class="detail">
            <tr>
                <td class="col">
                    文章标题：
                </td>
                <td>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="col">
                    审核情况：
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlResult" runat="server" onchange="TT(this.value);">
                        <asp:ListItem Value="1" Text="审核通过"></asp:ListItem>
                        <asp:ListItem Value="2" Text="审核不通过"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="tr1" style="display: none;">
                <td class="col">
                    不通过的理由：
                </td>
                <td align="left">
                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="90%" Rows="6"></asp:TextBox>
                </td>
            </tr>
            <tr style="display:none">
                <td class="col">
                    是否加分：
                </td>
                <td align="left">
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="加分" Checked="true" />
                </td>
            </tr>
            <tr style="display:none">
                <td class="col">
                    选择其他加分部门：
                </td>
                <td align="left">
                    <asp:TextBox ID="txt1department" runat="server" Height="106px" TextMode="MultiLine"
                        Width="215px"></asp:TextBox><a href="javascript:;" onclick="Add();">选择</a>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left">
                    <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">提交审核</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
