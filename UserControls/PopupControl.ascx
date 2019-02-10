<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PopupControl.ascx.cs" Inherits="UserControls_PopupControl" %>

<style type="text/css">
    .top
    {
        background: #f0f9ff; /* Old browsers */ /* IE9 SVG, needs conditional override of 'filter' to 'none' */
        background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iI2YwZjlmZiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjQ3JSIgc3RvcC1jb2xvcj0iI2NiZWJmZiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiNhMWRiZmYiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);
        background: -moz-linear-gradient(top,  #f0f9ff 0%, #cbebff 47%, #a1dbff 100%); /* FF3.6+ */
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#f0f9ff), color-stop(47%,#cbebff), color-stop(100%,#a1dbff)); /* Chrome,Safari4+ */
        background: -webkit-linear-gradient(top,  #f0f9ff 0%,#cbebff 47%,#a1dbff 100%); /* Chrome10+,Safari5.1+ */
        background: -o-linear-gradient(top,  #f0f9ff 0%,#cbebff 47%,#a1dbff 100%); /* Opera 11.10+ */
        background: -ms-linear-gradient(top,  #f0f9ff 0%,#cbebff 47%,#a1dbff 100%); /* IE10+ */
        background: linear-gradient(to bottom,  #f0f9ff 0%,#cbebff 47%,#a1dbff 100%); /* W3C */
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f0f9ff', endColorstr='#a1dbff',GradientType=0 ); /* IE6-8 */
        border-style: solid;
        border-width: 1px;
        border-color: #d8d8d8;
        color: #333333;
    }
    .bottom
    {
        border-style: solid;
        border-width: 1px;
        border-color: #d8d8d8;
        background: #f2f2f2;
        color: #333333;
    }
</style>
<div>
<asp:Label ID="lblDummy" runat="server" Text="Testing Pop Control" Visible="false"></asp:Label>
<table>
            <tr>
                <td class="top">
                <asp:UpdatePanel ID="updTitle" runat="server">
                <ContentTemplate>
                    <span style="font-size: 18px;">
                    <asp:Literal ID="ltTitle" runat="server"></asp:Literal></span>
                </ContentTemplate>
                </asp:UpdatePanel>
                <span style="float:right;cursor:pointer"><img alt="Close" src="../images/cross.png" style="height:20px" id="btnPopClose" /></span>
                </td>
                
            </tr>
            <tr>
                <td>
                <asp:UpdatePanel ID="updEmp" runat="server">
                <ContentTemplate>
                <asp:GridView ID="gvEmp" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvEmp_RowDataBound"
                        OnRowCommand="gvEmp_RowCommand" EmptyDataText="<b> Default Employer </b>">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    S.No.
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSNO" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <HeaderTemplate>
                                    Name    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnTitle" runat="server" CommandName="sel1" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>' Style="display: none;"></asp:Label>
                                    <%--<asp:LinkButton ID="lbtnEmp" runat="server" Text='<%# Eval("Name") %>' CommandName="sel1" CommandArgument='<%# Eval("EmpID") %>' ></asp:LinkButton>--%>
                                    <%--<asp:Label ID="lblEmpID" runat="server" Text='<%# Eval("EmpID") %>' style="display:none;" ></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lblDetail" runat="server"></asp:Label>
                                    <%--<asp:LinkButton ID="lbtnEmp" runat="server" Text='<%# Eval("Name") %>' CommandName="sel1" CommandArgument='<%# Eval("EmpID") %>' ></asp:LinkButton>--%>
                                    <%--<asp:Label ID="lblEmpID" runat="server" Text='<%# Eval("EmpID") %>' style="display:none;" ></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
          <HeaderTemplate>
          PAN
          </HeaderTemplate>
          <ItemTemplate>          
           <asp:Label ID="Label1" runat="server" Text='<%# Eval("PAN") %>' ></asp:Label>
          </ItemTemplate>
          </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>                    
                </td>
            </tr>
            <tr>
                <td class="bottom">
                <asp:UpdatePanel ID="upd2" runat="server">
                <ContentTemplate>
                <p style="text-align:center;margin-bottom:0px">
                    <asp:LinkButton ID="aLnk" runat="server" Text="Add" ToolTip="Click this link to see list of all users"
                        Style="font-family: Verdana;    font-size: 20px;    border: 2px solid;    padding: 1px 13px; display:none;">
                    </asp:LinkButton>
                    <asp:LinkButton ID="lbtnAdd" runat="server" Text="Add" OnClick="lbtnAdd_Click" Style="font-family: Verdana;    font-size: 20px;    border: 2px solid;    padding: 1px 13px;">
                    </asp:LinkButton>
                    <a id="aLnka" runat="server" href="~/Presentation/Salary.aspx?VType=13011" runat="server" Style="font-family: Verdana;    font-size: 20px;    border: 2px solid;    padding: 1px 13px; display:none;">Add</a>
                    <asp:LinkButton ID="aLnkUpdate" runat="server" OnClick="aLnkUpdate_Click" Text="Manage" ToolTip="Click this link to update the selected Employer"
                        Style="font-family: Verdana;    font-size: 20px;    border: 2px solid;    padding: 1px 13px;">
                    </asp:LinkButton>
                    </p>
                </ContentTemplate>
                </asp:UpdatePanel>
                    
                    <%--<a id="aLnk" runat="server" style="font-family:Verdana; font-size:11px;" title="Click this link to see list of all users">
        Add <asp:Literal ID="ltTitle2" runat="server"></asp:Literal>            
    </a>--%>
                    <%--<a id="aLnkUpdate" runat="server" style="font-family:Verdana; font-size:11px;" title="Click this link to update the selected Employer">
        Manage <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </a>--%>
                   <%--  <div style="float: right;">
                        
                       <asp:Button ID="btnPopClose" runat="server" Text="X" BackColor="Red" BorderColor="Red"
                             BorderStyle="Inset" Style="height: 20px; cursor: pointer;" />
                    </div>--%>
                    
                </td>
            </tr>
        </table>
    </div>