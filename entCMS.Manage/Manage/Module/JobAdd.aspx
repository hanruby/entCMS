<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="JobAdd.aspx.cs" Inherits="entCMS.Manage.Module.JobAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    添加职位
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：内容管理 >> 添加职位
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                所属栏目：
            </td>
            <td>
                <div class="select"><div>
                <asp:DropDownList ID="ddlCatalog" runat="server"></asp:DropDownList>
                </div></div>
                <asp:RequiredFieldValidator ID="rfvCatalog" runat="server" ControlToValidate="ddlCatalog" ErrorMessage="请选择栏目" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                职位名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" CssClass="input" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入职位" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                招聘人数：
            </td>
            <td>
                <asp:TextBox ID="txtNumbers" runat="server" Text="1" Width="32px"></asp:TextBox>
                <asp:CompareValidator ID="cvNumbers" runat="server" ControlToValidate="txtNumbers" ValueToCompare="0" Type="Integer" Operator="GreaterThan" ErrorMessage="请输入正整数"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                工作地点：
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" Width="200"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                工作职责
            </td>
            <td>
                <asp:TextBox ID="txtResponsibilities" runat="server" Width="400" Height="120" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvResponsibilities" runat="server" ControlToValidate="txtResponsibilities" ErrorMessage="请输入工作职责" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <span class="tips">1000个字以内</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                职位要求
            </td>
            <td>
                <asp:TextBox ID="txtRequirements" runat="server" Width="400" Height="120" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRequirements" runat="server" ControlToValidate="txtRequirements" ErrorMessage="请输入职位要求" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <span class="tips">1000个字以内</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                备注
            </td>
            <td>
                <asp:TextBox ID="txtRemark" runat="server" Width="400" Height="60" TextMode="MultiLine"></asp:TextBox>
                <span class="tips">500个字以内，如联系方式等信息</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                排序号：
            </td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Text="0" Width="32px"></asp:TextBox>
                <asp:CompareValidator ID="cvOrder" runat="server" ControlToValidate="txtOrder" ValueToCompare="0" Type="Integer" Operator="GreaterThanEqual" ErrorMessage="请输入正整数" Display="Dynamic"></asp:CompareValidator>
                <span class="tips">越小越靠前显示</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                是否启用：
            </td>
            <td>
                <asp:CheckBox ID="chkEnabled" runat="server" Text="启用" Checked="true" />
            </td>
        </tr>
        <tr>
            <td class="col">
                点击率：
            </td>
            <td>
                <asp:TextBox ID="txtHits" CssClass="input" runat="server" Text="0"></asp:TextBox>
                <asp:CompareValidator ID="cvHits" runat="server" ControlToValidate="txtHits" ValueToCompare="0" Type="Integer" Operator="GreaterThanEqual" ErrorMessage="请输入正整数" Display="Dynamic"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                到期时间：
            </td>
            <td>
                <asp:TextBox ID="txtEndTime" CssClass="input" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                <span class="tips">职位在设定到期时间后，前台会根据时间是否显示当前职位</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                发布时间：
            </td>
            <td>
                <asp:TextBox ID="txtTime" CssClass="input" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="false" ShowSummary="false" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>
                <a href="JobList.aspx?node=<%=NodeCode %>" class="btn">取消</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
