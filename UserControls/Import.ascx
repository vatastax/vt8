<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Import.ascx.cs" Inherits="UserControls_Import"%>
<%@ Register Assembly="MessageBox" Namespace="Utilities" TagPrefix="cc1" %>

<%@ Register Src="../UserControls/Messagebox.ascx" TagName="mm" TagPrefix="mm" %>
<link href="../StyleSheet/Main.css" rel="stylesheet" type="text/css" />
<link href="../StyleSheet/VSStyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
function getMessage(msg)
{

var ans; ans=window.confirm(msg); //alert (ans); if (ans==true)
{

//alert('Yes');

document.Form1.hdnbox.value='Yes';
}

else
{

//alert('No');
document.Form1.hdnbox.value='No';}

}

</script>
<%--StyleSheets for information box - jaipal--%>

<script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="js/index.js"></script>
<link href="../css/box_style2.css" rel="stylesheet" type="text/css" />

<%--StyleSheets for information box - jaipal--%>

<div class="login-wrap2" style="width:500px">
<%--<asp:UpdatePanel ID="upd_Import" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
       
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_SaveFile" />
    </Triggers>
</asp:UpdatePanel>--%>
 <cc1:MessageBox ID="msg_Imp" runat="server" OnGetMessageBoxResponse="msg_Imp_GetMessageBoxResponse" />
        <asp:HiddenField ID="hdnbox" runat="server" />
        <asp:Panel ID="pnl_PopupImport" runat="server">
            <cc1:MessageBox ID="msg_alert" runat="server" OnGetMessageBoxResponse="msg_alert_GetMessageBoxResponse" />
            <cc1:MessageBox ID="msg_confirm" runat="server" OnGetMessageBoxResponse="msg_confirm_GetMessageBoxResponse" />
            <cc1:MessageBox ID="msg_Valid_Date" runat="server" OnGetMessageBoxResponse="msg_Valid_Date_GetMessageBoxResponse" />
            <%-- <cc1:MessageBox ID="msg_Import" runat="server" 
                  ongetmessageboxresponse="msg_Import_GetMessageBoxResponse" />--%>
          <%--  <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td align="left">
                        <div id="popupheader">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td align="left">
                                        &nbsp;<asp:Label ID="lbl_headerMsg" runat="server" Text="Import File"></asp:Label>
                                    </td>
                                    <td align="right">
                                       
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <div id="popcontent">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="2" align="center">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        <asp:Label ID="lbl_ImportMsg" runat="server" Text="You Can Import .TXT,.XLS and .XLSX Files Only."
                                            Font-Bold="true" Font-Size="12px" Font-Italic="true" ForeColor="red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lbl_uploadFile" runat="server" Font-Bold="True" Font-Size="Small"
                                            Text="Upload File:"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <%--<ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />
                                       <ajaxToolkit:AsyncFileUpload ID="upload_File" runat="server" UploaderStyle="Modern" Visible="true"
                                            Width="250px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btn_SaveFile" runat="server" CausesValidation="false" CssClass="BtnForm"
                            OnClick="btn_SaveFile_Click" Text="Import Data" />
                    </td>
                </tr>
            </table>--%>
              <div class="row">
                  <div class="large-12 columns">
                  <div class="row">
                  <div class="large-12 columns">
                    <div>
                     <%--id="popupheader" style="background-color:#6699ff; background-image:none">--%>
                  <center><asp:Label ID="lbl_headerMsg" style="font-size:20px" runat="server" Text="Import File" Font-Bold="true" Font-Size="15px"></asp:Label></center>
                  </div>
                  </div>
                  </div>
                  <br />
                    <div class="row">
                  <div class="large-12 columns">
                   <asp:Label ID="lbl_ImportMsg" runat="server" Text="You Can Import .TXT,.XLS and .XLSX Files Only."
                                            Font-Bold="true" Font-Size="12px" Font-Italic="true" ForeColor="red"></asp:Label>
                                            <br />
                  </div>
                  </div>
                    <div class="row">
                  <div class="large-6 columns">
                   <asp:Label ID="lbl_uploadFile" runat="server" 
                                            Text="Upload File:" Font-Size="15px"></asp:Label>
                  </div>
                  <div class="large-6 columns">
                   <ajaxToolkit:AsyncFileUpload ID="upload_File" runat="server" Visible="true"
                                            Width="250px" CompleteBackColor="#6699FF" CssClass="cnt" 
                                            UploadingBackColor="#6699FF" UploaderStyle="Traditional" />
                  </div>
                  </div>
                  <br />
                    <div class="row">
                  <div class="large-12 columns text-center">
                  <asp:Button ID="btnback" runat="server" CausesValidation="false" CssClass="radius button" OnClick="btnback_Click"
                            Text="Back" />
                   <asp:Button ID="btn_SaveFile" runat="server" CausesValidation="false" CssClass="radius button"
                            OnClick="btn_SaveFile_Click" Text="Import Data" />
                  </div>
                  </div>
                  </div>
                  </div>
        </asp:Panel>
        <asp:Panel ID="msg_placeholder" runat="server" CssClass="content" Style="display: none">
        </asp:Panel>
</div>
<br />
