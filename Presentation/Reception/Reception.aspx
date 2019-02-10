<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Presentation/Reception/MasterPage.master"
    CodeFile="Reception.aspx.cs" Inherits="Presentation_Reception" %>

<%@ Register Assembly="GridControl" Namespace="GridControl" TagPrefix="VATAS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

    <script type="text/javascript">
        function showInputs() {
            document.getElementById('assdet1').style.display = 'block';
            document.getElementById('rowMain').style.display = 'none';
        }
        function hideInputs() {
            document.getElementById('assdet1').style.display = 'none';
            document.getElementById('rowMain').style.display = 'block';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="rowMain" class="row">
        <div class="large-12 columns" style="overflow: hidden; width: 100%;">
            <VATAS:VGrid ID="VGrid1" runat="server" Width="100%" AlternatingRowStyle="altr" HeaderStyle="bgc" />
        </div>
        <div class="large-12 columns" style="overflow: hidden; width: 970px;">
            <asp:Button ID="Button1" runat="server" PostBackUrl="Default.aspx" Text="Back" class="radius button"
                Font-Bold="true" Style="height: 53px" />
            <%--<asp:Button ID="btnAddAssessee" runat="server" OnClick="btnAddAssessee_Click" Text="New Return"
                class="radius button" Font-Bold="true" Style="height: 53px" />--%>
            <input type="button" id="btnNewRet" onclick="showInputs();" class="radius button" value="New Return" />
        </div>
    </div>

    <div id="assdet1" style="display: none;">
    <div class="row" id="Div3">
        <div style="padding: 10px; font-size: 15px; font-weight: bold;">
            <a href="#" style="color: #E14658">Assessment Details</a>
        </div>
    </div>
    <div class="row" id="row_AY" runat="server">
        <div class="large-8 columns">
            <asp:Label ID="Label3" runat="server" Text="Assessment Year"></asp:Label>
        </div>
        <div class="large-4 column">
            <asp:DropDownList ID="ddAY" runat="server" DataTextField="AssYear" DataValueField="AssYear">
                <asp:ListItem Text="2016-2017" Value="2016-2017" Selected="True"></asp:ListItem>
                <asp:ListItem Text="2015-2016" Value="2015-2016"></asp:ListItem>
                <asp:ListItem Text="2014-2015" Value="2014-2015"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row" id="row_ITR" runat="server">
        <div class="large-8 columns">
            <asp:Label ID="Label4" runat="server" Text="Income Tax Return"></asp:Label>
        </div>
        <div class="large-4 column">
            <asp:DropDownList ID="ddITR" runat="server">                    
            </asp:DropDownList>
        </div>
    </div>
    <div class="row" id="Div1" runat="server">
        <div class="large-8 columns">
            <asp:Label ID="Label1" runat="server" Text="Return Type"></asp:Label>
        </div>
        <div class="large-4 column">
            <asp:DropDownList ID="ddRetType" runat="server">
            <asp:ListItem Value="O" Text="Original"></asp:ListItem>
            <asp:ListItem Value="R" Text="Revised"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row" id="Div2" runat="server">
        <div class="large-8 columns">
             <input type="button" id="Button2" onclick="hideInputs();" class="radius button" value="Back" />
             &nbsp;
             <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"
                class="radius button" Font-Bold="true" Style="height: 53px" />
        </div>
        <div class="large-4 column">
           
        </div>
    </div>
    </div>
</asp:Content>
