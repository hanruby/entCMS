///-------------------------------------------------------------------------
//jQuery弹出窗口 By Await [2009-11-22]
//--------------------------------------------------------------------------
/*参数：[可选参数在调用时可写可不写,其他为必写]
----------------------------------------------------------------------------
title:	窗口标题
content:  内容(可选内容为){ text | id | img | url | iframe }
width:	内容宽度
height:	内容高度
drag:  是否可以拖动(ture为是,false为否)
time:	自动关闭等待的时间，为空是则不自动关闭
showbg:	[可选参数]设置是否显示遮罩层(0为不显示,1为显示)
cssName:  [可选参数]附加class名称
isref:  [可选参数]关闭时是否刷新??0为不刷新,1为刷新
------------------------------------------------------------------------*/
//示例:
//------------------------------------------------------------------------
//simplewindow("例子","text:例子","500","400","true","3000","0","exa")
//tipswindow('申诉意见','iframe:','630','500','true','','true','',0);return false;
//------------------------------------------------------------------------


var showwindow = true;
var templateSrc = AppPath + "/images/loading.gif"; //设置loading.gif路径
var maxWidth = 950, maxHeight = 700;
function tipswindow(title, content, width, height, drag, time, showbg, cssName, isref) {
    $("#window-box").remove(); //请除内容
    var width = width >= maxWidth ? this.width = maxWidth : this.width = width;     //设置最大窗口宽度
    var height = height >= maxHeight ? this.height = maxHeight : this.height = height;  //设置最大窗口高度
    if (showwindow == true) {
        var simplewindow_html = new String;
        simplewindow_html = "<div id=\"windowbg\" style=\"height:" + $(document).height() + "px;filter:alpha(opacity=0);opacity:0;z-index: 999901\"></div>";
        simplewindow_html += "<div id=\"window-box\" class=\"layer_global_main\">";
        simplewindow_html += "<div id=\"window-title\" class=\"layer_global_title\"><h2></h2><button id=\"window-close\"></button></div>";
        simplewindow_html += "<div id=\"window-content-border\"><div id=\"window-content\"></div></div>";
        simplewindow_html += "</div>";
        $("body").append(simplewindow_html);
        show = false;
    }
    contentType = content.substring(0, content.indexOf(":"));
    content = content.substring(content.indexOf(":") + 1, content.length);
    switch (contentType) {
        case "text":
            $("#window-content").html(content);
            break;
        case "id":
            $("#window-content").html($("#" + content + "").html());
            break;
        case "img":
            $("#window-content").ajaxStart(function () {
                $(this).html("<img src='" + templateSrc + "' class='loading' />");
            });
            $.ajax({
                error: function () {
                    $("#window-content").html("<p class='window-error'>加载数据出错...</p>");
                },
                success: function (html) {
                    $("#window-content").html("<img src=" + content + " alt='' />");
                }
            });
            break;
        case "url":
            var content_array = content.split("?");
            $("#window-content").ajaxStart(function () {
                $(this).html("<img src='" + templateSrc + "' class='loading' />");
            });
            $.ajax({
                type: content_array[0],
                url: content_array[1],
                data: content_array[2],
                error: function () {
                    $("#window-content").html("<p class='window-error'>加载数据出错...</p>");
                },
                success: function (html) {
                    $("#window-content").html(html);
                }
            });
            break;
        case "iframe":
            $("#window-content").ajaxStart(function () {
                $(this).html("<img src='" + templateSrc + "' class='loading' />");
            });
            $.ajax({
                error: function () {
                    $("#window-content").html("<p class='window-error'>加载数据出错...</p>");
                },
                success: function (html) {
                    $("#window-content").html("<iframe src=\"" + content + "\" width=\"100%\" height=\"" + parseInt(height) + "px" + "\" scrolling=\"auto\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\"></iframe>");
                }
            });
    }
    $("#window-title h2").html(title);
    if (showbg == "true") { $("#windowbg").show(); } else { $("#windowbg").remove(); };
    $("#windowbg").animate({ opacity: "0.3" }, "normal"); //设置透明度
    $("#window-box").show();
    if (height >= maxHeight) {
        $("#window-title").css({ width: (parseInt(width) + 24) + "px" });
        $("#window-content").css({ width: (parseInt(width)) + "px", height: height + "px" }); //width: (parseInt(width)+17) + "px"
    } else {
        $("#window-title").css({ width: (parseInt(width)+2) + "px" }); //  width: (parseInt(width)+ 10) + "px"
        $("#window-content").css({ width: width + "px", height: height + "px" });
    }
    var cw = document.documentElement.clientWidth, ch = document.documentElement.clientHeight, est = document.documentElement.scrollTop;
    var _version = browser.version;
    if (_version == 6.0) {
        $("#window-box").css({ left: "50%", top: (parseInt((ch) / 2) + est) + "px", marginTop: -((parseInt(height) + 53) / 2) + "px", marginLeft: -((parseInt(width) + 32) / 2) + "px", zIndex: "999999" });
    } else {
        $("#window-box").css({ left: "50%", top: "50%", marginTop: -((parseInt(height) + 53) / 2) + "px", marginLeft: -((parseInt(width) + 32) / 2) + "px", zIndex: "999999" });
    };
    var Drag_ID = document.getElementById("window-box"), DragHead = document.getElementById("window-title");

    var moveX = 0, moveY = 0, moveTop, moveLeft = 0, moveable = false;
    if (_version == 6.0) {
        moveTop = est;
    } else {
        moveTop = 0;
    }
    var sw = Drag_ID.scrollWidth, sh = Drag_ID.scrollHeight;
    DragHead.onmouseover = function (e) {
        if (drag == "true") { DragHead.style.cursor = "move"; } else { DragHead.style.cursor = "default"; }
    };
    DragHead.onmousedown = function (e) {
        if (drag == "true") { moveable = true; } else { moveable = false; }
        e = window.event ? window.event : e;
        var ol = Drag_ID.offsetLeft, ot = Drag_ID.offsetTop - moveTop;
        moveX = e.clientX - ol;
        moveY = e.clientY - ot;
        document.onmousemove = function (e) {
            if (moveable) {
                e = window.event ? window.event : e;
                var x = e.clientX - moveX;
                var y = e.clientY - moveY;
                if (x > 0 && (x + sw < cw) && y > 0 && (y + sh < ch)) {
                    Drag_ID.style.left = x + "px";
                    Drag_ID.style.top = parseInt(y + moveTop) + "px";
                    Drag_ID.style.margin = "auto";
                }
            }
        }
        document.onmouseup = function () { moveable = false; };
        Drag_ID.onselectstart = function (e) { return false; }
    }
    $("#window-content").attr("class", "window-" + cssName);
    var closewindow = function () {
        $("#windowbg").remove();
        $("#window-box").remove();
    }
    if (time == "" || typeof (time) == "undefined") {
        $("#window-close").click(function () {
            $("#windowbg").remove();
            $("#window-box").remove();
        });
    } else {
        //setTimeout(closewindow,time);
    }

    return false;
}

function windowClose() {
    $("#window-close").click();
    return false;
}

