<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BusinessMaster.aspx.cs" Inherits="Presentation_Business_Master" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> <%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>

<%@ Register Src="../mobilemenu.ascx" TagPrefix="mob" TagName="menu" %>
<%@ Register Src="../responsivemobilemenu.ascx" TagName="resmob" TagPrefix="resmenu" %>
<%@ Register Src="../SideSubUserMenu.ascx" TagPrefix="menu" TagName="side" %>
<%@ Register Src="../Presentation/MobSubUserMenu.ascx" TagName="mobmenu" TagPrefix="mob2" %>
<%@ Register Src="../Presentation/MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>


<!DOCTYPE html>
<html class="no-js" lang="en" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
<title>Control Panel</title>


<%--<script src="../scripts/jquery.js" type="text/javascript"></script>--%>

   <%-- <link href="../styles/StyleSheet.css" rel="stylesheet" type="text/css" />--%>

     <%-- <script src="../js/jquery.min.js" type="text/javascript"></script>--%>

<%--<link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />--%>

<%--<script type="text/javascript" src="../scripts/menu.js"></script> --%>

<%--<link href="../styles/foundation.min.css" rel="stylesheet" type="text/css" />--%>

    <%--<script src="../scripts/modernizr.js" type="text/javascript"></script>
    <script src="../scripts/foundation.min.js" type="text/javascript"></script>--%>

     <%--<link href="../ITRStylesheet/styles/style.css" rel="stylesheet" type="text/css" />--%>


     <!--master javascript file-->
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
     <!--master javascript file-->


      <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->

<script type="text/javascript">
    function validateIt() {
        if (confirm('Are you sure you want to delete it?'))
            return true;
        else
            return false;
    }
</script>
<script type="text/javascript">
    $(document).ready(function () {

        $("#btnmenu").click(function () {
            $("#divmenu").slideToggle();
        });

    });
</script>
<%-- <script type="text/javascript">
     $(document).ready(function () {

         $("#divass").click(function () {
             $("#divassdet").slideToggle();
         });

     });--%>



<script type="text/javascript">
    function validateIt() {
        if (confirm('Are you sure you want to delete the selected record?')) {
            return true;
        }
        else {
            return false;
        }

    }

</script>

 
</head>


<body onload="P7_ExpMenu()">

