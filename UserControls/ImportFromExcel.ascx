<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImportFromExcel.ascx.cs"
    Inherits="ImportFromExcel" %>
<%--StyleSheets for information box - jaipal--%>

<script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="js/index.js"></script>
<link href="../css/box_style2.css" rel="stylesheet" type="text/css" />

<%--StyleSheets for information box - jaipal--%>
<div class="login-wrap2" style="width:500px">
    <div class="row">
    <div class="large-12 columns">
        <%-- <asp:Panel ID="Pnl_ImportExcel" runat="server">--%>
        <%--  <asp:Label ID="lbl" runat="server" Text=""></asp:Label>--%>
        <%--  <div id="popupheader">--%>
        <%--<table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                            <td align="left">
                                <asp:Label ID="lbl_headerMsg" runat="server" Text="Import Excel" ForeColor="White"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:ImageButton ID="btn_CloseImp" runat="server" AccessKey="H" ImageUrl="../Images/windows_close_program.png"
                                    Width="30px" Height="30px" CausesValidation="false" />
                            </td>
                        </tr>
                    </table>
                </div>
                <table cellpadding="0" cellspacing="0" width="100%" height="80%">
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>--%>
        <asp:UpdatePanel ID="UpImport" runat="server">
                        <ContentTemplate></ContentTemplate>
                        </asp:UpdatePanel>

        <%--Following Code is Temporary and Will be changed by Nishu Mam to make Tab --%>
        <div class="row">
            <div class="large-6 columns">
                <asp:Button ID="btnChallan" runat="server" Text="Import Challan" 
                    class="radius button" onclick="btnChallan_Click" />
            </div>
            <div class="large-6 columns">
                <asp:Button ID="btnDeductee" runat="server" Text="Import Deductee" 
                    class="radius button" onclick="btnDeductee_Click" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_NameOfFile" runat="server" Text="Name of File"></asp:Label>
            </div>
            <div class="large-6 columns">
                <ajaxToolkit:AsyncFileUpload ID="asy_ImpExcel" runat="server" OnClientUploadComplete="Yes"
                    UploaderStyle="Traditional" />
                
            </div>
            <div class="large-6 columns">
                <asp:Label ID="lbl_FileName" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        </div>
        
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_NameOfSheet" runat="server" Text="Name of Sheet:"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_NameofSheetImp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_NameofSheetImp_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Button ID="btn_ExtractSheetName" runat="server" Text="Get Sheet Name" class="radius button"
                    OnClick="btn_ExtractSheetName_Click" />
            </div>
        </div>
        <div class="row">
            <div class="large-12 columns">
                <center></center>
            </div>
        </div>

       <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_BookEntry" runat="server" Text="Book Entry :" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_BookEntry" runat="server" Enabled="false" 
                    Visible="false" AutoPostBack="True" 
                    onselectedindexchanged="drp_BookEntry_SelectedIndexChanged">
                    <asp:ListItem Value="N">No</asp:ListItem>
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lblChallanNo" runat="server" Text="Challan No. :" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_ChallanNo" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_MinorCode" runat="server" Text="Minor Code :" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_MinorCode" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_PANImp" runat="server" Text="PAN:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_PANImp" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_NameImp" runat="server" Text="Name:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_NameImp" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_AmountImp" runat="server" Text="Amount:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_AmountImp" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_TDSImp" runat="server" Text="TDS:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_TDSImp" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_RateImp" runat="server" Text="Rate:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_RateImp" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_DateImp" runat="server" Text="Date:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_DateImp" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_CCodeImp" runat="server" Text="Reason Code:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_CCodeImp" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_PANREfNo" runat="server" Text="PAN Ref No:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_PANRefNo" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lblSection" runat="server" Text="Section:" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_Section" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lblTDS_DTAA" runat="server" Text="TDS/DTAA " Visible="false"></asp:Label>
            </div>
          <div class="large-6 columns">
              <asp:DropDownList ID="ddlTDS_DTAA" Enabled="false" runat="server" Visible="false">
              </asp:DropDownList>
          </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lblNature_Of_Remittance" runat="server" Text="Nature Of Remittance :" Visible="false"></asp:Label> 
            </div>
            <div class="large-2 columns">
              <asp:DropDownList ID="ddlNatureOfRem" Enabled="false" runat="server" Visible="false">
              </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lvlCountry_To_Which_Remittance_Made" runat="server" Text="Country To Which Remittance Made :" Visible="false"></asp:Label> 
            </div>
            <div class="large-6 columns">
              <asp:DropDownList ID="ddlCountryTowhichRemi" Enabled="false" runat="server" Visible="false">
              </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="large-2 columns">
                <asp:Label ID="lbl_Acknowledgement_No_of_15CA" runat="server" Text=" Acknowledgement No of 15CA :" Visible="false"></asp:Label> 
            </div>
            <div class="large-2 columns">
              <asp:DropDownList ID="ddl_Acknowledgement_No_of_15CA" Enabled="false" runat="server" Visible="false">
              </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="large-6 columns">
                <asp:Label ID="lbl_BSR" runat="server" Text="BSR Code :" Visible="false"></asp:Label>
            </div>
            <div class="large-6 columns">
                <asp:DropDownList ID="drp_BSRCode" runat="server" Enabled="false" Visible="false">
                </asp:DropDownList>
            </div>
        </div>

    </div>
    <br />
</div>
    <div class="row">
        <div class="large-12 columns"><center><asp:Button ID="btnback" runat="server" 
                    Text="Back" class="radius button" onclick="btnback_Click" />
                <asp:Button ID="btn_ImpExcel" runat="server" Text="Import" class="radius button" OnClick="btn_ImpExcel_Click" /></center>
            </div>
    </div>
        <%--  </asp:Panel>--%>
        <%--</div>--%>
    </div>
<br />