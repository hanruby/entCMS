$.fn.extend({
    allenMenu: function () {
        $(this).children('ul').children('li').hover(
			function () {
			    if (!$(this).children('ul').hasClass('focus')) {
			        $(this).addClass('focus');
			        $(this).children('ul:first').stop(true, true).animate({ height: 'show' }, 'fast');
			    }
			},
			function () {
			    $(this).removeClass('focus');
			    $(this).children('ul:first').stop(true, true).animate({ height: 'hide', opacity: 'hide' }, 'slow');
			}
		);
        $(this).children('ul').children('li').children('ul').hover(
			function () {
			    $(this).addClass('focus');
			},
			function () {
			    $(this).removeClass('focus');
			}
		);
    }
});

$.fn.extend({
    allenSlide: function () {
        var ads = $(this).find('ul:first li');
        var name = $(this).attr('id');
        var n = ads.length;
        var w = ads.width();
        var h = ads.height();
        var clicked = false;
        var t = 4000;
        var lt = 5000;
        var speed = 'slow';
        var curPage = 0;

        //$(this).children('ul:first').append($(this).find('ul:first li:first').clone());

        $(this).width(w).height(h);
        $(this).css('overflow', 'hidden');
        $(this).css('position', 'relative');
        $(this).children('ul:first').width(w * (n + 1));
        var pages = $('<div class="slide-page"></div>');
        for (var i = 1; i <= n; i++) {
            var el = $('<a href="#" id="' + name + '-page-' + i + '">' + i + '</a>');
            eval('el.click(function(){ clicked = true; slideTo(' + i + '); return false; });');
            pages.append(el);
        }
        $(this).append(pages);
        $('#' + name + '-page-1').parent().addClass('on');
        autoSlide();

        /* Fade Version
        */
        function slideTo(page) {
            curPage = page;
            var ml = -1 * w * (page - 1);
            $('#' + name).find('li:eq(' + (curPage - 1) + ')').stop();
            if (page > n) {
                page = 1;
                curPage = 1;
            }
            $('#' + name).find('li').each(function () {
                if ($(this).css("display") != "none") {
                    //$(this).css('z-index', '2');
                    $(this).fadeOut(speed);
                }
            });
            //$('#' + name).find('li:eq('+(page-1)+')').css('z-index', '1');
            $('#' + name).find('li:eq(' + (page - 1) + ')').fadeIn(speed);
            $('#' + name).find('.slide-page > a').removeClass('on');
            $('#' + name + '-page-' + curPage).addClass('on');
        }

        /* Slide Version
        function slideTo(page) {
        curPage = page;
        var ml = -1 * w * (page - 1);
        $('#' + name).children('ul:first').stop();
        if(page > n) {
        curPage = 1;
        } else if(page == 2 && !clicked) {
        $('#' + name).children('ul:first').css('margin-left', '0px');
        }
        $('#' + name).children('ul:first').animate({ marginLeft: ml }, speed);
        $('#' + name).find('.slide-page > a').removeClass('on');
        $('#' + name + '-page-' + curPage).addClass('on');
        }
        */

        function autoSlide() {
            var tp = curPage;
            if (!clicked) {
                slideTo(tp + 1);
                eval('setTimeout(function() { autoSlide(); }, ' + t + ');');
            } else {
                clicked = false;
                eval('setTimeout(function() { autoSlide(); }, ' + lt + ');');
            }
        }

    }
});


