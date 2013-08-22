<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Main.aspx.cs" Inherits="entCMS.Manage.Frame.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        /* CSS Reset */
        body,div,dl,dt,dd,ul,ol,li,h1,h2,h3,h4,h5,h6,pre,form,fieldset,input,textarea,p,blockquote,th,td{margin:0;padding:0}
        table{border-collapse:collapse;border-spacing:0}
        fieldset,img{border:0}
        address,caption,cite,code,dfn,strong,th,var,em,b{font-style:normal;font-weight:normal}
        ol,ul{list-style:none}
        caption,th{text-align:left}
        h1,h2,h3,h4,h5,h6{font-size:100%;font-weight:normal}
        abbr,acronym{border:0}
        /* CMS_Public */
        body,td{font:12px/1.5 Tahoma,Helvetica,Arial,sans-serif,"\5B8B\4F53"}
        input,textarea{font-size:12px}
        a:link,a:visited,a:active{color:#15428b;text-decoration:none}
        a:hover{color:#3777E1}
        /* Clear */
        .clearfix:after{content:"";display:block;height:0px;clear:both;visibility:hidden}
        .clearfix{display:inline-block}
        * html .clearfix{height:1%}
        /********** CMS_Main **********/
        #cms_main{min-width:768px;padding:5px}
        #main_ad{padding:5px 0px 0px 5px}
        .main_left{padding:5px 0px 5px 5px;margin-right:315px}
        .main_right{float:right;display:inline;margin-right:5px;padding:5px 0px;width:300px}
        .right_top{background:url(../images/main/main_right.gif) no-repeat;font-size:1px;height:5px}
        .right_middle{background:url(../images/main/main_right.gif) repeat-y -300px 0px; padding:0px 10px}
        .right_bottom{background:url(../images/main/main_right.gif) no-repeat 0px -5px;font-size:1px;height:5px;clear:both}
        .main_Lbox{border:#e1e6ed 1px solid;margin-bottom:10px;padding:5px}
        .main_Lbox h3{border-bottom:#b5cbd9 2px solid;line-height:25px;height:25px;color:#15428B;font-weight:bold}
        #sys-quicklink h3{background-position:2px -550px;padding-left:25px}
        #sys-quicklink ul li{display:inline;float:left;padding:10px 10px 10px 20px}
        #sys-quicklink ul li a{float:left;height:21px;line-height:21px;padding:0px 5px 0px 68px;display:inline;white-space:nowrap}
        #sys-quicklink ul li a:link,#sys-quicklink ul li a:visited,#sys-quicklink ul li a:active{background:url(../images/main/sysadd.gif) no-repeat 0px -4px}
        #sys-quicklink ul li a:hover{background:url(../images/main/sysadd.gif) no-repeat 0px -34px}
        #sys-quicklink ul li a span{color:#999;padding:0px 5px}
        #sys-quicklink ul li a span em{color:#F00;padding:0px 2px}
        #sys-guestbook h3{background-position:2px -575px;padding-left:25px}
        #sys-guestbook ul{padding:3px}
        #sys-guestbook ul li{padding:4px 2px;border-bottom:1px dashed #e1e6ed}
        #sys-pro h3{background-position:2px 0px;padding-left:25px}
        #sys-pro h3 span{font-weight:normal;color:#999;padding:0px 5px}
        #sys-pro h3 span em{color:#F00;padding:0px 2px}
        #sys-pro h3 a{float:right;height:20px;line-height:20px;width:65px;display:inline}
        #sys-pro h3 a:link,#sys-pro h3 a:visited,#sys-pro h3 a:active{background:url(../images/main/sysadd.gif) no-repeat 0px -5px}
        #sys-pro h3 a:hover{background:url(../images/main/sysadd.gif) no-repeat 0px -35px}
        #sys-pro h3 a span{display:none}
        #sys-pro ul{padding:3px}
        #sys-pro ul li{padding:4px 2px;border-bottom:1px dashed #e1e6ed}
        #sys-news h3{background-position:2px -601px;padding-left:25px}
        #sys-news h3 span{font-weight:normal;color:#999;padding:0px 5px}
        #sys-news h3 span em{color:#F00;padding:0px 2px}
        #sys-news h3 a{float:right;height:20px;line-height:20px;width:65px;display:inline}
        #sys-news h3 a:link,#sys-news h3 a:visited,#sys-news h3 a:active{background:url(../images/main/sysadd.gif) no-repeat 0px -5px}
        #sys-news h3 a:hover{background:url(../images/main/sysadd.gif) no-repeat 0px -35px}
        #sys-news h3 a span{display:none}
        #sys-news ul{padding:3px}
        #sys-news ul li{padding:4px 2px;border-bottom:1px dashed #e1e6ed}
        .main_seo{padding:5px 0 5px 0}
        .main_seo a{display:block;width:280px;height:120px;position:relative}
        .main_seo a span{display:block;position:absolute;bottom:0px;left:0px;width:280px;height:28px;line-height:28px;font-size:14px;font-weight:bold;text-align:center;background:url(../images/main/70.png);color:#FFF;cursor:pointer}
        #sys-server h3{background-position:2px -625px;padding-left:25px;border-bottom:#b5cbd9 2px solid;line-height:25px;height:25px;color:#15428B;font-weight:bold}
        #sys-server ul{padding:5px 5px 10px 5px;line-height:22px}
        #sys-server ul li{border-bottom:1px dashed #e1e6ed;text-indent:5px;color:#555}
        #sys-service{padding-bottom:5px}
        #sys-service h3{background-position:2px -650px;padding-left:25px;border-bottom:#b5cbd9 2px solid;line-height:25px;height:25px;color:#15428B;font-weight:bold}
        #sys-service p{text-align:center;padding:10px 0px 0px 0px}
        #sys-copyright{padding-bottom:5px}
        #sys-copyright h3{background-position:2px -675px;padding-left:25px;border-bottom:#b5cbd9 2px solid;line-height:25px;height:25px;color:#15428B;font-weight:bold}
        #sys-copyright p{padding:5px 5px 0px 5px;line-height:22px}
        #sys-copyright p img{border:1px solid #f0f0f0}
        .info_add,.edit_item,.edit_manage,.page_content,.member_info,.order_info,.guestbook_info,.sys_info,.sys_chat,.Friend_Link,.sys_admin,.sys_space,.sys_lang,.sys_menu,.mc_title,.mc_titlel,.mc_titler,.input_l,.input_ma,.input_mb,.input_mc,.input_md,.input_mn,.input_r,.input_search,.content_title td,.content_list td,.main_Rbox h3,.main_Lbox h3,.sys_data,.data_item1,.data_item2{background-image:url(../images/main/ico_list.gif);background-repeat:no-repeat}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="titlebar"></div>
    <div class="position"></div>
    <div id="cms_main">
	    <div class="main_right">
		    <div class="right_top">&nbsp;</div>
		    <div class="right_middle">
			    <div class="main_seo"><a href="Optimization.asp" target="mainFrame"><span>点击进入推广接口</span><img src="../images/main/seo.jpg" alt="" height="120" width="280"></a></div>
			    <div class="main_Rbox" id="sys-server">
				    <h3>服务器信息</h3>
				    <ul>
					    <li>当前版本：V3.5.7_Basic</li>
					    <li>当前域名：localhost</li>
					    <li>服务器IP：127.0.0.1　端口：8080</li>
					    <li>IIS版本：Microsoft-IIS/5.1</li>
					    <li>脚本超时时间：90 秒</li>
					    <li>服务器解译引擎：VBScript/5.8.23141</li>
					    <li>FSO读写权限：<span style="color:#090">√</span>
					    </li>
					    <li>JMail.SmtpMail(Dimac JMail 邮件收发)：<span style="color:#F00">×</span>
					    </li>
					    <li>Persits.Jpeg(ASPJPEG:图像读写组件)：<span style="color:#F00">×</span>
					    </li>
				    </ul>
			    </div>
		    </div>
		    <div class="right_bottom">&nbsp;</div>
	    </div>
	    <div class="main_left">
		    <div id="include-weather">
			    <center><iframe src="http://m.weather.com.cn/m/pn11/weather.htm" marginwidth="0" marginheight="0" hspace="0" vspace="0" frameborder="0" height="50" scrolling="no" width="95%"></iframe></center>
		    </div>
		    <div class="main_Lbox" id="sys-guestbook">
			    <h3>最新留言</h3>
			    <ul>
				    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="GuestBook_view.asp?ID=1"><img src="../images/main/info_view.gif" alt="查看test"></a></span><span style="color:#666">&nbsp;2013-05-29&nbsp;&nbsp;</span><span style="font-weight:bold">test</span></li>
			    </ul>
		    </div>
		    <div class="main_Lbox" id="sys-pro">
			    <h3><a href="Products_Add.asp?Menu_ID=2" title="产品展示"><span>添加</span></a>产品展示<span>共<em>12</em>条</span></h3>
			    <ul>
				    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="Products_Edit.asp?ID=12&amp;Menu_ID=2"><img src="../images/main/info_edit.gif" alt="编辑磷酸二氢钾"></a> <a title="确认删除" href="Products_Del.asp?height=105&amp;width=380&amp;ID=12&amp;Menu_ID=2" class="thickbox"><img src="../images/main/info_del.gif" alt="删除磷酸二氢钾"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>磷酸二氢钾</li>
                    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="Products_Edit.asp?ID=11&amp;Menu_ID=2"><img src="../images/main/info_edit.gif" alt="编辑氢化铝锂"></a> <a title="确认删除" href="Products_Del.asp?height=105&amp;width=380&amp;ID=11&amp;Menu_ID=2" class="thickbox"><img src="../images/main/info_del.gif" alt="删除氢化铝锂"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>氢化铝锂</li>
                    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="Products_Edit.asp?ID=10&amp;Menu_ID=2"><img src="../images/main/info_edit.gif" alt="编辑淀粉酶"></a> <a title="确认删除" href="Products_Del.asp?height=105&amp;width=380&amp;ID=10&amp;Menu_ID=2" class="thickbox"><img src="../images/main/info_del.gif" alt="删除淀粉酶"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>淀粉酶</li>
                    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="Products_Edit.asp?ID=9&amp;Menu_ID=2"><img src="../images/main/info_edit.gif" alt="编辑抗氧剂BHT"></a> <a title="确认删除" href="Products_Del.asp?height=105&amp;width=380&amp;ID=9&amp;Menu_ID=2" class="thickbox"><img src="../images/main/info_del.gif" alt="删除抗氧剂BHT"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>抗氧剂BHT</li>
                    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="Products_Edit.asp?ID=8&amp;Menu_ID=2"><img src="../images/main/info_edit.gif" alt="编辑聚乙烯醇"></a> <a title="确认删除" href="Products_Del.asp?height=105&amp;width=380&amp;ID=8&amp;Menu_ID=2" class="thickbox"><img src="../images/main/info_del.gif" alt="删除聚乙烯醇"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>聚乙烯醇</li>
			    </ul>
		    </div>
		    <div class="main_Lbox" id="sys-news">
			    <h3><a href="News_Add.asp?Menu_ID=3" title="新闻中心"><span>添加</span></a>新闻中心<span>共<em>5</em>条</span></h3>
			    <ul>
				    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="News_Edit.asp?ID=5&amp;Menu_ID=3"><img src="../images/main/info_edit.gif" alt="编辑德国巴斯夫三峡库区化工项目开建在即"></a> <a title="确认删除" href="News_Del.asp?height=105&amp;width=380&amp;ID=5&amp;Menu_ID=3" class="thickbox"><img src="../images/main/info_del.gif" alt="删除德国巴斯夫三峡库区化工项目开建在即"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>德国巴斯夫三峡库区化工项目开建在即</li>
                    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="News_Edit.asp?ID=4&amp;Menu_ID=3"><img src="../images/main/info_edit.gif" alt="编辑中国电力投资集团拟在新疆投资30亿"></a> <a title="确认删除" href="News_Del.asp?height=105&amp;width=380&amp;ID=4&amp;Menu_ID=3" class="thickbox"><img src="../images/main/info_del.gif" alt="删除中国电力投资集团拟在新疆投资30亿"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>中国电力投资集团拟在新疆投资30亿</li>
                    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="News_Edit.asp?ID=3&amp;Menu_ID=3"><img src="../images/main/info_edit.gif" alt="编辑全球最大纤维素乙醇工厂投入运营"></a> <a title="确认删除" href="News_Del.asp?height=105&amp;width=380&amp;ID=3&amp;Menu_ID=3" class="thickbox"><img src="../images/main/info_del.gif" alt="删除全球最大纤维素乙醇工厂投入运营"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>全球最大纤维素乙醇工厂投入运营</li>
                    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="News_Edit.asp?ID=2&amp;Menu_ID=3"><img src="../images/main/info_edit.gif" alt="编辑油气生产刺激油田化学品需求快增"></a> <a title="确认删除" href="News_Del.asp?height=105&amp;width=380&amp;ID=2&amp;Menu_ID=3" class="thickbox"><img src="../images/main/info_del.gif" alt="删除油气生产刺激油田化学品需求快增"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>油气生产刺激油田化学品需求快增</li>
                    <li style="" onmouseover="this.style.backgroundColor='#eff5ff'" onmouseout="this.style.backgroundColor=''"><span style="float:right"><a href="News_Edit.asp?ID=1&amp;Menu_ID=3"><img src="../images/main/info_edit.gif" alt="编辑甲醇行业三大问题"></a> <a title="确认删除" href="News_Del.asp?height=105&amp;width=380&amp;ID=1&amp;Menu_ID=3" class="thickbox"><img src="../images/main/info_del.gif" alt="删除甲醇行业三大问题"></a></span><span style="color:#666">&nbsp;2012-08-08&nbsp;&nbsp;</span>甲醇行业三大问题</li>
			    </ul>
		    </div>
	    </div>
    </div>
    </form>
</body>
</html>