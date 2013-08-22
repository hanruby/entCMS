<%@ Page Title="" Language="C#" MasterPageFile="~/cn/NestedSite.master" AutoEventWireup="true"
    CodeBehind="Inquiry.aspx.cs" Inherits="entCMS.Web.cn.Inquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMain" runat="server">
    <div class="title">
        <span class="title_l">
            <%=Node.NodeName %></span> <span class="title_r">当前位置: 首页 -
                <%=GetNavStr(" &gt ")%></span>
        <div class="clear">
        </div>
    </div>
    <div style="padding-top: 20px">
        <script src="<%=GetCurrentPath() %>/js/checkform.js" type="text/javascript"></script>
        <div id="lib_product_inquire">
            <% if (news.Id > 0)
               {
                   string prodShowUrl = GetCurrentPath() + (IsUrlRewrite ? "/ProductShow/" : "/ProductShow.aspx?id=") + news.Id;
            %>
            <div class="product_list">
                <div style="" class="item">
                    <div style="padding:10px;" class="img">
                        <div><a target="_blank" href="<%=prodShowUrl %>"><img src="<%=news.SmallPic %>" /></a></div>
                    </div>
                    <div class="info">
                        <div class="proname"><a target="_blank" href="<%=prodShowUrl %>"><%=news.Title %></a></div>
                        <div class="item">产品编号：<%=news.ProductNo %></div>
                        <div class="item">规格型号：<%=news.ProductModel %></div>
                        <div class="item">参数一：<%=news.Parameter1%></div>
                        <div class="item">参数二：<%=news.Parameter2%></div>
                        <div class="item">参数三：<%=news.Parameter3%></div>
                        <div class="item">参数四：<%=news.Parameter4%></div>
                        <div class="item">参数五：<%=news.Parameter5%></div>
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
                    <label>姓名：<font class="fc_red">*</font></label>
                    <span><input type="text" maxlength="20" size="25" check="姓名必须输入!~*" class="form_input" name="Name" /></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label>公司：</label>
                    <span><input type="text" maxlength="100" size="70" class="form_input" name="Company" /></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label>地址：</label>
                    <span><input type="text" maxlength="200" size="70" class="form_input" value="" name="Address"/></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label>邮编：</label>
                    <span><input type="text" maxlength="20" size="10" class="form_input" value="" name="Zipcode"/></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label>电子邮箱：<font class="fc_red">*</font></label>
                    <span><input type="text" maxlength="100" size="50" check="电子邮箱必须输入!~email|邮箱格式不正确!*" class="form_input" value="" name="Email" /></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label>联系电话：</label>
                    <span>
                        <input type="text" maxlength="20" size="40" class="form_input" value="" name="Phone" /></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label>传真：</label>
                    <span><input type="text" maxlength="20" size="40" class="form_input" value="" name="Fax"/></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label>标题：<font class="fc_red">*</font></label>
                    <span><input type="text" maxlength="100" size="50" check="标题必须输入!~*" class="form_input" name="Title" /></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label>内容：<font class="fc_red">*</font></label>
                    <span><textarea check="内容必须输入!~*" class="form_area contents" name="Content"></textarea></span>
                    <div class="clear"></div>
                </div>
                <div class="rows">
                    <label></label>
                    <span><input type="submit" value="提交" class="form_button" name="Submit" onclick="return checkForm(this.form)" /></span>
                    <div class="clear"></div>
                </div>
                <input type="hidden" value="<%=news.Id %>" name="pid" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFoot" runat="server">
</asp:Content>
