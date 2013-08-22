<%@ Page Title="" Language="C#" MasterPageFile="~/cn/Inside.master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="entCMS.HengyiLogisticsWeb.cn.NewsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphNav" runat="server">
    <a href="#" class="path">主页</a> &gt; 
    <a href="#" class="path">公司概览</a> &gt; 
    <a href="#" class="path">关于我们</a>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphTitle" runat="server">
    嘉里物流企业新闻
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSubTitle" runat="server">
    欢迎参阅本公司发布的新闻稿。
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <ul class="indexlistul">
        <li>
            <span>2013-07-15 - 巴西</span>
            <h3><a href="#">嘉里物流收购巴西领先物流企业 进一步发展拉美市场</a></h3>
        </li>
        <li>
            <span>2013-06-11 - 香港</span>
            <h3><a href="#">嘉里物流于中国新开三座物流中心</a></h3>
        </li>
        <li>
            <span>2013-05-20 - 香港</span>
            <h3><a href="#">嘉里物流于香港推出混合动力电动货车</a></h3>
        </li>
        <li>
            <span>2013-05-13 - 中国大陆</span>
            <h3><a href="#">嘉里物流赢得亚洲货运业及供应链奖两项大奖</a></h3>
        </li>
        <li>
            <span>2013-05-06 - 香港</span>
            <h3><a href="#">嘉里物流于香港为歌帝梵建立亚洲区的旅遊零售部包装中心并正式投入运营</a></h3>
        </li>
    </ul>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphFoot" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".indexlistul li:even").css("background", "#f8f8f8");
            $(".indexlistul li:odd").css("background", "none");
        });
    </script>
</asp:Content>
