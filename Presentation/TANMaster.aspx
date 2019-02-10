<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TANMaster.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="MessageBox" Namespace="Utilities" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../SubUserMenu.ascx" TagName="submenu" TagPrefix="sub" %>
<%@ Register Src="../Menu.ascx" TagName="mainmenu" TagPrefix="main" %>
<%@ Register Src="../Menu2.ascx" TagName="mainmenu2" TagPrefix="main2" %>
<%@ Register Src="MediumSubUserMenu.ascx" TagName="mediummenu" TagPrefix="mob3" %>
<%@ Register Src="~/menu_header.ascx" TagName="menuheader" TagPrefix="header" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<!DOCTYPE html >
<html class="no-js" lang="en">
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />
    <title>TAN Master</title>
    <script type="text/javascript" src="Scripts/common.js"></script>
    <!--Master javascript file-->
    <script src="../js/MasterJScript.js" type="text/javascript"></script>
    <!--Master javascript file-->
    <!--master style sheet-->
    <link href="../style_folder/ItrSoftwareCompanyStyleSheet.css" rel="stylesheet" type="text/css" />
    <!--master style sheet-->
    <link rel="stylesheet" type="text/css" href="../css/new_button.css" />
    <%----show tab/hide tab  -------%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#a1').click(function () {
                $('#SectionA').show();
            });
        });
    </script>
    <%------ on click on second tab hide data of first tab  -------%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#a2').click(function () {
                $('#SectionA').hide();
                $('#<%=hdnScreen.ClientID %>').val('Repeat');
            });
        });
    </script>
    <%---- when clcik on type of deductor dropdown after taht we click on address tab it show extra space to hide space below fn is used----%>
      <script type="text/javascript">
          $(document).ready(function () {
              $('#a4').click(function () {
                  $('#SectionA').css("display", "none");
                  $('#<%=hdnScreen.ClientID %>').val('NR');
                  
              });
          });
    </script>
     
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btn_Copy').click(function () {
                // alert('check1');
                $('#SectionA').removeClass('tab-pane fade in active');
                $('#sectionb').addClass('tab-pane fade active in');
                $('#SectionA').removeClass('tab-pane fade in active');
                $('#SectionA').hide();
              //  alert('check1');
                $('#<%=hdnScreen.ClientID %>').val('Repeat');

            });
        });
    </script>
    <script type="text/javascript">
        (document).ready(function () {
            ('#cbdb-menu_id a').each(function () {
                (this).click(function (evt) {

                    ('#cbdb-menu_id a').removeClass('active_new1');
                    (this).addClass('active_new1');


                    ('#cbdb-menu_id a').removeClass('border_bot_new1');
                    (this).addClass('border_bot_new1');

                    ('#cbdb-menu_id a').css(
                    "border-bottom", "1px solid black"
                    )

                    (this).css(
                    "border-bottom", "none",
                     "box-shadow", "none"
                    )

                    evt.preventDefault();

                })

            });
        });

        //for main menu on mobile:

       
    </script>
    <!--master style sheet-->
    <style type="text/css">
        input[type="file"], input[type="checkbox"], input[type="radio"], select, input[type="text"]
        {
            color: Black;
            font-size: 15px;
            font-family: 'Open Sans' , 'sans-serif';
            width: 230px;
            height: 34px;
        }
        
        .hrnew
        {
            height: 2px;
            background-image: -webkit-linear-gradient(left, rgba(0, 0, 0, 1), rgba(0, 0, 0, 1), rgba(0, 0, 0, 1));
            opacity: 1.0;
            margin-top: 4px;
        }
        
        .listItem
        {
            background-color: window;
            color: windowtext;
            padding: 1px;
        }
        
        .completionListElement
        {
            margin: 0px !important;
            background-color: inherit;
            color: windowtext;
            border: buttonshadow;
            border-width: 2px;
            border-style: solid;
            cursor: 'default';
            overflow: auto;
            width: 20px;
            text-align: center;
            list-style-type: none;
        }
        
        .highlightedListItem
        {
            background-color: #ffff99;
            color: black;
            padding: 1px;
            cursor: pointer;
        }
        .mar_bottom
        {
            margin-bottom: -24px;
        }
        
        .UpperCaseLetter
        {
            text-transform: uppercase;
        }
    </style>
    
    <script type="text/javascript">
        function SetMaxLenght() {
            var STDCodeLenght = document.getElementById('<%=txt_STDCode.ClientID %>').value.length;
            PageMethods.GetMaxLenghtTelephone(STDCodeLenght, onSucess, onError);
            function onSucess(result) {
                document.getElementById('<%=txt_Telephone.ClientID %>').focus();
                document.getElementById('<%=txt_Telephone.ClientID %>').maxLength = result;

            }
            function onError(result) {
                alert('Error');
            }
        }


        function SetMaxLenght1() {
            var STDCodeLenght1 = document.getElementById('<%=txt_STDCode1.ClientID %>').value.length;
            PageMethods.GetMaxLenghtTelephone1(STDCodeLenght1, onSucess, onError);
            function onSucess(result) {
                document.getElementById('<%=txt_Telephone1.ClientID %>').focus();
                document.getElementById('<%=txt_Telephone1.ClientID %>').maxLength = result;

            }
            function onError(result) {
                alert('Error');
            }
        }

        function getHdn() {
            //alert('get(Hdn)');
            setTimeout(FillTAN, 1000);
        }
        //Function to Fill ScreenBy TAN
        function FillTAN() {
            //alert(document.getElementById('<%=hdnEditTAN.ClientID %>').value);
            var FieldName = "TAN";
            if (document.getElementById('<%=hdnEditTAN.ClientID %>').value != "") {
                var FieldValue = document.getElementById('<%=hdnEditTAN.ClientID %>').value;
                //alert(FieldName);
                //alert(FieldValue);
            }
            else
                var FieldValue = document.getElementById('<%=txt_TANNumber.ClientID %>').value;
            PageMethods.FillByTAN(FieldName, FieldValue, onSucess, onError);
            function onSucess(result) {
                //FillAIR();
                //alert(FieldName);
                //alert(FieldValue);
                var disableTAN = "";
                var resultsplite = result;

                try {

                    if (result[0] != "NoRecords") {

                        document.getElementById('<%=txt_TANNumber.ClientID %>').value = resultsplite[1];

                        document.getElementById('<%=txt_PANNumber.ClientID %>').value = resultsplite[2];

                        document.getElementById('<%=drp_DeductorType1.ClientID %>').value = resultsplite[3];

                        disableTAN = resultsplite[3];

                        document.getElementById('<%=txt_AssesseName.ClientID %>').value = resultsplite[4];
                        //alert('check');
                        document.getElementById('<%=txt_PersonResponsible.ClientID %>').value = resultsplite[5];
                        document.getElementById('<%=txtDesignation.ClientID %>').value = resultsplite[6];
                        //document.getElementById('<%=drp_Designation.ClientID %>').value = resultsplite[6];
                        //alert('check');


                        document.getElementById('<%=txt_Address1.ClientID %>').value = resultsplite[7];
                        document.getElementById('<%=txt_Address2.ClientID %>').value = resultsplite[8];
                        document.getElementById('<%=txt_Address3.ClientID %>').value = resultsplite[9];
                        document.getElementById('<%=txt_Address4.ClientID %>').value = resultsplite[10];
                        document.getElementById('<%=txt_Address5.ClientID %>').value = resultsplite[11];
                        document.getElementById('<%=drp_State.ClientID %>').value = resultsplite[12];
                        document.getElementById('<%=txt_PINCode.ClientID %>').value = resultsplite[13];

                        document.getElementById('<%=txt_Address01.ClientID %>').value = resultsplite[14];
                        document.getElementById('<%=txt_Address02.ClientID %>').value = resultsplite[15];
                        document.getElementById('<%=txt_Address03.ClientID %>').value = resultsplite[16];
                        document.getElementById('<%=txt_Address04.ClientID %>').value = resultsplite[17];
                        document.getElementById('<%=txt_Address05.ClientID %>').value = resultsplite[18];
                        document.getElementById('<%=drp_State1.ClientID %>').value = resultsplite[19];
                        document.getElementById('<%=txt_PINCode1.ClientID %>').value = resultsplite[20];

                        document.getElementById('<%=txt_BranchorDivision.ClientID %>').value = resultsplite[21];
                        document.getElementById('<%=txt_STDCode.ClientID %>').value = resultsplite[22];
                        document.getElementById('<%=txt_Telephone.ClientID %>').value = resultsplite[23];
                        document.getElementById('<%=txt_Email.ClientID %>').value = resultsplite[24];

                        document.getElementById('<%=txt_STDCode1.ClientID %>').value = resultsplite[25];
                        document.getElementById('<%=txt_Telephone1.ClientID %>').value = resultsplite[26];
                        document.getElementById('<%=txt_Email1.ClientID %>').value = resultsplite[27];
                        document.getElementById('<%=drp_StateName.ClientID %>').value = resultsplite[44];
                        document.getElementById('<%=txt_PAOCode.ClientID %>').value = resultsplite[45];
                        document.getElementById('<%=txt_DDOCode.ClientID %>').value = resultsplite[46];
                        //dodcode
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').value = resultsplite[47];
                        //paoregno
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').value = resultsplite[48];
                        //ddoregno
                        document.getElementById('<%=drp_MinistryName.ClientID %>').value = resultsplite[49];
                        //ministrycode
                        //  document.getElementById ().value=resultsplite[50];
                        //ministaryname	    
                        document.getElementById('<%=txt_MobileNo.ClientID %>').value = resultsplite[51];
                        //mobilenumber
                        //PAN Of ResponsiblePerson
                        document.getElementById('<%=txt_PANofResPer.ClientID %>').value = resultsplite[56];
                        //AIN Number
                        document.getElementById('<%=txt_AINNumber.ClientID %>').value = resultsplite[54];
                        if (document.getElementById('<%=hdnEditTAN.ClientID %>').value != "") {
                            if (disableTAN == "A" || disableTAN == "S" || disableTAN == "D" || disableTAN == "E" || disableTAN == "G" || disableTAN == "H" || disableTAN == "L" || disableTAN == "N") {
                                document.getElementById('a3').style.display = "block";
                                //document.getElementById('<%=hdnScreen.ClientID %>').val('Repeat1');
                            }
                            else {
                                document.getElementById('a3').style.display = "none";
                                //document.getElementById('<%=hdnScreen.ClientID %>').val('Repeat1');
                            }
                        }


                        if (disableTAN == "J" || disableTAN == "P" || disableTAN == "T" || disableTAN == "B" || disableTAN == "M" || disableTAN == "K" || disableTAN == "F" || disableTAN == "Q") {

                            document.getElementById('<%=drp_MinistryName.ClientID %>').disabled = 'true';
                            document.getElementById('<%=drp_MinistryName.ClientID %>').style.backgroundColor = "#E3E3E3";
                            //	              ValidatorEnable(document.getElementById('req_MinistryName'),false);	              
                            document.getElementById('<%=txt_PAOCode.ClientID %>').disabled = 'true';
                            document.getElementById('<%= txt_PAOCode.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=txt_DDOCode.ClientID %>').disabled = 'true';
                            document.getElementById('<%=txt_DDOCode.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=drp_StateName.ClientID %>').disabled = 'true';
                            document.getElementById('<%=drp_StateName.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').disabled = 'true';
                            document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').disabled = 'true';
                            document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').style.backgroundColor = "#E3E3E3";

                        }
                        else if (disableTAN == "G" || disableTAN == "A" || disableTAN == "L" || disableTAN == "D") {
                            document.getElementById('<%=drp_MinistryName.ClientID %>').disabled = 'false';
                            document.getElementById('<%=drp_MinistryName.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=txt_PAOCode.ClientID %>').disabled = 'false';
                            document.getElementById('<%= txt_PAOCode.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=txt_DDOCode.ClientID %>').disabled = 'false';
                            document.getElementById('<%=txt_DDOCode.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=drp_StateName.ClientID %>').disabled = 'true';
                            document.getElementById('<%=drp_StateName.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').disabled = 'false';
                            document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').disabled = 'false';
                            document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').style.backgroundColor = "#ffffff";
                        }
                        else if (disableTAN == "H" || disableTAN == "N" || disableTAN == "E") {
                            document.getElementById('<%=drp_MinistryName.ClientID %>').disabled = 'false';
                            document.getElementById('<%=drp_MinistryName.ClientID %>').style.backgroundColor = "#ffffff";

                            document.getElementById('<%=txt_PAOCode.ClientID %>').disabled = 'false';
                            document.getElementById('<%= txt_PAOCode.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=txt_DDOCode.ClientID %>').disabled = 'false';
                            document.getElementById('<%=txt_DDOCode.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=drp_StateName.ClientID %>').disabled = 'false';
                            document.getElementById('<%=drp_StateName.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').disabled = 'false';
                            document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').disabled = 'false';
                            document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').style.backgroundColor = "#ffffff";
                        }
                        else if (disableTAN == "S") {

                            document.getElementById('<%=drp_MinistryName.ClientID %>').disabled = 'true';
                            document.getElementById('<%=drp_MinistryName.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=txt_PAOCode.ClientID %>').disabled = 'true';
                            //	             document.getElementById('<%=req_MinistryName.ClientID %>').disabled='true';
                            ValidatorEnable(document.getElementById('req_MinistryName'), false);
                            document.getElementById('<%= txt_PAOCode.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=txt_DDOCode.ClientID %>').disabled = 'true';
                            document.getElementById('<%=txt_DDOCode.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=drp_StateName.ClientID %>').disabled = false;
                            document.getElementById('<%=drp_StateName.ClientID %>').style.backgroundColor = "#ffffff";
                            document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').disabled = 'true';
                            document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').style.backgroundColor = "#E3E3E3";
                            document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').disabled = 'true';
                            document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').style.backgroundColor = "#E3E3E3";
                        }
                        
                    }
                }
                catch (e) { alert(e); }

            }
            function onError(result) {

            }
        }
        //Function to Fill AIR_Return In TAN Master
        function FillAIR() {
            var FieldName = "TAN";
            var FieldValue = document.getElementById('<%=txt_TANNumber.ClientID %>').value;
            PageMethods.FillByTAN(FieldName, FieldValue, onSucess, onError);
            function onSucess(result) {
                var resultsplite = result;
                document.getElementById('<%=txt_FatherName.ClientID %>').value = resultsplite[28];
                document.getElementById('<%=txt_FlatNo.ClientID %>').value = resultsplite[29];
                document.getElementById('<%= txt_HouseorPremisesNo.ClientID %>').value = resultsplite[30];
                document.getElementById('<%=txt_FloorNo.ClientID %>').value = resultsplite[31];
                document.getElementById('<%=txt_BuildingName.ClientID %>').value = resultsplite[32];
                document.getElementById('<%=txt_BlockorSector.ClientID %>').value = resultsplite[33];
                document.getElementById('<%=txt_RoadorStreet.ClientID %>').value = resultsplite[34];
                document.getElementById('<%=txt_LocalityorColony.ClientID %>').value = resultsplite[35];
                document.getElementById('<%=txt_City.ClientID %>').value = resultsplite[36];
                document.getElementById('<%=drp_State2.ClientID %>').value = resultsplite[37];
                document.getElementById('<%=txt_PINCode2.ClientID %>').value = resultsplite[38];
                document.getElementById('<%=drp_District.ClientID %>').value = resultsplite[41];

                document.getElementById('<%=drp_MediumofReturn.ClientID %>').value = resultsplite[39];
                document.getElementById('<%=drp_JurisdictionalName.ClientID %>').value = resultsplite[40];
            }
            function onError(result) {

            }
        }
        //Function to Validate the TAN Number
        function ValidateTANNumber() {
            var TAN = document.getElementById('<%=txt_TANNumber.ClientID %>').value;
            var AName = document.getElementById('<%=txt_AssesseName.ClientID %>').value;
            PageMethods.ValidateTAN(TAN, AName, onSucess, onError);
            function onSucess(result) {
                if (result == true) {

                    FillTAN();

                }
                else {

                    alert('TAN Is Not Valid!');

                }
            }
            function onError(result) {

            }
        }

        //Function to Validate the PAN Number
        function ValidatePANNumber() {
            var PAN = document.getElementById('<%=txt_PANNumber.ClientID %>').value;
            PageMethods.ValiadtePAN(PAN, onSucess, onError);
            function onSucess(result) {
                if (result == true) {
                    document.getElementById('<%=txt_AssesseName.ClientID %>').focus();
                }
                else {
                    alert('PAN Is Not Valid!');
                }
            }
            function onError(result) {

            }
        }

    </script>
    <script type="text/javascript">
        function FillAssesseeName() {
            var FieldName = "AName";
            var FieldValue = document.getElementById('<%=txt_AssesseName.ClientID %>').value;
            PageMethods.FillByAssess(FieldName, FieldValue, onSucess, onError);
            function onSucess(result) {
                // FillAIRByName();

                var disableAssessee = "";


                var resultsplite = result;
                if (result[0] != "NoRecords") {
                    document.getElementById('<%=txt_TANNumber.ClientID %>').value = resultsplite[1];
                    document.getElementById('<%=txt_PANNumber.ClientID %>').value = resultsplite[2];
                    document.getElementById('<%=drp_DeductorType1.ClientID %>').value = resultsplite[3];
                    disableAssessee = resultsplite[3];

                    document.getElementById('<%=txt_AssesseName.ClientID %>').value = resultsplite[4];
                    document.getElementById('<%=txt_PersonResponsible.ClientID %>').value = resultsplite[5];
                    document.getElementById('<%=txtDesignation.ClientID %>').value = resultsplite[6];
                    //document.getElementById('<%=drp_Designation.ClientID %>').value = resultsplite[6];
                    document.getElementById('<%=txt_Address1.ClientID %>').value = resultsplite[7];
                    document.getElementById('<%=txt_Address2.ClientID %>').value = resultsplite[8];
                    document.getElementById('<%=txt_Address3.ClientID %>').value = resultsplite[9];
                    document.getElementById('<%=txt_Address4.ClientID %>').value = resultsplite[10];
                    document.getElementById('<%=txt_Address5.ClientID %>').value = resultsplite[11];
                    document.getElementById('<%=drp_State.ClientID %>').value = resultsplite[12];
                    document.getElementById('<%=txt_PINCode.ClientID %>').value = resultsplite[13];
                    document.getElementById('<%=txt_Address01.ClientID %>').value = resultsplite[14];
                    document.getElementById('<%=txt_Address02.ClientID %>').value = resultsplite[15];
                    document.getElementById('<%=txt_Address03.ClientID %>').value = resultsplite[16];
                    document.getElementById('<%=txt_Address04.ClientID %>').value = resultsplite[17];
                    document.getElementById('<%=txt_Address05.ClientID %>').value = resultsplite[18];
                    document.getElementById('<%=drp_State1.ClientID %>').value = resultsplite[19];
                    document.getElementById('<%=txt_PINCode1.ClientID %>').value = resultsplite[20];
                    document.getElementById('<%=txt_BranchorDivision.ClientID %>').value = resultsplite[21];
                    document.getElementById('<%=txt_STDCode.ClientID %>').value = resultsplite[22];
                    document.getElementById('<%=txt_Telephone.ClientID %>').value = resultsplite[23];
                    document.getElementById('<%=txt_Email.ClientID %>').value = resultsplite[24];
                    document.getElementById('<%=txt_STDCode1.ClientID %>').value = resultsplite[25];
                    document.getElementById('<%=txt_Telephone1.ClientID %>').value = resultsplite[26];
                    document.getElementById('<%=txt_Email1.ClientID %>').value = resultsplite[27];
                    document.getElementById('<%=drp_StateName.ClientID %>').value = resultsplite[44];
                    document.getElementById('<%=txt_PAOCode.ClientID %>').value = resultsplite[45];
                    document.getElementById('<%=txt_DDOCode.ClientID %>').value = resultsplite[46];
                    document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').value = resultsplite[47];
                    document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').value = resultsplite[48];
                    document.getElementById('<%=drp_MinistryName.ClientID %>').value = resultsplite[49];
                    document.getElementById('<%=txt_MobileNo.ClientID %>').value = resultsplite[51];



                    if (disableAssessee == "J" || disableAssessee == "P" || disableAssessee == "T" || disableAssessee == "B" || disableAssessee == "M" || disableAssessee == "K" || disableAssessee == "F" || disableAssessee == "Q") {

                        document.getElementById('<%=drp_MinistryName.ClientID %>').disabled = 'true';
                        document.getElementById('<%=drp_MinistryName.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=txt_PAOCode.ClientID %>').disabled = 'true';
                        document.getElementById('<%= txt_PAOCode.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=txt_DDOCode.ClientID %>').disabled = 'true';
                        document.getElementById('<%=txt_DDOCode.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=drp_StateName.ClientID %>').disabled = 'true';
                        document.getElementById('<%=drp_StateName.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').disabled = 'true';
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').disabled = 'true';
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').style.backgroundColor = "#E3E3E3";

                    }
                    else if (disableAssessee == "G" || disableAssessee == "A" || disableAssessee == "L" || disableAssessee == "D") {
                        document.getElementById('<%=drp_MinistryName.ClientID %>').disabled = 'false';
                        document.getElementById('<%=drp_MinistryName.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=txt_PAOCode.ClientID %>').disabled = 'false';
                        document.getElementById('<%= txt_PAOCode.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=txt_DDOCode.ClientID %>').disabled = 'false';
                        document.getElementById('<%=txt_DDOCode.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=drp_StateName.ClientID %>').disabled = 'true';
                        document.getElementById('<%=drp_StateName.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').disabled = 'false';
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').disabled = 'false';
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').style.backgroundColor = "#ffffff";
                    }
                    else if (disableAssessee == "H" || disableAssessee == "N" || disableAssessee == "E") {
                        document.getElementById('<%=drp_MinistryName.ClientID %>').disabled = 'false';
                        document.getElementById('<%=drp_MinistryName.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=txt_PAOCode.ClientID %>').disabled = 'false';
                        document.getElementById('<%= txt_PAOCode.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=txt_DDOCode.ClientID %>').disabled = 'false';
                        document.getElementById('<%=txt_DDOCode.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=drp_StateName.ClientID %>').disabled = 'false';
                        document.getElementById('<%=drp_StateName.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').disabled = 'false';
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').disabled = 'false';
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').style.backgroundColor = "#ffffff";
                    }
                    else if (disableAssessee == "S") {

                        document.getElementById('<%=drp_MinistryName.ClientID %>').disabled = 'true';
                        document.getElementById('<%=drp_MinistryName.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=txt_PAOCode.ClientID %>').disabled = 'true';
                        document.getElementById('<%= txt_PAOCode.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=txt_DDOCode.ClientID %>').disabled = 'true';
                        document.getElementById('<%=txt_DDOCode.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=drp_StateName.ClientID %>').disabled = false;
                        document.getElementById('<%=drp_StateName.ClientID %>').style.backgroundColor = "#ffffff";
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').disabled = 'true';
                        document.getElementById('<%=txt_PAORegistrationNo.ClientID %>').style.backgroundColor = "#E3E3E3";
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').disabled = 'true';
                        document.getElementById('<%=txt_DDORegistrationNo.ClientID %>').style.backgroundColor = "#E3E3E3";
                    }
                }

            }
            function onError(result) {

            }
        }
        //Function To Fill AIR BY Assesse Name
        function FillAIRByName() {
            var FieldName = "AName";
            var FieldValue = document.getElementById('<%=txt_AssesseName.ClientID %>').value;
            PageMethods.FillByAssess(FieldName, FieldValue, onSucess, onError);
            function onSucess(result) {


                var disableAssessee = "";


                var resultsplite = result;
                document.getElementById('<%=txt_FatherName.ClientID %>').value = resultsplite[28];
                document.getElementById('<%=txt_FlatNo.ClientID %>').value = resultsplite[29];
                document.getElementById('<%= txt_HouseorPremisesNo.ClientID %>').value = resultsplite[30];
                document.getElementById('<%=txt_FloorNo.ClientID %>').value = resultsplite[31];
                document.getElementById('<%=txt_BuildingName.ClientID %>').value = resultsplite[32];
                document.getElementById('<%=txt_BlockorSector.ClientID %>').value = resultsplite[33];
                document.getElementById('<%=txt_RoadorStreet.ClientID %>').value = resultsplite[34];
                document.getElementById('<%=txt_LocalityorColony.ClientID %>').value = resultsplite[35];
                document.getElementById('<%=txt_City.ClientID %>').value = resultsplite[36];
                document.getElementById('<%=drp_State2.ClientID %>').value = resultsplite[37];
                document.getElementById('<%=txt_PINCode2.ClientID %>').value = resultsplite[38];
                document.getElementById('<%=drp_District.ClientID %>').value = resultsplite[41];

                document.getElementById('<%=drp_MediumofReturn.ClientID %>').value = resultsplite[39];
                document.getElementById('<%=drp_JurisdictionalName.ClientID %>').value = resultsplite[40];
            }
            function onError(result) {

            }

        }
        //Function to Count
        function f() {
            f.count = ++f.count || 1;
            alert("Call No " + f.count)
        }

        //Function to Check the Exietnce of TAN
        function CheckTAN() {


            var TAN = document.getElementById('<%=txt_TANNumber.ClientID %>').value;
            var flag;
            PageMethods.CheckTANExist(TAN, onSucess, onError);
            function onSucess(result) {

                if (result == false) {
                    CheckTAN.count = ++CheckTAN.count || 1;

                    if (CheckTAN.count == 1) {

                        var answer = confirm('Do you want to Add new TAN');


                        if (answer) {

                            document.getElementById('<%=txt_TANNumber.ClientID %>').focus();

                        }
                        else {
                            TAN = TAN.substring(0, TAN.length - 1);
                            document.getElementById('<%=txt_TANNumber.ClientID %>').value = TAN;
                            CheckTAN.count = 0;
                        }
                    }
                    else {
                        document.getElementById('<%=txt_TANNumber.ClientID %>').focus();
                    }
                }

            }
            function onError(result) {

            }
        }


    </script>
    <script type="text/javascript">
        function numbersonly(e) {
            var unicode = e.charCode ? e.charCode : e.keyCode
            if (unicode != 8) { //if the key isn't the backspace key (which we should allow)
                if (unicode < 48 || unicode > 57) //if not a number
                    return false //disable key press
            }
        }
    </script>
    <%----show tab  -------%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#drp_DeductorType1').change(function () {
                // DeductorType = $('#<%= drp_DeductorType1.ClientID %>').val();
                DeductorType = $("#drp_DeductorType1 option:selected").text()
                if ((DeductorType.indexOf("State Govt.") != -1) || (DeductorType.indexOf("Central Govt.") != -1) || (DeductorType.indexOf("Central Government") != -1) || (DeductorType.indexOf("State Government") != -1)) {
                   // alert(DeductorType);
                    $('#a3').css("display", "block");
                    //$('#<%=hdnScreen.ClientID %>').val('NR');
                    //  $('#<%=hdnScreen.ClientID %>').val('Repeat');
                    $('#<%=hdnScreen.ClientID %>').val('Repeat1');
                }
                else {
                    $('#a3').css("display", "none");
                    // $('#<%=hdnScreen.ClientID %>').val('NR');
                    //  $('#<%=hdnScreen.ClientID %>').val('Repeat');
                    $('#<%=hdnScreen.ClientID %>').val('Repeat1');
                }

            });
        });
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            // re-bind your jQuery events here
            $('#drp_DeductorType1').change(function () {
                // DeductorType = $('#<%= drp_DeductorType1.ClientID %>').val();
               // alert('jj');
                DeductorType = $("#drp_DeductorType1 option:selected").text()
               // alert(DeductorType);
            });
        });
    </script>
    <%--<script language="javascript" type="text/javascript">

       function ShowMessage(event,ctlName,context_key)
       {
       
     // look for window.event in case event isn't passed in
     
         window.PrefixText = document.getElementById(ctlName.id).value; 
       
       
          
         PageMethods.Fire_Error_Message(PrefixText,context_key,onSuccess, onError);
         function onSuccess(result)
        {
       
          if (window.event) { event = window.event; }
        if (event.keyCode != 13) {
          
          
      var array = result.split(',');
         
          
            var message_box=array[0];
            
            
            var msg=array[1];
            
            var display=array[2];
            var page_to_be_called=array[3];
            
            var screen=array[4];
         
            var current_popup=array[5];
             
            var current_page=array[6];
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
              textbox.setAttribute("onclick","javascript:return false();");
              textbox.value="";
               textbox.focus();    
            ShowMessage.count=0;
            //setTimeout(function(){ctlName.focus();}, 1);
              }
            }//message_box condition ends here.
            
          }
          
        }//Function OnSuccess Ends Here
        
        function onError(result)
       {

       }
      
       }//KeyCode Event End Here
            
            
      
            
            
            
       
        </script>--%>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 00px;
            margin-bottom: 00px;
        }
        a
        {
            text-decoration: none;
            color: #215DC6;
        }
        
        a:hover
        {
            text-decoration: none;
            color: #40ACF4;
        }
        .style1
        {
            color: #215DC6;
            font-family: Arial, Helvetica, sans-serif;
            font-weight: bold;
            font-size: 12px;
        }
        input[type=text]
        {
            padding: 4px;
        }
    </style>
