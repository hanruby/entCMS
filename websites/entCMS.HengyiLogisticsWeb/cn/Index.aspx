<%@ Page Title="" Language="C#" MasterPageFile="~/cn/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="entCMS.HengyiLogisticsWeb.cn.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <link type="text/css" rel="stylesheet" href="<%=GetClientUrl("~/cn/css/cameraslideshow.css")%>" />
<%--    <script type="text/javascript" src="<%=GetClientUrl("~/Scripts/jquery.mobile.customized.min.js") %>"></script>--%>
    <script type="text/javascript" src="<%=GetClientUrl("~/Scripts/jquery.easing.1.3.js") %>"></script>
    <script type="text/javascript" src="<%=GetClientUrl("~/Scripts/camera.js") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="homebanner">
        <script type="text/javascript">
	        jQuery(window).load(function() {
		        jQuery(function(){
			        jQuery('.camera_wrap').camera({
				        autoAdvance			: true,	//true, false
				        mobileAutoAdvance	: true, //true, false. Auto-advancing for mobile devices
				        barDirection		: 'leftToRight',	//'leftToRight', 'rightToLeft', 'topToBottom', 'bottomToTop'
				        barPosition			: 'bottom',	//'bottom', 'left', 'top', 'right'
				        cols				: 6,
				        easing				: 'easeInOutExpo',	//for the complete list http://jqueryui.com/demos/effect/easing.html
				        mobileEasing		: '',	//leave empty if you want to display the same easing on mobile devices and on desktop etc.
				        fx					: 'mosaicRandom',	//'random','simpleFade', 'curtainTopLeft', 'curtainTopRight', 'curtainBottomLeft', 			'curtainBottomRight', 'curtainSliceLeft', 'curtainSliceRight', 'blindCurtainTopLeft', 'blindCurtainTopRight', 'blindCurtainBottomLeft', 'blindCurtainBottomRight', 'blindCurtainSliceBottom', 'blindCurtainSliceTop', 'stampede', 'mosaic', 'mosaicReverse', 'mosaicRandom', 'mosaicSpiral', 'mosaicSpiralReverse', 'topLeftBottomRight', 'bottomRightTopLeft', 'bottomLeftTopRight', 'bottomLeftTopRight'
												        //you can also use more than one effect, just separate them with commas: 'simpleFade, scrollRight, scrollBottom'
				        mobileFx			: '',	//leave empty if you want to display the same effect on mobile devices and on desktop etc.
				        gridDifference		: 250,	//to make the grid blocks slower than the slices, this value must be smaller than transPeriod
				        height				: '290px',	//here you can type pixels (for instance '300px'), a percentage (relative to the width of the slideshow, for instance '50%') or 'auto'
				        imagePath			: 'images/',	//he path to the image folder (it serves for the blank.gif, when you want to display videos)	
				        loader				: 'none',	//pie, bar, none (even if you choose "pie", old browsers like IE8- can't display it... they will display always a loading bar)
				        loaderColor			: '#eeeeee', 
				        loaderBgColor		: '#222222', 
				        loaderOpacity		: .8,	//0, .1, .2, .3, .4, .5, .6, .7, .8, .9, 1
				        loaderPadding		: 2,	//how many empty pixels you want to display between the loader and its background
				        loaderStroke		: 7,	//the thickness both of the pie loader and of the bar loader. Remember: for the pie, the loader thickness must be less than a half of the pie diameter		
				        minHeight			: '157px',	//you can also leave it blank
				        navigation			: false,	//true or false, to display or not the navigation buttons
				        navigationHover		: false,	//if true the navigation button (prev, next and play/stop buttons) will be visible on hover state only, if false they will be visible always 
				        pagination			: true,
				        playPause			: false,	//true or false, to display or not the play/pause buttons
				        pieDiameter			: 38,
				        piePosition			: 'rightTop',	//'rightTop', 'leftTop', 'leftBottom', 'rightBottom'
				        rows				: 4,
				        slicedCols			: 6,
				        slicedRows			: 4,
				        thumbnails			: false,
				        time				: 7000,	//milliseconds between the end of the sliding effect and the start of the next one
				        transPeriod			: 1500,	//lenght of the sliding effect in milliseconds
				
		                ////////callbacks
				        onEndTransition		: function() {  },	//this callback is invoked when the transition effect ends
				        onLoaded			: function() {  },	//this callback is invoked when the image on a slide has completely loaded
				        onStartLoading		: function() {  },	//this callback is invoked when the image on a slide start loading
				        onStartTransition	: function() {  }	//this callback is invoked when the transition effect starts
			        });
		        });
	        });
        </script>
        <div class="camera_wrap">
            <div data-src='http://livedemo00.template-help.com/wordpress_42048/wp-content/uploads/2011/07/slide-1.jpg'
                data-link='http://livedemo00.template-help.com/wordpress_42048/vestibulum-iaculis/dolor-sit-amet-conse-ctetur-adipisicing-elit-sed-do-2/'
                data-thumb='http://livedemo00.template-help.com/wordpress_42048/wp-content/uploads/2011/07/slide-1-96x41.jpg'>
                <div class="camera_caption moveFromRight green" data-easing="easeOutBack">
                    <h3>Lorem ipsum dolor sit amet conse ctetur</h3>
                    <p>
                        Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor
                        incididunt ut labore et dolore magna aliqua. </p>
                    <a href="http://livedemo00.template-help.com/wordpress_42048/vestibulum-iaculis/dolor-sit-amet-conse-ctetur-adipisicing-elit-sed-do-2/">Read more</a>
                </div>
            </div>
            <div data-src='http://livedemo00.template-help.com/wordpress_42048/wp-content/uploads/2011/07/slide-2.jpg'
                data-link='http://livedemo00.template-help.com/wordpress_42048/portfolio-view/gallery-format/'
                data-thumb='http://livedemo00.template-help.com/wordpress_42048/wp-content/uploads/2011/07/slide-2-96x41.jpg'>
                <div class="camera_caption moveFromRight yellow" data-easing="easeOutBack">
                    <h3>Excepteur sint occaecat cupidatat non proident</h3>
                    <p>
                        Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip
                        ex ea commodo consequat. </p>
                    <a href="http://livedemo00.template-help.com/wordpress_42048/portfolio-view/gallery-format/">Read more</a>
                </div>
            </div>
            <div data-src='http://livedemo00.template-help.com/wordpress_42048/wp-content/uploads/2011/07/slide-3.jpg'
                data-link='http://livedemo00.template-help.com/wordpress_42048/news/sit-amet-conse-ctetur-adipisicing-elit-sed-do-lorem/'
                data-thumb='http://livedemo00.template-help.com/wordpress_42048/wp-content/uploads/2011/07/slide-3-96x41.jpg'>
                <div class="camera_caption moveFromRight orange" data-easing="easeOutBack">
                    <h3>Tempor incididunt ut labore et dolore magna aliqua</h3>
                    <p>
                        Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor
                        incididunt ut labore et dolore magna aliqua. </p>
                    <a href="http://livedemo00.template-help.com/wordpress_42048/news/sit-amet-conse-ctetur-adipisicing-elit-sed-do-lorem/">Read more</a>
                </div>
            </div>
            <div data-src='http://livedemo00.template-help.com/wordpress_42048/wp-content/uploads/2011/07/slide-4.jpg'
                data-link='http://livedemo00.template-help.com/wordpress_42048/general/amet-conse-ctetur-adipisicing-elit/'
                data-thumb='http://livedemo00.template-help.com/wordpress_42048/wp-content/uploads/2011/07/slide-4-96x41.jpg'>
                <div class="camera_caption moveFromRight blue" data-easing="easeOutBack">
                    <h3>Incididunt ut labore et dolore magna aliqua</h3>
                    <p>
                        Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor
                        incididunt ut labore et dolore magna aliqua. </p>
                    <a href="http://livedemo00.template-help.com/wordpress_42048/general/amet-conse-ctetur-adipisicing-elit/">Read more</a>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix box">
        <div class="container_12">
            <div class="grid home-widget">
                <div class="green">
                    <h2><img src="img/home-widget-icon01.gif" align="absmiddle"/>关于我们</h2>
                    <div class="top-box">
                        <div class="box-text">
                            <h4><%=WebName %></h4>
                            <p>宁波亨一国际货运代理有限公司是一家...</p>
                            <p></p>
                        </div>
                        <div class="box-button">
                            <a class="button" href="#">查看更多</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid home-widget">
                <div class="yellow">
                    <h2><img src="img/home-widget-icon02.gif" align="absmiddle"/>新闻资讯</h2>
                    <div class="top-box">
                        <div class="box-text">
                            <ul>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                                <li>
                                    <span class="post-date">2013-07-01</span>
                                    <h4><a href="">第一条新闻</a></h4>
                                </li>
                            </ul>
                        </div>
                        <div class="box-button">
                            <a class="button" href="#">查看更多</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid home-widget">
                <div class="orange">
                    <h2><img src="img/home-widget-icon03.gif" align="absmiddle"/>业务范围</h2>
                    <div class="top-box">
                        <div class="box-text">
                            <ul>
                                <li><a href="">空运</a></li>
                                <li><a href="">海运</a></li>
                                <li><a href="">拖卡</a></li>
                                <li><a href="">仓储</a></li>
                                <li><a href="">报关代理</a></li>
                            </ul>
                        </div>
                        <div class="box-button">
                            <a class="button" href="#">查看更多</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid home-widget">
                <div class="blue">
                    <h2><img src="img/home-widget-icon04.gif" align="absmiddle"/>联系我们</h2>
                    <div class="top-box">
                        <div class="box-text">
                            <h4><%=WebName %></h4>
                            <p>地址：</p>
                            <p>电话：</p>
                            <p>传真：</p>
                            <p>邮箱：</p>
                        </div>
                        <div class="box-button">
                            <a class="button" href="#">查看更多</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
