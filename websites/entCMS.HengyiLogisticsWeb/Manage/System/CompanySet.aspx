<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="CompanySet.aspx.cs" Inherits="entCMS.Manage.CompanySet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../KindEditor/kindeditor-min.js" type="text/javascript"></script>
    <script src="../KindEditor/lang/zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#<%=txtSummary.ClientID %>', {
                height: 300,
                allowImageUpload: true,
                allowFlashUpload: true,
                allowMediaUpload: false,
                allowFileUpload: true,
                allowFileManager: true,
                uploadJson: '../KE_UploadManager.ashx',
                fileManagerJson: '../KE_FileManager.ashx',
                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form')[0].submit();
                    });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    公司信息
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：系统管理 >> 公司信息
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                所属语言：
            </td>
            <td>
                <div class="select"><div>
                <asp:DropDownList ID="ddlLanguage" runat="server" Enabled="false">
                </asp:DropDownList>
                </div></div>
                <asp:CompareValidator ID="cvLang" runat="server" ControlToValidate="ddlLanguage" ValueToCompare="0" Type="Integer" Operator="GreaterThan" ErrorMessage="请选择所属语言"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入公司名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司地址：
            </td>
            <td>
                <asp:TextBox ID="txtAddr" runat="server" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                邮编：
            </td>
            <td>
                <asp:TextBox ID="txtZipCode" runat="server" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司电话：
            </td>
            <td>
                <asp:TextBox ID="txtTel" runat="server" Text="" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司传真：
            </td>
            <td>
                <asp:TextBox ID="txtFax" runat="server" Text="" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司邮箱：
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Text="" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司网址：
            </td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Width="350" Text=""></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                公司简介：
            </td>
            <td>
                <asp:TextBox ID="txtSummary" runat="server" Width="80%" Height="100" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" OnClientClick="editor.sync();">保存</asp:LinkButton>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
