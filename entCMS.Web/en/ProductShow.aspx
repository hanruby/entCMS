<%@ Page Title="" Language="C#" MasterPageFile="~/en/NestedSite.master" AutoEventWireup="true" CodeBehind="ProductShow.aspx.cs" Inherits="entCMS.Web.en.ProductShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div style="width: 720px;" id="lib_product_detail">
        <div class="info">
            <div style="" class="img">
                <div><img alt="" src="<%=news.SmallPic.Replace("_s","_b") %>" style="width: 300px; height: 300px;"/></div>
            </div>
            <div style="width: 355px;" class="pro_info">
                <div class="proname"><%=news.Title %></div>
                <div class="item">Product No：<%=news.ProductNo %></div>
                <div class="item">Product Model：<%=news.ProductModel %></div>
                <div class="item">Parameter1：<%=news.Parameter1%></div>
                <div class="item">Parameter2：<%=news.Parameter2%></div>
                <div class="item">Parameter3：<%=news.Parameter3%></div>
                <div class="item">Parameter4：<%=news.Parameter4%></div>
                <div class="item">Parameter5：<%=news.Parameter5%></div>
                <div class="price item"></div>
                <div style="padding: 40px 0 0 10px;">
                    <% 
                        string inquiryUrl = GetCurrentPath() + (IsUrlRewrite ? "/Inquiry/0015/" : "/Inquiry.aspx?node=0015&pid=") + news.Id;
                    %>
                    <a href="<%=inquiryUrl %>"><img src="<%=GetCurrentPath() %>/images/inqulry.jpg"></a>
                </div>
            </div>
        </div>
        <div class="description">
            <div class="desc_nav">
                <div>Product Description</div>
            </div>
            <div class="desc_contents">
                <%=news.Content %>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
