﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="entCMS.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <h1>测试页面</h1>
    <hr />
    <ul>
		<li><span></span></li>
	</ul>
    <div>
    </div>
    <script type="text/javascript" src="http://tajs.qq.com/stats?sId=26116266" charset="UTF-8"></script>
    <script type="text/javascript">
        //document.write('<a href="http://www.51.la/?5" target="_blank"><img alt="&#x6211;&#x8981;&#x5566;&#x514D;&#x8D39;&#x7EDF;&#x8BA1; VIP &#x7528;&#x6237;" src="http://icon.ajiang.net/icon_0.gif" style="border:none" /></a>\n');
        var a5tf = "51la";
        var a5pu = "";
        var a5pf = "51la";
        var a5su = window.location;
        var a5sf = document.referrer;
        var a5of = "";
        var a5op = "";
        var a5ops = 1;
        var a5ot = 1;
        var a5d = new Date();
        var a5color = "";
        if (navigator.appName == "Netscape") {
            a5color = screen.pixelDepth;
        } else {
            a5color = screen.colorDepth;
        }
        try {
            a5tf = top.document.referrer;
        } catch (e) { }
        try {
            a5pu = window.parent.location;
        } catch (e) { }
        try {
            a5pf = window.parent.document.referrer;
        } catch (e) { }
        try {
            a5ops = document.cookie.match(new RegExp("(^| )AJSTAT_ok_pages=([^;]*)(;|$)"));
            a5ops = (a5ops == null) ? 1 : (parseInt(unescape((a5ops)[2])) + 1);
            var a5oe = new Date();
            a5oe.setTime(a5oe.getTime() + 60 * 60 * 1000);
            document.cookie = "AJSTAT_ok_pages=" + a5ops + ";path=/;expires=" + a5oe.toGMTString();
            a5ot = document.cookie.match(new RegExp("(^| )AJSTAT_ok_times=([^;]*)(;|$)"));
            if (a5ot == null) {
                a5ot = 1;
            } else {
                a5ot = parseInt(unescape((a5ot)[2]));
                a5ot = (a5ops == 1) ? (a5ot + 1) : (a5ot);
            }
            a5oe.setTime(a5oe.getTime() + 365 * 24 * 60 * 60 * 1000);
            document.cookie = "AJSTAT_ok_times=" + a5ot + ";path=/;expires=" + a5oe.toGMTString();

        } catch (e) { }
        try {
            if (document.cookie == "") {
                a5ops = -1;
                a5ot = -1;
            }
        } catch (e) { }
        a5of = a5sf;
        if (a5pf !== "51la") {
            a5of = a5pf;
        }
        if (a5tf !== "51la") {
            a5of = a5tf;
        }
        a5op = a5pu;
        try {
            lainframe
        } catch (e) {
            a5op = a5su;
        }
        //document.write('<img style="width:0px;height:0px" src="http://vip.51.la:82/go2.asp?svid=6&id=5&tpages=' + a5ops + '&ttimes=' + a5ot + '&tzone=' + (0 - a5d.getTimezoneOffset() / 60) + '&tcolor=' + a5color + '&sSize=' + screen.width + ',' + screen.height + '&referrer=' + escape(a5of) + '&vpage=' + escape(a5op) + '" />');
    </script>
    </form>
</body>
</html>
