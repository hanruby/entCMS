<%@ Page Title="" Language="C#" MasterPageFile="~/cn/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="entCMS.Web.cn.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <style type="text/css">
    body{ background-position:top; background-repeat:no-repeat; }
    #head{ height:480px;}
    </style>
    <script type="text/javascript">
    var v=0;
    var arr=new Array();
    arr[0] = '<%=GetCurrentPath() %>/images/mainbg1.jpg';
    //var arr = ['/images/bg.jpg','images file'];
    window.onload = function(){
	    changeBg();
	    if( arr.length>1 ){
		    setInterval("changeBg()", 5000);
	    }
    }
    function changeBg()
    {
	    if(v>1){
		    v=0;
	    }
	    document.body.style.background = "url('"+arr[v]+"') no-repeat center top";
	    v++;
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="main">
        <div class="products_nav">
            <h3>产品列表</h3>
            <%=GetTopMenus("0002", "") %>
            <a href="<%=GetNodeUrl("0002", false)%>"><img src="<%=GetCurrentPath() %>/images/more.jpg" /></a>
            <div class="clear"></div>
        </div>
        <div class="products">
            <div class="l"><a href="javascript:void(0);" onclick="this.blur(); ISL_GoDown();"><img src="<%=GetCurrentPath() %>/images/left.jpg" /></a></div>
            <div class="list" id="index_product_scroll">
                <div class="Cont" id="ISL_Cont">
                    <div class="ScrCont" onmouseover="ISL_Stop();" onmouseout="ISL_Start();">
                        <div id="scroll_list_1">
                        <%  
                            //string prodShowFormat = IsUrlRewrite ? "/ProductShow/" : "/ProductShow.aspx?id=";
                            string procLiFormat = "<ul class='item'>";
                            procLiFormat += "<li class='img'><a class='img' href='{0}' title='{1}'><img src='{2}' alt='{1}' /></a></li>";
                            procLiFormat += "<li class='name'><a class='name' href='{0}' title='{1}'>{1}</a></li>";
                            procLiFormat += "</ul>";
                            System.Data.DataTable dtProc = GetIndexNews(4, 6);
                            for (int i = 0; i < dtProc.Rows.Count; i++)
                            {
                                System.Data.DataRow dr = dtProc.Rows[i];
                                string url = GetNewsUrl("ProductShow.aspx", dr["Id"]);
                                Response.Write(string.Format(procLiFormat, url, dr["Title"], dr["SmallPic"]));
                            }
                        %>
                        </div>
                        <div id="scroll_list_2"></div>
                    </div>
                </div>
            </div>
            <div class="r">
                <a href="javascript:void(0);" onclick="this.blur(); ISL_GoUp();"><img src="<%=GetCurrentPath() %>/images/right.jpg" /></a></div>
            <script type="text/javascript" src="<%=GetClientUrl("/scripts/scroll.js")%>"></script>
        </div>
        <div class="info">
            <div class="news">
                <div class="title">
                    <h3>最新新闻</h3> <a href="<%=GetNodeUrl("0003", false)%>"><img src="images/more.jpg" /></a>
                    <div class="clear"></div>
                </div>
                <ul>
                    <%  
                        //string newsShowFormat = IsUrlRewrite ? "/NewsShow/" : "/NewsShow.aspx?id=";
                        string newsLiFormat = "<li><a href='{0}' title='{1}'>{1}</a><span>{2}</span><div class='clear'></div></li>";
                        System.Data.DataTable dtNews = GetIndexNews(2, 5);
                        for (int i = 0; i < dtNews.Rows.Count; i++)
                        {
                            System.Data.DataRow dr = dtNews.Rows[i];
                            string url = GetNewsUrl("NewsShow.aspx", dr["Id"]);
                            Response.Write(string.Format(newsLiFormat, url, dr["Title"], Convert.ToDateTime(dr["EditTime"]).ToString("yyyy-MM-dd")));
                        }
                        
                        %>
                </ul>
            </div>
            <div class="new_line"><img src="<%=GetCurrentPath() %>/images/line.jpg" /></div>
            <div class="about">
                <div class="title">
                    <h3>关于我们</h3> <a href="<%=GetNodeUrl("0001", false) %>"><img src="<%=GetCurrentPath() %>/images/more.jpg" /></a>
                    <div class="clear">
                    </div>
                </div>
                <div id="aboutll">
                    <%=Company.Summary %>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
    <a id="online_param" href="?t=<%=onlineType %>&u=/&x=<%=onlineX %>&y=<%=onlineY %>&lang=<%=CurrentLanguage.Id %>"></a>
    <script type="text/javascript" src="<%=GetClientUrl("~/Manage/scripts/online.js") %>"></script>
</asp:Content>