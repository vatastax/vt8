<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BSRCodeControl.ascx.cs" Inherits="UserControls_BSRCodeControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

 
<asp:Panel  ID="Pnl_BSRCode" runat="server"  >
<table cellpadding="0" cellspacing="0" border="0" width="100%">
<tr><td colspan="3">
<div id="popupheader" style=" width:100%" >
<table cellpadding="0" cellspacing="0" width="100%" >
<tr>
<td align="left">
<asp:Label ID="lbl_BankBranches" runat="server" Font-Bold="True" ForeColor="White" Text="Bank Branches"></asp:Label></td><td align="right">
<asp:ImageButton ID="btn_Close" runat="server" Height="30px" 
            ImageUrl="../Images/windows_close_program.png" Width="30px" 
            onclick="btn_Close_Click" CausesValidation="False" />
</td>
</tr>
</table>
</div>
</td>
<td></td>
<td></td>
</tr>
<tr>
<td><br />&#160;&#160; 
<asp:Label ID="lbl_Bank" runat="server" Text="Bank:"></asp:Label><br />&#160;&#160;
<asp:DropDownList ID="drp_Bank" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drp_Bank_SelectedIndexChanged"></asp:DropDownList>
</td><td><br />&#160;&#160; 
<asp:Label ID="lbl_State" runat="server" Text="State:"></asp:Label><br />&#160;&#160; 
<asp:DropDownList ID="drp_State" runat="server" Width="150px" AutoPostBack="True" onselectedindexchanged="drp_State_SelectedIndexChanged"></asp:DropDownList>
</td>
<td><br /><asp:Label ID="lbl_Area" runat="server" Text="Area/City:"></asp:Label>&#160; 
                                    <asp:DropDownList 
                                        ID="drp_Area" runat="server" Width="200px" AutoPostBack="True" 
                                        onselectedindexchanged="drp_Area_SelectedIndexChanged"></asp:DropDownList></td></tr><tr><td colspan="2" class="style1"><br />&#160;&#160; <asp:Label ID="lbl_Branch" runat="server" Text="Branch:"></asp:Label><br />&#160;&#160; 
                                    <asp:DropDownList 
                                        ID="drp_Branch" runat="server" Width="300px" AutoPostBack="True" 
                                        onselectedindexchanged="drp_Branch_SelectedIndexChanged"></asp:DropDownList></td><td class="style1"></td></tr><tr><td 
                                    class="style1" colspan="2">&#160;</td><td class="style1">&#160;</td></tr><tr><td colspan="3">
                                <asp:Panel ID="pnl_GridBranches" runat="server" style=" border:1px solid black">
                                    <br />
                                  <center><asp:GridView   ID="gdv_BSRCodes" runat="server" ShowFooter="True" Width="95%" OnSelectedIndexChanged="gdv_BSRCodes_SelectedIndexChanged"  ><HeaderStyle CssClass="GridViewHeader" />
                                  <Columns><asp:CommandField ButtonType="Button" ShowSelectButton="True" /></Columns></asp:GridView>
                                  </center><br /></asp:Panel></td></tr></table></asp:Panel> 

