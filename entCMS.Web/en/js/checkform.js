/*
Powered by ly200.com		http://www.ly200.com
广州联雅网络科技有限公司		020-83226791

定义格式：提示语~格式|格式提示语*

其中*为可选，如果不定义，则允许为空
格式同样为可选项，格式列表如下：
1、数字f		数字后加f，如：3f，表示长度必须为3位
2、数字m		数字后加:，如：3m，表示长度必须为3位或3位以上
3、date		日期检测
4、=表单名称	检测当前表单的值是否为“表单名称”的值，通常用于确认密码检测
5、email		Email检测
6、mobile	大陆手机号码检测，不包含国际区码86，检测范围：130-139，150-153，155-159，180，185-189
7、tel		大陆电话号码检测，不包含国际区码86，格式如：020-83226791或02083226791

注：格式提示语可使用表单值，用{value}表示，如：请正确填写邮件地址！~email|您输入的值：{value}，这不是一个合法的邮件地址*
*/

var first_error_input = null;

var doc = document.documentElement || document.body;
var isIe = (document.all) ? true : false;
var ie_version;
if (isIe) {
    var version = navigator.appVersion.split(';');
    var trim_version = version[1].replace(/[ ]/g, '');
    if (trim_version == 'MSIE7.0') {
        ie_version = 7;
    } else if (trim_version == 'MSIE6.0') {
        ie_version = 6;
    }
}

try { document.execCommand('BackgroundImageCache', false, true); } catch (e) { };

function $_(obj) {
    return document.getElementById(obj) ? document.getElementById(obj) : '';
}

function set_number(obj, float) {
    p = float == 1 ? /[^\d-.]/g : /[^\d]/g;
    obj.value = obj.value.replace(p, '');
}
function $_(obj) {
    return document.getElementById(obj) ? document.getElementById(obj) : '';
}
function div_mask() {
    var div_mask = document.createElement('div');
    div_mask.setAttribute('id', 'div_mask');
    div_mask.style.cssText = 'z-index:10000; background-color:#000; filter:alpha(opacity=40); opacity:0.4; -moz-opacity:0.4; left:0px; top:0px; position:absolute;';
    div_mask.style.height = (doc.scrollHeight > doc.clientHeight ? doc.scrollHeight : doc.clientHeight) + 'px';
    div_mask.style.width = doc.scrollWidth + 'px';
    document.body.appendChild(div_mask);
}

function pop_info_tips(tips) {	//弹出信息
    if (!is_array(tips)) {
        if (tips != '' && tips != undefined) {
            tips = tips.split('|'); //如果提交过来的数据不是数组，则用|分割
        } else {
            return;
        }
    } else if (tips.length == 0) {
        return;
    }
    div_mask();
    var info = '';
    var e = clear_repeat(tips);
    for (var i = 0; i < e.length; i++) {
        info += '&#8226; ' + e[i] + '<br />';
    }
    var pop_info_tips = document.createElement('div');
    pop_info_tips.setAttribute('id', 'pop_info_tips');
    pop_info_tips.style.cssText = 'position:absolute; z-index:10001; border:4px solid #333; background:#fff; left:0px; top:0px; width:550px;';
    pop_info_tips.innerHTML = '\
		<div style="height:25px; line-height:25px; background:#f1f1f1; font-size:14px; font-weight:bold; text-indent:8px; color:#FF6600;">Info</div>\
		<div style="padding:8px;"><table width="100%" border="0" cellspacing="0" cellpadding="0"><tr><td style="font-size:14px; line-height:150%; height:50px;" valign="top">' + info + '</td></tr></table></div>\
		<div style="height:34px; padding-right:6px; background:#ccc; text-align:right;"><a href="javascript:void(0);" onclick="close_pop_info_tips();" style="display:block; float:right; border:1px solid #000; width:72px; height:20px; line-height:21px; text-align:center; background:#eee; font-weight:bold; color:#333; margin-top:6px; text-decoration:none;">关闭窗口</a></div>';
    document.body.appendChild(pop_info_tips);
    scroll_pop_info_tips(); //先马上执行一次，要不看起来会在左上角飞到中间来
    scroll_pop_info_tips_timer = setInterval('scroll_pop_info_tips()', 50);
    $_('pop_info_tips').focus();
    $_('pop_info_tips').blur();

    document.onkeyup = function (evt) {
        evt = evt || event;
        key = evt.keyCode || evt.which || evt.charCode;
        key == 27 && close_pop_info_tips();
    }
}

function scroll_pop_info_tips() {	//弹出框跟随滚动
    $_('pop_info_tips').style.left = (document.documentElement.scrollLeft || window.pageXOffset || document.body.scrollLeft) + doc.clientWidth / 2 - $_('pop_info_tips').offsetWidth / 2 + 'px';
    $_('pop_info_tips').style.top = (document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop) + doc.clientHeight / 2 - $_('pop_info_tips').offsetHeight / 2 + 'px';
}

function close_pop_info_tips() {	//关闭弹出窗口
    (typeof first_error_input != 'undefined' && first_error_input != null) && first_error_input.focus();
    document.body.removeChild($_('div_mask'));
    document.body.removeChild($_('pop_info_tips'));
    document.onkeyup = null;
    clearInterval(scroll_pop_info_tips_timer);
}

