<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage3.master"
    AutoEventWireup="true" CodeFile="TDSClientPay.aspx.cs" Inherits="Presentation_TDSClientPay" %>

<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VGrid" %>
<%@ Register Assembly="DynamicButtons_Service" Namespace="DynamicButtons_Service"
    TagPrefix="DB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $('document').ready(function () {

            $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').children().addClass('radius button')
            $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').removeAttr('style');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlMain" runat="server">
        <VGrid:VGrid ID="VGrid1" runat="server" />
        <br />
        <hr />
        <div style="text-align: right; font-weight: bold;">
            Total:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Literal ID="ltAmt" runat="server" Text="0.00"></asp:Literal>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
        <div class="row">
            <div class="large-12 columns hide-for-small-only">
                <DB:DynamicButtons_Service ID="dny_BOBtn" runat="server" Control_ID="pnl_ClientReturnsPay"
                    Page_ID="100" Page_ModuleID="100" />
                <%--<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />--%>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlSec" runat="server" Visible="false">
        <div class="row">
            <div class="large-12 columns hide-for-small-only">
            <br /><br />
            <center>
            <h2> Your Return will be uploaded within 24 hours!!</h2>
            </center>
            <br /><br />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