<form id="form1" runat="server">
<%----for header breadcrumps and menu nishu11/4/2015-----%>
  <div class="row hide-for-small-only">
    <div class="large-12 columns">
    <%--Add by nishu for header 11/4/2015 --%>
    <header:menuheader ID="header1" runat="server" />
    </div>
    </div>
     
    <div class="row hide-for-small-only">
        <div class="large-12 columns">
     
         <main:mainmenu ID="mm1" runat="server" />
        </div>

      </div>
        
     
              
      <div class="row hide-for-small-only">
        <div class="large-12 columns">
           <mob3:mediummenu id="medmenu" runat="server" />
         
        </div>
    </div>
      <div class="row show-for-small-only" style="background-color:#F8F8F8">
            <div class="small-9 columns">
            <a href="Default.aspx">
            <img src="../images/logo2.PNG" style="width:200px; height:70px" /></a>
        </div>
        <div class="small-3 columns">
            <img src="../images/menu1.JPG" id="btnmenu" style="margin-top:15px;width:40px; height:40px"/>  
        </div>
       
       </div>
      
      <div class="row hidden-for-large hidden-for-medium" id="divmenu" style="display:none">
      
      <div class="large-12 columns">
       <resmenu:resmob ID="mob1" runat="server" />
      
      </div>
      </div>
      <div class="row show-for-small-only" >
        <div class="large-12 columns">
          <mob2:mobmenu id="mobmenu" runat="server" />
                <%--<img src="../images/details.JPG" />--%>
            
        </div>
    </div>
     <div class="row">
     <div class="large-12 columns ">
         <asp:SiteMapPath ID="SiteMapPath1" runat="server" 
             Font-Names="Calibri" ForeColor="#333333">
         </asp:SiteMapPath>
         <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
     </div>
     </div>  
   
   <%--<div class="row show-for-small-only" id="divass">
   <div class="large-12 columns panel">
   Assesses Details
   </div>
   </div>
   <div class="row hidden-for-large hidden-for-medium" id="divassdet" style="display:none" >
   <div class="large-12 columns">
    <sub:submenu ID="Submenu2" runat="server" />
   </div>
   </div>--%>
      <div class="row">    
        
     <%--   <div class="large-3 columns show-for-large-only">
            
         
            <sub:submenu ID="Submenu1" runat="server" />--%>
              <%--  <br />--%>
               <%-- <%
                    if (Request.QueryString["vtype"].ToString() == "40" || Request.QueryString["vtype"].ToString() == "41")
                    {
                     %>
                     <emp:empmenu ID="Empmenu1" runat="server" />
                     <%
                    }
                         %>
                         <%
                             if (Request.QueryString["vtype"].ToString() == "42" || Request.QueryString["vtype"].ToString() == "43")
                    {
                     %>
                     <house:property ID="Property1" runat="server" />
                     <%
                    }
                        %>--%>
       <%-- </div>--%>
         
         
        <div class="large-12 columns">
                
         <asp:ScriptManager ID="ScriptManager1" runat="server">
            
        </asp:ScriptManager> 
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:MultiView ID="mltView" ActiveViewIndex = "0" runat="server">
                <asp:View ID="viewList" runat = "server" >
                <div class="row">
                <div class="large-12 columns panel">
                <asp:Label ID="lblHeading" runat="server" Font-Bold="True" Text="Business Master"></asp:Label>
                </div>
                </div>
                <div class="row">
                <div class="large-6 columns">
                   <asp:Label ID="Label1" runat="server" Text="P.A.N."></asp:Label>
                </div>
                <div class="large-6 columns">
                 <asp:TextBox ID="txtPAN" runat="server" MaxLength="10" style="text-transform:uppercase;" required></asp:TextBox>
                                                         <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPAN"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid PAN" ControlToValidate="txtPAN" Display="None"
                                                 ValidationExpression="^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$"></asp:RegularExpressionValidator>
                </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
             <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label>
                </div>
                <div class="large-6 columns">
                 <asp:TextBox ID="txtName" runat="server" required></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
                <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>

                </div>
                <div class="large-6 columns">
                 <asp:TextBox ID="txtAddr" runat="server" required></asp:TextBox>
                                                       <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddr"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
               <asp:Label ID="Label2" runat="server" Text="Designation"></asp:Label>
                </div>
                <div class="large-6 columns">
                <asp:TextBox ID="txtDesignation" runat="server" required></asp:TextBox>
                                                       <%-- <asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhone"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                </div>
                </div>
                  <div class="row">
                <div class="large-6 columns">
                <asp:Label ID="Label5" runat="server" Text="Phone No."></asp:Label>
                </div>
                <div class="large-6 columns">
                <asp:TextBox ID="txtPhone" runat="server" required></asp:TextBox>
                                                        <%--<asp:RequiredFieldValidator ValidationGroup="gg" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPhone"
                                                        ErrorMessage="*" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                </div>
                </div>
                <br />
                <div class="row">
                <div class="large-3 columns">
                  <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" class="radius button" Height="53px" Width="162px"  />
                </div>
                <div class="large-3 columns">
                  <asp:Button ValidationGroup="gg" ID="Button1" runat="server" OnClick="btnInsert_Click" Text="Insert" class="radius button" Height="53px" Width="162px"  />
                </div>
                <div class="large-3 columns">
                  <asp:Button ValidationGroup="gg" ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" class="radius button" Height="53px" Width="162px"  />
                </div>
                <div class="large-3 columns"><asp:Button ID="btnDel" runat="server" Text="Delete" OnClick="btnDel_Click" OnClientClick="return validateIt();" class=" radius button" Height="53px" Width="162px"  /></div>
                </div>
                <div class="row">
                <div class="large-12 columns">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="Large"></asp:Label>
                </div>
                </div>
                <%--  <div class="row">
                <div class="large-6 columns">
                <asp:Label ID="Label7" runat="server" Text="ECS"></asp:Label>
                </div>
                <div class="large-6 columns">
                 <asp:DropDownList ID="ddECS" runat="server" Width="173px">
                                                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                </div>
                </div>--%>
                <%--  <div class="row">
                <div class="large-6 columns"> <asp:Button ValidationGroup="gg" ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" class="button" /></div>
                <div class="large-6 columns">
                <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Update" class="button" />
                </div>
                </div>--%>
                </asp:View>
                   <asp:View ID="viewCountryDetail" runat = "server" >
                   <div class="row">
                   <div class="large-12 columns panel">
                   State Detail
                   </div>
                   </div>
                   <div class="row">
                   <div class="large-6 columns"> <asp:Label ID="lblStateName" runat="server" Text="State Name :" Width="130px" Height="6px" AssociatedControlID="txtStateName"></asp:Label></div>
                   <div class="large-6 columns">
                   <asp:textbox id="txtStateName" runat="server" Width="163px" TabIndex="1" required></asp:textbox>
                   </div>
                   <br />
                    <div class="row">
                   <div class="large-6 columns">
                    <asp:Label ID="lblCountryName" runat="server" Text="Country Name :" Width="103px" AssociatedControlID="txtCountryName"></asp:Label>
                   </div>
                   <div class="large-6 columns">
                      <asp:TextBox ID="txtCountryName" runat="server" Width="164px" style="vertical-align: middle; text-align: left" required></asp:TextBox>
                   </div>
                   <br />
                    <div class="row">
                   <div class="large-4 columns"><asp:button id="btnSave" runat="server" Width="68px" Text="Save" UseSubmitBehavior="False" TabIndex="9" CausesValidation = "true" ValidationGroup="Save" class="button"></asp:button></div>
                   <div class="large-4 columns"><asp:button id="btnDelete" runat="server" Width="66px" Text="Delete" CausesValidation="False" UseSubmitBehavior="False" TabIndex="10" class="button"></asp:button></div>
                   <div class="large-4 columns"><asp:Button id="btnGoBack" runat="server" Text="Go Back" CausesValidation="False" UseSubmitBehavior="False" TabIndex="11" class="button"></asp:Button></div>
                   <br />
                    <div class="row">
                   <div class="large-12 columns">
                <%--   <asp:RequiredFieldValidator id="rfvName" runat="server" Width="104px" ErrorMessage="Enter State Name" ControlToValidate="txtStateName" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                            <%--<asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                                Display="None" ErrorMessage="Enter Country Name" TabIndex="5" ValidationGroup="Save"
                                                Width="104px"></asp:RequiredFieldValidator>--%>
											<asp:ValidationSummary id="vlsUserGrp" runat="server" Width="496px" ValidationGroup="Save"></asp:ValidationSummary>
                   </div>
                
                   <br />
                    
                   </asp:View>
                    <asp:View ID="viewMessage" runat = "server">
                    <div class="row">
                    <div class="large-12 columns">
                      <asp:Label ID="lblMessage"  runat="server" Height="36px" Width="782px" Font-Bold="True" Font-Size="Large"></asp:Label>
                    </div>
                    </div>
                    <br />
                    <div class="row">
                    
                    <div class="large-12 columns">
                     <asp:Button id="btnGoBackM" tabIndex=10 runat="server" UseSubmitBehavior="False" Text="Go Back" CausesValidation="False" class="button"></asp:Button>
                    </div>
                    </div>
            </asp:View>
              <asp:View ID="ViewDetails" runat="server">
              <div class="row">
              <div class="large-12 columns"> <asp:Label ID="lblSubHeading" runat="server" Font-Bold="True" Text="Label"></asp:Label></div>
              </div>
              <div class="row">
              <div class="large-4 columns">
              <asp:Button id="btnOK" runat="server" Text="OK" Class="button" ></asp:Button>
              </div>
              <div class="large-4 columns"> <asp:Button ID="Button3" runat="server" Text="Remove" Visible="False"  Width="73px" Class="button"/></div>
                                                           <br />
              <div class="large-4 columns"></div>
              </div>
              </asp:View>
                </asp:MultiView>
            </ContentTemplate>
            </asp:UpdatePanel>       
        </div>
        
        
         
         
      
        
      </div>
        
      
       
      
      <footer class="row">
        <div class="large-12 columns">
          <hr/>
          <div class="row">
            <div class="large-6 columns">
              <p>© Copyright to Vatas Infotech.</p>
            </div>
            <div class="large-6 columns">
              <%--<ul class="inline-list right">
                <li><a href="#">Section 1</a></li>
                <li><a href="#">Section 2</a></li>
                <li><a href="#">Section 3</a></li>
                <li><a href="#">Section 4</a></li>
              </ul>--%>
            </div>
          </div>
         

        </div> 
      </footer>
   
          <%-- <div class="show-for-large-only">
   <menu:side ID="Sidemenu" runat="server"  />
   </div>--%>
    </form>