//存cookie
function setCookie(name, value)
{
	expires = new Date();
	expires.setTime(expires.getTime() + (1000 * 86400 * 365));
	document.cookie = name + "=" + value + "; expires=" + expires.toGMTString() + "; path=/";
}
//删除cookies
function deleteCookie(name, path, domain){
    if (GetCookie(name))
        document.cookie = name + "=" + ((path) ? "; path=" + path : "") + ((domain) ? "; domain=" + domain : "") + "; expires=Thu, 01-Jan-70 00:00:01 GMT";
}
//取cookies函数   
function getCookie(name)     
{
    var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
     if(arr != null) return unescape(arr[2]); return null;
}
//取对象
function get(id){
	return document.getElementById(id);
}
//取Url参数
function GetQueryString(name)
{    
	var reg=new RegExp("(^|&)"+name+"=([^&]*)(&|$)","i");
	var r=window.location.search.substr(1).match(reg);
	if(r!=null)
	{
		return unescape(r[2])
	}
	return null;     
}
//判断该对象是否存在
function ChkObjectIsExists(id)
{
    try
    {
        var iframeList = document.getElementById(id);
        if(iframeList == null|| iframeList == "undefined")
        {
            return false;
        }
        return true;
    }
    catch(e)
    {
        return false;
    }
}
//实现js版的endWith
String.prototype.endWith=function(str){
    if(str==null||str==""||this.length==0||str.length>this.length){
          return false;
    }
    if(this.substring(this.length-str.length)==str){
          return true;
    }else{
          return false;
    }
    return true;
}
//实现js版的startWith
String.prototype.startWith=function(str){
    if(str==null||str==""||this.length==0||str.length>this.length) {
        return false;
    }
    if(this.substr(0,str.length)==str) {
        return true;
    }else{
        return false;
    }
    return true;
}
//替换所有
String.prototype.ReplaceAll = function(searchArray, replaceArray )
{
	var replaced = this ;

	for ( var i = 0 ; i < searchArray.length ; i++ )
	{
		replaced = replaced.replace( searchArray[i], replaceArray[i] ) ;
	}

	return replaced ;
}
//去除所有html标签
String.prototype.RemoveHtml = function()
{
        return this.replace(/(<[^>]*>)/g, "").replace(/(<[^>]*>)/g, "");
}
//去除左边的空格
String.prototype.LTrim = function()
{
        return this.replace(/(^\s*)/g, "");
}
//去除右边的空格
String.prototype.Rtrim = function()
{
        return this.replace(/(\s*$)/g, "");
}
//去除前后空格
String.prototype.Trim = function()
{
        return this.replace(/(^\s*)|(\s*$)/g, "");
}
//得到左边的字符串
String.prototype.Left = function(len)
{
        if(isNaN(len)||len==null)
        {
                len = this.length;
        }
        else
        {
                if(parseInt(len)<0||parseInt(len)>this.length)
                {
                        len = this.length;
                }
        }
        return this.substr(0,len);
}
//得到右边的字符串
String.prototype.Right = function(len)
{
        if(isNaN(len)||len==null)
        {
                len = this.length;
        }
        else
        {
                if(parseInt(len)<0||parseInt(len)>this.length)
                {
                        len = this.length;
                }
        }
        return this.substring(this.length-len,this.length);
}
//得到中间的字符串,注意从0开始
String.prototype.Mid = function(start,len)
{
        return this.substr(start,len);
}
//在字符串里查找另一字符串:位置从0开始
String.prototype.InStr = function(str)
{
        if(str==null)
        {
                str = "";
        }
        return this.indexOf(str);
}
//在字符串里反向查找另一字符串:位置0开始
String.prototype.InStrRev = function(str)
{
        if(str==null)
        {
                str = "";
        }
        return this.lastIndexOf(str);
}
//是否是有汉字
String.prototype.existChinese = function()
{
        //[\u4E00-\u9FA5]為漢字﹐[\uFE30-\uFFA0]為全角符號
        return /^[\x00-\xff]*$/.test(this);
}
//转换成全角
String.prototype.toCase = function()
{
        var tmp = "";
        for(var i=0;i<this.length;i++)
        {
                if(this.charCodeAt(i)>0&&this.charCodeAt(i)<255)
                {
                        tmp += String.fromCharCode(this.charCodeAt(i)+65248);
                }
                else
                {
                        tmp += String.fromCharCode(this.charCodeAt(i));
                }
        }
        return tmp
}
//对字符串进行Html编码
String.prototype.toHtmlEncode = function()
{
        var str = this;
        str=str.replace(/&/g,"&");
        str=str.replace(/</g,"&lt;");
        str=str.replace(/>/g,"&gt;");
        str=str.replace(/\'/g,"'");
        str=str.replace(/\"/g,"&quot;");
        str=str.replace(/\n/g,"<br/>");
        str=str.replace(/\ /g," ");
        str=str.replace(/\t/g,"    ");
        return str;
}
//转换成日期
String.prototype.toDate = function()
{
	try
	{
			return new Date(this.replace(/-/g, "\/"));
	}
	catch(e)
	{
			return new Date();
	}
}
//格式化时间eg:format="yyyy-MM-dd hh:mm:ss"
String.prototype.format = function(format){
	var thisDate=this.toDate();
	var o = {  
	   "M+" :thisDate.getMonth() + 1,
	   "d+" :thisDate.getDate(),
	   "h+" :thisDate.getHours(),
	   "m+" :thisDate.getMinutes(),
	   "s+" :thisDate.getSeconds(),
	   "q+" :Math.floor((thisDate.getMonth() + 3) / 3),
	   "S" :thisDate.getMilliseconds()
   }
   if (/(y+)/.test(format)) {
	   format = format.replace(RegExp.$1, (thisDate.getFullYear() + "")
			   .substr(4 - RegExp.$1.length));
   }
   for (var k in o) {
	   if (new RegExp("(" + k + ")").test(format)) {
		   format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k]
				   : ("00" + o[k]).substr(("" + o[k]).length)); 
	   }
   }
   return format;
}

function HtmlQueryString()
{    
	var url=window.location.href;
	if(url.indexOf("?")>=0){
		url=url.split("?")[0];
	}
	url=url.replace(/\.html/ig,"");
	if(url.indexOf("page=")>=0)
	{
		return url.split("page=")[1];
	}
	return 1;
}