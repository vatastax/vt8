<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/MasterPage.master" AutoEventWireup="true" CodeFile="Operator.aspx.cs" Inherits="Presentation_Operator" %>
<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <style type="text/css">
        .bgc
        {
            background-color: lightgray;
        }
        .altr
        {
            background-color: Green;
        }
    </style>

    <%--<script type="text/javascript">
        function showInputs() {
            document.getElementById('assdet1').style.display = 'block';
            document.getElementById('rowMain').style.display = 'none';
        }
        function hideInputs() {
            document.getElementById('assdet1').style.display = 'none';
            document.getElementById('rowMain').style.display = 'block';
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">
<div class="large-12 columns" style="overflow: hidden; width: 970px;">
    <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" />
</div>
</div>

<%--<div id="assdet1" style="display: none;">
    <div class="row" id="Div3">
        <div style="padding: 10px; font-size: 15px; font-weight: bold;">
            <a href="#" style="color: #E14658">Deductee Details</a>
        </div>
    </div>
     <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label10" runat="server" Text="Form Type"></asp:Label>
                            </div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="ddFormType" runat="server">
                                    <asp:ListItem Text="Form24Q" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Form26Q" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Form27Q" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Form27EQ" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label2" runat="server" Text="Financial Year"></asp:Label>
                                <asp:RequiredFieldValidator ID="rrq1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="*" ValidationGroup="vgTDS" InitialValue="-1"></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">                                 
                                </asp:DropDownList>                                
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label8" runat="server" Text="Assessment Year"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTDSAY" ErrorMessage="*" ValidationGroup="vgTDS" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-6 columns">
                              <asp:TextBox ID="txtTDSAY" runat="server" style="width:100%;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label9" runat="server" Text="Quarter"></asp:Label>                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="DropDownList3" ErrorMessage="*" ValidationGroup="vgTDS" InitialValue="-1" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem Text="-- Select --" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Quarter-1" Value="Q1"></asp:ListItem>
                                    <asp:ListItem Text="Quarter-2" Value="Q2"></asp:ListItem>
                                    <asp:ListItem Text="Quarter-3" Value="Q3"></asp:ListItem>
                                    <asp:ListItem Text="Quarter-4" Value="Q4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="large-6 columns">
                                <asp:Label ID="Label24" runat="server" Text="Return Type"></asp:Label>                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddRetType" ErrorMessage="*" ValidationGroup="vgTDS" InitialValue="-1" ></asp:RequiredFieldValidator>
                            </div>
                            <div class="large-6 columns">
                                <asp:DropDownList ID="ddRetType" runat="server">
                                    <asp:ListItem Text="-- Select --" Value="-1"></asp:ListItem>
                                    <asp:ListItem Text="Regular" Value="Regular"></asp:ListItem>
                                    <asp:ListItem Text="Correction" Value="Correction"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                             <div class="large-6 columns">&nbsp;</div>
                             <div class="large-6 columns">
                         <asp:Button ID="Button3" runat="server" Font-Bold="true" Text="Submit" class="radius button"
                                    OnClick="Button3_Click" Width="162px" Height="53px"  ValidationGroup="vgTDS" />
                                    </div>
                                    </div>
    </div>--%>
</asp:Content>

