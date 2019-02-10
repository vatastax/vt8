<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fileuploadDirCtrl_TDS.ascx.cs" Inherits="UserControls_fileuploadDirCtrl_TDS" %>
  <style type="text/css">
        .grid
        {
            color:White;
        }
        #fu2_gvDetails tr th
        { background-color:#494e6b;
          color:White;
        }
    </style>
<%--<asp:Panel ID="Pnl_Details" runat="server" Width="600px">--%>
<script type="text/javascript">

    function showWait() {
        
    }

    //    $(function() {
    //        $("#fu1_FileUpload1").uploadify({
    //         'swf'      : '~/uploadify/uploadify.swf',
    //         'uploader': '~/uploadify/uploadify.php',
    //        'multi':true,
    //        'auto':true
    //        });
    //    });
    //  
    //call fileupload asyn
    $("body").on("click", "#fu2_btnUpload", function () {
        //  $("#fu1_btnUpload").click(function () {
        try {
              alert('click');
            var fileUpload = $("#fu2_FileUpload1").get(0);
            var files = fileUpload.files;

            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }

            // alert(data);
            $.ajax({
                url: "../UserControls/FileUploadHandler.ashx",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (result) {
                     alert(result);
                    $('#fu2_lblSuccess').html("File Uploded");
                },
                error: function (err) {
                    alert(err.statusText)
                }

            });

        }
        catch (e) {
            alert(e);
        }
        // });
        //document.getElementById('<%#btn.ClientID %>').click();
    });
    //bind grid



    var _validFileExtensions = [".pdf", ".jpg", ".gif", ".png", ".doc", ".docx", ".xls", ".xlsx", ".xml", ".csv", ".txt", ".zip", ".rar", ".fvu", ".html", ".log"];
    function ValidateSingleInput(oInput) {
        if (oInput.type == "file") {
            var sFileName = oInput.value;
            if (sFileName.length > 0) {
                var blnValid = false;
                for (var j = 0; j < _validFileExtensions.length; j++) {
                    var sCurExtension = _validFileExtensions[j];
                    if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                        blnValid = true;
                        break;
                    }
                }

                if (!blnValid) {
                    alert("Sorry, " + sFileName + " is invalid, allowed extensions are: " + _validFileExtensions.join(", "));
                    oInput.value = "";
                    return false;
                }
            }
        }
        if ((parseInt(oInput.files[0].size) / 1000000) > 5) {
            alert("Sorry, The Size of File cannot be more than 5MB");
            oInput.value = "";
            return false;
        }
        else
            return true;
        //alert((parseInt(oInput.files[0].size)/1000000).toString());
        //return true;
        $(document).ready(function () {
            $('input[type="button" i]').css("text-decoration", "none")
            $('input[type="button" i]').css("border-radius", "10px");
            $('input[type="button" i]').css("background-color", " #e14658");
            $('input[type="button" i]').css("border", "none");
            $('input[type="button" i]').css("color", "white");
            $('input[type="button" i]').css("text-align", "center");
            $('input[type="button" i]').css("font-size", "12px");
            $('input[type="button" i]').css("cursor", "pointer");
        });
    }
    
</script>
<script type="text/javascript">
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
    function EndRequestHandler(sender, args) {

    }
           
    </script>
<asp:UpdatePanel ID="upsss3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
<ContentTemplate>
<asp:Panel ID="Pnl_MultipleUpload" runat="server" style="width: auto; height:200px; overflow-y:auto " >
        <%--<asp:Label ID="Label7" runat="server" Text="Label" Visible="false"></asp:Label>--%>
     <table style=" width:100%; border-radius:10px; margin-bottom:0px">
     <tr>
     <td style="    margin: 0;
    padding: 0"> <asp:FileUpload ID="FileUpload1" runat="server" ViewStateMode="Enabled" onchange="ValidateSingleInput(this);" multiple="true"   /></td>
     <td style=" padding-top:15px;    margin: 0;
    padding: 0" > <asp:Button ID="btnUpload" Text="Upload" runat="server"  class="button radius" style="    text-decoration: none;
    border-radius: 10px;
    background-color: #e14658;
    border: none;
    color: white;
    text-align: center;
    font-size: 12px;
    cursor: pointer;
    height: 40px; padding:5px 25px 5px 25px; font-weight:bold" onclick="btn_Click" /> <asp:Button ID="btn" runat="server" Text="Button" Visible="false" 
    onclick="btn_Click" /></td>
     </tr>
    
     <tr><td colspan="2" style="  margin: 0;
    padding: 0"><asp:Label ID="lblSuccess" runat="server" ForeColor="Green" /></td></tr>
       
     </table>
    <div style="    padding: 15px;
    text-align: center;
    background-color: #d3d3d3; border-radius:10px" id="divmsg" > <asp:Label ID="div_Grd_download_null" runat="server" Text="No Files Uploded Yet" Font-Bold="true" Font-Size="Larger" ForeColor="Red" style="color:red; font-size:17px" visible="false"></asp:Label></div>
      
        
      <asp:GridView ID="gvDetails" CellPadding="2" runat="server" Width="100%" 
            AutoGenerateColumns="False" ForeColor="white" 
            onrowcommand="gvDetails_RowCommand" style="border:1px solid #d3d3d3; "  >
      <AlternatingRowStyle BackColor="White" />
      <Columns>
      <asp:TemplateField>
      <HeaderTemplate>
      <asp:CheckBox ID="chkSelectHeader" runat="server" />
      </HeaderTemplate>
      <ItemTemplate>
      <asp:CheckBox ID="chkSelect" runat="server" />
      </ItemTemplate>
      </asp:TemplateField>
      <asp:BoundField DataField="Text" HeaderText="FileName" />
      <asp:BoundField DataField="Value" HeaderText="Uploaded On" />
      <%--<asp:TemplateField HeaderText="DateTime">
      <ItemTemplate>
     <asp:Label ID="lblDateTime" runat="server"></asp:Label>
      </ItemTemplate>
      </asp:TemplateField>--%>
      <asp:TemplateField HeaderText="Action">
      <ItemTemplate>
      <asp:ImageButton ID="imgDownload" runat="server" ImageUrl="~/images/download-red.png" ToolTip="Download File" CommandName="Download" style="height:14px; width:14px" onclientclick="javascript:showWait()" />&nbsp;
       <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/images/Editing-Delete-icon-hover.png" ToolTip="Delete File" CommandName="xyz" />
   
      </ItemTemplate>
      </asp:TemplateField>
       
      </Columns>
      <EditRowStyle BackColor="#2461BF" />
      <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
      <HeaderStyle BackColor="#507CD1" Font-Bold="true" ForeColor="White" CssClass="grid" />
      <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
      <RowStyle BackColor="#EFF3FB" />
      <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
      </asp:GridView> 
       <hr style="display:none" id="hh" />
    
    </asp:Panel>
</ContentTemplate>

</asp:UpdatePanel>
<asp:UpdateProgress ID="updateprogress1" runat="server" AssociatedUpdatePanelID="upsss3"></asp:UpdateProgress>
    
    <div class="ui-dialog-buttonpane  ui-helper-clearfix " style="display:none" id="btnbuttons">

     <asp:Button ID="btn_Download" runat="server" Text="Download" onclick="btn_Download_Click" style="background-color:#e54658; border:#e54658; border-radius:5px; color:White"   />
     <asp:Button ID="btn_CloseDownload" runat="server" Text="Close" Width="124px" style="background-color:#e54658; border:#e54658; border-radius:5px; color:White"   />

    </div> 