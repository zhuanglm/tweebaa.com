<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShareProduct.aspx.cs" Inherits="TweebaaWebApp2.Product.ShareProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body itemscope itemtype="http://schema.org/Product">

<!-- Add by Long 2016/01/11 to fix google plus share -->
 <h1 itemprop="name"><%=strProductName%></h1>
  <img itemprop="image" src="<%=strImgSrc %>" />
  <p itemprop="description"><%=strPrdDesc %></p>

</body>
</html>
