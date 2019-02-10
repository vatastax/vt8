<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage.master" AutoEventWireup="true" CodeFile="Supervisor.aspx.cs" Inherits="Presentation_Supervisor" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
    <div class="large-12 columns">
    <asp:Button ID="btnList" runat="server" Text="New Jobs" PostBackUrl="~/Presentation/Supervisor.aspx" class="radius button" Font-Bold="true" 
    style="height:38px;padding-top:0;padding-bottom:0; margin:0px;width:260px;" />

    <asp:Button ID="btnReporting" runat="server" Text="Assigned Jobs" class="radius button" PostBackUrl="~/Presentation/Supervisor_Verif.aspx"  Font-Bold="true" 
    style=" height:38px;padding-top:0;padding-bottom:0; margin:0px; width:260px;" />    

    </div>
    </div>

 <%--<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Save"
                                class="radius button" Font-Bold="true" style=" height:53px" />--%>
                                <br />
<div class="row">
<div class="large-12 columns" style="overflow: hidden; width: 100%;">
    <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" />
</div>
</div>
</asp:Content>