</head>
<body style="font-family: 'Open Sans','sans-serif';">
    <form id="form1" runat="server">
    <div style="display: none">
        <div id="maindiv" runat="server" class="container-fluid"> <div class="row"> <div
        class="col-lg-12"> <%--<div class="row"> <div class="large-12 columns" runat="server"
        >--%> <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ToolkitScriptManager> 
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(PageLoaded);
            function PageLoaded(sender, args) {
                //alert('loaded');
            }
            function BeginRequestHandler(sender, args) {
                //            var elem = args.get_postBackElement();
                //            ActivateAlertDiv('visible', 'AlertDiv', elem.value + ' processing...');
            }
            //following event is being used as the last event after page loaded for updatepanel asynchronous events
            function EndRequestHandler(sender, args) {
                try {
                   // $('#btn_Copy').click();
                   //  $('#btn_Copy').click(function () {
                    if ($('#hdnScreen').val() == "Repeat") {
                        $('#SectionA').removeClass('tab-pane fade in active');
                        $('#sectionb').addClass('tab-pane fade in active');
                        // $('#a2').click();
                        $('#SectionA').removeClass('tab-pane fade in active');
                        $('#SectionA').hide();
                        // alert('check');
                    }
                    else if ($('#<%=hdnScreen.ClientID %>').val('Repeat1')) {
                    }
                //  });
                        $('#drp_DeductorType1').change(function () {
                            // DeductorType = $('#<%= drp_DeductorType1.ClientID %>').val();
                            DeductorType = $("#drp_DeductorType1 option:selected").text()
                            if ((DeductorType.indexOf("State Govt.") != -1) || (DeductorType.indexOf("Central Govt.") != -1) || (DeductorType.indexOf("Central Government") != -1) || (DeductorType.indexOf("State Government") != -1)) {
                                //alert(DeductorType);
                                $('#a3').css("display", "block");
                               $('#<%=hdnScreen.ClientID %>').val('Repeat1');
                            }
                            else {
                                $('#a3').css("display", "none");
                                $('#<%=hdnScreen.ClientID %>').val('Repeat1');
                            }

                        });
                   // alert('ended');
                }
                catch (e) { alert(e); }
            }

        </script>
       <asp:HiddenField ID="hdnEditTAN"
        runat="server"> </asp:HiddenField> <%-- Nishu--%> <cc1:MessageBox ID="msg_TanCorrection1"
        runat="server" OnGetMessageBoxResponse="msg_TanCorrection1_GetMessageBoxResponse"
        /> <cc1:MessageBox ID="msg_TanCorrection2" runat="server" OnGetMessageBoxResponse="msg_TanCorrection2_GetMessageBoxResponse"
        /> <cc1:MessageBox ID="msg_TanCorrection3" runat="server" OnGetMessageBoxResponse="msg_TanCorrection3_GetMessageBoxResponse"
        /> <cc1:MessageBox ID="msg_TanCorrection4" runat="server" /> </div>
    </div>
    <asp:Panel ID="Pnl_NewTAN" runat="server">
        <div class="row">
            <div class=" col-md-6 col-lg-6">
                <asp:Label ID="lbl_NewTanNo" runat="server" Text="New TAN No"></asp:Label>
            </div>
            <div class="col-md-6  col-lg-6">
                <asp:TextBox ID="txt_NewTanNo" runat="server"></asp:TextBox><asp:Button ID="btn_SubmitNewTAN"
                    runat="server" Text="Submit" CausesValidation="false" OnClick="btn_SubmitNewTAN_Click"
                    class="button" />
            </div>
        </div>
    </asp:Panel>
    <asp:ModalPopupExtender ID="Pop_NewTANNo" runat="server" PopupControlID="Pnl_NewTAN"
        TargetControlID="lbl_Message" BackgroundCssClass="modalBackground">
    </asp:ModalPopupExtender>
    <div class="row">
        <div class="col-md-6 col-lg-6">
            <cc1:MessageBox ID="msg_ConfirmCorrection" runat="server" OnGetMessageBoxResponse="msg_ConfirmCorrection_GetMessageBoxResponse" />
        </div>
        <div class="col-md-6 col-lg-6">
        </div>
    </div>
    <asp:Panel ID="Pnl_Modal" runat="server" CssClass="ModalWindow">
        <div class="row">
            <div class="large-12 columns">
                <asp:Label ID="lbl_Message" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-lg-6">
                <asp:Button ID="btn_ok" runat="server" Text="OK" OnClick="btn_ok_Click" class="button" />
            </div>
            <div class="col-md-6 col-lg-6">
                <asp:Button ID="btn_Cancel" runat="server" Text="CANCEL" OnClick="btn_Cancel_Click"
                    class="button" />
            </div>
        </div>
    </asp:Panel>
    <div class="row">
        <div class="large-6 columns">
            <asp:Label ID="lbl_MinistryCode" runat="server" Text="Select Ministry Code:" Visible="False"></asp:Label>
        </div>
        <div class="large-6 columns">
            <asp:Label ID="lbl_DeductorTypeCode" runat="server" Text="Select Deductor Type Code:"
                Visible="false"></asp:Label>
            <asp:Button ID="btn_backtoChallan" runat="server" Text="Back To Challan" Visible="false"
                OnClick="btn_backtoChallan_Click" CausesValidation="false" class="button" />
        </div>
    </div>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lbl_MinistryCode"
        PopupControlID="Pnl_Modal">
    </asp:ModalPopupExtender>
    </div> </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 hide-for-small-only">
                <%--Add by nishu for header 11/4/2015 --%>
                <header:menuheader ID="header1" runat="server" />
            </div>
        </div>
        <div class="row">
            <div class="large-12 columns">
                <div class="large-6 columns text-left">
                    <asp:SiteMapPath ID="SiteMapPath1" runat="server">
                    </asp:SiteMapPath>
                </div>
                <div class="large-6 columns text-right">
                    <a href="Main.aspx">
                        <input type="button" value="Back to Main" class="newbtn" /></a>
                </div>
            </div>
        </div>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        <div class=" hide-for-small-only">
            <%-- <% if (Session["IsMasterPage"] != null)
           {
               if (Session["IsMasterPage"].ToString() != "1")
               { %>--%>
            <%-- <main:mainmenu ID="mm1" runat="server" />----%>
            <%-- <%}
           }%>--%>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <%--<div class="col-xs-3 col-sm-3 large-3 columns hide-for-small">
