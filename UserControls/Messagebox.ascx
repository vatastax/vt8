<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Messagebox.ascx.cs" Inherits="UserControls_Messagebox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="upd_msg" runat="server" UpdateMode="Conditional">
<ContentTemplate>
 <asp:Panel ID="pnl_msg" runat="server" CssClass="pnlconfirm" >
    <%-- <div class="confirmmain-div">
    	<div id="firDiv" class="confirmfirst-div" >
    		<asp:Label runat="server" ID="lbl_msg" style="margin-left:20px; font-size:small; font-weight:bold"  ></asp:Label>
    	</div>
    	<div id="secDiv" class="confirmsecond-div">
     
    	</div>
        </div>--%>
        <asp:Label runat="server" ID="lbl_headerMsg" style="margin-left:20px; font-size:small; font-weight:bold" ></asp:Label>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
        <td></td>
        <td></td>
        </tr>
         <tr>
        <td colspan="2">
        <center><asp:Label runat="server" ID="lbl_msg" style="margin-left:20px; font-size:small; font-weight:bold" ></asp:Label></center>
        </td>
        </tr>
         <tr>
        <td></td>
        <td></td>
        </tr>
         <tr>
        <td colspan="2">
        
         <center> <asp:Button ID="btn_Ok" runat="server" onclick="btn_Ok_Click" Visible="false" CausesValidation="false"  />
       <asp:Button ID="btn_Cancel" runat="server" Visible="false" CausesValidation="false" 
                onclick="btn_Cancel_Click" />
      <asp:Button ID="btn_Other" runat="server"  Visible="false" CausesValidation="false"
                onclick="btn_Other_Click" /></center>
                </td>
        </tr>
        </table>
     </asp:Panel>
     <asp:ModalPopupExtender ID="mdl_popmsg" runat="server"  TargetControlID="lbl_headerMsg" PopupControlID="pnl_msg" BackgroundCssClass="modalBackground"></asp:ModalPopupExtender>
</ContentTemplate>
<Triggers>
<asp:PostBackTrigger ControlID="btn_Ok" />
<asp:PostBackTrigger ControlID="btn_Cancel" />
<asp:PostBackTrigger ControlID="btn_Other" />
</Triggers>
</asp:UpdatePanel>
 