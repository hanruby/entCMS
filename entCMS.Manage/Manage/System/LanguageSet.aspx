<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="LanguageSet.aspx.cs" Inherits="entCMS.Manage.LanguageSet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hd{ border-bottom: 1px solid #ccc; padding:0px; color:#555; padding-top:10px;}
        .hd h3 { float:left; margin:0px; margin-left:10px; background-color:#f8f8f8; width:100px; text-align:center; line-height:2em; font-size:12px; font-weight:bold; cursor: pointer;}
        .hd h3.cur { background-color: #1F75B7; color: #fff }
        .tab { padding: 15px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    语言设置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：系统管理 >> 系统设置 >> 语言列表 >> 语言设置
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
<div class="hd">
    <h3 class="">常量设置</h3>
    <h3 class="">变量设置</h3>
    <asp:HiddenField ID="hidTab" runat="server" Value="0"/>
    <div class="clear"></div>
</div>
<div class="tab" style="display:none;">
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td></td>
            <td colspan="3"><b>公司信息相关：</b></td>
        </tr>
        <tr>
            <td class="col">
                公司地址：
            </td>
            <td>
                <asp:TextBox ID="txtAddr" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                公司邮编：
            </td>
            <td>
                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司电话：
            </td>
            <td>
                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                公司传真：
            </td>
            <td>
                <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司邮箱：
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                公司网址：
            </td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td></td>
            <td colspan="3"><b>全局：</b></td>
        </tr>
        <tr>
            <td class="col">
                首页：
            </td>
            <td>
                <asp:TextBox ID="txtHome" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                当前位置：
            </td>
            <td>
                <asp:TextBox ID="txtCurPos" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                更多：
            </td>
            <td>
                <asp:TextBox ID="txtMore" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                无相关内容：
            </td>
            <td>
                <asp:TextBox ID="txtNoData" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                搜索按钮：
            </td>
            <td>
                <asp:TextBox ID="txtSearchButtonText" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                搜索空关键字：
            </td>
            <td>
                <asp:TextBox ID="txtSearchEmptyKeyword" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td></td>
            <td colspan="3"><b>首页相关：</b></td>
        </tr>
        <tr>
            <td class="col">
                关于我们：
            </td>
            <td>
                <asp:TextBox ID="txtAboutUs" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                联系我们：
            </td>
            <td>
                <asp:TextBox ID="txtContactUs" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                最新新闻：
            </td>
            <td>
                <asp:TextBox ID="txtLatestNews" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                新闻列表：
            </td>
            <td>
                <asp:TextBox ID="txtNewsList" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                最新产品：
            </td>
            <td>
                <asp:TextBox ID="txtNewProducts" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                产品列表：
            </td>
            <td>
                <asp:TextBox ID="txtProductList" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td></td>
            <td colspan="3"><b>详细内容相关：</b></td>
        </tr>
        <tr>
            <td class="col">
                日期：
            </td>
            <td>
                <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                作者：
            </td>
            <td>
                <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                点击率：
            </td>
            <td>
                <asp:TextBox ID="txtHits" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                来源：
            </td>
            <td>
                <asp:TextBox ID="txtSource" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td></td>
            <td colspan="3"><b>分页相关：</b></td>
        </tr>
        <tr>
            <td class="col">
                分页首页：
            </td>
            <td>
                <asp:TextBox ID="txtFirstPage" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                分页前页：
            </td>
            <td>
                <asp:TextBox ID="txtPrevPage" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                分页后页：
            </td>
            <td>
                <asp:TextBox ID="txtNextPage" runat="server"></asp:TextBox>
            </td>
            <td class="col">
                分页尾页：
            </td>
            <td>
                <asp:TextBox ID="txtLastPage" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                分页跳转：
            </td>
            <td>
                <asp:TextBox ID="txtGoPage" runat="server"></asp:TextBox>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col" style="background-color:#fff;"></td>
            <td><asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton></td>
        </tr>
    </table>
</div>
<div class="tab" style="display:none;">
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td></td>
            <td>每行定义一个变量，变量与值用等号连接，如：ILoveYou=我爱你</td>
        </tr>
        <tr>
            <td class="col">
                变量：
            </td>
            <td>
                <asp:TextBox ID="txtVars" runat="server" TextMode="MultiLine" Height="300" Width="80%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:LinkButton ID="btnSave2" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton></td>
        </tr>
    </table>
</div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
    <script type="text/javascript">
        $(function () {
            $('h3').each(function (i, e) {
                $(this).click(function () {
                    $('h3').removeClass('cur');
                    $('h3:eq(' + i + ')').addClass('cur');
                    $('#<%=hidTab.ClientID %>').val(i.toString());
                    $('.tab').css('display', 'none');
                    $('.tab:eq(' + i + ')').css('display', '');
                });
            });

            $('h3:first').addClass('cur');
            $('.tab:first').css('display', '');
        });
    </script>
</asp:Content>
