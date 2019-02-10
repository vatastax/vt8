<%@ Control Language="C#" AutoEventWireup="true" CodeFile="multipleFileUpload.ascx.cs" Inherits="User_Control_multipleFileUpload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
   <title>Untitled Page</title>
     <script type="text/javascript">
     //Function to Fill the Cell of the Table 
        function fillCell(row, cellNumber, text) {
            var cell = row.insertCell(cellNumber);
            cell.innerHTML = text;
            cell.style.borderBottom = cell.style.borderRight = "solid 1px #aaaaff";
        }
      //Function to Add the File Uploaded By the User To the Upload Control  
        function addToClientTable(name, text) {
        var table = document.getElementById("ctl00_SampleContent_clientSide");
           
            var row = table.insertRow(1); 
            var Check='<input type="Checkbox"  width="20px" height="20px" checked="true">';        
            var image='<input type="image" src="DeleteRed.jpg" alt="Submit button" width="20px" height="20px" onclick="DeleteRow(this)" >';
            var attachimage='<input type="image" src="attach.jpg" alt="Submit button" width="20px" height="20px">';
            fillCell(row, 0, attachimage);
            fillCell(row, 1, Check);
            fillCell(row, 2, name);
            fillCell(row, 3, text);
            fillCell(row,4,image)
            show();
            
           
        }
        
        //Fuction to Trace the Error
        function uploadError(sender, args) {
            addToClientTable(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");
        }
        //Function to Take Action after the file is uploaded
        function uploadComplete(sender, args) {
            var contentType = args.get_contentType();
            var text = args.get_length() + " bytes";

            addToClientTable(args.get_fileName(), text);
           
        }
        
        //Function to Delete the Selected Row
         function DeleteRow(o) 
         {
           var p=o.parentNode.parentNode;
           p.parentNode.removeChild(p);
           var oRows = document.getElementById('ctl00_SampleContent_clientSide').getElementsByTagName('tr');
          var iRowCount = oRows.length;
          if(iRowCount==1)
          {
          Hide();
          }
          
         }
         //Function to  Show the Attachment Table
        function show() 
        {
        if(document.getElementById('container').style.display=='none') {
        document.getElementById('container').style.display='block';
        } 
        }
        
        //Function to Hide the Attachment Table
        function Hide()
        {
        if(document.getElementById('container').style.display=='block'){
        document.getElementById('container').style.display='none';
        }
        }

    </script>
    
    <div>
        <%--<asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnClientUploadError="uploadError"
     OnClientUploadComplete="uploadComplete" 
      Width="400px" UploaderStyle="Modern"
     UploadingBackColor="#CCFFFF" ThrobberID="myThrobber" />--%>

     <asp:AjaxFileUpload ID="AsyncFileUpload1" runat="server" OnUploadComplete="File_Upload"  BackColor="#CCFFFF" ThrobberID="myThrobber" MaximumNumberOfFiles="50"  />
        </div>


        <br />     
     <br />
     <div id="container" style="display:none">
          <table id="ctl00_SampleContent_clientSide" style="border-collapse: collapse; border-left: solid 1px #aaaaff; border-top: solid 1px #aaaaff;" cellpadding="3">
        <tr>
        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: rgb(170, 170, 255); border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: rgb(170, 170, 255);"></td>
        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: rgb(170, 170, 255); border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: rgb(170, 170, 255);"></td>
        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: rgb(170, 170, 255); border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: rgb(170, 170, 255);">File Name</td>
        <td style="border-right-style: solid; border-right-width: 1px; border-right-color: rgb(170, 170, 255); border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: rgb(170, 170, 255);">File Size</td>
        <td align="center" style="border-right-style: solid; border-right-width: 1px; border-right-color: rgb(170, 170, 255); border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: rgb(170, 170, 255);">Remove</td>
        </tr>
</table>
    </div>
  
    <center><asp:Button ID="btn_Close" runat="server" Text="Close"  CausesValidation="false"
            onclick="btn_Close_Click" /></center>