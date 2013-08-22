<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="AdAdd.aspx.cs" Inherits="entCMS.Manage.Plugins.AdAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- 图片预览-->
    <script src="../Scripts/jquery.shadow.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.ifixpng.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.fancyzoom.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
添加广告
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：其他管理 >> 广告管理 >> 添加广告
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                类型：
            </td>
            <td>
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Value="0" Text="飘窗"></asp:ListItem>
                    <asp:ListItem Value="1" Text="对联"></asp:ListItem>
                    <asp:ListItem Value="2" Text="左上角"></asp:ListItem>
                    <asp:ListItem Value="3" Text="右上角"></asp:ListItem>
                    <asp:ListItem Value="4" Text="左下角"></asp:ListItem>
                    <asp:ListItem Value="5" Text="右下角"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="col">
                标题：
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="请输入标题" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                图片一：
            </td>
            <td>
                <asp:HiddenField ID="hidPicType1" runat="server" Value="0" />
                <div id='localPic1'>
                    <asp:TextBox Id="txtPic1" runat="server" Width="50%"></asp:TextBox>
                    <button onclick="changeDiv(1, 1);return false;">本地上传</button>
                </div>
                <div id='remotePic1' style='display:none;'>
                    <asp:FileUpload ID="fuPic1" runat="server" />
                    <button onclick="changeDiv(1, 0);return false;">网络图片</button>
                </div>
                <img id='imgShow1' src='' alt='缩略图' style='display:none'/>
                <button onclick="previewImage(1);return false">预览</button>
            </td>
        </tr>
        <tr>
            <td class="col">
                链接地址一：
            </td>
            <td>
                <asp:TextBox ID="txtUrl1" runat="server" Width="350"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                图片二：
            </td>
            <td>
                <asp:HiddenField ID="hidPicType2" runat="server" Value="0" />
                <div id='localPic2'>
                    <asp:TextBox Id="txtPic2" runat="server" Width="50%"></asp:TextBox>
                    <button onclick="changeDiv(2, 1);return false;">本地上传</button>
                </div>
                <div id='remotePic2' style='display:none;'>
                    <asp:FileUpload ID="fuPic2" runat="server" />
                    <button onclick="changeDiv(2, 0);return false;">网络图片</button>
                </div>
                <img id='imgShow2' src='' alt='缩略图' style='display:none'/>
                <button onclick="previewImage(2);return false">预览</button>
            </td>
        </tr>
        <tr>
            <td class="col">
                链接地址二：
            </td>
            <td>
                <asp:TextBox ID="txtUrl2" runat="server" Width="350"></asp:TextBox>
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
                备注：
            </td>
            <td>
                <asp:TextBox ID="txtMemo" runat="server" TextMode="MultiLine" Width="80%" Rows="4"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>&nbsp;
                <a href='AdList.aspx?node=<%=NodeCode %>' class="btn">取消</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
<script type="text/javascript">
    function changeDiv(i, t) {
        var hidPicType;
        if(i==1)
            hidPicType = $('#<%=hidPicType1.ClientID %>');
        else if (i == 2)
            hidPicType = $('#<%=hidPicType2.ClientID %>');

        var localPic = $('#localPic' + i);
        var remotePic = $('#remotePic' + i);

        hidPicType.val(t);

        localPic.toggle();
        remotePic.toggle();
    }

    function previewImage(t) {
        var pic;
        if (t == 1)
            pic = $('#<%=txtPic1.ClientID %>');
        else if (t == 2)
            pic = $('#<%=txtPic2.ClientID %>');

        var img = $('#imgShow' + t);
        img.attr('src', pic.val());

        img.fancyzoom({ imgDir: '/Manage/Images/fancyzoom/', Speed: 400, showoverlay: false });

        img.click();
    }
</script>
</asp:Content>
