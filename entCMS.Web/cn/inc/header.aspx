<div class="logo">
    <div class="logo_l"><a href="/"><img src="images/logo3.png" /></a></div>
    <div class="logo_r">
        <div class="langs">
            <ul>
                <li class="right"></li>
                <li class="mid">
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
                </li>
                <li class="left"></li>
            </ul>
            <div class="clear"></div>
        </div>
        <div class="logo_form">
            <form action="Search.aspx" method="post">
            <input type="image" src="images/glass.png" align="middle" />
            <input type="text" name="Keyword" size="30" class="keyword" />
            <input type="image" src="images/search.jpg" align="middle" />
            </form>
        </div>
    </div>
    <div class="clear"></div>
</div>
<div class="nav">
    <div class="nav_l"><img src="images/nav_l.png" /></div>
    <div class="nav_m">
        <%=GetTopMenus("0000", "")%>
    </div>
    <div class="nav_r">
        <img src="images/nav_r.png" /></div>
    <div class="clear"></div>
</div>