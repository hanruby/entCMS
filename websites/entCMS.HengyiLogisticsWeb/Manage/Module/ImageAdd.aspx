<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="ImageAdd.aspx.cs" Inherits="entCMS.Manage.Module.ImageAdd" %>
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

    <script src="../KindEditor/kindeditor-min.js" type="text/javascript"></script>
    <script src="../KindEditor/lang/zh_CN.js" type="text/javascript"></script>
    <script src="../My97DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#<%=txtContent.ClientID %>', {
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

            K('#getSummary').click(function (e) {
                var text = editor.html();
                // 替换img, embed等标签
                text = text.replace(/(<script[^>]*?>.*?<\/script>)/ig, '');
                text = text.replace(/<(.[^>]*)>/ig, '');
                text = text.replace(/([\r\n])[\s]+/ig, '');
                text = text.replace(/-->/ig, '');
                text = text.replace(/<\!--.*/ig, '');
                text = text.replace(/&(quot|#34);/ig, '\"');
                text = text.replace(/&(amp|#38);/ig, '&');
                text = text.replace(/&(lt|#60);/ig, '<');
                text = text.replace(/&(gt|#62);/ig, '>');
                text = text.replace(/&(nbsp|#160);/ig, ' ');
                text = text.replace(/&(iexcl|#161);/ig, '\xa1');
                text = text.replace(/&(cent|#162);/ig, '\xa2');
                text = text.replace(/&(pound|#163);/ig, '\xa3');
                text = text.replace(/&(copy|#169);/ig, '\xa9');
                text = text.replace(/&#(\d+);/ig, ' ');
                /*
                text = text.replace('<', '');
                text = text.replace('>', '');
                text = text.replace('\r\n', '');
                */
                if (text.length > 200) text = text.substring(0, 200) + '......';

                $('#<%=txtSummary.ClientID %>').val(text);

                return false;
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    添加图片
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：内容管理 >> 添加图片
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
                <asp:DropDownList ID="ddlCatalog" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCatalog" runat="server" ControlToValidate="ddlCatalog" ErrorMessage="请选择栏目" Display="None"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                图片名称：
            </td>
            <td>
                <asp:TextBox ID="txtTitle" CssClass="input" runat="server" Width="80%"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="请输入图片名称" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                缩略图：
            </td>
            <td>
                <asp:HiddenField ID="hidImages1" runat="server" />
                <span id="spanButtonPlaceholder1"></span><span class="tips">(最大 2.0MB)</span>
                <div id="fsUploadProgress1" class="flash"></div>
                <div id="preview1" class="preview"></div>
                <div class="clear"></div>
            </td>
        </tr>
        <tr>
            <td class="col">
                内容：
            </td>
            <td>
                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Width="80%" Rows="8"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvContent" runat="server" ControlToValidate="txtContent" ErrorMessage="请输入文章内容" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                摘要：
            </td>
            <td>
                <div><a id='getSummary' href='javascript:void(0);'>提取摘要</a></div>
                <asp:TextBox ID="txtSummary" CssClass="input" runat="server" TextMode="MultiLine" Width="80%" Rows="3"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td class="col">
                专题：
            </td>
            <td>
                <asp:CheckBoxList ID="cblZt" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="col">
                标签：
            </td>
            <td>
                <asp:TextBox ID="txtTags" CssClass="input" runat="server" Width="50%"></asp:TextBox>
                <span>多个标签可以用（,）分开。</span>
            </td>
        </tr>
        <tr style="display:none">
            <td class="col">
                作者：
            </td>
            <td>
                <asp:TextBox ID="txtAuthor" CssClass="input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr style="display:none">
            <td class="col">
                来源：
            </td>
            <td>
                <asp:TextBox ID="txtSource" CssClass="input" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                点击率：
            </td>
            <td>
                <asp:TextBox ID="txtHits" CssClass="input" runat="server" Text="0"></asp:TextBox>
                <asp:CompareValidator ID="cvHits" runat="server" ControlToValidate="txtHits" ValueToCompare="0" Type="Integer" Operator="GreaterThanEqual" ErrorMessage="请输入正整数"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                时间：
            </td>
            <td>
                <asp:TextBox ID="txtTime" CssClass="input" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:ValidationSummary ID="vs" runat="server" ShowMessageBox="true" ShowSummary="false" /></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" OnClientClick="editor.sync();$('#getSummary').click();">保存</asp:LinkButton>
                <a href="ImageList.aspx?node=<%=NodeCode %>" class="btn">取消</a>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
<script type="text/javascript">
    $(function () {
        var images1 = $('#<%=hidImages1.ClientID %>').val().split('|');
        for (var i = 0; i < images1.length; i++) {
            if (images1[i].length > 4) {
                addImage(1, images1[i]);
            }
        }
    });
</script>
<script type="text/javascript">
    function addImage(id, imgfile) {
        if (id == 1) {
            $('#<%=hidImages1.ClientID %>').val(imgfile);
            $("#preview" + id).html('');
        }
        var div = $("<div/>"); //.css({ "background-image": "url(" + imgfile + ")" });
        var img = $("<img/>");
        img.attr('title', '点击查看大图').attr('src', imgfile).appendTo(div).click(function () {
            top.$.fancybox.open({ href: imgfile.replace('_s', '_b'), live: true });
        });
        var btn = $("<div class='cancel' title='点击删除图片'></div>").appendTo(div).click(function () {
            div.remove();
            if (id == 1) {
                $('#<%=hidImages1.ClientID %>').val('');
            }
        });
        div.appendTo($("#preview" + id));
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
            if (this.customSettings.id == 1) file.id = "singlefile";
            var progress = new FileProgress(file, this.customSettings.progressTarget);
            progress.setStatus("正在上传...");
            progress.toggleCancel(true, this);
        }
        catch (ex) { }

        return true;
    }
    function uploadProgress(file, bytesLoaded, bytesTotal) {
        try {
            if (this.customSettings.id == 1) file.id = "singlefile";
            var percent = Math.ceil((bytesLoaded / bytesTotal) * 100);
            var progress = new FileProgress(file, this.customSettings.progressTarget);
            progress.setProgress(percent);
            progress.setStatus("正在上传(" + percent + "%)，请稍候...");
        } catch (ex) {
            this.debug(ex);
        }
    }
    function uploadSuccess(file, serverData) {
        try {
            if (this.customSettings.id == 1) file.id = "singlefile"; // This makes it so FileProgress only makes a single UI element, instead of one for each file
            var progress = new FileProgress(file, this.customSettings.progressTarget);
            progress.setComplete();
            progress.setStatus("上传完成。");
            progress.toggleCancel(false);

            if (serverData === " ") {
                this.customSettings.upload_successful = false;
            } else {
                this.customSettings.upload_successful = true;
                var id = this.customSettings.id;
                addImage(id, serverData);
            }

        } catch (e) {
        }
    }
    var swfu1; // swfupload对象
    $(function () {
        // 初始化swfupload
        var settings_object1 = {
            debug: false,
            upload_url: '<%=GetClientUrl("~/Manage/KE_UploadManager.ashx") %>',
            flash_url: '<%=GetClientUrl("~/Manage/swfupload/swfupload.swf")%>',
            flash9_url: '<%=GetClientUrl("~/Manage/swfupload/swfupload_fp9.swf")%>',
            file_post_name: "imgFile",
            file_size_limit: "2 MB",
            file_types: "*.jpg;*.jpeg;*.gif;*.png",
            file_types_description: "全部图片文件",
            file_upload_limit: 100,
            file_queue_limit: 1,
            button_action: SWFUpload.BUTTON_ACTION.SELECT_FILE, // 一次选择一个文件
            button_window_mode: 'transparent',

            file_dialog_complete_handler: fileDialogComplete,
            upload_start_handler: uploadStart,
            upload_progress_handler: uploadProgress,
            upload_success_handler: uploadSuccess,

            // Button Settings
            button_image_url: '<%=GetClientUrl("~/Manage/swfupload/XPButtonUploadText_61x22.png") %>',
            //button_text: '上传',
            button_placeholder_id: "spanButtonPlaceholder1",
            button_width: 61,
            button_height: 22,

            post_params: {
                "Action": "swfupload",
                "type": 2,
                "dir": "image",
                "configFile": '<%=configFile.Replace("\\","\\\\")%>'
            },
            custom_settings: {
                progressTarget: "fsUploadProgress1",
                upload_successful: false,
                id: 1
            }
        };
        swfu1 = new SWFUpload(settings_object1);
    });
    </script>
</asp:Content>