<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="ImageSet.aspx.cs" Inherits="entCMS.Manage.ImageSet" %>
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
    图片设置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：系统管理 >> 系统设置 >> 图片设置
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
<div class="hd">
    <h3 class="">图片设置</h3>
    <h3 class="">图片水印设置</h3>
    <asp:HiddenField ID="hidTab" runat="server" Value="0"/>
    <div class="clear"></div>
</div>
<div class="tab" style="display:none;">
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                自动删除图片：
            </td>
            <td>
                <asp:CheckBox ID="chkAutoDelImg" runat="server" Text="开启后删除信息时将自动删除相应图片" />
            </td>
        </tr>
        <tr>
            <td class="col">
                自动重命名：
            </td>
            <td>
                <asp:CheckBox ID="chkAutoRename" runat="server" Text="对上传的文件名自动进行重命名" />
                <br />
                <span class="tips">未开启此功能情况下上传中文名称文件,在网站转移后,图片名称可能会出现乱码,造成图片不显示</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                自动生成缩略图：
            </td>
            <td>
                <asp:CheckBox ID="chkAutoCreateThumbnail" runat="server" Text="开启后添加大图时将自动生成缩略图" />
            </td>
        </tr>
        <tr>
            <td class="col">
                缩略图生成方式：
            </td>
            <td>
                <asp:RadioButtonList ID="rblCreateThumbnailMode" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="指定高宽缩放(可能变形) " Value="1" />
                    <asp:ListItem Text="指定宽，高按比例缩放 " Value="2" />
                    <asp:ListItem Text="指定高，宽按比例缩放 " Value="3" />
                    <asp:ListItem Text="指定高宽裁减（不变形） " Value="4" Selected="True" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td><b>缩略图大小 (缩略图一般显示在列表页或首页图片展示)</b></td>
        </tr>
        <tr>
            <td class="col">产品模块：</td>
            <td>宽<asp:TextBox ID="txtProductThumbnailWidth" runat="server" Width="50"></asp:TextBox>像素，高<asp:TextBox ID="txtProductThumbnailHeight" runat="server" Width="50"></asp:TextBox>像素</td>
        </tr>
        <tr>
            <td class="col">图片模块：</td>
            <td>宽<asp:TextBox ID="txtImageThumbnailWidth" runat="server" Width="50"></asp:TextBox>像素，高<asp:TextBox ID="txtImageThumbnailHeight" runat="server" Width="50"></asp:TextBox>像素</td>
        </tr>
        <tr>
            <td class="col">文章模块：</td>
            <td>宽<asp:TextBox ID="txtNewsThumbnailWidth" runat="server" Width="50"></asp:TextBox>像素，高<asp:TextBox ID="txtNewsThumbnailHeight" runat="server" Width="50"></asp:TextBox>像素</td>
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
            <td class="col">
                图片添加水印：
            </td>
            <td>
                <asp:CheckBoxList ID="cblAddWaterMark" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="详细大图片添加 " Value="1"></asp:ListItem>
                    <asp:ListItem Text="缩略片添加 " Value="2"></asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="col">
                水印类型：
            </td>
            <td>
                <asp:RadioButtonList ID="rblWaterMarkType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="文字水印 " Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="图片水印 " Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="col">
                大图水印图片：
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
                缩略图水印图片：
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
                大图水印文字大小：
            </td>
            <td>
                <asp:TextBox ID="txtWaterMarkTextFontSize" runat="server" Width="50" Text="35"></asp:TextBox>像素
            </td>
        </tr>
        <tr>
            <td class="col">
                缩略图水印文字大小：
            </td>
            <td>
                <asp:TextBox ID="txtThumbnailWaterMarkTextFontSize" runat="server" Width="50" Text="10"></asp:TextBox>像素
            </td>
        </tr>
        <tr>
            <td class="col">
                水印文字字体：
            </td>
            <td>
                <asp:TextBox ID="txtWaterMarkTextFont" runat="server" Width="350" Text="~/manage/fonts/arial.ttf"></asp:TextBox>
                <span class="tips">请将字体文件放到~/manage/fonts/下</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                水印文字：
            </td>
            <td>
                <asp:TextBox ID="txtWaterMarkText" runat="server" Width="350"></asp:TextBox>
                <span class="tips">不支持中文（中文水印需要下载中文字体才能支持）</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                水印文字颜色：
            </td>
            <td>
                <asp:TextBox ID="txtWaterMarkTextColor" runat="server" Width="100" Text="#000000" style="float:left"></asp:TextBox>
                <div class="select"><div>
                <select name='select_color' onchange="if(this.options[this.selectedIndex].value!='') {do_color('#<%=txtWaterMarkText.ClientID %>',this.options[this.selectedIndex].value,'#<%=txtWaterMarkTextColor.ClientID %>');}"> 
	                <option>选择颜色</option>
	                <option style="background-color: #FFFFFF;color:#FFFFFF" value="#FFFFFF">白色</option> 
	                <option style="background-color:Black;color:Black" value="#000000">黑色</option> 
	                <option style="background-color:Red;color:Red" value="#FF0000">红色</option> 
	                <option style="background-color:Yellow;color:Yellow" value="#FFFF00">黄色</option> 
	                <option style="background-color:Green;color:Green" value="#008000">绿色</option> 
	                <option style="background-color:Orange;color:Orange" value="#FF8000">橙色</option> 
	                <option style="background-color:Purple;color:Purple" value="#800080">紫色</option> 
	                <option style="background-color:Blue;color:Blue" value="#0000FF">蓝色</option> 
	                <option style="background-color:Brown;color:Brown" value="#800000">褐色</option> 
	                <option style="background-color:#00FFFF;color: #00FFFF" value="#00FFFF">粉绿</option> 
	                <option style="background-color:#7FFFD4;color: #7FFFD4" value="#7FFFD4">淡绿</option> 
	                <option style="background-color:#FFE4C4;color: #FFE4C4" value="#FFE4C4">黄灰</option> 
	                <option style="background-color:#7FFF00;color: #7FFF00" value="#7FFF00">翠绿</option> 
	                <option style="background-color:#D2691E;color: #D2691E" value="#D2691E">综红</option> 
	                <option style="background-color:#FF7F50;color: #FF7F50" value="#FF7F50">砖红</option> 
	                <option style="background-color:#6495ED;color: #6495ED" value="#6495ED">淡蓝</option> 
	                <option style="background-color:#DC143C;color: #DC143C" value="#DC143C">暗红</option> 
	                <option style="background-color:#FF1493;color: #FF1493" value="#FF1493">玫红</option> 
	                <option style="background-color:#FF00FF;color: #FF00FF" value="#FF00FF">紫红</option> 
	                <option style="background-color:#FFD700;color: #FFD700" value="#FFD700">桔黄</option> 
	                <option style="background-color:#DAA520;color: #DAA520" value="#DAA520">军黄</option> 
	                <option style="background-color:#808080;color: #808080" value="#808080">烟灰</option> 
	                <option style="background-color:#778899;color: #778899" value="#778899">深灰</option> 
	                <option style="background-color:#B0C4DE;color: #B0C4DE" value="#B0C4DE">灰蓝</option> 
	            </select>
                </div></div> 
            </td>
        </tr>
        <tr>
            <td class="col">
                水印文字角度：
            </td>
            <td>
                <asp:TextBox ID="txtWaterMarkAngle" runat="server" Width="50" Text="0"></asp:TextBox>
                <span class="tips">水平为0</span>
            </td>
        </tr>
        <tr>
            <td class="col">
                水印透明度：
            </td>
            <td>
                <asp:TextBox ID="txtWaterMarkAlpha" runat="server" Width="50" Text="0.5"></asp:TextBox>
                <span class="tips">0~1</span>
            </td>
        </tr>
        <tr>
            <td class="col">水印位置：</td>
            <td align="left">
                <asp:RadioButtonList ID="rblWaterMarkPosition" runat="server" RepeatColumns="3" RepeatLayout="Flow">
                    <asp:ListItem Text="左上角 " Value="1"></asp:ListItem>
                    <asp:ListItem Text="顶中部 " Value="2"></asp:ListItem>
                    <asp:ListItem Text="右上角 " Value="3"></asp:ListItem>
                    <asp:ListItem Text="左中部 " Value="4"></asp:ListItem>
                    <asp:ListItem Text="中间部 " Value="5" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="右中部 " Value="6"></asp:ListItem>
                    <asp:ListItem Text="左下角 " Value="7"></asp:ListItem>
                    <asp:ListItem Text="底中部 " Value="8"></asp:ListItem>
                    <asp:ListItem Text="右下角 " Value="9"></asp:ListItem>
                </asp:RadioButtonList>
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
    <script type="text/javascript">
        function do_color(vobject, vvar, valor) {
            $(vobject).css('color', vvar);
            $(valor).val(vvar);
        }
    </script>
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
                file_queue_limit: 0,
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
