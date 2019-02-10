<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage3.master" AutoEventWireup="true" CodeFile="stnew.aspx.cs" Inherits="Presentation_stnew" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VGrid" %>
<%@ Register Assembly="DynamicButtons_Service" TagPrefix="db" Namespace="DynamicButtons_Service"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
$('document').ready(function () {
        $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').children().addClass('radius button')
        $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').removeAttr('style');
});
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="pnlGrid" runat="server" style="overflow:auto; width:900px;">
<VGrid:VGrid id="VGrid1" runat="server" />
</asp:Panel>
<br />
<div class="row">
    <div class="large-12 columns hide-for-small-only">
        <DB:DynamicButtons_Service ID="dny_BOBtn" runat="server" Control_ID="Pnl_Btn1"
            Page_ID="stnew" Page_ModuleID="100" />
    </div>
</div>
</asp:Content>