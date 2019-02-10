<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DirectorMaster.aspx.cs" Inherits="Presentation_DirectorMaster" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> <%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Control Panel</title>
<link rel="stylesheet" type="text/css" media="screen" href="../styles/style.css" />
<script type="text/javascript" src="../scripts/menu.js"></script> 
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 00px;
	margin-bottom: 00px;
}
a
{
text-decoration:none;
color: #215DC6;
}

a:hover
{
text-decoration:none;
color: #40ACF4;
}
.style1 {
	color: #215DC6;
	font-family: Arial, Helvetica, sans-serif;
	font-weight: bold;
	font-size: 12px;
}
-->

</style>

 <link href="../foundation/css/foundation.min.css" rel="stylesheet" />
    <script src="../foundation/js/foundation.min.js"></script>
</head>


<body onload="P7_ExpMenu()">
<table width="100%" border="0" cellspacing="00" cellpadding="00">

<tr>
<td colspan="2">
<%
    if(Session["ay"]!=null)
    {
    %>

<main:mainmenu ID="mm1" runat="server" />
<%
    }
    else
    {
    %>

<main2:mainmenu2 ID="mm12" runat="server" />
<%
    }
    %>
</td></tr>
<tr>
<td width="21%" height="650" valign="top" bgcolor="#6D89DD"><sub:submenu ID="sub1" runat="server" /></td>
<td width="79%" valign="top">         <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            
        </asp:ScriptManager> 
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
          <div>
              &nbsp;</div>
   
            <asp:MultiView ID="mltView" ActiveViewIndex = "0" runat="server">
                <asp:View ID="viewList" runat = "server" >
                
                                  <table cellspacing="3" cellpadding="0" style="width :780; height : 147" align="center" border="0">
				                <tr>
				                <td valign="top" align="center" bgcolor="#ffffff" style="width: 581px; height: 472px;">
					            <p class="heading">
								<table id="Table3" cellspacing="1" cellpadding="2" border="0" style="width: 133%; height: 240px;">
									<tr>
										<td bgcolor="#ffb937" style="HEIGHT: 13px; width:1142px;" colspan="1"><font class="WhiteMed">&nbsp;<asp:Label ID="lblHeading" runat="server" Font-Bold="True"
                                                Text="Director Master"></asp:Label></font></td>
									</tr>
                                    <tr>
                                        <td style="width: 1142px; height: 25px; text-align: left; vertical-align: top;">
                                            <table style="width: 768px">
                                                <tr>
                                                    <td style="width: 146px">
                                                        <asp:Label ID="Label1" runat="server" Text="P.A.N."></asp:Label></td>
                                                    <td style="width: 557px">
                                                        <asp:TextBox ID="txtPAN" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 146px">
                                                        <asp:Label ID="Label3" runat="server" Text="Name"></asp:Label></td>
                                                    <td style="width: 557px">
                                                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 146px">
                                                        <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
                                                        <asp:LinkButton ID="lnkDetails" runat="server">Details</asp:LinkButton></td>
                                                    <td style="width: 557px">
                                                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 146px">
                                                        <asp:Label ID="Label5" runat="server" Text="Designation"></asp:Label></td>
                                                    <td style="width: 557px">
                                                        <asp:TextBox ID="txtdesignation" runat="server"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 146px">
                                                        <asp:Label ID="Label6" runat="server" Text="Phone"></asp:Label></td>
                                                    <td style="width: 557px">
                                                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                            <table style="width: 559px">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Button1" runat="server" Text="Add" Width="87px" OnClick="Button1_Click" /></td>
                                                    <td>
                                                        <asp:Button ID="Button2" runat="server" Text="Update" /></td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                            <br />
                                        </td>
                                    </tr>
									<tr>
									</div>
                                                
                                                
                                                <%--<table id = "Table4" cellspacing="1" cellpadding="2" border="0" style="width: 137%" >
                                                    <tr>
                                                        <td style="width: 154px; height: 30px;" align="right">
                                                            <asp:Label ID="lblSearch" runat="server" Text="Search :" AssociatedControlID="txtSearch" Font-Bold="True" Width="182px"></asp:Label>
                                                        </td>
                                                        <td style="width: 133px; height: 30px">
                                                            <asp:TextBox ID="txtSearch" runat="server" Height="16px" Width="172px" ValidationGroup="Search"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 42px; height: 30px;">
                                                            <asp:DropDownList ID="ddlSearch" runat="server" Width="172px" Height="16px" ValidationGroup="Search">
                                                                <asp:ListItem Value="none">-Select Field-</asp:ListItem>
                                                                <asp:ListItem Value="1">State Name</asp:ListItem>
                                                                <asp:ListItem Value="2">Country Name</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 62px; height: 30px;">
                                                            <asp:Button ID="btnSearch" runat="server" Text="Search" Width="85px" ValidationGroup="Search"  />
                                                        </td>
                                                    </tr>
                                               </table> 
                                               <table id = "Table5" cellspacing="1" cellpadding="2" border="0" style="width: 136%" >
                                                     <tr>
                                                        <td align="center" style="width: 877px">
                                                            &nbsp; &nbsp; &nbsp; &nbsp; 
                                                            <br />
                                                            &nbsp;<asp:Button id="btnAdd" runat="server" Text="Add New"></asp:Button>
                                                            <asp:Button ID="btnRemove" runat="server" Text="Remove" Visible="False"  Width="73px"/>
                                                            <asp:Button ID="btnShowAll" runat="server"  Text="Show All"
                                                                Width="75px"/><br />
                                                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                        </td>
                                                     </tr>
                                               </table>--%>
									
									<%--<tr>
										<td style="width: 809px; height: 124px;" align="center">
                                            <asp:RequiredFieldValidator ID="rfvtxtSearch" runat="server" ControlToValidate="txtSearch"
                                                Display="None" ErrorMessage="Enter Searching Keyword" ValidationGroup="Search"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="rfvddlSearch" runat="server" ControlToValidate="ddlSearch"
                                                Display="None" ErrorMessage="Please Select the Field Name." InitialValue="none"
                                                ValidationGroup="Search"></asp:RequiredFieldValidator><br />
                                            <asp:ValidationSummary ID="vdsSearch" runat="server" HeaderText="Error Message" ValidationGroup="Search" ShowMessageBox="True" ShowSummary="False" />
                                        </td>
									</tr>--%>
				<tr>
					<td valign="top" align="left" bgcolor="#ffffff" colspan="1" style="width: 1142px; height: 12px;">&nbsp;</td>
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
                    <table  cellspacing="3" cellpadding="0" width="780" align="center" border="0">
				        <tr>
					        <td valign="top" align="center" bgColor="#ffffff" style="height: 212px; width: 580px;">
						
								<table id="Table2" cellspacing="1" cellpadding="2" width="99%" border="0">
									<tr>
										<td style="HEIGHT: 26px; text-align: Center; width: 636px;" bgColor="#ffb937"><FONT class="WhiteMed">&nbsp;State Detail</FONT></TD>
									</tr>
									<tr>
										<td style="TEXT-ALIGN: center; width: 636px; height: 158px;">
											<table id="Table1" style="WIDTH: 767px;" cellspacing="1" cellpadding="1" border="0">
												<tr>
                                                    <td align="right" style="width: 169px; text-align: left" valign="top">
                                                    </td>
                                                    <td align="right" style="width: 105px; text-align: left" valign="top">
                                                        <asp:Label ID="lblStateName" runat="server" Text="State Name :" Width="130px" Height="6px" AssociatedControlID="txtStateName"></asp:Label></td>
													<td style="width: 82px; text-align: left;" valign="top" align="left" colspan="">
														<asp:textbox id="txtStateName" runat="server" Width="163px" TabIndex="1"></asp:textbox></td>
													<td style="width: 132px;" valign="top" align="center" colspan="">
														</td>
												</tr>
                                                <tr>
                                                    <td align="center" colspan="" style="width: 169px; height: 1px; text-align: left"
                                                        valign="top">
                                                    </td>
                                                    <td align="center" style="width: 105px; height: 1px; text-align: left" valign="top" colspan="">
                                                        <asp:Label ID="lblCountryName" runat="server" Text="Country Name :" Width="103px" AssociatedControlID="txtCountryName"></asp:Label></td>
                                                    <td align="center" style="width: 82px; height: 1px; text-align: left" valign="top">
                                                        <asp:TextBox ID="txtCountryName" runat="server" Width="164px" style="vertical-align: middle; text-align: left"></asp:TextBox>
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
														<asp:button id="btnSave" runat="server" Width="68px" Text="Save" UseSubmitBehavior="False" TabIndex="9" CausesValidation = "true" ValidationGroup="Save"></asp:button>
														<asp:button id="btnDelete" runat="server" Width="66px" Text="Delete" CausesValidation="False" UseSubmitBehavior="False" TabIndex="10"></asp:button>&nbsp;<asp:Button id="btnGoBack" runat="server" Text="Go Back" CausesValidation="False" UseSubmitBehavior="False" TabIndex="11"></asp:Button></TD>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td style="width: 636px">
											<asp:RequiredFieldValidator id="rfvName" runat="server" Width="104px" ErrorMessage="Enter State Name" ControlToValidate="txtStateName" Display="None" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCountryName"
                                                Display="None" ErrorMessage="Enter Country Name" TabIndex="5" ValidationGroup="Save"
                                                Width="104px"></asp:RequiredFieldValidator>
											<asp:ValidationSummary id="vlsUserGrp" runat="server" Width="496px" ValidationGroup="Save"></asp:ValidationSummary></TD>
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
				                            <asp:Label ID="lblMessage"  runat="server" Height="36px" Width="782px" Font-Bold="True" Font-Size="Large"></asp:Label>
				                            </td>
				                        </tr>
				                        <tr>
				                        <td>
				                            <asp:Button id="btnGoBackM" tabIndex=10 runat="server" UseSubmitBehavior="False" Text="Go Back" CausesValidation="False"></asp:Button>
				                        </td>
				                        </tr>
				                    </table>           
                
                                    </td> 
                                 </tr>    
                            </table> 
              </asp:View> 
              
              
              
              
            </asp:MultiView>
                &nbsp;&nbsp;
            
        </ContentTemplate>
        
      </asp:UpdatePanel>
            &nbsp; &nbsp;
     
    </form>
                
    
    
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
</table>
</body>
</html>
