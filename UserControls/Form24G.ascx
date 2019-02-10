<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Form24G.ascx.cs" Inherits="UserControls_Form24G" %>

<%@ Register Assembly="MessageBox" Namespace="Utilities" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<script language="javascript" type="text/javascript">

       function ShowMessage(event,div_id,ctlName)
       {
       
       window.divlist=document.getElementById(div_id);
      
       window.PrefixText = document.getElementById(ctlName.id).value; 
       window.textbox=document.getElementById(ctlName.id);
       var div =divlist.textContent;
        
          var array = div.split(',');
          
          
            var message_box=array[0].toString();
           
            var msg=array[1].toString();
          
            var display=array[2].toString();
            var page_to_be_called=array[3].toString();
           
            var screen=array[4].toString();
           
            var current_popup=array[5].toString();
            
            var current_page=array[6].toString();
            //window.autoCompleteExtender = $find(autocomplete);        

          
            if(display=='M')
            {
            divlist.style.display="none";
           
             if(message_box=='C')
            {
             
            var answer= confirm(msg);
           
            if(answer)
            {
            
            if(screen !="Self")
            {
             window.location.href="Main.aspx?screen=" +screen+ "&currentpopup=" +current_popup+ "&page=" +page_to_be_called+ "&current_page="+current_page;
            }
                                
            
            }
            else
            {
            
           
            textbox.value="";
           
           
            }
            
            }
            else if(message_box=='A')
            {
            alert(msg);
            }
            }
            
            
            
       }
        </script>--%>
<asp:UpdatePanel ID="update_FormControl" runat="server"  UpdateMode="Conditional" >
<ContentTemplate>
   <asp:Panel ID="pnl_PopupWindow" runat="server"   >
            <cc1:MessageBox ID="msg_alert" runat="server" />
            <cc1:MessageBox ID="msg_confirm" runat="server"  
                />
                
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
        <td align="left">
         <div id="popupheader">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
        <td align="left"><asp:Label ID="lbl_headerMsg" runat="server" Text="Vatas TDS Management" ></asp:Label></td>
        <td align="right">
            <asp:ImageButton ID="btn_Close" runat="server" 
                ImageUrl="../Images/windows_close_program.png" Width="30px" Height="30px" 
                  CausesValidation="false"  OnClick="btn_Close_Click"/></td>
        </tr>        
        </table>
        
        </div>
        </td>
        <td ></td>
        </tr>
        <tr>
        <td align="left">
        <br />
          <div id="popcontent">
      
          <table cellpadding="0" cellspacing="0" border="0" style="height: 207px">
        
        <tr>
        
        <td><asp:Label ID="lbl_AINNumber" runat="server" Text="AIN Number:"></asp:Label></td>
        <td><asp:TextBox ID="txt_AINNumber" runat="server" Width="250px" MaxLength="10" 
                AutoPostBack="True" ontextchanged="txt_AINNumber_TextChanged" ></asp:TextBox>
        
           </td>
            <div id="list3" class="divList">
            </div>
           <asp:AutoCompleteExtender ID="autoComplete_AIN" runat="server" 
                                CompletionInterval="1" CompletionListCssClass="AutoExtender" 
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                CompletionListElementID="list3"
                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                                EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetList" 
                                ServicePath="../SearchList.asmx"
                                 TargetControlID="txt_AINNumber" UseContextKey="True"></asp:AutoCompleteExtender>
        </tr>
        <tr>
        
        <td><asp:Label ID="lbl_AOName" runat="server" Text="Accounts Office Name:"></asp:Label></td>
        <td><asp:TextBox ID="txt_AOName" runat="server" Width="250px" MaxLength="10" 
                AutoPostBack="True" ontextchanged="txt_AOName_TextChanged"></asp:TextBox>
         <div ID="list4" class="divList">
            </div>
        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                CompletionInterval="1" CompletionListCssClass="AutoExtender" 
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                                CompletionListElementID="list4"
                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                                EnableCaching="true" MinimumPrefixLength="1" 
                                 TargetControlID="txt_AOName" UseContextKey="True" 
                ServiceMethod="GetCompletionList1"></asp:AutoCompleteExtender>
        </td>
        
           
            <%--<div ID="Div1" class="divList">--%>
            </div>
            <%-- <asp:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" 
                ServiceMethod="GetCompletionList3" UseContextKey="True" TargetControlID="txt_PANNumber" MinimumPrefixLength="1" 
                                    CompletionInterval="10"
                                    EnableCaching="true"
                                    CompletionSetCount="5"
                                    CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListElementID="list3"></asp:AutoCompleteExtender>--%>
        </tr>
        <tr>
        <td>
            <asp:Label ID="lbl_FinancialYear" runat="server" Text="Financial Year:"></asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="drp_FinancialYear" runat="server" AutoPostBack="True" 
                Width="250px" >
            </asp:DropDownList>
            </td>
        </tr>

              <tr>
                  <td>
                      <asp:Label ID="lbl_Month" runat="server" Text="Month:"></asp:Label>
                  </td>
                  <td>
                      <asp:DropDownList ID="drp_Month" runat="server" AutoPostBack="True"  Width="250px">
                      </asp:DropDownList>
                  </td>
              </tr>

              <tr>
                  <td colspan="2">
                     <%-- <asp:RadioButtonList ID="rdl_SelectReturn" runat="server" AutoPostBack="true" 
                          CausesValidation="false" 
                          onselectedindexchanged="rdl_SelectReturn_SelectedIndexChanged" 
                          RepeatDirection="Horizontal" Width="300px">
                          <asp:ListItem>New</asp:ListItem>
                          <asp:ListItem>File</asp:ListItem>
                          <asp:ListItem>Database</asp:ListItem>
                      </asp:RadioButtonList>--%>
                      <center>
                          <asp:Button ID="btn_Submit" runat="server" onclick="btn_Submit_Click" CausesValidation="false"
                              Text="Submit" />
                      </center>
                      </td>
                  <td>
                      &nbsp;</td>
              </tr>

        </table>
        </div>
        </td>
        <td></td>
        </tr>
        <tr>
        <td align="center"><%--<asp:Button ID="btn_OK" runat="server" Text="OK" Width="33px" />--%></td>
        <td></td>
        </tr>
        
        </table>
      
       
        </asp:Panel>
 </ContentTemplate>
<Triggers>
<%--<asp:PostBackTrigger ControlID="btn_SaveFile" />--%>
<asp:PostBackTrigger ControlID="btn_Close" />

</Triggers>
</asp:UpdatePanel>