function clear_repeat(array) {   	//清除数组重复项
    for (var i = 0; i < array.length; i++) {
        for (var j = i + 1; j < array.length; j++) {
            if (array[j] === array[i]) {
                array.splice(j, 1);
                j--;
            }
        }
    }
    return array;
}

function is_array(data) {
    if (typeof data == 'object' && typeof data.sort == 'function' && typeof data.length == 'number') {
        return true;
    } else {
        return false;
    }
}


function checkForm(fm) {
    if ($_('lib_div_mask') || $_('lib_pop_info_tips')) {
        return false;
    }

    var error_info = new Array;
    var submit_button = null;
    first_error_input = null;

    for (var i = 0; i < fm.length; i++) {
        fm[i].type.toLowerCase() == 'submit' && (submit_button = fm[i]);
        fm[i].className = fm[i].className.replace(' form_focus', '');

        var check = fm[i].getAttribute('check');
        if (check == null || check == 'undefined') {
            continue; //忽略未定义check的元素
        }

        var format_pos = check.lastIndexOf('~');
        if (format_pos < 0) {
            continue;
        }

        var tips = check.substring(0, format_pos); //提示信息
        var format_str = check.substring(format_pos + 1, check.length); //格式要求

        if (format_str.charAt(format_str.length - 1) == '*') {	//不允许为空
            var notNull = true; //不允许为空
            var format = format_str.substring(0, format_str.length - 1); //格式
        } else {
            var notNull = false; //允许为空
            var format = format_str.substring(0, format_str.length); //格式
        }

        if (notNull == false && format == '') {	//允许为空并且不需要格式检查
            continue;
        }

        var value = fm[i].value = trim(fm[i].value); //内容去除空格
        if (value == '' && notNull) {
            error_info[error_info.length] = tips;
            fm[i].className = fm[i].className + ' form_focus';
            first_error_input == null && fm[i].type.toLowerCase() != 'hidden' && (first_error_input = fm[i]);
            continue;
        } else if (format == '' || value == '') {
            continue;
        }

        var format_need = format.substring(0, format.lastIndexOf('|'));
        var format_need_first_char = format_need.charAt(0);
        var format_need_last_char = format_need.charAt(format_need.length - 1);
        var format_tips = format.substring(format.lastIndexOf('|') + 1, format.length).replace('{value}', '<font class="fc_red">' + value + '</font>');
        (format_tips == '') && (format_tips = tips);

        if (format_need_last_char == 'f' || format_need_last_char == 'm') {	//以f或m结尾，可能是需要进行长度检查的
            var fromat_need_length = format_need.substring(0, format_need.length - 1);
            if (!isNaN(fromat_need_length) && (format_need_last_char == 'f' && value.length != fromat_need_length) || (format_need_last_char == 'm' && value.length < fromat_need_length)) {
                error_info[error_info.length] = format_tips;
                fm[i].className = fm[i].className + ' form_focus';
                first_error_input == null && fm[i].type.toLowerCase() != 'hidden' && (first_error_input = fm[i]);
            }
        } else if (format_need == 'date') {	//日期格式检查
            var found = value.match(/(\d{1,5})-(\d{1,2})-(\d{1,2})/);
            if (found != null) {
                var year = trim_0(found[1]);
                var month = trim_0(found[2]) - 1;
                var date = trim_0(found[3]);
                var d = new Date(year, month, date);
            }
            if (found == null || found[0] != value || found[2] > 12 || found[3] > 31 || d.getFullYear() != year || d.getMonth() != month || d.getDate() != date) {
                error_info[error_info.length] = format_tips;
                fm[i].className = fm[i].className + ' form_focus';
                first_error_input == null && fm[i].type.toLowerCase() != 'hidden' && (first_error_input = fm[i]);
            }
        } else if ((format_need_first_char == '=' && trim(fm[format_need.substring(1, format_need.length)].value) != value) || (format_need == 'email' && !/([\w][\w-\.]*@[\w][\w-_]*\.[\w][\w\.]+)/g.test(value)) || (format_need == 'mobile' && !(/^13\d{9}$/g.test(value) || /^15[0-35-9]\d{8}$/g.test(value) || /^18[05-9]\d{8}$/g.test(value))) || (format_need == 'tel' && !(/^\d{3,4}-{0,1}\d{7,8}$/g.test(value)))) {	//检测是否与某字段的值相等，邮件格式检查，手机号码检测，电话号码检测
            error_info[error_info.length] = format_tips;
            fm[i].className = fm[i].className + ' form_focus';
            first_error_input == null && fm[i].type.toLowerCase() != 'hidden' && (first_error_input = fm[i]);
        }
    }

    if (error_info.length) {
        pop_info_tips(error_info);
        return false;
    } else {
        submit_button != null && (submit_button.disabled = true);
        return true;
    }
}

function trim(str) {	//除去字符串变量两端的空格
    return str.replace(/^ */, '').replace(/ *$/, '');
}

function trim_0(str) {	//除去字符串表示的数值变量开头的所有的0
    if (str.length == 0) {
        return str;
    }
    str = str.replace(/^0*/, '');
    str.length == 0 && (str = '0');
    return str;
}