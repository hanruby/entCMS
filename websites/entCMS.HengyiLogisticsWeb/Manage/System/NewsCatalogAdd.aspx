<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="NewsCatalogAdd.aspx.cs" Inherits="entCMS.Manage.NewsCatalogAdd" %>
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
内容栏目添加
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
当前位置：系统管理 >> 内容栏目 >> 添加
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <asp:HiddenField ID="hidCode" runat="server" />
    <table border="0" align="center" cellpadding="0" cellspacing="0" width="100%" class="detail">
        <tr>
            <td class="col">
                所属语言：
            </td>
            <td>
                <div class="select"><div>
                <asp:DropDownList ID="ddlLanguage" runat="server" 
                    OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                </div></div>
                <asp:CompareValidator ID="cvLang" runat="server" ControlToValidate="ddlLanguage" ValueToCompare="0" Type="Integer" Operator="GreaterThan" ErrorMessage="请选择所属语言"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                上级栏目：
            </td>
            <td>
                <div class="select"><div>
                <asp:DropDownList ID="ddlParentNode" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="ddlParentNode_SelectedIndexChanged"></asp:DropDownList>
                </div></div>
                <asp:CompareValidator ID="cvParentNode" runat="server" ControlToValidate="ddlParentNode" ValueToCompare="" Type="String" Operator="NotEqual" ErrorMessage="请选择上级栏目"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                栏目名称：
            </td>
            <td>
                <asp:TextBox ID="txtName" CssClass="input" runat="server" Width="350"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="请输入栏目名称" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                栏目类别：
            </td>
            <td>
                <div class="select"><div>
                <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                </div></div>
                <span class="tips">默认指前台展示时本栏目内容显示为第一个子栏目的内容</span>
                <%-- 
                <asp:DropDownList ID="ddlType" runat="server">
                    <asp:ListItem Text="图文模块" Value="1"></asp:ListItem>
                    <asp:ListItem Text="文章模块" Value="2"></asp:ListItem>
                    <asp:ListItem Text="图片模块" Value="3"></asp:ListItem>
                    <asp:ListItem Text="产品模块" Value="4"></asp:ListItem>
                    <asp:ListItem Text="下载模块" Value="5"></asp:ListItem>
                    <asp:ListItem Text="招聘模块" Value="6"></asp:ListItem>
                    <asp:ListItem Text="友链模块" Value="7"></asp:ListItem>
                    <asp:ListItem Text="留言模块" Value="8"></asp:ListItem>
                    <asp:ListItem Text="调用模块" Value="9"></asp:ListItem>
                    <asp:ListItem Text="外部链接" Value="20"></asp:ListItem>
                    <asp:ListItem Text="网站地图" Value="30"></asp:ListItem>
                    <asp:ListItem Text="全站搜索" Value="40"></asp:ListItem>
                    <asp:ListItem Text="会员模块" Value="50"></asp:ListItem>
                </asp:DropDownList>
                --%>
            </td>
        </tr>
        <tr>
            <td class="col">
                标题：
            </td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                副标题：
            </td>
            <td>
                <asp:TextBox ID="txtSubTitle" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <!--取消填写，根据模块填写实际后台页面地址-->
        <tr style="display:none">
            <td class="col">
                后台链接：
            </td>
            <td>
                <asp:TextBox ID="txtBackUrl" runat="server" Width="350px" Text="~/Manage/Module/NewsList.aspx"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                前台链接：
            </td>
            <td>
                <asp:TextBox ID="txtLinkUrl" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="col">
                栏目大图：
            </td>
            <td valign="middle">
                <asp:HiddenField ID="hidImages1" runat="server" />
                <span id="spanButtonPlaceholder1"></span><span class="tips">(最大 1.0MB)</span>
                <div id="fsUploadProgress1" class="flash"></div>
                <div id="preview1" class="preview"></div>
                <div class="clear"></div>
            </td>
        </tr>
        <tr>
            <td class="col">
                栏目小图：
            </td>
            <td valign="middle">
                <asp:HiddenField ID="hidImages2" runat="server" />
                <span id="spanButtonPlaceholder2"></span><span class="tips">(最大 1.0MB)</span>
                <div id="fsUploadProgress2" class="flash"></div>
                <div id="preview2" class="preview"></div>
                <div class="clear"></div>
            </td>
        </tr>
        <tr>
            <td class="col">
                排序号：
            </td>
            <td>
                <asp:TextBox ID="txtOrder" runat="server" Text="0" Width="32px"></asp:TextBox>
                <asp:CompareValidator ID="cvOrder" runat="server" ControlToValidate="txtOrder" ValueToCompare="0" Type="Integer" Operator="GreaterThanEqual" ErrorMessage="请输入正整数"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="col">
                导航栏显示：
            </td>
            <td>
                <asp:RadioButtonList ID="rblNavType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="不显示" Value="0" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="头部导航条" Value="1"></asp:ListItem>
                    <asp:ListItem Text="底部导航条" Value="2"></asp:ListItem>
                    <asp:ListItem Text="两者都显示" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
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
            <td></td>
            <td>
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click">保存</asp:LinkButton>&nbsp;
                <a href='NewsCatalogList.aspx?node=<%=NodeCode %>&lang=<%=lang %>' class="btn">列表</a>
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
            var images2 = $('#<%=hidImages2.ClientID %>').val().split('|');
            for (var i = 0; i < images2.length; i++) {
                if (images2[i].length > 4) {
                    addImage(2, images2[i]);
                }
            }
        });
    </script>
    <script type="text/javascript">
        function clearImages(id) {
            if (id == 1) {
                $('#<%=hidImages1.ClientID %>').val('');
            } else if (id == 2) {
                $('#<%=hidImages2.ClientID %>').val('');
            }
            $("#preview" + id).html('');
        }
        function addImage(id, imgfile) {
            if (id == 1) {
                $('#<%=hidImages1.ClientID %>').val(imgfile);
            } else if (id == 2) {
                $('#<%=hidImages2.ClientID %>').val(imgfile);
            }
            $("#preview" + id).html('');
            var div = $("<div/>"); //.css({ "background-image": "url(" + imgfile + ")" });
            var img = $("<img/>");
            img.attr('title', '点击查看大图').attr('src', imgfile).appendTo(div).click(function () {
                top.$.fancybox.open({ href: imgfile.replace('_s', '_b'), live: true });
            });
            var btn = $("<div class='cancel' title='点击删除图片'></div>").appendTo(div).click(function () {
                div.remove();
                if (id == 1) {
                    $('#<%=hidImages1.ClientID %>').val('');
                } else if (id == 2) {
                    $('#<%=hidImages2.ClientID %>').val('');
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
                file.id = "singlefile" + this.customSettings.id;
                var progress = new FileProgress(file, this.customSettings.progressTarget);
                progress.setStatus("正在上传...");
                progress.toggleCancel(true, this);
            }
            catch (ex) { }

            return true;
        }
        function uploadProgress(file, bytesLoaded, bytesTotal) {
            try {
                file.id = "singlefile" + this.customSettings.id;
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
                file.id = "singlefile" + this.customSettings.id; // This makes it so FileProgress only makes a single UI element, instead of one for each file
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
        var swfu1, swfu2; // swfupload对象
        $(function () {
            // 初始化swfupload
            var settings_object1 = {
                debug: false,
                upload_url: '<%=GetClientUrl("~/Manage/KE_UploadManager.ashx") %>',
                flash_url: '<%=GetClientUrl("~/Manage/swfupload/swfupload.swf")%>',
                flash9_url: '<%=GetClientUrl("~/Manage/swfupload/swfupload_fp9.swf")%>',
                file_post_name: "imgFile",
                file_size_limit: "1 MB",
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
                    "dir": "image",
                    "configFile": ''
                },
                custom_settings: {
                    progressTarget: "fsUploadProgress1",
                    upload_successful: false,
                    id: 1
                }
            };
            swfu1 = new SWFUpload(settings_object1);
            // 初始化swfupload
            var settings_object2 = {
                debug: false,
                upload_url: '<%=GetClientUrl("~/Manage/KE_UploadManager.ashx") %>',
                flash_url: '<%=GetClientUrl("~/Manage/swfupload/swfupload.swf")%>',
                flash9_url: '<%=GetClientUrl("~/Manage/swfupload/swfupload_fp9.swf")%>',
                file_post_name: "imgFile",
                file_size_limit: "1 MB",
                file_types: "*.jpg;*.jpeg;*.gif;*.png",
                file_types_description: "全部图片文件",
                file_upload_limit: 100,
                file_queue_limit: 1,
                button_action: SWFUpload.BUTTON_ACTION.SELECT_FILE, // 一次选择多个文件
                button_window_mode: 'transparent',

                file_dialog_complete_handler: fileDialogComplete,
                upload_start_handler: uploadStart,
                upload_progress_handler: uploadProgress,
                upload_success_handler: uploadSuccess,

                // Button Settings
                button_image_url: '<%=GetClientUrl("~/Manage/swfupload/XPButtonUploadText_61x22.png") %>',
                //button_text: '上传',
                button_placeholder_id: "spanButtonPlaceholder2",
                button_width: 61,
                button_height: 22,

                post_params: {
                    "Action": "swfupload",
                    "dir": "image",
                    "configFile": ''
                },
                custom_settings: {
                    progressTarget: "fsUploadProgress2",
                    upload_successful: false,
                    id: 2
                }
            };
            swfu2 = new SWFUpload(settings_object2);
        });
        </script>
</asp:Content>
