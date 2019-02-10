<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Presentation_Upload_IncomeTaxSite_Default" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        <div class="large-12 columns" style="overflow: hidden; width: 100%;">
            <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" AlternatingRowStyle="AssesseAltRow" Grid_CssClass="AssesseeBody"  HeaderStyle="Assesee_Header"     />
        </div>
    </div>
    <div class="row">
        <div class="large-12 columns" style="overflow: hidden; width: 970px;"> 
            <asp:Button ID="btnDownload" runat="server" OnClick="btnDownload_Click" Text="Download"
                                class="radius button" Font-Bold="true" style=" height:53px" /> 
        </div>
    </div>
</asp:Content>