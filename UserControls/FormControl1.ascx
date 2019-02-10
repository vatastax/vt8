<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FormControl1.ascx.cs" Inherits="UserControls_FormControl1" %>
<%@ Register Assembly="MessageBox" Namespace="Utilities" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%--<script src="../javascriptandJQuery/ErrorMessage.js" type="text/javascript"></script>--%>
<%--<script type="text/javascript">
//Function to Count
function f()
{
f.count = ++f.count || 1 ;
alert("Call No " + f.count)
}

//Function to Check the Exietnce of TAN
function CheckTAN()
{


var TAN=document.getElementById('<%=txt_TANNumber.ClientID %>').value;
var flag;
PageMethods.CheckTANExist(TAN,onSucess, onError);
function onSucess(result)
{

if(result==false)
  {
  CheckTAN.count = ++CheckTAN.count || 1 ;
  
  if(CheckTAN.count==1){
 
 var answer= confirm('TAN Does Not Exist, New TAN should be added from TANMaster.');
 
 
 if(answer)
 {
 
 document.getElementById('<%=txt_TANNumber.ClientID %>').focus();
 
 }
 else
 {
 TAN= TAN.substring(0,TAN.length-1);
 document.getElementById('<%=txt_TANNumber.ClientID %>').value=TAN;
CheckTAN.count=0;
 }
 }
 else
 {
 document.getElementById('<%=txt_TANNumber.ClientID %>').focus();
 }
  }
  
}
 function onError(result)
 {
        
 }
}
</script>--%>
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





<asp:UpdatePanel ID="update_FormControl" runat="server"  UpdateMode="Always" >
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
        <td><asp:Label ID="lbl_TANNumber" runat="server" Text="TAN Number:"></asp:Label></td>
        <td><asp:TextBox ID="txt_TANNumber" runat="server" Width="250px" AutoPostBack="true"  
                ontextchanged="txt_TANNumber_TextChanged" MaxLength="10" TabIndex="1"></asp:TextBox>
        <div id="list1" class="divlist"></div>
         
            <asp:AutoCompleteExtender ID="auto_TANUC" runat="server" ServiceMethod="GetList" 
                                ServicePath="../SearchList.asmx"
 UseContextKey="True" MinimumPrefixLength="1" 
                                    CompletionInterval="10"
                                    EnableCaching="true"
                                    CompletionSetCount="5"
                                    CompletionListCssClass="AutoExtender"
                                    CompletionListItemCssClass="AutoExtenderList"
                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                    CompletionListElementID="list1" TargetControlID="txt_TANNumber" >
            </asp:AutoCompleteExtender>
 </td>
        </tr>

        <tr>
        <td><asp:Label ID="lbl_Name" runat="server" Text="Name:"></asp:Label></td>
        <td><asp:TextBox ID="txt_Name" runat="server" Width="250px" AutoPostBack="true" 
                ontextchanged="txt_Name_TextChanged" TabIndex="8"></asp:TextBox>
            <div ID="list2" class="divlist">
            </div>
            <asp:AutoCompleteExtender ID="auto_Name" runat="server" CompletionInterval="10" 
                CompletionListCssClass="AutoExtender" CompletionListElementID="list2" 
                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetList" 
                ServicePath="../SearchList.asmx" TargetControlID="txt_Name" UseContextKey="True">
            </asp:AutoCompleteExtender>
            </td>
        </tr>

        <tr>
        <td>
            <asp:Label ID="lbl_PANNumber" runat="server" Text="PAN Number:"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txt_PANNumber" runat="server" MaxLength="10" Width="250px"></asp:TextBox>
            </td>
            <div ID="list3" class="divList">
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
        <asp:Label ID="lbl_FormType" runat="server" Text="Form Type:"></asp:Label>
        </td>
        <td>    
            <asp:DropDownList ID="drp_FormType" runat="server" Width="250px" 
                AutoPostBack="True" 
                onselectedindexchanged="drp_FormType_SelectedIndexChanged" ></asp:DropDownList></td>
        </tr>

        <tr>
        <td>
         <asp:Label ID="lbl_FinancialYear" runat="server" Text="Financial Year:"></asp:Label>
        </td>
        <td>
       
                <asp:DropDownList ID="drp_FinancialYear" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="drp_FinancialYear_SelectedIndexChanged" Width="250px">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
        <td>
       <asp:Label ID="lbl_AssesmentYear" runat="server" Text="Assesment Year:"></asp:Label>
            
       
        </td>
        <td>
            <asp:TextBox ID="txt_AssesmentYear" runat="server" Width="250px"></asp:TextBox>
            </td>
            
        </tr>

              <tr>
                  <td>
                      <asp:Label ID="lbl_Quater" runat="server" Text="Quater:"></asp:Label>
                      </td>
                  <td>
                      <asp:DropDownList ID="drp_Quater" runat="server" AutoPostBack="True" 
                          onselectedindexchanged="drp_Quater_SelectedIndexChanged" Width="250px">
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
                      </td>
                  <td>
                      <%--<asp:FileUpload ID="upload_File" runat="server" Visible="false"  />--%>
                      </td>
              </tr>

              <tr>
                  <td colspan="2">
                    
                      &nbsp;<center>
                          <asp:Button ID="btn_Submit" runat="server" onclick="btn_Submit_Click" 
                              Text="Submit" />
                      </center>
                  </td>
                  <td>
                      <%--<asp:FileUpload ID="upload_File" runat="server" Visible="false"  />--%>
                  </td>
              </tr>

              <tr>
                  <td align="center" colspan="2">
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
     
       
   
    
 