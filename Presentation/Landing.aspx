<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Landing.aspx.cs" Inherits="Presentation_Landing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
</head>
<body >
    <form id="form1" runat="server"  >
    <div class="row">
    <div class="large-6 columns">
         <img src="../images/logo2.PNG" alt="Logo" style="width:200px; "/>
    </div>
    <div class="large-6 columns">
         <p style="color:#E14658;font-family:Segoe Script; font-weight:bold;font-size:20px;margin-top:10px; margin-bottom:0px; text-align:right" >toll free no. <span style="color:Black">1800-1200-322</span></p>
       <%-- <p style=" color:#ef5845; font-size:20px; margin-top:10px">LAST 14 DAYS LEFT TO EFILE YOUR INCOME TAX RETURN</p>--%>
    </div>
    <div >
        <img src="../Landing%20Images/landingimage1.JPG" style="width:100%; " />
        <img src="../Landing%20Images/landingpattern.JPG" style="width:100%; height:15px"  />
    </div>
    <div>
       <div class="large-6 columns" style="padding:0 10px;">
       <%--<div class="large-6 columns" style="padding:0 10px; border-right: 1px solid #D9D9D9">--%>
            <p style="text-align:center; font-family:MS Sans Serif; font-size:16px; margin-top:0px; margin-bottom:0px">FILE YOUR TAX RETURN</p>
            <p style="color:#E14658; font-family:Segoe Script; font-size:19px; font-weight:bold; text-align:center; margin-top:0px; margin-bottom:0px">FREE</p>
            <p style="text-align:center;font-size:15px; font-weight:bold; margin-top:0px; margin-bottom:0px">with www.echarteredaccountants.com</p>
            <p style="text-align:center; font-size:15px; font-weight:bold; margin-top:0px; margin-bottom:0px ">Assessment Year 2016-17</p>
            <p style=" margin-top:0px; margin-bottom:0px"><img src="../Landing%20Images/bullet.PNG" alt"bullet" style="margin-right:5px; height:27px" /><span style="color:#E14658; text-align:center; font-size:13px">efiling </span><span style=" font-size:13px">Quick & Accurate</span></p>
            <p style=" margin-top:0px; margin-bottom:0px"><img src="../Landing%20Images/bullet.PNG" alt"bullet" style="margin-right:5px;height:27px"/><span style="color:#E14658; text-align:center; font-size:13px">Hassle free </span><span style=" font-size:13px">Return Filing</span></p>
            <p style=" margin-top:0px; margin-bottom:0px"><img src="../Landing%20Images/bullet.PNG" alt"bullet" style="margin-right:5px;height:27px"/><span style="color:#E14658; text-align:center; font-size:13px">100% Guaranteed </span><span style=" font-size:13px">Service</span></p>
        </div>
        <div class="large-6 columns" style="padding:0 10px ;margin-top:0px; margin-bottom:0px">
            <p style="color:#E14658; text-align:center;font-family:MS Sans Serif; font-size:18px; font-weight:bold;margin-top:0px; margin-bottom:0px">Features</p>
            <ul style="font-size:13px;margin-top:0px; margin-bottom:0px">
                <li>Form ITR-1 and ITR-4S available for e-filing</li>
                 <li>Compuation of income under different heads</li>
                 <p style="font-size:11.5px;margin-top:0px; margin-bottom:0px;">* Salary &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;      * Business Income(Presumtive Basis)</p>
                 <p style="font-size:11.5px;margin-top:0px; margin-bottom:0px;">* House property &nbsp; &nbsp;&nbsp;&nbsp;     * Other Sources</p>

                   <%-- <ul style="font-size:11.5px;margin-top:0px; margin-bottom:0px;width:auto">
                        <li>Salary</li>
                        <li>House property</li>
                        <li>Business Income(Presumtive Basis)</li>
                        <li>Other Sources</li>
                    </ul>--%>
                <li>Facility to generate Income Tax Challan 280 </li>
                <li>Create assessee by importing XML</li>
                <li>Facility to e-file ITR without password </li>
                <li>Get computation on single click</li>
                <%--<li>Get ITR 1(Sahaj) form printed </li>--%>

            </ul>
        </div>
      <%--  <div class="large-4 columns" style="padding:0 10px">
            space for third column
        </div>--%>
    </div>
    <div style="clear:both; text-align:center;   ">
        <asp:Button id="btn_redirect" Text="Get Started" runat="server" PostBackUrl="Itr1.aspx" class="button radius" style="margin-top:10px; margin-bottom:0" />
    </div>

  <%--  <div style="clear:both; text-align:center;   ">
        <p style="font-size:15px;margin-top:0px; margin-bottom:0px">your pocket <span style="color:#E14658;font-family:Segoe Script; font-weight:bold; font-size:20px">TAX</span> manager</p>
    </div>--%>
    <%--<div style="text-align:right;  padding-right:10px; margin-top:0px; margin-bottom:0px">
        <p style="color:#E14658;font-family:Segoe Script; font-weight:bold;font-size:15px;margin-top:0px; margin-bottom:0px" >toll free no.<span style="color:Black">1800-1200-322</span></p>
    </div>--%>
    </div>
    </form>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-73250728-1', 'auto');
        ga('send', 'pageview');

    </script>
</body>
</html>