<%--

                                                   
                                           
				<tr>
					<td valign="top" align="left" bgcolor="#ffffff" colspan="1" style=" height: 12px;">&nbsp;</td>
				</tr>
                                              
                                            </td>
                                                   
									</tr>
			</table> 		
								</table>
								
								
						</p>
					</td>	
				</tr>
             
               </asp:View>
                <asp:View ID="viewCountryDetail" runat = "server" >
                    
									</tr>
									<tr>
										<td style="TEXT-ALIGN: center; width: 636px; height: 158px;">
											<table id="Table1" style="WIDTH: 767px;" cellspacing="1" cellpadding="1" border="0">
												<tr>
                                                    <td align="right" style="width: 169px; text-align: left" valign="top">
                                                    </td>
                                                    <td align="right" style="width: 105px; text-align: left" valign="top">
                                                       </td>
													<td style="width: 82px; text-align: left;" valign="top" align="left" colspan="">
														</td>
													<td style="width: 132px;" valign="top" align="center" colspan="">
														</td>
												</tr>
                                                <tr>
                                                    <td align="center" colspan="" style="width: 169px; height: 1px; text-align: left"
                                                        valign="top">
                                                    </td>
                                                    <td align="center" style="width: 105px; height: 1px; text-align: left" valign="top" colspan="">
                                                       </td>
                                                    <td align="center" style="width: 82px; height: 1px; text-align: left" valign="top">
                                                     
                                                    </td>
                                                    <td align="center" style="width: 132px; height: 1px" valign="top" colspan="">
                                                        &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" style="height: 16px; text-align: center">
                                                        
                                                       
                                                    </td>
                                                </tr>
												<tr>
													<td style="TEXT-ALIGN: center; height: 21px;" colSpan="6">
														
														&nbsp;</TD>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td style="width: 636px">
											</TD>
									</tr>
								</table>
								
					</td>
				</tr>
				<tr>
					<td valign="top" align="left" bgColor="#ffffff" colspan="1" style="height: 19px; width: 580px;">&nbsp;</td>
				</tr>
			</table>
           </asp:View>
                  
            
            <asp:View ID="viewMessage" runat = "server">
            
            <table height="147" cellspacing="3" cellpadding="0" width="780" align="center" border="0">
				             <tr>
				                <td valign="top" align="center" bgcolor="#ffffff" style="width: 583px; height: 478px;"> 
				                    <table>
				                        <tr>
				                            <td valign="middle">
				                          
				                            </td>
				                        </tr>
				                        <tr>
				                        <td>
				                           
				                        </td>
				                        </tr>
				                    </table>           
                
                                    </td> 
                                 </tr>    
                            </table> 
              </asp:View> 
              <asp:View ID="ViewDetails" runat="server">
                                
                                  <table cellspacing="3" cellpadding="0" style="width :780; height : 147" align="center" border="0">
				                <tr>
				                <td valign="top" align="center" bgcolor="#ffffff" height="478" style="width: 581px">
					            <p class="heading">
								<table id="Table6" cellspacing="1" cellpadding="2" border="0" style="width: 135%">
									<tr>
										<td bgcolor="#ffb937" style="HEIGHT: 19px; width: 809px;" colspan="1">
                                           </td>
									</tr>
									<tr><td style="height: 19px; width: 809px;"> 
                                    </td></tr>
                                    <tr>
                                        <td style="width: 809px; height: 22px">
                                            &nbsp;&nbsp;<br />
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                            <br />
                                        </td>
                                    </tr>
									<tr>
									</div>
                                        &nbsp;&nbsp;
                                               &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp;
                                               &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                        &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                               <table id = "Table8" cellspacing="1" cellpadding="2" border="0" style="width: 136%">
                                                     <tr>
                                                        <td align="center" style="width: 877px">
                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                            <br />
                                                            <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />--%>&nbsp;
                                                           
                                                         <%--  <br />
                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                        </td>
                                                     </tr>
                                               </table>
                                              
                                            </td>
                                                   
									</tr>--%>
									
									<%--<tr>
										<td style="width: 809px; height: 124px;" align="center">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearch"
                                                Display="None" ErrorMessage="Enter Searching Keyword" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSearch"
                                                Display="None" ErrorMessage="Please Select the Field Name." InitialValue="none"
                                                ValidationGroup="Search"></asp:RequiredFieldValidator><br />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Error Message" ValidationGroup="Search" ShowMessageBox="True" ShowSummary="False" />
                                        </td>
									</tr>--%>
				
</body>
</html>
