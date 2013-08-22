<%@ Page Title="" Language="C#" MasterPageFile="~/Manage/MasterPage.master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="entCMS.Manage.Frame.Main1" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        body,td{font:12px/1.5 Tahoma,Helvetica,Arial,sans-serif,"宋体"}
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
        .main_Lbox h3{border-bottom:#b5cbd9 2px solid;line-height:25px;height:25px;color:#15428B;font-weight:bold;padding-left:25px;}
        .main_Lbox .text {background: none repeat scroll 0 0 #FAFAFA;padding: 8px;}
        #sys-home h3{background-position:2px -175px;}
        #sys-home h4{color: #124BB5;padding-left: 5px;font-size:100%;font-weight:bold;}
        #sys-home h4.line{margin-top:8px;}
        #sys-home ul{margin-top: 5px;padding-left:15px;}
        #sys-home ul li{color: #339900;display: inline;line-height: 2;margin-right: 15px;overflow: hidden;}
        #sys-home ul li span{color:#000;margin-right:5px;}
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
        #sys-server ul li{border-bottom:1px dashed #e1e6ed;text-indent:0px;color: #339900;}
        #sys-server ul li span{color:#000;}
        #sys-service{padding-bottom:5px}
        #sys-service h3{background-position:2px -650px;padding-left:25px;border-bottom:#b5cbd9 2px solid;line-height:25px;height:25px;color:#15428B;font-weight:bold}
        #sys-service p{text-align:center;padding:10px 0px 0px 0px}
        #sys-copyright{padding-bottom:5px}
        #sys-copyright h3{background-position:2px -675px;padding-left:25px;border-bottom:#b5cbd9 2px solid;line-height:25px;height:25px;color:#15428B;font-weight:bold}
        #sys-copyright p{padding:5px 5px 0px 5px;line-height:22px}
        #sys-copyright p img{border:1px solid #f0f0f0}
        .info_add,.edit_item,.edit_manage,.page_content,.member_info,.order_info,.guestbook_info,.sys_info,.sys_chat,.Friend_Link,.sys_admin,.sys_space,.sys_lang,.sys_menu,.mc_title,.mc_titlel,.mc_titler,.input_l,.input_ma,.input_mb,.input_mc,.input_md,.input_mn,.input_r,.input_search,.content_title td,.content_list td,.main_Rbox h3,.main_Lbox h3,.sys_data,.data_item1,.data_item2{background-image:url(../images/main/ico_list.gif);background-repeat:no-repeat}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitle" runat="server">
    后台首页
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPosition" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphButtons" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphMain" runat="server">
    <div id="cms_main">
	    <div class="main_right">
		    <div class="right_top">&nbsp;</div>
		    <div class="right_middle">
			    <div class="main_seo"><a href="../Extend.aspx" target="MainFrame"><span>点击进入推广接口</span><img src="../images/main/seo.jpg" alt="" height="120" width="280"></a></div>
			    <div class="main_Rbox" id="sys-server">
				    <h3>服务器信息</h3>
				    <ul>
					    <li><span>当前版本：</span><asp:Literal ID="ltlVer" runat="server"></asp:Literal></li>
					    <li><span>操作系统：</span><%=System.Environment.OSVersion.ToString()%></li>
                        <li><span>内存数：</span><asp:Literal ID="ltlMem" runat="server"></asp:Literal></li>
                        <li><span>CPU类型：</span><%=Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")%></li>
                        <li><span>CPU数：</span><%=System.Environment.ProcessorCount %></li>
                        <li><span>站点物理路径：</span><%=HttpContext.Current.Request.PhysicalApplicationPath%></li>
                        <li><span>站点物理路径：</span><%=HttpContext.Current.Request.PhysicalApplicationPath%></li>
					    <li><span>服务软件：</span><%=HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"]%></li>
                        <li><span>端口：</span><%=HttpContext.Current.Request.ServerVariables["Server_Port"]%></li>
					    <li><span>服务器名：</span><%=System.Environment.MachineName%></li>
                        <li><span>DOTNET 版本：</span><%=System.Environment.Version%></li>
                        <li><span>服务器时区：</span><%=((DateTime.Now - DateTime.UtcNow).TotalHours > 0 ? "+" + (DateTime.Now - DateTime.UtcNow).TotalHours.ToString() : "" + (DateTime.Now - DateTime.UtcNow).TotalHours)%> 小时</li>
					    <li><span>脚本超时时间：</span><%=Server.ScriptTimeout%> 秒</li>
					    <li><span>开机运行时长：</span><%=((System.Environment.TickCount / 3600000).ToString("N2")) %></li>
					    <li><span>进程开始时间：</span><asp:Literal ID="ltlPST" runat="server"></asp:Literal></li>
					    <li><span>AspNet内存占用：</span><asp:Literal ID="ltlANM" runat="server"></asp:Literal> M</li>
					    <li><span>AspNet CPU时间：</span><asp:Literal ID="ltlANCT" runat="server"></asp:Literal> 秒</li>

				    </ul>
			    </div>
		    </div>
		    <div class="right_bottom">&nbsp;</div>
	    </div>
	    <div class="main_left">
		    <div id="include-weather">
			    <center><%--<iframe src="http://m.weather.com.cn/m/pn11/weather.htm" marginwidth="0" marginheight="0" hspace="0" vspace="0" frameborder="0" height="50" scrolling="no" width="95%"></iframe>--%></center>
		    </div>
            <div class="main_Lbox" id="sys-home">
                <h3>概况</h3>
                <div class="text">
                    <h4>用户信息</h4>
                    <ul>
				        <li><span>用户名：</span><asp:Literal ID="ltlName" runat="server"></asp:Literal></li>
				        <li><span>登录次数：</span><asp:Literal ID="ltlCnt" runat="server"></asp:Literal></li>
				        <li><span>IP：</span><asp:Literal ID="ltlIP" runat="server"></asp:Literal></li>
				        <li><span>登录时间：</span><asp:Literal ID="ltlTime" runat="server"></asp:Literal></li>
			        </ul>
                    <h4 class="line">内容概况</h4>
                    <ul>
                        <li><span>图文模块：</span><asp:Literal ID="Literal1" runat="server"></asp:Literal></li>
                        <li><span>文章模块：</span><asp:Literal ID="Literal2" runat="server"></asp:Literal></li>
                        <li><span>图片模块：</span><asp:Literal ID="Literal3" runat="server"></asp:Literal></li>
                        <li><span>产品模块：</span><asp:Literal ID="Literal4" runat="server"></asp:Literal></li>
                        <li><span>留言模块：</span><asp:Literal ID="Literal5" runat="server"></asp:Literal></li>
                        <li><span>招聘模块：</span><asp:Literal ID="Literal6" runat="server"></asp:Literal></li>
                        <li><span>友链模块：</span><asp:Literal ID="Literal7" runat="server"></asp:Literal></li>
                    </ul>
                    <!--
                    <h4 class="line">访问概况</h4>
                    <ul>
                        <li><span>今日：</span>0</li>
                        <li><span>独立访客：</span>0</li>
                        <li><span>IP：</span>0</li>
                    </ul>
                    -->
                </div>
            </div>
		    <div class="main_Lbox" id="sys-guestbook">
			    <h3><a href="../Module/FeedbackList.aspx" title="留言列表"><span>最新留言</span></a></h3>
			    <ul>
                    <%                        
                        for (int i = 0; i < LastedFeedbacks.Rows.Count; i++)
                        {
                            DataRow dr = LastedFeedbacks.Rows[i];
                            Response.Write(string.Format("<li style=''onmouseover=\"this.style.backgroundColor='#eff5ff'\" onmouseout=\"this.style.backgroundColor=''\"><span style='float:right'><a href='../Module/FeedbackShow.aspx?id={0}'><img src='../images/main/info_view.gif' alt='查看'></a></span><span style='color:#666'>&nbsp;{1}&nbsp;&nbsp;</span><span style='font-weight:bold'>{2}</span></li>", dr["Id"], Convert.ToDateTime(dr["PostTime"]).ToString("yyyy-MM-dd"), dr["Title"]));
                        }
                    %>
			    </ul>
		    </div>
		    <div class="main_Lbox" id="sys-pro">
			    <h3><a href="../Module/ProductAdd.aspx" title="添加产品"><span>添加</span></a>产品中心</h3>
			    <ul>
                    <%                        
                        for (int i = 0; i < LastedProducts.Rows.Count; i++)
                        {
                            DataRow dr = LastedProducts.Rows[i];
                            Response.Write(string.Format("<li style=''onmouseover=\"this.style.backgroundColor='#eff5ff'\" onmouseout=\"this.style.backgroundColor=''\"><span style='float:right'><a href='../Module/ProductAdd.aspx?id={0}&action=edit'><img src='../images/main/info_view.gif' alt='查看'></a></span><span style='color:#666'>&nbsp;{1}&nbsp;&nbsp;</span><span style='font-weight:bold'>{2}</span></li>", dr["Id"], Convert.ToDateTime(dr["EditTime"]).ToString("yyyy-MM-dd"), dr["Title"]));
                        }
                    %>
			    </ul>
		    </div>
		    <div class="main_Lbox" id="sys-news">
			    <h3><a href="../Module/NewsAdd.aspx" title="添加新闻"><span>添加</span></a>新闻中心</h3>
			    <ul>
                    <%                        
                        for (int i = 0; i < LastedNewses.Rows.Count; i++)
                        {
                            DataRow dr = LastedNewses.Rows[i];
                            Response.Write(string.Format("<li style=''onmouseover=\"this.style.backgroundColor='#eff5ff'\" onmouseout=\"this.style.backgroundColor=''\"><span style='float:right'><a href='../Module/NewsAdd.aspx?id={0}&action=edit'><img src='../images/main/info_view.gif' alt='查看'></a></span><span style='color:#666'>&nbsp;{1}&nbsp;&nbsp;</span><span style='font-weight:bold'>{2}</span></li>", dr["Id"], Convert.ToDateTime(dr["EditTime"]).ToString("yyyy-MM-dd"), dr["Title"]));
                        }
                    %>
			    </ul>
		    </div>
	    </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphOther" runat="server">
</asp:Content>