<sub:submenu ID="Submenu1" runat="server"  />
</div>--%>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <div class="row panel" style="display: none">
                    <div class="large-6 small-6  columns bg-primary">
                        <h5>
                            <asp:Label ID="lbl_ReturnType" runat="server" ForeColor="White" Font-Bold="true"
                                Text="Select Return Type:"></asp:Label></h5>
                    </div>
                    <div class="large-6  columns">
                        <asp:DropDownList ID="drp_ReturnType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_ReturnType_SelectedIndexChanged"
                            Style="height: auto">
                            <asp:ListItem>----Select----</asp:ListItem>
                            <asp:ListItem Value="TDS">TDS/TCS Return</asp:ListItem>
                            <asp:ListItem Value="AIR ">AIR Return</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="container-fluid">
                    <ul class="nav nav-tabs" role="tablist" id="mytab">
                        <li class="active"><a href="#SectionA" data-toggle="tab" id="a1">TAN Details</a></li>
                        <li><a href="#sectiond" data-toggle="tab" click="show(); id="a4">Address</a></li>
                        <li><a href="#sectionb" data-toggle="tab" id="a2">Responsible Person's Details</a></li>
                        <li><a href="#sectionc" data-toggle="tab" click="show();" style="display: none" id="a3" >
                            Ministry Details</a></li>
                    </ul>
                </div>
                <hr class="hrnew" style="margin-top: -3px;" />
                <script type="text/javascript">
                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
                </script>
                <div class="tab-content">
                    <asp:UpdatePanel ID="upd_TAN" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="tab-content">
                                <div id="SectionA" class="tab-pane fade in active">
                                    <div class="row">
                                        <div class="large-12 columns ">
                                            <div class="large-3 columns text-left">
                                                <asp:Label ID="lbl_TANNumber" runat="server" onchange="javascript:return ValidateTANNumber();"
                                                    Text="TAN Number:"></asp:Label><span style="color: Red">*</span>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox runat="server" ID="txt_TANNumber" AutoPostBack="false" AutoCompleteType="Cellular"
                                                    onchange="javascript:return FillTAN();" CssClass="UpperCaseLetter" MaxLength="10"
                                                    OnTextChanged="txt_TANNumber_TextChanged" TabIndex="1"></asp:TextBox>
                                                <asp:AutoCompleteExtender ID="auto_TAN" runat="server" FirstRowSelected="true" UseContextKey="True"
                                                    MinimumPrefixLength="1" ServiceMethod="GetList" ServicePath="../SearchList.asmx"
                                                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="5" CompletionListCssClass="completionListElement"
                                                    CompletionListItemCssClass="listItem" CompletionListHighlightedItemCssClass="highlightedListItem"
                                                    TargetControlID="txt_TANNumber">
                                                </asp:AutoCompleteExtender>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_TANNumber" Display="Dynamic"
                                                    ErrorMessage="Please provide TAN Number in TAN Details tab!" Text="&lt;img src='../images/Exclamation.gif' title='Please provide TAN Number! '"
                                                    ID="req_BsrCode0"></asp:RequiredFieldValidator>
                                                <div id="divwidth" style="z-index: 300">
                                                </div>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_PANNumber" runat="server" Text="PAN Number:"></asp:Label><span
                                                    style="color: Red">*</span>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="txt_PANNumber" runat="server" AutoCompleteType="Cellular" OnTextChanged="txt_PANNumber_TextChanged1"
                                                    CssClass="UpperCaseLetter" TabIndex="2" MaxLength="10" AutoPostBack="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_PANNumber" ErrorMessage="Please provide PAN Number in TAN Details tab!"
                                                    Text="&lt;img src='../images/Exclamation.gif' title='Please provide the PAN Number!'"
                                                    Display="Dynamic" ID="req_BsrCode1"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns mar_bottom">
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_AssesseeName" runat="server" Text="Deductor Name:"></asp:Label><span
                                                    style="color: Red">*</span>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="txt_AssesseName" runat="server" AutoCompleteType="Cellular" AutoPostBack="false"
                                                    onchange="javascript:return FillAssesseeName();" CssClass="UpperCaseLetter" TabIndex="3"
                                                    MaxLength="75"></asp:TextBox>
                                                &nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="txt_AssesseName"
                                                    ErrorMessage="Please provide the Assesse Name in TAN Details tab!" Display="Dynamic"
                                                    Text="&lt;img src='../images/Exclamation.gif' title='Please provide the Assesse Name!'"
                                                    ID="req_BsrCode2"></asp:RequiredFieldValidator>
                                                <div id="divwidth2" class="divList" style="z-index: 3">
                                                </div>
                                                <asp:AutoCompleteExtender ID="auto_AName" runat="server" ServiceMethod="GetList"
                                                    FirstRowSelected="true" ServicePath="../SearchList.asmx" UseContextKey="True"
                                                    MinimumPrefixLength="1" CompletionInterval="10" EnableCaching="true" CompletionSetCount="5"
                                                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" CompletionListElementID="divwidth2"
                                                    TargetControlID="txt_AssesseName">
                                                </asp:AutoCompleteExtender>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_DeductorType" runat="server" Text="Type of Deductor:"></asp:Label><span
                                                    style="color: Red">*</span>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="drp_DeductorType1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_DeductorType1_SelectedIndexChanged"
                                                    TabIndex="7">
                                                </asp:DropDownList>
                                                &nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="drp_DeductorType1"
                                                    ErrorMessage="Please Select the Deductor Type in TAN details tab!" Text="&lt;img src='../images/Exclamation.gif' title='Please Select the Deductor Type!'"
                                                    Display="Dynamic" ID="req_BsrCode3"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns mar_bottom">
                                            <div class="large-3 columns">
                                            </div>
                                            <div class="large-3 columns">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div id="sectionb" class="tab-pane fade">
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <asp:Button ID="btn_Copy" runat="server" CausesValidation="false" OnClick="btn_Copy_Click"
                                                Text="Same as deductor address" class="button" />
                                        </div>
                                    </div>
                                    <asp:MultiView ID="mv_TAN" runat="server">
                                        <asp:View ID="vw_TAN2" runat="server">
                                            <div class="row">
                                                <div class="large-3 columns">
                                                    <asp:Label ID="lbl_LocalityColony" runat="server" Text="Locality/Colony"></asp:Label>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:TextBox ID="txt_LocalityorColony" runat="server" MaxLength="60"></asp:TextBox>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:Label ID="lbl_City" runat="server" Text="City"></asp:Label>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:TextBox ID="txt_City" runat="server" MaxLength="25"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="large-3 columns">
                                                    <asp:Label ID="lbl_State2" runat="server" Text="State"></asp:Label>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:DropDownList ID="drp_State2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_State2_SelectedIndexChanged"
                                                        Style="height: auto">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:Label ID="lbl_PINCode2" runat="server" Text="PIN Code"></asp:Label>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:TextBox ID="txt_PINCode2" runat="server" MaxLength="6"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="large-3 columns">
                                                    <asp:Label ID="lbl_DistrictName" runat="server" Text="District Name"></asp:Label>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:DropDownList ID="drp_District" runat="server" Style="height: auto">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:Label ID="lbl_MediumofReturn" runat="server" Text="Medium of Return"></asp:Label>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:DropDownList ID="drp_MediumofReturn" runat="server" Style="height: auto">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="large-3 columns">
                                                    <asp:Label ID="lbl_JurisdictionalName" runat="server" Text="Jurisdictional CIT(CIB)Name"></asp:Label>
                                                </div>
                                                <div class="large-3 columns">
                                                    <asp:DropDownList ID="drp_JurisdictionalName" runat="server" Style="height: auto">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="large-3 columns">
                                                </div>
                                                <div class="large-3 columns">
                                                </div>
                                            </div>
                                        </asp:View>
                                        <asp:View ID="vw_TAN1" runat="server">
                                            <div class="row">
                                                <div class="large-12 columns ">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_PersonResponsible" runat="server" Text="Person Responsible:"></asp:Label><span
                                                            style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_PersonResponsible" runat="server" CssClass="UpperCaseLetter"
                                                            TabIndex="5" MaxLength="75"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_PersonResponsible"
                                                            ErrorMessage="Please provide the Person Responsible  in TAN details tab!" Text="&lt;img src='../images/Exclamation.gif' title='Please provide the Person Responsible!'"
                                                            Display="Dynamic" ID="req_BsrCode5"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="Label1" runat="server" Text="PAN Of Person Responsible:"></asp:Label><span
                                                            style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_PANofResPer" runat="server" AutoPostBack="false" CssClass="UpperCaseLetter"
                                                            TabIndex="6" MaxLength="75"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_PANofResPer" ErrorMessage="Please provide the PAN of Person Responsible  in TAN details tab!"
                                                            Text="&lt;img src='../images/Exclamation.gif' title='Please provide the PAN of Person Responsible!'"
                                                            Display="Dynamic" ID="req_PANofResPer"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="large-12 columns">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Designation" runat="server" Text="Designation:"></asp:Label><span
                                                            style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <%--nishu 28/3/2015 --%>
                                                        <asp:TextBox ID="txtDesignation" runat="server" CssClass="UpperCaseLetter"></asp:TextBox>
                                                        <asp:DropDownList ID="drp_Designation" runat="server" TabIndex="4" Style="height: auto"
                                                            Required Visible="false">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txt_Designation" runat="server" Visible="false"></asp:TextBox>
                                                        <%-- Button visibility hide by nishu 28/3/2015--%>
                                                        <asp:Button ID="btn_AddDesignation" runat="server" Text="Add Designation" CausesValidation="False"
                                                            OnClick="btn_AddDesignation_Click" TabIndex="21" class="button" Visible="false" />
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="drp_Designation" ErrorMessage="Please Select the Designation!"
                                                            Text="&lt;img src='../images/Exclamation.gif' title='Please Select the Designation!'"
                                                            ID="req_BsrCode6" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        <asp:Button ID="btn_CancelDesig" runat="server" Text="Cancel" CausesValidation="False"
                                                            OnClick="btn_CancelDesig_Click" class="button" Visible="false" />
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address6" runat="server" Text="Flat/Door/Building"></asp:Label><span
                                                            style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address01" runat="server" TabIndex="26" MaxLength="25" CssClass="UpperCaseLetter"></asp:TextBox>
                                                        &nbsp;<asp:RequiredFieldValidator ID="req_BsrCode8" runat="server" Display="None"
                                                            ControlToValidate="txt_Address01" ErrorMessage="Please Specify the Address in Responsible Person Details tab!"
                                                            Text="&lt;img src='../images/Exclamation.gif' title='Please Specify the Address!'"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row ">
                                                <div class="large-12 columns">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address7" runat="server" Text="Road/Street:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address02" runat="server" TabIndex="27" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address8" runat="server" Text="Area/Locality:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address03" runat="server" TabIndex="28" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row ">
                                                <div class="large-12 columns">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address9" runat="server" Text="Town/City/District:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address04" runat="server" TabIndex="29" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address10" runat="server" Text="Address:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address05" runat="server" TabIndex="30" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row ">
                                                <div class="large-12 columns">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_State0" runat="server" Text="State:"></asp:Label><span style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:DropDownList ID="drp_State1" runat="server" TabIndex="31">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="req_BsrCode15" runat="server" Display="None" ControlToValidate="drp_State1"
                                                            ErrorMessage="Please Select State in Responsible Person Details tab!" Text="&lt;img src='../images/Exclamation.gif' title='Please Select State!'"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_STDCode0" runat="server" Text="STD Code:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_STDCode1" runat="server" TabIndex="32" MaxLength="5" onchange="javascript:return SetMaxLenght1();"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row ">
                                                <div class="large-12 columns mar_bottom">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Email" runat="server" Text="E-mail ID:"></asp:Label><span style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Email" runat="server" TabIndex="33" MaxLength="75" Style="text-transform: lowercase"></asp:TextBox>
                                                        &nbsp;<asp:RequiredFieldValidator ID="req_BsrCode11" runat="server" Display="None"
                                                            ControlToValidate="txt_Email" ErrorMessage="Please provide the Email Address in Deductee Address tab!"
                                                            Text="&lt;img src='../images/Exclamation.gif' title='Please provide the Email Address! '"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="reg_Email1" runat="server" Display="None" ControlToValidate="txt_Email"
                                                            ErrorMessage="Please Enter Valid Email Format!" Text="&lt;img src='../images/Exclamation.gif' title='Please provide the Email Address! '"
                                                            ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_MobileNo" runat="server" Text="Mobile No:"></asp:Label><span style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_MobileNo" runat="server" TabIndex="34" MaxLength="10"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="req_MobileNo" runat="server" ControlToValidate="txt_MobileNo"
                                                            ErrorMessage="Please provide the Mobile No. in Deductee Address tab!" Text="&lt;img src='../images/Exclamation.gif' title='Please provide the Mobile No!'"></asp:RequiredFieldValidator>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterMode="ValidChars"
                                                            FilterType="Numbers" TargetControlID="txt_MobileNo">
                                                        </asp:FilteredTextBoxExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row ">
                                                <div class="large-12 columns">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_PINCode0" runat="server" Text="PIN Code:"></asp:Label><span style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_PINCode1" runat="server" TabIndex="35" MaxLength="6"></asp:TextBox>
                                                        &nbsp;<asp:RequiredFieldValidator ID="req_BsrCode14" runat="server" Display="None"
                                                            ControlToValidate="txt_PINCode1" ErrorMessage="Please provide PINCode in Deductee Address tab!"
                                                            Text="&lt;img src='../images/Exclamation.gif' title='Please provide PINCode!'"></asp:RequiredFieldValidator>
                                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterMode="ValidChars"
                                                            FilterType="Numbers" TargetControlID="txt_PINCode1">
                                                        </asp:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="large-3 columns">
                                                    </div>
                                                    <div class="large-3 columns">
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<div class="row">
                                            <div class="large-12 columns">
                                            
                                                <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Telephone01" runat="server" Text="Telephone:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="TextBox1" runat="server" TabIndex="33" MaxLength="10"></asp:TextBox>
                                                    </div>
                                                <div class="large-3 columns">
                                                </div>
                                                <div class="large-3 columns">
                                                </div>
                                                </div>
                                            </div>--%>
                                        </asp:View>
                                    </asp:MultiView>
                                </div>
                                <div id="sectionc" class="tab-pane fade">
                                    <div class="row">
                                        <div class="large-12 columns mar_bottom">
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_MinistryName" runat="server" Text="Ministry Name:"></asp:Label><span
                                                    style="color: Red">*</span>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="drp_MinistryName" runat="server" TabIndex="8">
                                                </asp:DropDownList>
                                                &nbsp;<asp:RequiredFieldValidator runat="server" ControlToValidate="drp_MinistryName"
                                                    ErrorMessage="Please Select Ministry Name!" Text="&lt;img src='../images/Exclamation.gif' title='Please Select Ministry Name!'"
                                                    Display="Dynamic" ID="req_MinistryName"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_PAOCode" runat="server" Text="PAO Code:"></asp:Label>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="txt_PAOCode" runat="server" MaxLength="20" CssClass="UpperCaseLetter"
                                                    TabIndex="9"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns ">
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_DDOCode" runat="server" Text="DDO Code:"></asp:Label>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="txt_DDOCode" runat="server" TabIndex="10" MaxLength="20" CssClass="UpperCaseLetter"></asp:TextBox>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_StateName" runat="server" Text="State Name:" Height="25"></asp:Label>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:DropDownList ID="drp_StateName" runat="server" TabIndex="11">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="large-12 columns">
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_PAORegistrationNo" runat="server" Text="PAO Registration No:"></asp:Label>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="txt_PAORegistrationNo" runat="server" TabIndex="12" MaxLength="7"
                                                    CssClass="UpperCaseLetter"></asp:TextBox>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_DDORegistartionNo" runat="server" Text="DDO Registration No:"></asp:Label>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="txt_DDORegistrationNo" runat="server" TabIndex="13" MaxLength="10"
                                                    CssClass="UpperCaseLetter"></asp:TextBox>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:Label ID="lbl_AINNumber" runat="server" Text="AIN Number:" Style="display: none"></asp:Label>
                                            </div>
                                            <div class="large-3 columns">
                                                <asp:TextBox ID="txt_AINNumber" runat="server" MaxLength="7" Style="display: none"
                                                    TabIndex="24"></asp:TextBox>
                                            </div>
                                            <div class="large-3 columns">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" style="display: none">
                                        <div class="large-6 columns">
                                        </div>
                                        <div class="large-6 columns">
                                        </div>
                                    </div>
                                    <br />
                                </div>
                                <%--<div class="col-md-6 col-lg-6">
