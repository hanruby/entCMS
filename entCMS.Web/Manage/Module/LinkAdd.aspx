<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="LinkAdd.aspx.cs" Inherits="entCMS.Manage.Module.LinkAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .preview{}
    .preview div{float:left;position:relative;display:block;width:103px;height:103px;margin:2px;}
    .preview div.cancel {z-index:10;position:absolute;display:block;top:2px;right:0px;height:14px;width:14px;background:url(../swfupload/cancelbutton.gif) no-repeat 0 0;pointer:hand;}
    .preview div.cancel:hover { background-position:-14px 0px; }
    .preview img {z-index:1;position:absolute; padding:2px;border:1px solid #ccc; width:100px; height:100px;}
    </style>
    <link type="text/css" href="../SWFUpload/swfupload.css" rel="Stylesheet" />
    <script type="text/javascript" src="../SWFUpload/swfupload.js"></script>
    <script type="text/javascript" src="../SWFUpload/plugins/swfupload.swfobject.js"></script>
    <script type="text/javascript" src="../SWFUpload/plugins/swfupload.queue.js"></script>
    <script type="text/javascript" src="../SWFUpload/plugins/swfupload.progress.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    添加链接
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：内容管理 >> 链接管理 >> 添加链接
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidID" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                类别：
            </td>
            <td>
                <div class="select"><div>
                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                </div></div>
                <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlType" ErrorMessage="请选择类别" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                地址：
            </td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Width="350" Text="http://"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="txtUrl" ErrorMessage="请输入地址" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                logo图标：
            </td>
            <td>
                <asp:HiddenField ID="hidPicType" runat="server" Value="0" />
                <div id='localPic'>
                    <asp:TextBox Id="txtLogo" runat="server" Width="50%" onblur="addImage(this.value)"></asp:TextBox>
                    <button onclick="changeDiv(1);return false;">本地上传</button>
                </div>
                <div id='remotePic' style='display:none;'>
                    <span id="spanButtonPlaceholder"></span><span class="tips">(最大 1.0MB)</span><button onclick="changeDiv(0);return false;">网络图片</button>
                    <div class="flash" id="fsUploadProgress"></div>
                </div>
                <div class="preview"></div>
            </td>
        </tr>
        <tr>
            <td class="col">
                排序号：
            </td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Text="0" Width="32px">0</asp:TextBox>
                <asp:CompareValidator ID="cvOrder" runat="server" ControlToValidate="txtOrder" ValueToCompare="0" Type="Integer" Operator="GreaterThanEqual" ErrorMessage="请输入正整数"></asp:CompareValidator>
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
                <a href='LinkList.aspx?node=<%=NodeCode %>' class="btn">取消</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
<script type="text/javascript">
    function changeDiv(t) {
        var hidPicType = $('#<%=hidPicType.ClientID %>');
        var localPic = $('#localPic');
        var remotePic = $('#remotePic');

        hidPicType.val(t);

        localPic.toggle();
        remotePic.toggle();
    }
    
    function del() {
        var pic = $('#<%=txtLogo.ClientID %>');

        $.post('../System/Ajax.ashx',
            { Action: "DeleteImage", FileName: pic.val() },
            function (data, textStatus) {
                if (data.result) {
                    alert('删除成功！如果需要LOGO，请重新上传。');
                    pic.val('');
                }
                else {
                    alert(data.msg);
                }
            },
            "json"
        );
    }
</script>

<script type="text/javascript">
    $(function () {
        addImage($('#<%=txtLogo.ClientID %>').val());
    });
    </script>

    <script type="text/javascript">
        function addImage(imgfile) {
            if (imgfile.length == 0) return;

            $('#<%=txtLogo.ClientID %>').val(imgfile);
            $(".preview").html('');
            var div = $("<div/>"); //.css({ "background-image": "url(" + imgfile + ")" });
            var img = $("<img/>");
            img.attr('title', '点击查看大图').attr('src', imgfile).appendTo(div).click(function () {
                top.$.fancybox.open({ href: imgfile.replace('_s', '_b'), live: true });
            });
            var btn = $("<div class='cancel' title='点击删除图片'></div>").appendTo(div).click(function () {
                div.remove();
                $('#<%=txtLogo.ClientID %>').val('');
            });
            div.appendTo($(".preview"));
        }
        function fileDialogComplete(numFilesSelected, numFilesQueued) {
            try {
                /* I want auto start the upload and I can do that here */
                this.startUpload();
            } catch (ex) {
                this.debug(ex);
            }
        }
        function uploadStart(file) {
            try {
                /* I don't want to do any file validation or anything,  I'll just update the UI and
                return true to indicate that the upload should start.
                It's important to update the UI here because in Linux no uploadProgress events are called. The best
                we can do is say we are uploading.
                */
                file.id = "singlefile";
                var progress = new FileProgress(file, this.customSettings.progressTarget);
                progress.setStatus("正在上传...");
                progress.toggleCancel(true, this);
            }
            catch (ex) { }

            return true;
        }
        function uploadProgress(file, bytesLoaded, bytesTotal) {
            try {
                var percent = Math.ceil((bytesLoaded / bytesTotal) * 100);
                file.id = "singlefile";
                var progress = new FileProgress(file, this.customSettings.progressTarget);
                progress.setProgress(percent);
                progress.setStatus("正在上传...");
            } catch (ex) {
                this.debug(ex);
            }
        }
        function uploadSuccess(file, serverData) {
            try {
                file.id = "singlefile"; // This makes it so FileProgress only makes a single UI element, instead of one for each file
                var progress = new FileProgress(file, this.customSettings.progressTarget);
                progress.setComplete();
                progress.setStatus("上传完成。");
                progress.toggleCancel(false);

                if (serverData === " ") {
                    this.customSettings.upload_successful = false;
                } else {
                    this.customSettings.upload_successful = true;
                    addImage(serverData);
                }

            } catch (e) {
            }
        }
        var swfu; // swfupload对象
        $(function () {
            // 初始化swfupload
            var settings_object = {
                debug: false,
                upload_url: '<%=GetClientUrl("~/Manage/KE_UploadManager.ashx") %>',
                flash_url: '<%=GetClientUrl("~/Manage/swfupload/swfupload.swf")%>',
                //flash9_url: "http://www.swfupload.org/swfupload_fp9.swf",
                file_post_name: "imgFile",
                file_size_limit: "1 MB",
                file_types: "*.jpg;*.jpeg;*.gif;*.png",
                file_types_description: "全部图片文件",
                file_upload_limit: 100,
                file_queue_limit: 0,
                button_action: SWFUpload.BUTTON_ACTION.SELECT_FILE, // 一次选择一个文件
                button_window_mode: 'transparent',

                file_dialog_complete_handler: fileDialogComplete,
                upload_start_handler: uploadStart,
                upload_progress_handler: uploadProgress,
                upload_success_handler: uploadSuccess,

                // Button Settings
                button_image_url: '<%=GetClientUrl("~/Manage/swfupload/XPButtonUploadText_61x22.png") %>',
                //button_text: '上传',
                button_placeholder_id: "spanButtonPlaceholder",
                button_width: 61,
                button_height: 22,

                post_params: {
                    "Action": "swfupload",
                    "dir": "image",
                    "configFile": ''
                },
                custom_settings: {
                    progressTarget: "fsUploadProgress",
                    upload_successful: false
                }
            };
            swfu = new SWFUpload(settings_object);
        });
    </script>
</asp:Content>
