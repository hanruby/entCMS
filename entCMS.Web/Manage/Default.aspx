<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="entCMS.Manage.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
	body {
		color:			#FFF;
		background:		#66C;	/* color page so it can be seen */
	}

	.ui-layout-north ,
	.ui-layout-south ,
	.ui-layout-west ,
	.ui-layout-east {
	/*	NOTE: hiding an iframe may cause JS errors if the iframe page autoruns a script, so...
		onopen: loadIframePage() == loads the *real* iframe page from "longdesc" attribute at 1st open */
		display:	none;
		overflow:	hidden;
	}
	iframe {
		padding:	0 !important; /* iframes should not have padding */
		/*overflow:	auto !important;*/
	}

	/* color panes so they can be seen */
	.ui-layout-pane {
		color:			#000;
		background:		#EEE;
	}
	/* masks are usually transparent - make them visible (must 'override' default) */
	.ui-layout-mask {
		background:	#C00 !important;
		opacity:	.20 !important;
		filter:		alpha(opacity=20) !important;
	}

	.ui-layout-south {
		padding:	0;		/* south pane is an iframe-container, so remove padding */
	}
	.ui-layout-west {
		padding:	0;		/* west pane has a scrolling content-div, so remove padding */
	}
	.ui-layout-west .ui-layout-content { /* Google IFRAME */
		border-top:		1px solid #BBB;
		border-bottom:	1px solid #BBB;
	}
	.ui-layout-west .header ,
	.ui-layout-west .footer ,
	.ui-layout-west p {
		background:		#EEE;
		font-weight:	bold;
		text-align:		center;
		padding:		5px 10px;
	}
	.ui-layout-west .footer {
		color:			#FFF;
		background:		#777;
	}
	.ui-layout-west p { /* 2nd Footer: "Toggle South" */
		background:		#F9F9F9;
		border:			4px outset #FFF;
		margin:			7px;
	}
	</style>
    <link href="Scripts/jquery.layout.default.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.0.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.layout-130.js" type="text/javascript"></script>
	<script type="text/javascript">
	    /*
	    *	NOTE: For best code readability, view this with a fixed-space font and tabs equal to 4-chars
	    */
	    var myLayout;

	    $(document).ready(function () {
	        myLayout = $("body").layout({
	            resizable: false
	            , minSize: 40
		        , north__size: 50
		        , south__size: 40
		        , west__size: 198
		        , center__minHeight: 200
		        , spacing_closed: 4
                , north__spacing_open: 0
                , south__spacing_open: 0
		        , initClosed: false
		        , maskContents: true // IMPORTANT - enable iframe masking - all panes in this case
	            //, onopen: loadIframePage // same callback for ALL borderPanes
	            //, east__resizeWhileDragging: true	// slow with a page full of iframes!
	            //,	west__initClosed:	false
	            //,	south__initClosed:	false
	            //,	west__maskIframesOnResize: false
	        });
	    });

	    var AppPath = "<%=ResolveUrl(".") %>";

    </script>
    
    <%--<link rel="stylesheet" href="TipsWindown/tipswindow.css" type="text/css" media="all" />
    <script type="text/javascript" src="TipsWindown/tipswindow.js"></script>--%>
    
    <!-- 引入fancybox样式 -->
    <link type="text/css" href="Scripts/fancybox/source/jquery.fancybox.css" rel="Stylesheet" media="screen" />
    <!-- 引入fancybox -->
    <script type="text/javascript" src="Scripts/fancybox/source/jquery.fancybox.pack.js"></script>
    <script type="text/javascript" src="Scripts/fancybox/source/jquery.fancybox.zh-cn.js"></script>
    <!-- 引入zDialog -->
    <script type="text/javascript" src="Scripts/zDialog/zDrag.js"></script>
    <script type="text/javascript" src="Scripts/zDialog/zDialog.js"></script>

    <script type="text/javascript">
        
        function MainFrameReload() {
            //var iframe = document.getElementById("MainFrame");
            var iframe = frames["MainFrame"];
            iframe.document.location.href = iframe.document.location.href;
        }

        function LeftFrameReload() {
            var iframe = frames["LeftFrame"];
            iframe.document.location.href = iframe.document.location.href;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h3>Loading...</h3>
    
    <!-- IFRAME as layout-pane -->
    <iframe class="ui-layout-north" src="Frame/Top.aspx" longdesc="Frame/Top.aspx" frameborder="0" scrolling="no"></iframe>
    
    <!-- IFRAME as layout-pane -->
    <iframe class="ui-layout-center" src="Frame/Main.aspx" longdesc="Frame/Main.aspx" frameborder="0" scrolling="auto" id="MainFrame" name="MainFrame"></iframe>
    
    <!-- IFRAME 'filling' a layout-pane -->
	<iframe class="ui-layout-south" src="Frame/Bottom.aspx" longdesc="Frame/Bottom.aspx" frameborder="0" scrolling="no"></iframe>
    
    <!-- IFRAME as layout-pane -->
    <iframe class="ui-layout-west" src="Frame/Left.aspx" longdesc="Frame/Left.aspx" frameborder="0" scrolling="auto" id="LeftFrame" name="LeftFrame"></iframe>
    </form>
</body>
</html>