<asp:Label ID="lbl_PersonResponsible" runat="server" 
                        Text="Person Responsible:" 
                        ></asp:Label>
</div>
<div class="col-md-6 col-lg-6">
<asp:TextBox ID="txt_PersonResponsible" runat="server" 
                        AutoPostBack="true" CssClass="UpperCaseLetter" TabIndex="19" MaxLength="75" ></asp:TextBox>
                 &nbsp;
                    <asp:RequiredFieldValidator runat="server" 
                        ControlToValidate="txt_PersonResponsible" 
                        ErrorMessage="Please provide the Person Responsible!" 
                        Text="&lt;img src='../images/Exclamation.gif' title='Please provide the Person Responsible!'" 
                        ID="req_BsrCode5"></asp:RequiredFieldValidator>
</div>
</div>



<div class="row">
<div class="col-md-6 col-lg-6">
 <asp:Label ID="lbl_Designation" runat="server" 
                        Text="Designation:" 
                       ></asp:Label>
</div>
<div class="col-md-6 col-lg-6">
 <asp:DropDownList ID="drp_Designation" runat="server"  TabIndex="20" style="height:auto" Required>
                                </asp:DropDownList>
                                <asp:TextBox ID="txt_Designation" runat="server" Visible="false"  ></asp:TextBox>
                              
                    <asp:Button ID="btn_AddDesignation" runat="server" Text="Add Designation" 
                                    CausesValidation="False" 
                                    onclick="btn_AddDesignation_Click" TabIndex="21" class="button" />
                                    
                                 <asp:RequiredFieldValidator runat="server" 
                                    ControlToValidate="drp_Designation" 
                                    ErrorMessage="Please Select the Designation!" 
                                    Text="&lt;img src='../images/Exclamation.gif' title='Please Select the Designation!'" 
                                    ID="req_BsrCode6"></asp:RequiredFieldValidator>

                              
                                <asp:Button ID="btn_CancelDesig" runat="server" Text="Cancel" 
                                     CausesValidation="False" onclick="btn_CancelDesig_Click" class="button" 
                                    />
