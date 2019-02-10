<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="ReceptionReporting.aspx.cs" Inherits="Presentation_ReceptionReporting" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VGrid" %>
<%@ Register Assembly="DynamicButtons_Service" TagPrefix="db" Namespace="DynamicButtons_Service"  %>

<html>
<head>
<script type="text/javascript">
    $('document').ready(function () {
        $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').children().addClass('radius button')
        $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').removeAttr('style');


    });
</script>
</head>
<body>
<form id="form1" runat="server">
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
</form>
</body>
</html>
