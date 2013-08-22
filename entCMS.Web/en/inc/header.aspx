<div id="top">
    <div class="top1">
        <div class="logo">
            <a href="<%=WebUrl%>">
                <img border="0" src="<%=WebLogo%>"></a></div>
        <div class="top2">
            <table cellspacing="0" cellpadding="0" border="0" align="right">
                <tbody>
                    <tr>
                        <%foreach(entCMS.Models.cmsLanguage lng in Languages){                       
                            string flag = GetClientUrl("~/Images/flags/"+lng.Code+".gif");
                        %>
                        <td width="22">
                            <img border="0" align="middle" src="<%=flag%>">
                        </td>
                        <td>
                            <a href="<%=GetClientUrl(lng.HomeUrl)%>">
                                <%=lng.ShortName%></a>
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
            <form action="<%=GetCurrentPath() %>/Search.aspx" method="post" name="Search" id="Search">
            <table cellspacing="0" cellpadding="0" border="0" align="right">
                <tbody>
                    <tr>
                        <td width="170">
                            <input type="radio" style="display: none;" checked="checked" value="Product" name="Range" />
                            <input style="background-color: #fff; color: #666; border: 1px #666 solid;" name="Keyword"
                                value="Enter Search Keyword" onfocus="javascript:if(this.value=='Enter Search Keyword') this.value=''"
                                class="search_input" id="Keyword"
                                onblur="javascript:if(this.value=='')this.value='Enter Search Keyword'" />
                        </td>
                        <td>
                            <input type="image" border="0" align="bottom" src="<%=GetCurrentPath() %>/images/btn_search.gif" name="imageField3" onclick="return search();" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <script type="text/javascript">
                function search() {
                    var val = $('#Keyword').val();
                    if (val == 'Enter Search Keyword' || val.replace(/(^\s*)|(\s*$)/g, "") == "") {
                        alert("Please Enter Search Keyword!");
                        return false;
                    }
                    $('#Search')[0].submit();
                    return true;
                }
            </script>
            </form>
        </div>
    </div>
</div>
<div id="menu">
    <div class="menu1">
        <div class="menu">
            <%=TopMenus%>
            <div style="clear: both"></div>
        </div>
    </div>
</div>