</div>
</div>

<br />

<div class="row">
<div class="col-md-6 col-lg-6">
 <asp:Label ID="lbl_StateName" runat="server" 
                        Text="State Name:" Font-Size="Small" 
                        Height="25"></asp:Label>
</div>
<div class="col-md-6 col-lg-6">
 <asp:DropDownList ID="drp_StateName" runat="server"  TabIndex="22" style="height:auto">
                                </asp:DropDownList>
</div>
</div>


<br />
<div class="row">
<div class="col-md-6 col-lg-6">
<asp:Label ID="lbl_PAORegistrationNo" runat="server" 
                        Text="PAO Registration No:"  
                        ></asp:Label>
</div>
<div class="col-md-6 col-lg-6"> <asp:TextBox ID="txt_PAORegistrationNo" runat="server" 
                        TabIndex="23" MaxLength="7"></asp:TextBox>
</div>
</div>
<br />


<div class="row">
<div class="large-6 columns">
 <asp:Label ID="lbl_DDORegistartionNo" runat="server" 
                        Text="DDO Registration No:"  
                        ></asp:Label>
</div>
<div class="large-6 columns">
  <asp:TextBox ID="txt_DDORegistrationNo" runat="server" 
                        TabIndex="24" MaxLength="10"></asp:TextBox>
