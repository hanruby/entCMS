<%@ Page Title="" Language="C#" MasterPageFile="~/cn/NestedSite.master" AutoEventWireup="true" CodeBehind="ProductShow.aspx.cs" Inherits="entCMS.Web.cn.ProductShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="title">
        <span class="title_l"><%=Node.NodeName %></span> 
        <span class="title_r">当前位置: 首页 - <%=GetNavStr(" &gt ")%></span>
        <div class="clear"></div>
    </div>
    <div style="padding-top: 20px">
        <div style="width: 720px;" id="lib_product_detail">
            <div class="info">
                <div style="width: 350px; height: 350px;" class="img">
                    <div><img alt="" src="<%=news.SmallPic.Replace("_s","_b") %>" style="width: 350px; height: 350px;"/></div>
                </div>
                <div style="width: 355px;" class="pro_info">
                    <div class="proname"><%=news.Title %></div>
                    <div class="item">产品编号：<%=news.ProductNo %></div>
                    <div class="item">规格型号：<%=news.ProductModel %></div>
                    <div class="item">参数一：<%=news.Parameter1%></div>
                    <div class="item">参数二：<%=news.Parameter2%></div>
                    <div class="item">参数三：<%=news.Parameter3%></div>
                    <div class="item">参数四：<%=news.Parameter4%></div>
                    <div class="item">参数五：<%=news.Parameter5%></div>
                    <div class="price item"></div>
                    <div style="padding: 40px 0 0 10px;">
                        <% 
                            string inquiryUrl = GetCurrentPath() + (IsUrlRewrite ? "/Inquiry/0004/" : "/Inquiry.aspx?node=0004&pid=") + news.Id;
                        %>
                        <a href="<%=inquiryUrl %>"><img src="<%=GetCurrentPath() %>/images/inqulry.jpg"></a>
                    </div>
                </div>
            </div>
            <div class="description">
                <div class="desc_nav">
                    <div>产品说明</div>
                </div>
                <div class="desc_contents">
                    <%=news.Content %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
