<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ind1.aspx.cs" Inherits="Presentation_FormMain"%>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %> 
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>

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
    <script src="../foundation/js/foundation.min.js" type="text/javascript"></script>
</head>


<body onload="P7_ExpMenu()">
<table width="100%" border="0" cellspacing="00" cellpadding="00">

<tr>
<td colspan="2"><main:mainmenu ID="mm1" runat="server" /></td></tr>
<tr>
<td width="21%" height="650" valign="top" bgcolor="#6D89DD"><sub:submenu ID="sub1" runat="server" /></td>
<td width="79%" valign="top">         
 <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            
        </asp:ScriptManager> 
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                &nbsp;
   
   
            <asp:MultiView ID="mltView" ActiveViewIndex = "0" runat="server">
                <asp:View ID="viewList" runat = "server" >
                
                                  <table cellspacing="3" cellpadding="0" style="width :780; height : 147" align="center" border="0">
				                <tr>
				                <td valign="top" align="center" bgcolor="#ffffff" style="width: 581px; height: 449px;">
					            <p class="heading">
								<table id="Table3" cellspacing="1" cellpadding="2" border="0" style="width: 100%">
									<tr>
										<td bgcolor="#ffb937" style="HEIGHT: 19px; width: 809px;" colspan="1"><font class="WhiteMed">&nbsp;<asp:Label ID="lblHeading" runat="server" Font-Bold="True"
                                                Text="Assessee Details"></asp:Label></font></td>
									</tr>
									<tr><td style="height: 21px; width: 809px;" align="left"> 
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="text-align: left; height: 24px;">
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Status"></asp:Label>
                                                    &nbsp; &nbsp;&nbsp;</td>
                                                <td style="text-align: left; height: 24px;">
                                                    <asp:DropDownList ID="ddlStatus" runat="server" Width="272px" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem>Individual</asp:ListItem>
                                                        <asp:ListItem>Hindu Undivided Family</asp:ListItem>
                                                        <asp:ListItem>Partnership</asp:ListItem>
                                                        <asp:ListItem>Company</asp:ListItem>
                                                        <asp:ListItem>Association of Person</asp:ListItem>
                                                        <asp:ListItem>Cooperative Society</asp:ListItem>
                                                        <asp:ListItem>Trust</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                </td>
                                                <td style="height: 24px; text-align: left">
                                                    <asp:LinkButton ID="lnkLogout" runat="server" ForeColor="#C00000" OnClick="lnkLogout_Click" Font-Bold="True">LogOut</asp:LinkButton></td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left">
                                                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="P.A.N"></asp:Label><br />
                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://incometaxindiaefiling.gov.in/knowpan/knowpan.jsp"
                                                        Target="_blank">Find your PAN</asp:HyperLink></td>
                                                <td style="text-align: left">
                                                    &nbsp;<asp:TextBox ID="txtPAN" runat="server" Font-Bold="True" Width="266px" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPAN"
                                                        ErrorMessage="PAN Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                <td style="text-align: left">
                                                </td>
                                            </tr>
                                        </table>
                                    </td></tr>
                                    <tr>
                                        <td>
                                           <asp:Panel ID="PanelIndividual" runat="server">
                                            <table>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label4" runat="server" Text="Salute"></asp:Label></td>
                                                    <td style="width: 186px; text-align: left;">
                                                        <asp:DropDownList ID="ddlSalute" runat="server" Width="88px">
                                                            <asp:ListItem>Mr.</asp:ListItem>
                                                            <asp:ListItem>Mrs.</asp:ListItem>
                                                            <asp:ListItem>Miss.</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label5" runat="server" Text="Last Name"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:TextBox ID="txtLastName" runat="server" Width="168px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; height: 21px; text-align: left;">
                                                        <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name" Width="96px"></asp:Label></td>
                                                    <td style="width: 186px; height: 21px">
                                                        <asp:TextBox ID="txtMiddleName" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; height: 21px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label></td>
                                                    <td style="width: 467px; height: 21px">
                                                        <asp:TextBox ID="txtFirstName" runat="server" Width="168px"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label8" runat="server" Text="Father's Name"></asp:Label></td>
                                                    <td style="width: 186px">
                                                        <asp:TextBox ID="txtFatherName" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label49" runat="server" Text="T.A.N."></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:TextBox ID="txtTAN" runat="server" Width="168px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTAN"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label9" runat="server" Text="Date of Birth"></asp:Label>
                                                        </td>
                                                    <td style="width: 186px">
                                                        <asp:TextBox ID="txtDOB" runat="server" Width="168px" OnTextChanged="txtDOB_TextChanged"></asp:TextBox><br />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDOB"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label10" runat="server" Text="Residential Status" Width="128px"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:DropDownList ID="ddlResStatus" runat="server" Width="176px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                            <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        &nbsp;<asp:Label ID="Label11" runat="server" Text="AO Code/Area Code" Width="143px"></asp:Label></td>
                                                    <td style="width: 186px">
                                                        <asp:TextBox ID="txtWard" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label7" runat="server" Text="Business Nature"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:DropDownList ID="ddlBussNature" runat="server" Width="176px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="" style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label13" runat="server" Text="Type of Assessee"></asp:Label></td>
                                                    <td colspan="" style="width: 186px">
                                                        <asp:DropDownList ID="ddlAssesseeType" runat="server" Width="176px">
                                                            <asp:ListItem>Others</asp:ListItem>
                                                            <asp:ListItem>Musician</asp:ListItem>
                                                            <asp:ListItem>Playwright</asp:ListItem>
                                                            <asp:ListItem>Actor</asp:ListItem>
                                                            <asp:ListItem>Author</asp:ListItem>
                                                            <asp:ListItem>Sports Person</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="width: 467px; text-align: left">
                                                    </td>
                                                    <td style="width: 467px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;" colspan="2">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Change in Jurisdiction" /></td>
                                                    <td style="width: 166px" colspan="2">
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text="Is there a permanent establishment in India"
                                                            Width="304px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label14" runat="server" Text="STD"></asp:Label><br />
                                                        <asp:TextBox ID="txtSTD" runat="server" Width="75px"></asp:TextBox></td>
                                                    <td style="width: 186px">
                                                        <asp:Label ID="Label33" runat="server" Text="Phone"></asp:Label><br />
                                                        <asp:TextBox ID="txtPhone" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        &nbsp;<asp:Label ID="Label15" runat="server" Text="Address:"></asp:Label>
                                                        <asp:LinkButton ID="lnkIndividual" runat="server" OnClick="LinkButton1_Click">Details</asp:LinkButton>
                                                        </td>
                                                    <td style="width: 467px">
                                                        <asp:TextBox ID="txtAddress" runat="server" Width="288px" ReadOnly="True"></asp:TextBox><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="" style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label12" runat="server" Text="E-Mail"></asp:Label>&nbsp;
                                                    </td>
                                                    <td colspan="2" style="width: 166px">
                                                        <asp:TextBox ID="txtEmail" runat="server" Width="312px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                                                            ErrorMessage="E Mail Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
                                            
                                            </asp:Panel>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Panel ID="PanelHUF" runat="server">
                                            <table>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label16" runat="server" Text="Name"></asp:Label></td>
                                                    <td colspan="3" style="width: 253px; text-align: left">
                                                        <asp:TextBox ID="txtNameHUF" runat="server" Width="313px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNameHUF"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; height: 21px; text-align: left;">
                                                        <asp:Label ID="Label20" runat="server" Text="T.A.N."></asp:Label></td>
                                                    <td style="width: 166px; height: 21px">
                                                        <asp:TextBox ID="txtTANHUF" runat="server" Width="168px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTANHUF"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 467px; height: 21px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label21" runat="server" Text="Date of Formation"></asp:Label></td>
                                                    <td style="width: 467px; height: 21px">
                                                        <asp:TextBox ID="txtDateHUF" runat="server" Width="168px" OnTextChanged="txtDateHUF_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtDateHUF"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label23" runat="server" Text="AO Code/Area Code" Width="138px"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:TextBox ID="txtWardHUF" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label22" runat="server" Text="Residential Status" Width="128px"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:DropDownList ID="ddlResHUF" runat="server" Width="176px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                            <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label24" runat="server" Text="Business Nature"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:DropDownList ID="ddlBNHUF" runat="server" Width="176px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        </td>
                                                    <td style="width: 467px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;" colspan="2">
                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text="Change in Jurisdiction" /></td>
                                                    <td style="width: 166px" colspan="2">
                                                        <asp:CheckBox ID="CheckBox4" runat="server" Text="Is there a permanent establishment in India"
                                                            Width="304px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label26" runat="server" Text="STD"></asp:Label><asp:TextBox ID="txtSTD1"
                                                            runat="server" Width="75px"></asp:TextBox></td>
                                                    <td style="width: 166px">
                                                        <asp:Label ID="Label39" runat="server" Text="Phone"></asp:Label><asp:TextBox ID="txtPhone1"
                                                            runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        &nbsp;<asp:Label ID="Label27" runat="server" Text="Address:"></asp:Label>
                                                        <asp:LinkButton ID="lnkHUF" runat="server" OnClick="lnkHUF_Click">Details</asp:LinkButton></td>
                                                    <td style="width: 467px">
                                                        <asp:TextBox ID="txtAddressHUF" runat="server" Width="288px"></asp:TextBox><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="" style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label28" runat="server" Text="E-Mail"></asp:Label></td>
                                                    <td colspan="2" style="width: 166px">
                                                        <asp:TextBox ID="txtEmailHUF" runat="server" Width="312px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtEmailHUF"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
       
                                            </asp:Panel>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Panel ID="PanelPartnership" runat="server">
                                            <table>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label29" runat="server" Text="Name"></asp:Label></td>
                                                    <td style="width: 166px; text-align: left;" colspan="2">
                                                        <asp:TextBox ID="txtNamePart" runat="server" Width="307px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNamePart"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 467px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; height: 21px; text-align: left;">
                                                        <asp:Label ID="Label34" runat="server" Text="T.A.N."></asp:Label></td>
                                                    <td style="width: 166px; height: 21px">
                                                        <asp:TextBox ID="txtTANPart" runat="server" Width="168px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtTANPart"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 467px; height: 21px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label35" runat="server" Text="Date of Constitution"></asp:Label></td>
                                                    <td style="width: 467px; height: 21px">
                                                        <asp:TextBox ID="txtDatePart" runat="server" Width="168px" OnTextChanged="txtDatePart_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtDatePart"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label37" runat="server" Text="AO Code/Area Code" Width="142px"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:TextBox ID="txtWardPart" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label36" runat="server" Text="Residential Status" Width="128px"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:DropDownList ID="ddlResPart" runat="server" Width="176px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                            <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left; height: 25px;">
                                                        <asp:Label ID="Label38" runat="server" Text="Business Nature"></asp:Label></td>
                                                    <td style="width: 166px; height: 25px;">
                                                        <asp:DropDownList ID="ddlBussNaturePart" runat="server" Width="176px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="width: 467px; text-align: left; height: 25px;">
                                                        &nbsp;
                                                        <asp:Label ID="Label6" runat="server" Text="Type of Firm"></asp:Label></td>
                                                    <td style="width: 467px; height: 25px;">
                                                        <asp:DropDownList ID="ddlTypeofFirmPart" runat="server" Width="174px">
                                                            <asp:ListItem>Others</asp:ListItem>
                                                            <asp:ListItem>Professional</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;" colspan="2">
                                                        <asp:CheckBox ID="CheckBox5" runat="server" Text="Change in Jurisdiction" /></td>
                                                    <td style="width: 166px" colspan="2">
                                                        <asp:CheckBox ID="CheckBox6" runat="server" Text="Is there a permanent establishment in India"
                                                            Width="304px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label40" runat="server" Text="STD"></asp:Label><asp:TextBox ID="txtSTD2"
                                                            runat="server" Width="75px"></asp:TextBox></td>
                                                    <td style="width: 166px">
                                                        <asp:Label ID="Label43" runat="server" Text="Phone"></asp:Label><asp:TextBox ID="txtPhone2"
                                                            runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        &nbsp;<asp:Label ID="Label41" runat="server" Text="Address:"></asp:Label>
                                                        <asp:LinkButton ID="lnkPartner" runat="server" OnClick="lnkPartner_Click">Details</asp:LinkButton></td>
                                                    <td style="width: 467px">
                                                        <asp:TextBox ID="txtAddressPart" runat="server" Width="288px"></asp:TextBox><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="" style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label42" runat="server" Text="E-Mail"></asp:Label></td>
                                                    <td colspan="2" style="width: 166px">
                                                        <asp:TextBox ID="txtEmailPart" runat="server" Width="312px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtEmailPart"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
       
                                            </asp:Panel>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Panel ID="PanelCompany" runat="server">
                                            <table>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label44" runat="server" Text="Name"></asp:Label></td>
                                                    <td style="width: 166px; text-align: left;" colspan="2">
                                                        <asp:TextBox ID="txtNameComp" runat="server" Width="311px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtNameComp"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; height: 21px; text-align: left;">
                                                        <asp:Label ID="Label48" runat="server" Text="T.A.N."></asp:Label></td>
                                                    <td style="width: 166px; height: 21px">
                                                        <asp:TextBox ID="txtTANComp" runat="server" Width="168px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtTANComp"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 467px; height: 21px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label50" runat="server" Text="Date of Incorporation"></asp:Label></td>
                                                    <td style="width: 467px; height: 21px">
                                                        <asp:TextBox ID="txtDateComp" runat="server" Width="168px" OnTextChanged="txtDateComp_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtDateComp"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label52" runat="server" Text="AO Code/Area Code"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:TextBox ID="txtWardComp" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label51" runat="server" Text="Residential Status" Width="128px"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:DropDownList ID="ddlResComp" runat="server" Width="176px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                            <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label53" runat="server" Text="Business Nature"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:DropDownList ID="ddlBussNatureComp" runat="server" Width="176px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label54" runat="server" Text="Status of Company"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:DropDownList ID="ddlCompStatus" runat="server" Width="176px">
                                                            <asp:ListItem>Public Company</asp:ListItem>
                                                            <asp:ListItem>Private Company</asp:ListItem>
                                                            <asp:ListItem>Foreign Company</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left; height: 22px;" colspan="2">
                                                        <asp:CheckBox ID="CheckBox7" runat="server" Text="Change in Jurisdiction" /></td>
                                                    <td style="width: 166px; height: 22px;" colspan="2">
                                                        <asp:CheckBox ID="CheckBox8" runat="server" Text="Is there a permanent establishment in India"
                                                            Width="304px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label45" runat="server" Text="STD"></asp:Label><asp:TextBox ID="txtSTD3"
                                                            runat="server" Width="75px"></asp:TextBox></td>
                                                    <td style="width: 166px">
                                                        <asp:Label ID="Label46" runat="server" Text="Phone"></asp:Label><asp:TextBox ID="txtPhone3"
                                                            runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        &nbsp;<asp:Label ID="Label56" runat="server" Text="Address:"></asp:Label>
                                                        <asp:LinkButton ID="lnkCompany" runat="server" OnClick="lnkCompany_Click">Details</asp:LinkButton></td>
                                                    <td style="width: 467px">
                                                        <asp:TextBox ID="txtAddressComp" runat="server" Width="288px"></asp:TextBox><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="" style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label57" runat="server" Text="E-Mail"></asp:Label></td>
                                                    <td colspan="2" style="width: 166px">
                                                        <asp:TextBox ID="txtEmailComp" runat="server" Width="312px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtEmailComp"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="1" style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label17" runat="server" Text="Nature of Company" Width="134px"></asp:Label></td>
                                                    <td colspan="3" style="width: 166px">
                                                        <asp:DropDownList ID="ddlCompNature" runat="server" Width="616px">
                                                            <asp:ListItem>Select</asp:ListItem>
                                                            <asp:ListItem>A public sector company</asp:ListItem>
                                                            <asp:ListItem>A company owned by the Reserve Bank of India</asp:ListItem>
                                                            <asp:ListItem>A company having more than forty percent of the shares held by Govt or RBI or Both</asp:ListItem>
                                                            <asp:ListItem>A banking company </asp:ListItem>
                                                            <asp:ListItem>A company registered with IRDA</asp:ListItem>
                                                            <asp:ListItem>A company being NBFC</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="1" style="width: 253px; text-align: left">
                                                        </td>
                                                    <td style="width: 166px">
                                                        
                                                        <asp:Button ID="Button3" runat="server" Text="Additional Details" /></td>
                                                    <td style="width: 166px">
                                                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Director Details" /></td>
                                                    <td style="width: 166px">
                                                        <asp:Button ID="Button6" runat="server" Text="Benefeciary Details" /></td>
                                                </tr>
                                            </table>
                                                
       
                                            </asp:Panel>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Panel ID="PanelAOP" runat="server">
                                            <table>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label59" runat="server" Text="Name"></asp:Label></td>
                                                    <td style="width: 166px; text-align: left;">
                                                        <asp:TextBox ID="txtNameAOP" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtNameAOP"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 467px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; height: 21px; text-align: left;">
                                                        <asp:Label ID="Label63" runat="server" Text="T.A.N."></asp:Label></td>
                                                    <td style="width: 166px; height: 21px">
                                                        <asp:TextBox ID="txtTANAOP" runat="server" Width="168px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtTANAOP"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 467px; height: 21px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label64" runat="server" Text="Date of Formation"></asp:Label></td>
                                                    <td style="width: 467px; height: 21px">
                                                        <asp:TextBox ID="txtDateAOP" runat="server" Width="168px" OnTextChanged="txtDateAOP_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtDateAOP"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label66" runat="server" Text="AO Code/Area Code" Width="138px"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:TextBox ID="txtWardAOP" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label65" runat="server" Text="Residential Status" Width="128px"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:DropDownList ID="ddlResAOP" runat="server" Width="176px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                            <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label67" runat="server" Text="Business Nature"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:DropDownList ID="ddlBussAOP" runat="server" Width="176px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="width: 467px; text-align: left;">
                                                        &nbsp;
                                                        </td>
                                                    <td style="width: 467px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;" colspan="2">
                                                        <asp:CheckBox ID="CheckBox9" runat="server" Text="Change in Jurisdiction" /></td>
                                                    <td style="width: 166px" colspan="2">
                                                        <asp:CheckBox ID="CheckBox10" runat="server" Text="Is there a permanent establishment in India"
                                                            Width="304px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label47" runat="server" Text="STD"></asp:Label><asp:TextBox ID="txtSTD4"
                                                            runat="server" Width="75px"></asp:TextBox></td>
                                                    <td style="width: 166px">
                                                        <asp:Label ID="Label55" runat="server" Text="Phone"></asp:Label><asp:TextBox ID="txtPhone4"
                                                            runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        &nbsp;<asp:Label ID="Label70" runat="server" Text="Address:"></asp:Label>
                                                        <asp:LinkButton ID="lnkAOP" runat="server" OnClick="lnkAOP_Click">Details</asp:LinkButton></td>
                                                    <td style="width: 467px">
                                                        <asp:TextBox ID="txtAddrAOP" runat="server" Width="288px"></asp:TextBox><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="" style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label71" runat="server" Text="E-Mail"></asp:Label></td>
                                                    <td colspan="2" style="width: 166px">
                                                        <asp:TextBox ID="txtEmailAOP" runat="server" Width="312px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtEmailAOP"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
       
                                            </asp:Panel>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Panel ID="PanelCOOP" runat="server" >
                                            <table>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label73" runat="server" Text="Name"></asp:Label></td>
                                                    <td style="width: 166px; text-align: left;" colspan="2">
                                                        <asp:TextBox ID="txtNameCOOP" runat="server" Width="311px"></asp:TextBox></td>
                                                    <td style="width: 484px; text-align: left;">
                                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtNameCOOP"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator>
                                                        </td>
                                                    <td style="width: 467px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; height: 21px; text-align: left;">
                                                        <asp:Label ID="Label77" runat="server" Text="T.A.N."></asp:Label></td>
                                                    <td style="width: 166px; height: 21px">
                                                        <asp:TextBox ID="txtTANCOOP" runat="server" Width="168px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtTANCOOP"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                    <td style="width: 484px; height: 21px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label78" runat="server" Text="Date of Incorporation"></asp:Label></td>
                                                    <td style="width: 467px; height: 21px">
                                                        <asp:TextBox ID="txtDateCOOP" runat="server" Width="168px" OnTextChanged="txtDateCOOP_TextChanged"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="Required" ControlToValidate="txtDateCOOP" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label80" runat="server" Text="AO Code/Area Code" Width="139px"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:TextBox ID="txtWardCOOP" runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 484px; text-align: left;">
                                                        &nbsp;
                                                        <asp:Label ID="Label79" runat="server" Text="Residential Status" Width="128px"></asp:Label></td>
                                                    <td style="width: 467px">
                                                        <asp:DropDownList ID="ddlResCOOP" runat="server" Width="176px">
                                                            <asp:ListItem>Resident</asp:ListItem>
                                                            <asp:ListItem>Non-Resident</asp:ListItem>
                                                            <asp:ListItem>Not-Ordinarily Resident</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;">
                                                        <asp:Label ID="Label81" runat="server" Text="Business Nature"></asp:Label></td>
                                                    <td style="width: 166px">
                                                        <asp:DropDownList ID="ddlBussNatureCOOP" runat="server" Width="176px">
                                                            <asp:ListItem>Manufacturing</asp:ListItem>
                                                            <asp:ListItem>Trading</asp:ListItem>
                                                            <asp:ListItem>Manufacturing-cum-Trading</asp:ListItem>
                                                            <asp:ListItem>Services</asp:ListItem>
                                                            <asp:ListItem>Profession</asp:ListItem>
                                                            <asp:ListItem>Other</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td style="width: 484px; text-align: left;">
                                                        &nbsp;
                                                        </td>
                                                    <td style="width: 467px">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left;" colspan="2">
                                                        <asp:CheckBox ID="CheckBox11" runat="server" Text="Change in Jurisdiction" /></td>
                                                    <td style="width: 166px" colspan="2">
                                                        <asp:CheckBox ID="CheckBox12" runat="server" Text="Is there a permanent establishment in India"
                                                            Width="304px" /></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label58" runat="server" Text="STD"></asp:Label><asp:TextBox ID="txtSTD5"
                                                            runat="server" Width="75px"></asp:TextBox></td>
                                                    <td style="width: 166px">
                                                        <asp:Label ID="Label60" runat="server" Text="Phone"></asp:Label><asp:TextBox ID="txtPhone5"
                                                            runat="server" Width="168px"></asp:TextBox></td>
                                                    <td style="width: 484px; text-align: left">
                                                        &nbsp;<asp:Label ID="Label84" runat="server" Text="Address:"></asp:Label>
                                                        <asp:LinkButton ID="lnkCOOP" runat="server" OnClick="LinkButton6_Click">Details</asp:LinkButton></td>
                                                    <td style="width: 467px">
                                                        <asp:TextBox ID="txtAddrCOOP" runat="server" Width="288px"></asp:TextBox><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="" style="width: 253px; text-align: left">
                                                        <asp:Label ID="Label85" runat="server" Text="E-Mail"></asp:Label></td>
                                                    <td colspan="2" style="width: 166px">
                                                        <asp:TextBox ID="txtEmailCOOP" runat="server" Width="312px"></asp:TextBox></td>
                                                    <td style="width: 467px; text-align: left">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtEmailCOOP"
                                                            ErrorMessage="Required" Display="Dynamic" EnableClientScript="False"></asp:RequiredFieldValidator></td>
                                                </tr>
                                            </table>
          
                                            </asp:Panel>
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Panel ID="pnlAddress" runat="server" BorderColor="#404040" BorderStyle="Double" Visible="False">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text="Flat/Door/Block No."></asp:Label>
                                                            </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFlat" runat="server"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Label ID="Label18" runat="server" Text="Name of Premises/Building/Village"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtPremises" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label19" runat="server" Text="Road/Street/Lane/PostOffice"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtRoad" runat="server"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Label ID="Label25" runat="server" Text="Area"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtArea" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label30" runat="server" Text="City"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Label ID="Label31" runat="server" Text="State"></asp:Label></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlState" runat="server" Width="145px" DataSourceID="ObjectDataSource1" DataTextField="StateName" DataValueField="StateCode">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label32" runat="server" Text="PIN"></asp:Label>
                                                            </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPIN" runat="server"></asp:TextBox></td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button ID="btnOK" runat="server" Text="Save" Width="61px" OnClick="btnOK_Click" Enabled="False" /></td>
                                                        <td align="center" colspan="1">
                                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click2" Text="Edit" /></td>
                                                        <td align="center">
                                                            <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" /></td>
                                                        <td align="center">
                                                            <asp:Button ID="btnUpdateAddress" runat="server" Enabled="False" OnClick="btnUpdateAddress_Click"
                                                                Text="Update" /></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                                
                                                
                                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getStates"
                                            TypeName="Taxation.BusinessLogic.bllStates" OnSelecting="ObjectDataSource1_Selecting"></asp:ObjectDataSource>
                                            <br />
                                            </tr>
                                            <tr>
                                            <td>
                                            <asp:Panel ID="PanelButtons" runat="server" Height="50px" Width="125px">
                                                <table style="width: 767px">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Button4" runat="server" Text="Back" Width="67px" OnClick="Button4_Click" /></td>
                                                    <td>
                                                        <asp:Button ID="btnEdit" runat="server" Text="  Edit  " Width="67px" OnClick="Button1_Click1" /></td>
                                                    <td>
                                                        </td>
                                                    <td>
                                                        <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" Text="New" Width="62px" /></td>
                                                    <td>
                                                        <asp:Button ID="btnInsert" runat="server" Text="Add" OnClick="Button1_Click" Width="67px" Enabled="False" /></td>
                                                    <td>
                                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Update" Enabled="False" /></td>
                                                </tr>
                                            </table>
                                            </asp:Panel>
                                            <br />
                                            &nbsp;&nbsp;
                                            
                                            
                                            &nbsp;&nbsp;<br />
                                        <br />
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
                                                   
									</tr>
				<tr>
					<td valign="top" align="left" bgcolor="#ffffff" colspan="1" style="width: 581px; height: 104px;">&nbsp;</td>
				</tr>
                                              
                                            </td>
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
										<td style="HEIGHT: 19px; text-align: Center; width: 636px;" bgColor="#ffb937"><FONT class="WhiteMed">&nbsp;State Detail</FONT></TD>
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
													<td style="TEXT-ALIGN: center; height: 16px;" colSpan="6">
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
