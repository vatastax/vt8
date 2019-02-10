<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Presentation_Reception_Default" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
<%--<style type="text/css">
.bgc
{
    background-color:Red;
}
.altr
{
    background-color:Green;
}
.Assesee_Header
{
    background-color:#494e6b;
    color:White;
    height:37px;
  
    
}
.AssesseeBody
{
    padding: 0.5625rem 0.625rem;
    font-size: 0.875rem;
    color: #222222;
    text-align: left;
    width:100%;
}
.AssesseAltRow
{
    background-color:#f9f9f9;
}
</style>--%>
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
 <%--   <center>--%>
    <asp:Button ID="btnAddAssessee" runat="server" OnClick="btnAddAssessee_Click" Text="Add New Assessee"
                                class="radius button" Font-Bold="true" style=" height:53px" />
    <%--</center>--%>
    </div>
    </div>
</asp:Content>

