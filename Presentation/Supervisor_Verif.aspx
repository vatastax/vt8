<%@ Page Title="" Language="C#" ClientIDMode="Static" MasterPageFile="~/Presentation/MasterPage.master" AutoEventWireup="true" CodeFile="Supervisor_Verif.aspx.cs" Inherits="Presentation_Supervisor_Verif" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
         <script src="../Popup/jquery.min.js" type="text/javascript"></script>
    <script src="../Popup/jquery-ui.js" type="text/javascript"></script>
    <link href="../Popup/jquery-ui.css" rel="stylesheet" type="text/css" />
     <script src="Scripts/jquery_scripts.js" type="text/javascript"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             $('#a2').click(function () {
                 alert_custom($('#divMsg').html(), 1, 'Error', aaa11, '', '', ['OK'], '300', '100px');
                 //alert_custom('Return has been returned back to the operator to re-check and re-work.', 1, 'Error', '', '', '', ['OK'], '200', '100px');
             });

             if ($("#hdn1").val() != '' && $("#hdn1").val() != undefined) {
                 $('#a2').click();
                 $("#hdn1").val() = '';
                 //alert_custom('Return has been returned back to the operator to re-check and re-work.', 1, 'Error', '', '', '', ['OK'], '200', '100px');
             }
         });
         function aaa11() {
             //alert(document.getElementById('<%= txtMsg.ClientID %>').value);
             //alert(document.getElementById('<%= txtMsg.ClientID %>').innerHTML);
             //document.getElementById('<%= hdnMsg.ClientID %>').value = document.getElementById('<%= txtMsg.ClientID %>').innerHTML;
             document.getElementById('<%= btnMsg.ClientID %>').click();
         }
         function setMsg(id) {
             alert(id.value);
             document.getElementById('<%= hdnMsg.ClientID %>').value = id.value;

         }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
    <div class="large-12 columns">
    <asp:Button ID="btnList" runat="server" Text="New Jobs" PostBackUrl="~/Presentation/Supervisor.aspx" class="radius button" Font-Bold="true" 
    style="height:38px;padding-top:0;padding-bottom:0; margin:0px;width:260px;" />

    <asp:Button ID="btnReporting" runat="server" Text="Verification of Jobs" class="radius button" PostBackUrl="~/Presentation/Supervisor_Verif.aspx"  Font-Bold="true" 
    style=" height:38px;padding-top:0;padding-bottom:0; margin:0px; width:260px;" />    

    </div>
    </div>
<asp:HiddenField ID="hdn1" runat="server" />
<asp:HiddenField ID="hdnMsg" runat="server" />
 <%--<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save"
                                class="radius button" Font-Bold="true" style=" height:53px" />--%>
                                <h2>Verification of Work</h2>
                                <br />
                                <a href="#" id="a2"></a>
                                <div id="divMsg" style="display:none;">
                                <table width="100%">
                                <tr>
                                <td>
                                    Message To Operator:
                                </td>
                                <td align="center">
                                    <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" Width="95%" Height="100px" onchange="setMsg(this);"></asp:TextBox>
                                </td>
                                </tr>
                                <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnMsg" runat="server" OnClick="btnMsg_Click" />
                                </td>
                                </tr>
                                </table>
                                </div>
<div class="large-12 columns" style="overflow: hidden; width: 100%;">
    <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" />
</div>
</asp:Content>

