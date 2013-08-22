<%@ Page Title="" Language="C#" MasterPageFile="~/en/NestedSite.master" AutoEventWireup="true"
    CodeBehind="ProductList.aspx.cs" Inherits="entCMS.Web.en.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">  
    <div id="lib_product_list">
        <%
            //string prodShowFormat = IsUrlRewrite ? "/ProductShow/" : "/ProductShow.aspx?id=";
            //int count = 0;
            //System.Data.DataTable prodDataTable = GetNews(NodeCode, true, CurPage, 10, ref count);
            foreach (System.Data.DataRow dr in prodDataTable.Rows)
            {
                string title = dr["Title"].ToString();
                string url = GetNewsUrl("ProductShow.aspx", dr["Id"]);
                string img = dr["SmallPic"].ToString();
                
        %>
        <div style="width: 24.90%;" class="item">
            <ul>
                <li style="width: 160px; height: 130px" class="img">
                    <div>
                        <a href="<%=url %>"><img alt="<%=title %>" src="<%=img %>" width="160" height="130" /></a>
                    </div>
                </li>
                <li class="name"><a href="<%=url %>"><%=title %></a></li>
                <li class="price"></li>
            </ul>
        </div>
        <% } %> 
    </div>
    <div id="turn_page">
        <anp:AspNetPager ID="pager" runat="server"
            AlwaysShow="true" PageSize="20" 
            OnPageChanged="pager_PageChanged" 
            FirstLastButtonsClass="page_button" 
            PagingButtonsClass="page_item" 
            CurrentPageButtonClass="page_item_current">
        </anp:AspNetPager>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
