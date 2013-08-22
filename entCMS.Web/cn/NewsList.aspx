<%@ Page Title="" Language="C#" MasterPageFile="~/cn/NestedSite.master" AutoEventWireup="true"
    CodeBehind="NewsList.aspx.cs" Inherits="entCMS.Web.cn.NewsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="title">
        <span class="title_l"><%=Node.NodeName %></span> 
        <span class="title_r">当前位置: 首页 - <%=GetNavStr(" &gt ")%></span>
        <div class="clear"></div>
    </div>
    <div class="info">
        <ul id="lib_info_list">
            <%
                //string newsShowFormat = IsUrlRewrite ? "/NewsShow/" : "/NewsShow.aspx?id=";
                string newsListFormat = "<li><span>{0}</span> •&nbsp;&nbsp;<a href='{1}' title='{2}'>{2}</a><div class='clear'></div></li>";
                //int count = 0;
                //System.Data.DataTable newsDataTable = GetNews(NodeCode, true, CurPage, 10, ref count);
                foreach (System.Data.DataRow dr in newsDataTable.Rows)
                {
                    Response.Write(string.Format(newsListFormat,
                        Convert.ToDateTime(dr["EditTime"]).ToShortDateString(),
                        GetNewsUrl("NewsShow.aspx", dr["Id"]),
                        dr["Title"]));
                }
            %>
        </ul>
        <div class="blank6"></div>
        <div id="turn_page">
            <anp:AspNetPager ID="pager" runat="server"
                AlwaysShow="true" PageSize="20" 
                OnPageChanged="pager_PageChanged" 
                FirstLastButtonsClass="page_button" 
                PagingButtonsClass="page_item" 
                CurrentPageButtonClass="page_item_current">
            </anp:AspNetPager>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
