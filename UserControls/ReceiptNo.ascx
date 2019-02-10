<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReceiptNo.ascx.cs" Inherits="UserControls_ReceiptNo" %>
<%@ Register Assembly="MessageBox" Namespace="Utilities" TagPrefix="cc1" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<script src="../javascriptandJQuery/ErrorMessage.js" type="text/javascript"></script>
<%--<asp:UpdatePanel ID="update_ReceiptNo" runat="server" UpdateMode="Always">
    <ContentTemplate>--%>
<%--StyleSheets for information box - jaipal--%>

<script src="js/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="js/index.js"></script>
<link href="../css/box_style2.css" rel="stylesheet" type="text/css" />
<%-------------show popup on submit button click ------------------%>

<script type="text/javascript">
    function submitCSIFlow() {
        alert('function called');
        try {
            setTimeout(CSI_Download, 10000);
        }
        catch (e) { alert(e); }
    }

</script>
        <asp:Panel ID="pnl_PopupWindow" runat="server">
        <div class="login-wrap2">
            <div>
                <center><asp:Label ID="lbl_headerMsg" style="font-size:20px" runat="server" Text="Vatas TDS Management"></asp:Label></center>
                <br />
                <%--<asp:ImageButton ID="btn_Close" runat="server" ImageUrl="../Images/windows_close_program.png"
                    Width="30px" Height="30px" CausesValidation="false" OnClick="btn_Close_Click" />--%>
            </div>
            <asp:UpdatePanel ID="updRec" runat="server">
            <ContentTemplate>
                <div>
                <asp:Label ID="lbl_Confirm" runat="server" Text="Do you want to enter previous return no:"></asp:Label>
                
                <center><asp:RadioButtonList ID="rdl_PreviousReceiptNo" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="rdl_PreviousReceiptNo_SelectedIndexChanged" RepeatDirection="Horizontal">
                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                </asp:RadioButtonList></center>
                </div>
                <div>
                    <center><asp:Label ID="lbl_PreviousReceiptNo" runat="server" Text="Enter Previous ReceiptNo:"></asp:Label>
                    <asp:TextBox ID="txt_PreviousReceiptNo" runat="server" AutoPostBack="true" TabIndex="1"
                        Width="150px" MaxLength="15" Enabled="False"></asp:TextBox></center>
                </div>
            </ContentTemplate>
            </asp:UpdatePanel>
            
            <br />
            <div>
                <center><asp:Button ID="btnback" runat="server" class="button radius" Text="Back" 
                        CausesValidation="False" onclick="btnback_Click1" />
                <asp:Button ID="btn_Submit" runat="server" class="button radius" Text="Submit" onclick="btn_Submit_Click" 
                    CausesValidation="False" OnClientClick="startProcess(); return true;" /></center>
            </div>
            </div>
        </asp:Panel>
    <%--</ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_SaveFile" />
        <asp:PostBackTrigger ControlID="btn_Close" />
    </Triggers>
</asp:UpdatePanel>--%>
