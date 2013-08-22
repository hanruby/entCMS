<%@ Page Title="" Language="C#" MasterPageFile="~/en/NestedSite.master" AutoEventWireup="true" CodeBehind="Inquiry.aspx.cs" Inherits="entCMS.Web.en.Inquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <script src="<%=GetCurrentPath() %>/js/checkform.js" type="text/javascript"></script>
    <div id="lib_product_inquire">
        <% if (news.Id > 0)
            {
                string prodShowUrl = GetCurrentPath() + (IsUrlRewrite ? "/ProductShow/" : "/ProductShow.aspx?id=") + news.Id;
        %>
        <div class="product_list">
            <div style="width: 720px;" class="item">
                <div style="padding:10px;" class="img">
                    <div><a target="_blank" href="<%=prodShowUrl %>"><img src="<%=news.SmallPic %>" /></a></div>
                </div>
                <div class="info">
                    <div class="proname"><a target="_blank" href="<%=prodShowUrl %>"><%=news.Title %></a></div>
                    <div class="item">Product No：<%=news.ProductNo %></div>
                    <div class="item">Product Model：<%=news.ProductModel %></div>
                    <div class="item">Parameter1：<%=news.Parameter1%></div>
                    <div class="item">Parameter2：<%=news.Parameter2%></div>
                    <div class="item">Parameter3：<%=news.Parameter3%></div>
                    <div class="item">Parameter4：<%=news.Parameter4%></div>
                    <div class="item">Parameter5：<%=news.Parameter5%></div>
                    <div class="price item"></div>
                    <div class="flh_180"></div>
                </div>
                <div class="cline">
                    <div class="line"></div>
                </div>
            </div>
        </div>
        <% } %>
        <div style="width: 720px;" class="form">
            <div class="rows">
                <label>First Name：<font class="fc_red">*</font></label>
                <span><input type="text" maxlength="20" size="25" check="First Name must be enter!~*" class="form_input" name="FirstName" /></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label>Last Name：<font class="fc_red">*</font></label>
                <span><input type="text" maxlength="20" size="25" check="Last Name must be enter!~*" class="form_input" name="LastName" /></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label>Company：</label>
                <span><input type="text" maxlength="100" size="70" class="form_input" name="Company" /></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label>Address：</label>
                <span><input type="text" maxlength="200" size="70" class="form_input" value="" name="Address"/></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label>Email：<font class="fc_red">*</font></label>
                <span><input type="text" maxlength="100" size="50" check="Email must be enter!~email|email is not validate!*" class="form_input" value="" name="Email" /></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label>Phone：</label>
                <span>
                    <input type="text" maxlength="20" size="40" class="form_input" value="" name="Phone" /></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label>Fax：</label>
                <span><input type="text" maxlength="20" size="40" class="form_input" value="" name="Fax"/></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label>Subject：<font class="fc_red">*</font></label>
                <span><input type="text" maxlength="100" size="50" check="Subject must be enter!~*" class="form_input" name="Title" /></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label>Content：<font class="fc_red">*</font></label>
                <span><textarea check="Content must be enter!~*" class="form_area contents" name="Content"></textarea></span>
                <div class="clear"></div>
            </div>
            <div class="rows">
                <label></label>
                <span><input type="submit" value="Submit" class="form_button" name="Submit" onclick="return checkForm(this.form)" /></span>
                <div class="clear"></div>
            </div>
            <input type="hidden" value="<%=news.Id %>" name="pid" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
