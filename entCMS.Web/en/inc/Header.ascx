<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="entCMS.Web.en.inc.Header" %>

<div id="top">
    <div class="top1">
        <div class="logo">
            <a href="<%=webpage.WebUrl%>"><img border="0" src="<%=webpage.WebLogo%>"></a></div>
        <div class="top2">
            <table cellspacing="0" cellpadding="0" border="0" align="right">
                <tbody>
                    <tr>
                        <%foreach (entCMS.Models.cmsLanguage lng in webpage.Languages)
                          {
                              string flag = webpage.GetClientUrl("~/Images/flags/" + lng.Code + ".gif");
                        %>
                        <td width="22">
                            <img border="0" align="middle" src="<%=flag%>">
                        </td>
                        <td>
                            <a href="<%=webpage.GetClientUrl(lng.HomeUrl)%>">
                                <%=lng.Name%></a>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <%}%>
                    </tr>
                </tbody>
            </table>
            <br/>
            <br/>
            <form action="<%=webpage.GetCurrentPath() %>/Search.aspx" method="post" name="Search" id="Search">
            <table cellspacing="0" cellpadding="0" border="0" align="right">
                <tbody>
                    <tr>
                        <td width="170">
                            <input type="radio" style="display: none;" checked="checked" value="Product" name="Range" />
                            <input style="background-color: #fff; color: #666; border: 1px #666 solid;" name="Keyword"
                                value="Enter Search Keyword" onfocus="javascript:if(this.value=='Enter Search Keyword') this.value=''"
                                class="search_input" id="Keyword" onkeydown="if(event.keyCode==13){search_();return false;}"
                                onblur="javascript:if(this.value=='')this.value='Enter Search Keyword'" />
                        </td>
                        <td>
                            <input type="image" border="0" align="bottom" src="<%=webpage.GetCurrentPath() %>/images/btn_search.gif" name="imageField3" />
                        </td>
                    </tr>
                </tbody>
            </table>
            </form>
        </div>
    </div>
</div>
<div id="menu">
    <div class="menu1">
        <div class="menu">
            <%=webpage.Menus%>
            <div style="clear: both"></div>
        </div>
    </div>
</div>