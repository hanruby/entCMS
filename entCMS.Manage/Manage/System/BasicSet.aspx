<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="BasicSet.aspx.cs" Inherits="entCMS.Manage.BasicSet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hd{ border-bottom: 1px solid #ccc; padding:0px; color:#555; padding-top:10px;}
        .hd h3 { float:left; margin:0px; margin-left:10px; background-color:#f8f8f8; width:100px; text-align:center; line-height:2em; font-size:12px; font-weight:bold; cursor: pointer;}
        .hd h3.cur { background-color: #1F75B7; color: #fff }
        .tab { padding: 15px; }
    </style>
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
    基本设置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：系统管理 >> 系统设置 >> 基本设置
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
<div class="hd">
    <h3 class="">基本设置</h3>
    <h3 class="">系统邮箱设置</h3>
    <asp:HiddenField ID="hidTab" runat="server" Value="0"/>
    <div class="clear"></div>
</div>
<div class="tab" style="display:none;">
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                网站名称：
            </td>
            <td>
                <asp:TextBox ID="txtWebName" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvWebName" runat="server" ControlToValidate="txtWebName" ErrorMessage="请输入网站名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                网站LOGO：
            </td>
            <td valign="middle">
                <asp:HiddenField ID="hidLogo" runat="server" />
                <span id="spanButtonPlaceholder"></span><span class="tips">(最大 1.0MB)</span>
                <div class="flash" id="fsUploadProgress"></div>
                <div class="preview"></div>
            </td>
        </tr>
        <tr>
            <td class="col">
                网站网址：
            </td>
            <td>
                <asp:TextBox ID="txtWebUrl" runat="server" Width="350"></asp:TextBox>
                <span class="tips">建议填写检测到的网址：<%=GetAppPath() %></span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <b>搜索引擎优化设置</b>
            </td>
        </tr>
        <tr>
            <td class="col">
                网站关键字：
            </td>
            <td>
                <asp:TextBox ID="txtKeywords" runat="server" Width="350"></asp:TextBox>
                <span class="tips">多个关键词请用竖线|隔开，建议3到4个关键词。</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                网站描述：
            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Width="350" Height="100" TextMode="MultiLine" MaxLength="100">网站描述，一般显示在搜索引擎搜索结果中的描述文字，用于介绍网站，吸引浏览者点击。</asp:TextBox>
                <span class="tips">100字以内</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                伪静态：
            </td>
            <td>
                <asp:CheckBox ID="chkUrlRewrite" runat="server" Text="使用伪静态（需服务器支持）" />
                <span class="tips">增强搜索引擎的友好面。使用此功能后请联系管理员修改系统配置。</span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <b>其他设置</b>
            </td>
        </tr>
        <tr>
            <td class="col">
                网站底部信息：
            </td>
            <td>
                <asp:TextBox ID="txtFootInfo" runat="server" Width="350" Height="100" TextMode="MultiLine" MaxLength="100">网站底部描述，一般显示版权信息、备案信息和联系方式等。</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                第三方代码：
            </td>
            <td>
                <asp:TextBox ID="txtThirdCode" runat="server" Width="350" Height="100" TextMode="MultiLine" MaxLength="100">第三方代码，主要用于填写统计插件或在线交流插件等代码。</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>&nbsp;
            </td>
        </tr>
    </table>
</div>
<div class="tab" style="display:none;">
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td></td>
            <td><b>用于系统发送邮件，站内所有邮件都由该邮箱发送，所以请务必正确填写。</b></td>
        </tr>
        <tr>
            <td class="col">
                发件人姓名：
            </td>
            <td>
                <asp:TextBox ID="txtSender" runat="server" Width="350"></asp:TextBox>
                <span class="tips">所显示的发件人姓名</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                邮箱账号：
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="350"></asp:TextBox>
                <span class="tips">用于发送邮件的邮箱账号</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                邮箱密码：
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="350" TextMode="Password"></asp:TextBox>
                <span class="tips">用于发送邮件的邮箱密码</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                邮件SMTP服务器：
            </td>
            <td>
                <asp:TextBox ID="txtSMTP" runat="server" Width="350"></asp:TextBox>
                <span class="tips">如163邮箱为smtp.163.com</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                邮件发送测试：
            </td>
            <td>
                <asp:TextBox ID="txtTo" runat="server" Width="350"></asp:TextBox>
                <span class="tips">用于测试的收件人邮箱</span><br />
                <div style="padding: 4px 0px; line-height:20px;">
                    <a href="javascript:void(0);" onclick="return testSendMail()">点击测试</a>
                    <span id="testResult"></span>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="btnSave2" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>&nbsp;
            </td>
        </tr>
    </table>
</div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
    <script type="text/javascript">
        function testSendMail() {
            if ($('#<%=txtSender.ClientID %>').val() == '') {
                alert('请输入发件人姓名');
                $('#<%=txtSender.ClientID %>').focus();
                return false;
            }
            if ($('#<%=txtEmail.ClientID %>').val() == '') {
                alert('请输入发件人邮箱账号');
                $('#<%=txtEmail.ClientID %>').focus();
                return false;
            }
            if ($('#<%=txtPassword.ClientID %>').val() == '') {
                alert('请输入发件人邮箱密码');
                $('#<%=txtPassword.ClientID %>').focus();
                return false;
            }
            if ($('#<%=txtSMTP.ClientID %>').val() == '') {
                alert('请输入发送邮箱的SMTP地址');
                $('#<%=txtSMTP.ClientID %>').focus();
                return false;
            }
            if ($('#<%=txtTo.ClientID %>').val() == '') {
                alert('请输入收件人邮箱地址');
                $('#<%=txtTo.ClientID %>').focus();
                return false;
            }
            $('#testResult').html("正在测试......");
            $.post(
                '<%=GetClientUrl("~/Manage/System/Ajax.ashx")%>?' + (new Date()),
                { Action: "EmailTest", sender: $('#<%=txtSender.ClientID %>').val(), email: $('#<%=txtEmail.ClientID %>').val(), password: $('#<%=txtPassword.ClientID %>').val(), smtp: $('#<%=txtSMTP.ClientID %>').val(), to: $('#<%=txtTo.ClientID %>').val() },
                function (result) {
                    if (result) {
                        if (result.result) {
                            $('#testResult').html("测试邮件发送成功！");
                        } else {
                            $('#testResult').html("测试发送邮件失败！解决办法：请检查帐号密码和smtp是否有误或查看邮箱是否开启smtp服务。");
                        }
                    } else {
                        $('#testResult').html("测试发送邮件失败！解决办法：请检查帐号密码和smtp是否有误或查看邮箱是否开启smtp服务。");
                    }
                });
            return false;
        }
    </script>

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
    
    <script type="text/javascript">
        $(function () {
            addImage($('#<%=hidLogo.ClientID %>').val());
        });
    </script>

    <script type="text/javascript">
        function addImage(imgfile) {
            if (imgfile.length == 0) return;

            $('#<%=hidLogo.ClientID %>').val(imgfile);
            $(".preview").html('');
            var div = $("<div/>"); //.css({ "background-image": "url(" + imgfile + ")" });
            var img = $("<img/>");
            img.attr('title', '点击查看大图').attr('src', imgfile).appendTo(div).click(function () {
                top.$.fancybox.open({ href: imgfile.replace('_s', '_b'), live: true });
            });
            var btn = $("<div class='cancel' title='点击删除图片'></div>").appendTo(div).click(function () {
                div.remove();
                $('#<%=hidLogo.ClientID %>').val('');
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
                file_types_description : "全部图片文件",
                file_upload_limit: 100,
                file_queue_limit: 0,
                button_action: SWFUpload.BUTTON_ACTION.SELECT_FILE, // 一次选择一个文件
                button_window_mode: 'transparent',

                file_dialog_complete_handler: fileDialogComplete,
                upload_start_handler: uploadStart,
                upload_progress_handler: uploadProgress,
                upload_success_handler: uploadSuccess,

                // Button Settings
                button_image_url : '<%=GetClientUrl("~/Manage/swfupload/XPButtonUploadText_61x22.png") %>',
                //button_text: '上传',
				button_placeholder_id : "spanButtonPlaceholder",
				button_width: 61,
				button_height: 22,

				post_params: {
				    "Action": "swfupload",
                    "dir": "image",
                    "configFile": ''
				},
                custom_settings : {
                    progressTarget: "fsUploadProgress",
					upload_successful : false
				}            };
            swfu = new SWFUpload(settings_object);
        });
    </script>
</asp:Content>
