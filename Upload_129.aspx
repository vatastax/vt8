<%@ Page Title="" Language="C#" MasterPageFile="MasterPage2.master" AutoEventWireup="true" CodeFile="Upload_129.aspx.cs" Inherits="Presentation_Upload_129" %>
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
        <DB:DynamicButtons_Service ID="dny_BOBtn" runat="server" Control_ID="pnl_Grid_Standard"
            Page_ID="100" Page_ModuleID="100" />
    </div>
</div>
</asp:Content>