<%@ Page Title="" Language="C#" MasterPageFile="~/cn/Site.Master" AutoEventWireup="true"
    CodeBehind="_NewsList.aspx.cs" Inherits="entCMS.HengyiLogisticsWeb.cn.NewsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="insidebanner">
    </div>
    <div class="clearfix box">
        <div class="container_12 clearfix">
            <div id="insidemain" class="fixed">
                <div class="sidebar">
                    <div class="sidemenu">
                        <script type="text/javascript">$(document).ready(function () { highlight(1, 13, 0, 0); });</script>
                        <a onclick="javascript:highlight(1);" id="flip_1" class="flip" href="#">关于我们</a>
                        <ul class="panel" id="panel_1">
                            <li><a class="panel_11" href="#" onclick="javascript:panelsub(1,1);">经营哲学</a></li>
                            <li id="panelsubmenu_11" class="panelsubmenu">
                                <a class="panelsub_111" href="#">我们的企业愿景</a> 
                                <a class="panelsub_112" href="#">我们的标志</a>
                            </li>
                            <li><a class="panel_13" href="#">基本资料</a></li>
                            <li><a class="panel_14" href="#">奖项及嘉许</a></li>
                            <li><a class="panel_15" href="#">质量认证</a></li>
                            <li><a class="panel_16" href="#" onclick="javascript:panelsub(1,6);">社会责任</a></li>
                            <li id="panelsubmenu_16" class="panelsubmenu">
                                <a class="panelsub_161" href="#">环保</a> 
                                <a class="panelsub_162" href="#">社会</a> 
                                <a class="panelsub_163" href="#">推动社区</a> 
                                <a class="panelsub_164" href="#">员工</a> 
                            </li>
                        </ul>
                        <a onclick="javascript:highlight(2);" id="flip_2" class="flip" href="# ">加入我们</a>
                        <ul class="panel" id="panel_2">
                            <li><a class="panel_21" href="#" onclick="javascript:panelsub(2,1);">嘉里物流精英荟萃</a></li>
                            <li id="panelsubmenu_21" class="panelsubmenu">
                                <a class="panelsub_211" href="#">公司简介</a> 
                                <a class="panelsub_212" href="#">理念哲学</a> 
                                <a class="panelsub_213" href="#">物流专才</a> 
                            </li>
                            <li><a class="panel_22" href="#">管理见习生计划</a></li>
                        </ul>
                        <a onclick="javascript:highlight(3);" id="flip_3" class="flip" href="#">新闻发布</a>
                        <ul class="panel" id="panel_3">
                            <li><a class="panel_31" href="#">新闻稿</a></li>
                            <li><a class="panel_32" href="#" onclick="javascript:panelsub(3,2);">刊物</a></li>
                            <li id="panelsubmenu_32" class="panelsubmenu">
                                <a class="panelsub_321" href="#">Kerry Logistics FOCUS</a> 
                                <a class="panelsub_322" href="#">企业册子</a> 
                                <a class="panelsub_323" href="#">行业解决方案</a> 
                                <a class="panelsub_324" href="#">服务宣传册</a> 
                                <a class="panelsub_325" href="#">全球办事处营运单张</a> 
                            </li>
                            <li><a class="panel_33" href="#" onclick="javascript:panelsub(3,3);">图库</a></li>
                            <li id="panelsubmenu_33" class="panelsubmenu">
                                <a class="panelsub_331" href="#">商标</a> 
                                <a class="panelsub_332" href="#">图集</a> 
                                <a class="panelsub_333" href="#">影片</a> 
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="insideright">
                    <span class="BreadcrumbNav">您在这里：
                        <a href="#" class="path">主页</a> &gt; 
                        <a href="#" class="path">公司概览</a> &gt; 
                        <a href="#" class="path">关于我们</a> 
                    </span>
                    <h1 class="contenttitle">亚洲领先的物流服务供应商</h1>
                    <div class="content">
                        <h2 class="subtitle">嘉里物流是亚洲领先的物流服务供应商，也是众多财富 500 强企业一致之选。</h2>
                        我们的总部设于香港，环球网络遍及六大洲，于大中华及东盟地区拥有最庞大及密集的配送网络和物流枢纽。<br>
                        <br>
                        核心业务包括综合物流、国际货代及供应链解决方案等，为各类型商品、非商品及辅助销售材料，提供专业物流服务。<br>
                        <br>
                        数百家来自不同行业的国际顶级品牌及财富五百强企业，选择嘉里物流作为他们的物流伙伴，包括：时尚服饰及精品、电子科技、食品及饮料、快消品、工业及物料科学、汽车、医药等行业。<br>
                        <br>
                        作为一家以资产为基础的企业，我们为客户提供挚诚可靠和别具弹性的方案，配合他们在中国和亚洲的持续增长及未来拓展目标，提供专业而完善的服务。<br>
                        <br>
                        提供全方位专业解决方案是我们的服务方针，全力以赴是我们的态度：这一切由全球员工和合作伙伴体现出来。<br>
                        <br>
                        我们自主研发的供应链可视化系统&nbsp;- KerrierVISION 集高透明度、存取无障碍、联系无间等优点于一身，能为客户带来更大的经济效益。<br>
                        <br>
                        凭借世界级实力、高质素人才、行业专家，以及屡获殊荣的资讯科技系统及运作，我们致力透过更快捷和更具成本效益的方案，将您的产品运抵目的地。<br>
                        <br>
                        亚洲领先的物流服务供应商 - 嘉里物流，是您最佳的合作伙伴。
                    </div>
                    <div class="contentbar"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
