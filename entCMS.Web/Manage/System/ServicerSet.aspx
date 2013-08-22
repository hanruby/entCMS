<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="ServicerSet.aspx.cs" Inherits="entCMS.Manage.ServicerSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../KindEditor/kindeditor-min.js" type="text/javascript"></script>
    <script src="../KindEditor/lang/zh_CN.js" type="text/javascript"></script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('#<%=txtOtherInfo.ClientID %>', {
                height: 150,
                allowImageUpload: true,
                allowFlashUpload: true,
                allowMediaUpload: false,
                allowFileUpload: true,
                allowFileManager: true,
                uploadJson: '../KE_UploadManager.ashx',
                fileManagerJson: '../KE_FileManager.ashx',
                filterMode: true, // true:开启过滤模式, false:关闭过滤模式
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
    <script type="text/javascript" src="../Scripts/servicer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    客服设置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
    当前位置：系统管理 >> 在线客服 >> 客服设置
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0" class="detail">
        <tr>
            <td class="col">
                在线交流方式：
            </td>
            <td>
                <asp:RadioButtonList ID="rblType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="" Value="1">固定于页面左边</asp:ListItem>
                    <asp:ListItem Text="" Value="2">居左随屏幕滚动</asp:ListItem>
                    <asp:ListItem Text="" Value="3">固定于页面右边</asp:ListItem>
                    <asp:ListItem Text="" Value="4">居右随屏幕滚动</asp:ListItem>
                    <asp:ListItem Text="关闭" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr id="onlineleft" style="display: none">
            <td class="col">
                居左时滚动位置：
            </td>
            <td>
                距离浏览器左边：
                <asp:TextBox ID="txtX1" runat="server" Width="40"></asp:TextBox>像素&nbsp;&nbsp;
                距离浏览器顶部：
                <asp:TextBox ID="txtY1" runat="server" Width="40"></asp:TextBox>像素
            </td>
        </tr>
        <tr id="onlineright" style="display: none">
            <td class="col">
                居右时滚动位置：
            </td>
            <td>
                距离浏览器右边：
                <asp:TextBox ID="txtX2" runat="server" Width="40"></asp:TextBox>像素&nbsp;&nbsp;
                距离浏览器顶部：
                <asp:TextBox ID="txtY2" runat="server" Width="40"></asp:TextBox>像素
            </td>
        </tr>
        <tr>
            <td class="col">
                漂浮风格：
            </td>
            <td>
                <div class="select"><div>
                <asp:DropDownList ID="ddlStyle" runat="server" Width="70px">
                    <asp:ListItem Text="风格1" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="风格2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="风格3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="风格4" Value="4"></asp:ListItem>
                </asp:DropDownList>
                </div></div>
                <div class="select"><div>
                <asp:DropDownList ID="ddlStyleColor" runat="server">
                    <asp:ListItem Text="蓝色" Value="1"></asp:ListItem>
                    <asp:ListItem Text="红色" Value="2"></asp:ListItem>
                    <asp:ListItem Text="紫色" Value="3"></asp:ListItem>
                    <asp:ListItem Text="绿色" Value="4" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="灰色" Value="5"></asp:ListItem>
                </asp:DropDownList>
                </div></div>
            </td>
        </tr>
        <tr>
            <td class="col">
                QQ图标：
            </td>
            <td>
                <a href="javascript:void(0)" onclick="divshow('online_box_qq')" style="text-decoration: underline;">更改图标</a>
                <img align='absmiddle' src="../images/qq/qq_<%=qq %>.jpg" id="metqqimg" style="vertical-align: middle;margin: 5px;" />
            </td>
        </tr>
        <tr>
            <td class="col">
                MSN图标：
            </td>
            <td>
                <a href="javascript:void(0)" onclick="divshow('online_box_msn')" style="text-decoration: underline;">更改图标</a>
                <img align='absmiddle' src="../images/msn/msn_<%=msn %>.gif" id="metmsnimg" style="vertical-align: middle;margin: 5px;" />
            </td>
        </tr>
        <tr>
            <td class="col">
                淘宝旺旺图标：
            </td>
            <td>
                <a href="javascript:void(0)" onclick="divshow('online_box_taobao')" style="text-decoration: underline;">更改图标</a>
                <img align='absmiddle' src="../images/taobao/taobao_<%=tb %>.jpg" id="mettaobaoimg" style="vertical-align: middle;margin: 5px;" />
            </td>
        </tr>
        <tr>
            <td class="col">
                SKYPE图标：
            </td>
            <td>
                <a href="javascript:void(0)" onclick="divshow('online_box_skype')" style="text-decoration: underline;">更改图标</a>
                <img align='absmiddle' src="../images/skype/skype_<%=skype %>.gif" id="metskypeimg" style="vertical-align: middle;margin: 5px;" />
            </td>
        </tr>
        <tr>
            <td class="col">
                阿里旺旺图标：
            </td>
            <td>
                <a href="javascript:void(0)" onclick="divshow('online_box_alibaba')" style="text-decoration: underline;">更改图标</a>
                <img align='absmiddle' src="../images/alibaba/alibaba_<%=ali %>.jpg" id="metalibabaimg" style="vertical-align: middle;margin: 5px;" />
            </td>
        </tr>
        <tr>
            <td class="col">
                关闭客服名称：
            </td>
            <td>
                <asp:CheckBox ID="chkOnName" runat="server" Text="关闭" />
            </td>
        </tr>
        <tr>
            <td class="col" valign="middle">
                电话或其他说明：
            </td>
            <td valign="top">
                <asp:TextBox ID="txtOtherInfo" runat="server" TextMode="MultiLine" Rows="3" Width="700" Text="<p>界面风格-在线交流设置</p>"></asp:TextBox><span class="tips">支持HTML语言，可加入第三方代码</span>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="submit">
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn" OnClick="btnSave_Click" OnClientClick="editor.sync();">保存</asp:LinkButton>
            </td>
        </tr>
    </table>
    <!--imgtype-->    
    <div id="online_box_qq" style="display:none">
        <h3><img align='absmiddle' src="../images/close.png" onclick="closediv('online_box_qq')" />选择图片风格</h3>
        <ul>
            <li><span><input type="radio" value="4" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_4.jpg" />
            </li>
            <li><span><input type="radio" value="45" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_45.jpg" />
            </li>
            <li><span><input type="radio" value="5" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_5.jpg" />
            </li>
            <li><span><input type="radio" value="8" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_8.jpg" />
            </li>
            <li><span><input type="radio" value="9" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_9.jpg" />
            </li>
            <li><span><input type="radio" value="10" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_10.jpg" />
            </li>
            <li><span><input type="radio" value="44" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_44.jpg" />
            </li>
            <li><span><input type="radio" value="46" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_46.jpg" />
            </li>
            <li><span><input type="radio" value="1" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_1.jpg" />
            </li>
            <li><span><input type="radio" value="6" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_6.jpg" />
            </li>
            <li><span><input type="radio" value="7" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_7.jpg" />
            </li>
            <li><span><input type="radio" value="47" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_47.jpg" />
            </li>
            <li><span><input type="radio" value="41" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_41.jpg" />
            </li>
            <li><span><input type="radio" value="42" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_42.jpg" />
            </li>
            <li><span><input type="radio" value="2" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_2.jpg" />
            </li>
            <li><span><input type="radio" value="3" name="met_qq_type" checked='checked' /></span>
                <img align='absmiddle' src="../images/qq/qq_3.jpg" />
            </li>
            <li><span><input type="radio" value="11" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_11.jpg" style="position: relative; bottom: 10px;" />
            </li>
            <li><span><input type="radio" value="12" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_12.jpg" />
            </li>
            <li><span><input type="radio" value="43" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_43.jpg" />
            </li>
            <li><span><input type="radio" value="13" name="met_qq_type" /></span>
                <img align='absmiddle' src="../images/qq/qq_13.jpg" />
            </li>
        </ul>
        <div class="clear"></div>
        <div class="botom">
            <a href="javascript:void(0)" onclick="closediv('online_box_qq')">取消</a> <a href="javascript:void(0)"
                onclick="okonlineicon('qq')">确认</a>
        </div>
    </div>
    <div id="online_box_msn" style="display:none">
        <h3><img align='absmiddle' src="../images/close.png" onclick="closediv('online_box_msn')" />选择图片风格</h3>
        <ul>
            <li><span>
                <input type="radio" value="1" name="met_msn_type" checked='checked' /></span>
                <img align='absmiddle' src="../images/msn/msn_1.gif" />
            </li>
            <li><span>
                <input type="radio" value="2" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_2.gif" />
            </li>
            <li><span>
                <input type="radio" value="3" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_3.gif" />
            </li>
            <li><span>
                <input type="radio" value="4" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_4.gif" />
            </li>
            <li><span>
                <input type="radio" value="5" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_5.gif" />
            </li>
            <li><span>
                <input type="radio" value="6" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_6.gif" />
            </li>
            <li><span>
                <input type="radio" value="7" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_7.gif" />
            </li>
            <li><span>
                <input type="radio" value="8" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_8.gif" />
            </li>
            <li><span>
                <input type="radio" value="9" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_9.gif" />
            </li>
            <li><span>
                <input type="radio" value="10" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_10.gif" />
            </li>
            <li><span>
                <input type="radio" value="11" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_11.gif" />
            </li>
            <li><span>
                <input type="radio" value="12" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_12.gif" />
            </li>
            <li><span>
                <input type="radio" value="13" name="met_msn_type" /></span>
                <img align='absmiddle' src="../images/msn/msn_13.gif" />
            </li>
        </ul>
        <div class="clear"></div>
        <div class="botom">
            <a href="javascript:void(0)" onclick="closediv('online_box_msn')">取消</a> <a href="javascript:void(0)"
                onclick="okonlineicon('msn')">确认</a>
        </div>
    </div>
    <div id="online_box_taobao" style="display:none">
        <h3><img align='absmiddle' src="../images/close.png" onclick="closediv('online_box_taobao')" />选择图片风格</h3>
        <ul>
            <li><span>
                <input type="radio" value="2" name="met_taobao_type" checked='checked' /></span>
                <img align='absmiddle' src="../images/taobao/taobao_2.jpg" />
            </li>
            <li><span>
                <input type="radio" value="1" name="met_taobao_type" /></span>
                <img align='absmiddle' src="../images/taobao/taobao_1.jpg" />
            </li>
        </ul>
        <div class="clear"></div>
        <div class="botom">
            <a href="javascript:void(0)" onclick="closediv('online_box_taobao')">取消</a> <a href="javascript:void(0)"
                onclick="okonlineicon('taobao')">确认</a>
        </div>
    </div>
    <div id="online_box_skype" style="display:none">
        <h3><img align='absmiddle' src="../images/close.png" onclick="closediv('online_box_skype')" />选择图片风格</h3>
        <ul>
            <li><span>
                <input type="radio" value="11" name="met_skype_type" checked='checked' /></span>
                <img align='absmiddle' src="../images/skype/skype_11.gif" />
            </li>
            <li><span>
                <input type="radio" value="12" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_12.gif" />
            </li>
            <li><span>
                <input type="radio" value="13" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_13.gif" />
            </li>
            <li><span>
                <input type="radio" value="4" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_4.gif" />
            </li>
            <li><span>
                <input type="radio" value="5" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_5.gif" />
            </li>
            <li><span>
                <input type="radio" value="6" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_6.gif" />
            </li>
            <li><span>
                <input type="radio" value="7" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_7.gif" />
            </li>
            <li><span>
                <input type="radio" value="8" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_8.gif" />
            </li>
            <li><span>
                <input type="radio" value="9" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_9.gif" />
            </li>
            <li><span>
                <input type="radio" value="10" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_10.gif" />
            </li>
            <li><span>
                <input type="radio" value="1" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_1.gif" />
            </li>
            <li><span>
                <input type="radio" value="2" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_2.gif" />
            </li>
            <li><span>
                <input type="radio" value="3" name="met_skype_type" /></span>
                <img align='absmiddle' src="../images/skype/skype_3.gif" />
            </li>
        </ul>
        <div class="clear"></div>
        <div class="botom">
            <a href="javascript:void(0)" onclick="closediv('online_box_skype')">取消</a> <a href="javascript:void(0)"
                onclick="okonlineicon('skype')">确认</a>
        </div>
    </div>
    <div id="online_box_alibaba" style="display:none">
        <h3><img align='absmiddle' src="../images/close.png" onclick="closediv('online_box_alibaba')" />选择图片风格</h3>
        <ul>
            <li><span>
                <input type="radio" value="102" name="met_alibaba_type" /></span>
                <img align='absmiddle' src="../images/alibaba/alibaba_102.jpg" />
            </li>
            <li><span>
                <input type="radio" value="101" name="met_alibaba_type" checked='checked' /></span>
                <img align='absmiddle' src="../images/alibaba/alibaba_101.jpg" />
            </li>
            <li><span>
                <input type="radio" value="1" name="met_alibaba_type" /></span>
                <img align='absmiddle' src="../images/alibaba/alibaba_1.jpg" />
            </li>
            <li><span>
                <input type="radio" value="2" name="met_alibaba_type" /></span>
                <img align='absmiddle' src="../images/alibaba/alibaba_2.jpg" />
            </li>
        </ul>
        <div class="clear"></div>
        <div class="botom">
            <a href="javascript:void(0)" onclick="closediv('online_box_alibaba')">取消</a> <a href="javascript:void(0)"
                onclick="okonlineicon('alibaba')">确认</a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
    <a id="online_param" href="?t=<%=type %>&u=/&x=<%=x %>&y=<%=y %>&lang=<%=CurrentLanguageId %>"></a>
    <script type="text/javascript" src="../scripts/online.js"></script>
    <script type="text/javascript">
        function selectRadio(name, value){
            $("input:radio[name='"+name+"']").each(function(i,e){
                if($(this).val()==value){
                    $(this).attr('checked', true);
                    return;
                }
            });
        }

        $(document).ready(function () {
            selectRadio('met_qq_type', '<%=qq %>');
            selectRadio('met_msn_type', '<%=msn %>');
            selectRadio('met_taobao_type', '<%=tb %>');
            selectRadio('met_skype_type', '<%=skype %>');
            selectRadio('met_alibaba_type', '<%=ali %>');
        });
    </script>
</asp:Content>
