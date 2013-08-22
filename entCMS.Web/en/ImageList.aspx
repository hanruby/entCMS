<%@ Page Title="" Language="C#" MasterPageFile="~/en/NestedSite.master" AutoEventWireup="true" CodeBehind="ImageList.aspx.cs" Inherits="entCMS.Web.en.ImageList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div id="lib_product_list">
        <%
            string prodShowFormat = IsUrlRewrite ? "/ImageShow/" : "/ImageShow.aspx?id=";
            int count = 0;
            System.Data.DataTable prodDataTable = GetNews(NodeCode, true, CurPage, 10, ref count);
            foreach (System.Data.DataRow dr in prodDataTable.Rows)
            {
                string title = dr["Title"].ToString();
                string url = GetNewsUrl("ImageShow.aspx", dr["Id"]);
                string img = dr["SmallPic"].ToString();
                
        %>
        <div style="width: 24.90%;" class="item">
            <ul>
                <li style="width: 160px; height: 160px" class="img">
                    <div>
                        <a href="<%=url %>"><img alt="<%=title %>" src="<%=img %>" width="160" height="160" /></a>
                    </div>
                </li>
                <li class="name"><a href="<%=url %>"><%=title %></a></li>
                <li class="price"></li>
            </ul>
        </div>
        <% } %> 
    </div>
    <table border="0" cellpadding="0" cellspacing="0" width="98%">
        <tbody>
            <tr height="35">
                <td align="center">
                    
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