</div>
</div>


<div class="row">
<div class="large-6 columns">
<asp:Label ID="lbl_AINNumber" runat="server" 
                        Text="AIN Number:" 
                        style="display:none"></asp:Label>
</div>
<div class="large-6 columns">
<asp:TextBox ID="txt_AINNumber" runat="server" MaxLength="7" style="display:none" 
                        TabIndex="24" ></asp:TextBox>
</div>
</div>--%>
                                <div id="sectiond" class="tab-pane fade ">
                                    <asp:MultiView ID="Multiview2" runat="server">
                                        <div style="display: none">
                                            <asp:View ID="vw_tab4" runat="server">
                                                <div class="row">
                                                    <div class="large-6 columns">
                                                        <asp:Label ID="lbl_FatherName" runat="server" Text="Father Name(Responsible Person):"></asp:Label>
                                                    </div>
                                                    <div class="large-6 columns">
                                                        <asp:TextBox ID="txt_FatherName" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="large-6 columns">
                                                        <asp:Label ID="lbl_FlatNo" runat="server" Text="Flat No"></asp:Label>
                                                    </div>
                                                    <div class="large-6 columns">
                                                        <asp:TextBox ID="txt_FlatNo" runat="server" MaxLength="8"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="large-6 columns">
                                                        <asp:Label ID="lbl_HouseorPremisesNo" runat="server" Text="House/Premises No"></asp:Label>
                                                    </div>
                                                    <div class="large-6 columns">
                                                        <asp:TextBox ID="txt_HouseorPremisesNo" runat="server" MaxLength="8"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="large-6 columns">
                                                        <asp:Label ID="lbl_FloorNo" runat="server" Text="Floor No"></asp:Label>
                                                    </div>
                                                    <div class="large-6 columns">
                                                        <asp:TextBox ID="txt_FloorNo" runat="server" W MaxLength="3"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="large-6 columns">
                                                        <asp:Label ID="lbl_BuildingName" runat="server" Text="Building Name"></asp:Label>
                                                    </div>
                                                    <div class="large-6 columns">
                                                        <asp:TextBox ID="txt_BuildingName" runat="server" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="large-6 columns">
                                                        <asp:Label ID="lbl_BlockSector" runat="server" Text="Block/Sector"></asp:Label>
                                                    </div>
                                                    <div class="large-6 columns">
                                                        <asp:TextBox ID="txt_BlockorSector" runat="server" MaxLength="4"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="large-6 columns">
                                                        <asp:Label ID="lbl_RoadStreet" runat="server" Text="Road/Street"></asp:Label>
                                                    </div>
                                                    <div class="large-6 columns">
                                                        <asp:TextBox ID="txt_RoadorStreet" runat="server" MaxLength="60"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </asp:View>
                                        </div>
                                        <asp:View ID="vw_tab3" runat="server">
                                            <div class="row">
                                                <div class="large-12 columns mar_bottom">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_BranchorDivision" runat="server" Text="Branch/Division:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_BranchorDivision" runat="server" TabIndex="14" MaxLength="75"></asp:TextBox>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address1" runat="server" Text="Flat/Door/Building"></asp:Label><span
                                                            style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address1" runat="server" TabIndex="15" MaxLength="25" CssClass="UpperCaseLetter"></asp:TextBox>
                                                        &nbsp;<asp:RequiredFieldValidator ID="req_BsrCode7" runat="server" Display="Dynamic"
                                                            ControlToValidate="txt_Address1" ErrorMessage="Please Specify the Address in Responsible Person Address tab!"
                                                            Text="&lt;img src='../images/Exclamation.gif' title='Please Specify the Address!'"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="large-12 columns">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address2" runat="server" Text="Road/Street:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address2" runat="server" TabIndex="16" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address3" runat="server" Text="Area/Locality:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address3" runat="server" TabIndex="17" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="large-12 columns ">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address4" runat="server" Text="Town/City/District:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address4" runat="server" TabIndex="18" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Address5" runat="server" Text="Address:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Address5" runat="server" TabIndex="19" MaxLength="25"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="large-12 columns mar_bottom">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_State" runat="server" Text="State:"></asp:Label><span style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:DropDownList ID="drp_State" runat="server" TabIndex="20">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="req_BsrCode9" runat="server" Display="None" ControlToValidate="drp_State"
                                                            ErrorMessage="Please Select State in Responsible Person Address tab!" Text="&lt;img src='../images/Exclamation.gif' title='Please Select State!'"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_PINCode" runat="server" Height="25px" Text="PIN Code:"></asp:Label><span
                                                            style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_PINCode" runat="server" TabIndex="21" MaxLength="6"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="req_BsrCode10" runat="server" Display="None" ControlToValidate="txt_PINCode"
                                                            ErrorMessage="Please provide PINCode in Responsible Person Address tab!" Text="&lt;img src='../images/Exclamation.gif' title='Please provide PINCode!'"></asp:RequiredFieldValidator>
                                                        <asp:FilteredTextBoxExtender ID="FTM1" runat="server" FilterMode="ValidChars" FilterType="Numbers"
                                                            TargetControlID="txt_PINCode">
                                                        </asp:FilteredTextBoxExtender>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="large-12 columns mar_bottom">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_STDCode" runat="server" Text="STD Code:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_STDCode" runat="server" TabIndex="22" MaxLength="5" onchange="javascript:return SetMaxLenght();"></asp:TextBox>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Telephone0" runat="server" Text="Telephone:"></asp:Label>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Telephone1" runat="server" TabIndex="23" MaxLength="10"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="large-12 columns">
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Mobile" runat="server" Text="Mobile:"></asp:Label><span style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Telephone" runat="server" TabIndex="24" MaxLength="10"></asp:TextBox>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:Label ID="lbl_Email1" runat="server" Text="E-mail ID:"></asp:Label><span style="color: Red">*</span>
                                                    </div>
                                                    <div class="large-3 columns">
                                                        <asp:TextBox ID="txt_Email1" runat="server" TabIndex="25" MaxLength="75" Style="text-transform: lowercase"></asp:TextBox>
                                                        &nbsp;<asp:RequiredFieldValidator ID="req_BsrCode12" runat="server" Display="None"
                                                            ControlToValidate="txt_Email1" ErrorMessage="Please provide Email Address in Responsible Person Address tab!"
                                                            Text="&lt;img src='../images/Exclamation.gif' title='Please provide Email Address!'"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="reg_Email2" runat="server" Display="None" ControlToValidate="txt_Email1"
                                                            ErrorMessage="Please Enter Valid Email Format!" Text="&lt;img src='../images/Exclamation.gif' title='Please provide the Email Address! '"
                                                            ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:View>
                                    </asp:MultiView>
                                </div>
                            </div>
                            <asp:ValidationSummary ID="Vld_Form26" runat="server" ShowMessageBox="True" BorderColor="Black"
                                BorderStyle="Solid" HeaderText="Please Correct the Following:" ShowSummary="false">
                            </asp:ValidationSummary>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:UpdatePanel ID="upd_TANSave" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="row">
                            <div class="large-12 columns text-right">
                                <asp:Button ID="btn_New" runat="server" Text="New" Font-Bold="False" CausesValidation="false"
                                    OnClick="btn_New_Click" class="button radius" />
                                <asp:Button ID="btn_Save" runat="server" Text="Save" TabIndex="36" OnClick="btn_Save_Click"
                                    class="button radius" />
                                <asp:Button ID="btn_Delete" runat="server" Text="Delete" CausesValidation="false"
                                    OnClick="btn_Delete_Click" class="button radius" /><cc1:MessageBox ID="msg_Delete"
                                        runat="server" OnGetMessageBoxResponse="msg_Delete_GetMessageBoxResponse" />
                                <asp:Button ID="btn_Exit" runat="server" Text="Exit" class="button radius" CausesValidation="False"
                                    OnClick="btn_Exit_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btn_New" />
                        <asp:PostBackTrigger ControlID="btn_Save" />
                        <asp:PostBackTrigger ControlID="btn_Delete" />
                        <asp:PostBackTrigger ControlID="btn_Exit" />
                    </Triggers>
                </asp:UpdatePanel>
                <script type="text/javascript">
                    function AutoCompleteDataFill() {
                        document.getElementById("<%=btn_Exit.ClientID%>").Click;
                    }
                </script>
            </div>
    </div> </div> <div class="row"> <div class="large-12 columns"> <hr /> <p> © 2015
    Vatas Infotech Pvt.Ltd.</p> </div> </div>
   <asp:HiddenField ID="hdnScreen" runat="server" Value="NR" />
    </form>
</body>
</html>
