<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage3.master" AutoEventWireup="true" CodeFile="TDSClient.aspx.cs" Inherits="Presentation_TDSClient" %>

<%@ Register Assembly="DynamicButtons_Service" Namespace="DynamicButtons_Service" TagPrefix="cc2" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VGrid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $('document').ready(function () {
        $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').children().addClass('radius button')
        $('#ctl00_ContentPlaceHolder1_dny_BOBtn_Pnl_DynamicControlContainer').removeAttr('style');
        //.find('*').attr('disabled', true);
        //.each(function () {

        //$(this).children('*').addClass('radius button');
        //});
        //        $('#dny_BOBtn').children().click(function () {
        //            alert('this is clicked');
        //        });
        //.css('font-weight', 'Bold');
        //.addClass('radius button');
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<VGrid:VGrid id="VGrid1" runat="server" />
<br />
<div class="row">
<div class="large-12 columns hide-for-small-only">
<cc2:DynamicButtons_Service ID="dny_BOBtn" Control_ID="pnl_ClientReturns" runat="server"  Page_ID="100" Page_ModuleID="100">
</cc2:DynamicButtons_Service>
</div>
</div>  
</asp:Content>