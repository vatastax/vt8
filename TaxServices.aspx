<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TaxServices.aspx.cs" Inherits="TaxServices" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>

<html class="no-js" lang="en" >
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
 <meta name="viewport" content="width=device-width, initial-scale=1.0" />

<meta charset="utf-8"/>
    <title></title>
    <link href="foundation-5.5.0/css/foundation.css" rel="stylesheet" type="text/css" />
    <script src="foundation-5.5.0/js/foundation.min.js" type="text/javascript"></script>

      <script src="js/ajax-googleapis-com-aja-libs-jquery-1.11.1-jquery.min.js" type="text/javascript"></script>
      <script src="bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
     <script src="js/modernizr.custom.34978.js" type="text/javascript"></script>
      <script src="js/rmm-js/responsivemobilemenu.js" type="text/javascript"></script>

     <!--master javascript file-->
    <script src="js/MasterJScript.js" type="text/javascript"></script>
   <!--master javascript file-->

   
    <!--master style sheet-->
    <link href="style_folder/StaticStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <%--StyleSheets for box - jaipal--%>
    <script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
    <link href="css/big_box_style.css" rel="stylesheet" type="text/css" />
     <%--StyleSheets for box - jaipal--%>
</head>
<body>
    <form id="form1" runat="server">
   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
        <%--<div class="row hide-for-small-only ">
    <div class="large-12 columns">
    <%--Add by nishu for header 11/4/2015 --%>
  
  <%--<img src="images/logo2.png" style="width:240px">--%>
   <%-- </div>
    </div--%>
    <br />
    <%------------------show logo and menu on mobile screen -----------------------%>
     <div class="row show-for-small-only ">
         <div class="large-3 columns" >
         
            <a href="Default.aspx"><img src="images/logo2.png" style="width:240px" /></a>
      
      
        </div>
        <div class="large-9 columns ">
        <div class="rmm" data-menu-style = "minimal">
          <ul  >
          <li><a href="default.aspx" class="button">Go To</a></li>
          <li><a href="itrscreenshots.aspx" class="button">Demo e-filing</a></li>
          <li><a href="PriceGuide.aspx" class="button">Price Guide</a></li>
            <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
               <li><asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout1_Click"></asp:LinkButton></li> 
          </ul>
          </div>
         </div>
    
       </div>

    <%------------------show logo and menu on medium and large screen ----------%>  
     <div class="row hide-for-small-only" >
         <div class="large-4 columns" >
         
            
             <a href="Default.aspx"><img src="images/logo2.png" style="width:240px" /></a>
      
        </div>
        <div class="large-8 columns ">
          <ul class="right button-group">
          <li><a  class="button">Go-To</a>
          <ul style="background-color:gray; opacity:0.8; border:1px solid gray; border-radius:10px; padding:0 10px">
                  <li style="padding-top:4px;"><a href="pageRedirect.aspx?prj=tds" style="color:white;" ><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Tax Deducted at Source</a>  <a href="vat.aspx" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Value Added Tax</a></li>
                <li style="padding-top:2px;"><a href="pageRedirect.aspx?prj=stax" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Service Tax</a >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <a href="cet.aspx" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Central Excise Tax</a></li>
                 <li style="padding-top:2px;padding-bottom:2px;"><a href="nri.aspx" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;NRI Taxation</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="tp.aspx" style="color:white;"><img src="images/bullet.png" />&nbsp;&nbsp;&nbsp;Transfer Pricing</a></li>
            </ul>
          </li>
          <li><a href="itrscreenshots.aspx" class="button">Demo e-filing</a></li>
          <li><a href="PriceGuide.aspx" class="button">Price Guide</a></li>
            <%--<li><a href="#" class="button">Rates and Tables</a></li>--%>
               <li><asp:LinkButton ID="LinkButton2" runat="server" Text="Logout" CssClass="button" OnClick="lbtnLogout11_Click"></asp:LinkButton></li>      
          </ul>
         </div>
         <div style="float:right;"><asp:Literal ID="ltWelcome" runat="server"></asp:Literal> </div>
       </div>

      <div class="row ">
        <div class="large-12 columns " >
          <br />
             <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="calibri" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        </div>
         
    </div>
  
    <div class="row" >
    <div class="large-12 columns" style="margin-bottom:80px">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="VwITRV" runat="server">
             <%--<fieldset  style="background-color:#F8F8F8; width:80%">
                <legend>Check Your ITR-V Status</legend>--%>
                   
                   <%-- <br />
                    <table style="width:80%; border:0px">
                    <tr>
                    <td>--%>
            <div class="row">
                 <div class="large-12 columns" style="margin:10px; color:#ef5845; font-size:18px;  font-weight:bold;">
                    Check Your ITR-V Status
                </div>  
            </div>
            <div class="row" style="background-color:#F8F8F8; border:1px solid #DDDDDD;width:100%; padding:20px 0">
               
              <div class="large-12 columns" style="margin:10px">
                  <div class="large-6 columns" >    
                    <asp:Label ID="Label12" runat="server" Text="Enter PAN Number : "></asp:Label>
                  </div>
                   <%-- </td>
                    <td>--%>
                   <div class="large-6 columns">     
                     <asp:TextBox ID="Txt_PAN" runat="server" Width="240px" Height="35px"></asp:TextBox>
                   </div>
                 </div>
                   <%-- </td>
                    </tr>
                    <tr style="background-color:White">
                    <td>
                    &nbsp;
                    </td>
                    <td>
                     &nbsp;
                    </td>
                    </tr>
                      <tr>
                    <td>--%>
               <div class="large-12 columns" style="margin:10px">
                  <div class="large-6 columns">
                     <asp:Label ID="Label3" runat="server" Text="Enter Assessment Year : "></asp:Label>
                  </div>
                    <%--</td>
                    <td>--%>
                   <div class="large-6 columns">
                     <asp:DropDownList ID="DDLYear" runat="server" Width="240px">
                            </asp:DropDownList>
                   </div>
                </div>
                   <%-- </td>
                    </tr>
                    <tr style="background-color:White">
                    <td>
                    &nbsp;
                    </td>
                    <td>
                     &nbsp;
                    </td>
                    </tr>
                      <tr>
                    <td>--%>
                    <div class="large-12 columns" style="margin:10px">
                      <div class="large-6 columns"></div>
                      <div class="large-6 columns">
                         <asp:Button ID="Button2" runat="server" Text="Retreive Data" 
                                onclick="Button2_Click" class="button" />
                       </div>
                    </div>
                    <%--</td>
                    <td>
                    </td>
                    </tr>
                    <tr style="background-color:White">
                    <td>
                    &nbsp;
                    </td>
                    <td>
                     &nbsp;
                    </td>
                    </tr>
                      <tr>
                    <td>--%>
                <div class="large-12 columns" style="margin:10px">
                    <div class="large-6 columns">
                      <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </div>
                   <%-- </td>
                    <td>--%>
                    <div class="large-6 columns">
                       <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                    <%--</td>
                    </tr>
                    <tr style="background-color:White">
                    <td>
                    &nbsp;
                    </td>
                    <td>
                     &nbsp;
                    </td>
                    </tr>
                      <tr>
                    <td>--%>
                  <div class="large-12 columns" style="margin:10px; text-align:center">
                     <asp:Label ID="lbl_status_Itr" runat="server" Text=""></asp:Label>
                  </div>
                    <%--</td>
                    <td>
                    </td>
                    </tr>
                    <tr style="background-color:White">
                    <td>
                    &nbsp;
                    </td>
                    <td>
                     &nbsp;
                    </td>
                    </tr>
                    </table>--%>
                 </div>
                <%--</fieldset>--%>
            </asp:View>
            

            <asp:View ID="Vw26AS" runat="server">
            <%--<fieldset style="background-color:#F8F8F8;">
                <legend>View 26AS Information</legend>
            
            <table style="width:100%; border:0px">
                <tr>
                <td>--%>
             <div class="row">
             <%------------------------------------------------------------------------------------------%>
                 <div class="large-12 columns" style="margin:10px; color:#ef5845; font-size:18px;  font-weight:bold">
                 <div class="login-wrap" style="margin-top:40px;width:580px">
                    <span >View 26AS Information</span>
                
            <div class="row" style="background-color:#F8F8F8; border:1px solid #DDDDDD;width:100%; padding:20px 0">
               
              <div class="large-12 columns" style="margin:10px">
                  <div class="large-6 columns" >  
                        <asp:Label ID="Label18" runat="server" Text="PAN : "></asp:Label>   
                  </div>
               <%--</td>
                    <td>--%>
                     <div class="large-6 columns" >  
                         <asp:TextBox ID="txtPan11" runat="server" placeholder="PAN Number" Width="240px" Height="35"></asp:TextBox>
                    </div>
                </div>
                <%--</td>
                </tr>
                <tr style="background-color:White">
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>--%>
            <div class="large-12 columns" style="margin:10px">
                 <div class="large-6 columns" >  
                    <asp:Label ID="Label19" runat="server" Text="DOB : "></asp:Label>
                </div>
               <%-- </td>
                <td>--%>
                <div class="large-6 columns" > 
                    <asp:TextBox ID="txtDob1"
                                            runat="server" placeholder="YYYY-MM-DD" Width="240px"  Height="35"></asp:TextBox>
                </div>
            </div>
               <%-- </td>
                </tr>
                <tr style="background-color:White">
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>--%>
         <div class="large-12 columns" style="margin:10px">
             <div class="large-6 columns" >
                 <asp:Label ID="Label20" runat="server" Text="Assessment Year : "></asp:Label>
             </div>
                <%--</td>
                <td>--%>
              <div class="large-6 columns" >
                <asp:DropDownList ID="DDLYear1" runat="server" Width="240px"></asp:DropDownList>
              </div>
          </div>
                <%--</td>
                </tr>
                <tr style="background-color:White">
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>--%>
            <div class="large-12 columns" style="margin:10px">
              <div class="large-6 columns" >
                 <asp:Button ID="Button9" runat="server" Text="Retrieve Data" OnClick="Button9_Click" class="button" />
              </div>
                <%--</td>
                <td>--%>
              <div class="large-6 columns" >
                  <asp:Label ID="lblError1" runat="server" Text=""></asp:Label>
              </div>
            </div>
                <%--</td>
                </tr>
                <tr style="background-color:White">
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>--%>
            <div class="large-12 columns" style="margin:10px">
              <div class="large-6 columns" >
                 <asp:Label ID="lbl_TAN" runat="server" Text=""></asp:Label>
               </div>
                <%--</td>
                <td>--%>
               <div class="large-6 columns">
                 <asp:Label ID="lbl_TAN_Name" runat="server" Text=""></asp:Label>
               </div>
            </div>
                <%--</td>
                </tr>--%>
                <%--<tr style="background-color:White">
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>--%>
                <%--<tr>
                <td>--%>
           <div class="large-12 columns" style="margin:10px">
              <div class="large-6 columns" >
                <b>TDS on Salary</b>
              </div>
                <%--</td>
                <td>--%>
             <div class="large-6 columns">
                    <asp:GridView ID="GrdVw_TDSonSal" runat="server" EmptyDataText="No Transaction Present"
                           ShowHeaderWhenEmpty="true">
                    </asp:GridView>
              </div>
           </div>
               <%-- </td>
                </tr>
                <tr>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>--%>
          <div class="large-12 columns" style="margin:10px">
              <div class="large-6 columns" >
                  <b>TDS Other Than Salary</b>
              </div>
                <%--</td>
                <td>--%>
               <div class="large-6 columns">
                    <asp:GridView ID="GrdVw_TDSOnOthSal" runat="server" EmptyDataText="No Transaction Present"
                           ShowHeaderWhenEmpty="true">
                     </asp:GridView>
                </div>
          </div>
                <%--</td>
                </tr>
                <tr>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>--%>
            <div class="large-12 columns" style="margin:10px">
              <div class="large-6 columns" >
                 <b>TCS</b>
                </div>
                <%--</td>
                <td>--%>
              <div class="large-6 columns">
                 <asp:GridView ID="GrdVw_TCS" runat="server" EmptyDataText="No Transaction Present"
                        ShowHeaderWhenEmpty="true">
                  </asp:GridView>
              </div>
            </div>
                <%--</td>
                </tr>
                <tr>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>--%>
            <div class="large-12 columns" style="margin:10px; ">
              <div class="large-6 columns" style="padding-left:30px">
                 <b>Tax Payments</b>
              </div>
              <%--  </td>
                <td>--%>
              <div class="large-6 columns" style="padding-left:30px">
                 <asp:GridView ID="GrdVw_TaxPayments" runat="server" EmptyDataText="No Transaction Present"
                     ShowHeaderWhenEmpty="true">
                   </asp:GridView>
                </div>
             </div>
                <%--</td>
                </tr>
                <tr>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>

                </td>
                <td>

                </td>
                </tr>
                <tr>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>

                </td>
                <td>

                </td>
                </tr>
                <tr>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>

                </td>
                <td>

                </td>
                </tr>
                <tr>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                <tr>
                <td>

                </td>
                <td>

                </td>
                </tr>
                <tr>
                <td>
                &nbsp;
                </td>
                <td>
                &nbsp;
                </td>
                </tr>
                </table>--%>
            <%--</fieldset>--%>
            </div>
            </div>  
                </div>
            </div>
            </asp:View>


            <asp:View ID="VwRefundStatus" runat="server">
           <%-- <fieldset style="background-color:#F8F8F8;">
                <legend>Check Income Tax Refund Status</legend>--%>
           <div class="row">
                 <div class="large-12 columns" style="margin:10px; color:#ef5845; font-size:18px;  font-weight:bold">
                   Check Income Tax Refund Status
                </div>  
            </div>
            <div class="row" style="background-color:#F8F8F8; border:1px solid #DDDDDD;width:100%; padding:20px 0">
               
              <div class="large-12 columns" style="margin:10px">
                 <%--   <table style="border:0px; width:100%">
                    <tr>
                    <td>--%>
                <div class="large-6 columns" >
                    PAN:
                </div>
                   <%-- </td>
                    <td>--%>
                <div class="large-6 columns" >
                       <asp:TextBox ID="TextBox3" runat="server" Width="240px" Height="35px" ></asp:TextBox>
                </div>
              </div>
                    <%--</td>
                    </tr>
                    <tr style="background-color:White">
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                     <tr>
                    <td>--%>
                <div class="large-12 columns" style="margin:10px">
                   <div class="large-6 columns">
                        Assessment Year:
                   </div>
                    <%--</td>
                    <td>  --%>      
                     <div class="large-6 columns">
                        <asp:TextBox ID="TextBox4" runat="server" Width="240px" Height="35px"></asp:TextBox>
                       <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                                        Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                        Mask="9999-99" MaskType="Date" TargetControlID="TextBox4">
                                    </asp:MaskedEditExtender>
                    </div>
                </div>
                    <%--</td>
                    </tr>
                    <tr style="background-color:White">
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                     <tr>
                    <td>--%>
              <div class="large-12 columns" style="margin:10px">
                 <div class="large-6 columns"></div>
                 <div class="large-6 columns">
                     <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Submit" class="button" />
                 </div>
                    <%--</td>
                    <td>--%>
                </div>
              <div class="large-12 columns" style="margin:10px; ">
                 <div class="large-6 columns " style="padding-left:30px">
                     <asp:Label ID="lblRefundDemand" runat="server" Text=""></asp:Label>
                 </div>
                  <div class="large-6 columns"></div>
              </div>
                    <%--</td>
                    </tr>
                </table>
               </fieldset>--%>
            </div>
            </asp:View>
            <asp:View ID="View4" runat="server">
            </asp:View>
            <asp:View ID="View5" runat="server">
            </asp:View>
        </asp:MultiView>
    </div>
    </div>

    <footer class="row" >
    <div class="large-12 columns">
      <hr/>
      <div class="row">
        <div class="large-6 columns">
           © 2015 Vatas Infotech Pvt.Ltd.      
      
      </div>
    </div>
    </div>
  </footer>
    
    
    </form>
</body>
</html>
