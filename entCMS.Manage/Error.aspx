﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="entCMS.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        h3{color:#f00;}
        .desc{padding:15px;background-color:#ffffcc;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style=""><h3><asp:Literal ID="ltlMsg" runat="server"></asp:Literal></h3></div>
    <div class="desc"><asp:Literal ID="ltlStackTrace" runat="server"></asp:Literal></div>
    </form>
</body>
</html>
