<%@ Page Title="" Language="C#" MasterPageFile="~/en/NestedSite.master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="entCMS.Web.en.NewsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">    
    <table border="0" cellpadding="0" cellspacing="0" width="98%">
        <%
            //string newsShowFormat = IsUrlRewrite ? "/NewsShow/" : "/NewsShow.aspx?id=";
            //int count = 0;
            //System.Data.DataTable newsDataTable = GetNews(NodeCode, true, CurPage, 10, ref count);
            foreach (System.Data.DataRow dr in newsDataTable.Rows)
            {
                string url = GetNewsUrl("NewsShow.aspx", dr["Id"]);
        %>
        <tr height="30">
            <td style="border-bottom: dashed 1px #CCCCCC;">
                &nbsp;<img src="<%=GetCurrentPath() %>/images/arr.gif" align="absmiddle" height="4" width="3">&nbsp;&nbsp;
                <a href="<%=url %>"><%=dr["Title"] %></a>
            </td>
            <td style="border-bottom: dashed 1px #CCCCCC;" align="center">
                <%=Convert.ToDateTime(dr["EditTime"]).ToShortDateString() %>
            </td>
        </tr>
        <%}%>
    </table>
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
