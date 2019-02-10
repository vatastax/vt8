//Auto Trigger while User Idle Function to prompt for Logout

var timeoutID;
function setup() {
   
    this.addEventListener("mousemove", resetTimer, false);
    this.addEventListener("mousedown", resetTimer, false);
    this.addEventListener("keypress", resetTimer, false);
    this.addEventListener("DOMMouseScroll", resetTimer, false);
    this.addEventListener("mousewheel", resetTimer, false);
    this.addEventListener("touchmove", resetTimer, false);
    this.addEventListener("MSPointerMove", resetTimer, false);
    startTimer();
}
setup();
function startTimer() {
    // wait 2 seconds before calling goInactive
    timeoutID = window.setTimeout(goInactive, 500000);
}
function resetTimer(e) {
    window.clearTimeout(timeoutID);
//    TimerStopBit = 0;
//    TimerValMain = 1;
//    TimerValDetail = 60;
    goActive();
}
function goInactive() {
    //openDialog2();
    $(document).ready(function () {
        if ($("div").hasClass('ui-widget-overlay')) {

        }
        else {
            document.getElementById('aLogout').click();
            document.getElementById('stimer').innerHTML = '02:00';
                TimerStopBit = 0;
                TimerValMain = 1;
                TimerValDetail = 60;
            showTimer();
        }
    });
    
    //alert('You are going to logout');
    // do something
}
function goActive() {
    // do something
    startTimer();
}

var TimerValMain = 1;
var TimerValDetail = 60;
var TimerStopBit = 0;
function showTimer() {
//    alert(TimerStopBit);
//    alert(TimerValMain);
//    alert(TimerStopBit);
    if (TimerStopBit == 0) {
        if (TimerValDetail > 1) {
            TimerValDetail = TimerValDetail - 1;
            document.getElementById('stimer').innerHTML = '0' + TimerValMain + ':' + ((TimerValDetail.toString().length > 1) ? TimerValDetail.toString() : '0' + TimerValDetail.toString());
            setTimeout(showTimer, 1000);
        }
        else {
            if (TimerValMain == 1) {
                TimerValMain = 0;
                TimerValDetail = 60;
                setTimeout(showTimer, 1000);
            }
            else {
                //alert('Time Out');
                window.location = 'Logout.aspx';
            }
        }
    }
}

//////////////////////////////////////////////////////////////////////////
function validateDate(id, dtValStart) {
    try {
        var arrDate = id.value.split('/');
        //var dateEntered = new Date(id.value);
        var dateEntered = new Date(arrDate[1] + '/' + arrDate[0] + '/' + arrDate[2]);
        arrDate = dtValStart.toString().split('/');
        var dtValStart_dt = new Date(arrDate[1] + '/' + arrDate[0] + '/' + arrDate[2]);
        var dtValEnd_dt = new Date();
        if (dateEntered < dtValStart_dt || dateEntered > dtValEnd_dt) {
            alert('Invalid Date');
            id.value = '';
            id.focus();
            return false;
        }
        else
            return true;
    }
    catch (e) { alert(e); }
}

//Following function is to disable the below textboxes as per Dropdown Value
//function disableBelowTxt_Val(id,Val) {
//    try {
//        var arr = new Array();
//        arr = id.id.split('_');
//        spinnerElement = arr[0] + '_' + arr[1] + '_imgSpinner';
//        var middleIndx = arr[1].toString().substring(3, 5);
//        if (parseInt(middleIndx) < 10)
//            middleIndx = '0' + (parseInt(middleIndx) + 1).toString();
//        else
//            middleIndx = (parseInt(middleIndx) + 1).toString();
//        var middleName = arr[1].toString().substring(0, 3);
//        middleName = middleName.toString() + middleIndx.toString();
//        document.getElementById(arr[0] + '_' + middleName + '_txtAmount').disabled = true;

//        var arrHdns = document.getElementById("hdnControlHide").value.split('~');
//        document.getElementById("hdnControlHide").value = document.getElementById("hdnControlHide").value

//        if (id.options[id.selectedIndex].text == 'No')
//            document.getElementById("hdnControlHide").value = document.getElementById("hdnControlHide").value + '~' + arr[0] + '_' + middleName + '_txtAmount';
//        else {
//            
//            document.getElementById("hdnControlHide").value = document.getElementById("hdnControlHide").value + arr[0] + '_' + middleName + '_txtAmount';
//        }
//    }
//    catch (e) { alert(e); }
//}

function redirectHere(pageName) {
    window.location = pageName; 
}

//Show Price Guide
function showPricingGuide() {
    try {
        $("#popup_Pricing").dialog({
            title: "Price Guide",
            width: 'auto',
            height: 'auto',
            minHeight: '0',
            modal: true,
            buttons: { Yes: function () {
                window.location = "saveAssessee.aspx?wx=1"
            },
                No: function () {
                    window.location = "saveAssessee.aspx"
                },
                Cancel: function () {
                    $(this).dialog('close');
                }
            }
        });
    }
    catch (e) { alert(e); }     
}

//Redirect to Main Page
function redirectToMain() {
    $("#popupdiv").dialog({
        title: "Error Message",
        width: 'auto',
        height: 'auto',
        minHeight: '0',
        modal: true,
        buttons: { Yes: function () {
            window.location = "saveAssessee.aspx?wx=1"
        },
            No: function () {
                window.location = "saveAssessee.aspx"
            },
            Cancel: function () {
                $(this).dialog('close');
            }
        }
    });
}

//function to trigger Save/Update conditionally from Continue Button Click:

function SubmitData() {
    moveValNext1();
    try {
        document.getElementById('btnSaveMasterData').click();
    }
    catch (e) { alert(e); }
}

//For transfer of data from one column to another within float Grid:

function CopyColVal(cols, id) {
    try {
        //alert(document.getElementById('GridViewFlaoting_ctl02_txtC13').value);
        var arrCtrlTitle = new Array();
        var mainID = 0;
        //alert(cols);
        arrCtrlTitle = id.id.toString().split('_');
        mainID = arrCtrlTitle[1].substring(arrCtrlTitle[1].length - 1);
        var arrCols = new Array();
        var tot = 0;
        arrCols = cols.toString().split(',');
        var element_name;
        //alert(arrCols.length);
        //alert(document.getElementById('GridViewFlaoting_ctl0' + mainID + '_txtC' + arrCols[0].toString().replace('=', '').replace('-', '').replace('*', '')).value);
        //    alert(arrCols[2]);
        var ValToUse = 0;
        for (var i = 0; i < arrCols.length; i++) {
            element_name = 'GridViewFlaoting_ctl0' + mainID + '_txtC' + arrCols[i].toString().replace('=', '').replace('-', '').replace('*', '');
            //alert(element_name);
            //var cc = new String();
            //            alert(document.getElementById(element_name).value);
            //            alert(arrCols[i]);
            if (document.getElementById(element_name) != null) {
                if (document.getElementById(element_name).value == '')
                    ValToUse = 0;
                else
                    ValToUse = parseInt(document.getElementById(element_name).value);
                //alert('valtouse ' + ValToUse);
                if (arrCols[i].charAt(0) != '=') {
                    if (arrCols[i].charAt(0) == '-')
                        tot = tot - parseInt(ValToUse);
                    else if (arrCols[i].charAt(0) == '*')
                        tot = tot * parseInt(ValToUse);
                    else// if (arrCols[i].charAt(0) == '+')
                        tot = tot + parseInt(ValToUse);
                    //alert(tot.toString());

                }
                else if (arrCols[i].charAt(0) == '=')
                    document.getElementById(element_name).value = tot.toString();
            }
        }
    } catch (e) { alert(e); }
}


//For Float Grid Submit Button Validation:
var IsFormValidate = 'true';
function moveVal_Float2() {
    var IsTxtValidate = 'true';
    try {
        if (document.getElementById('hdnValidations_Detail').value != '') {
            var tmpMsg = '';
            var varMsg = '';
            var IsValidate = 'true';
            var arrMain = new Array();
            var arrDetail = new Array();
            var arrMains = new Array();
            var vv = new String();

            arrMain = document.getElementById('hdnValidations_Detail').value.split('~');
            var arrMain2 = new Array();

            var cntReq = 0;

            var IsNull = 0;
            var cnter = 2;

            for (var i = 0; i < arrMain.length; i++) {
                arrDetail = arrMain[i].split('_');
                for (var j = 0; j < arrDetail.length; j++) {
                    if (arrDetail[j].indexOf('required') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;

                                if (vv.indexOf('_txtC') != -1) {
                                    if (document.getElementById(vv).value == '') {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Required';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                        document.getElementById(vv).className = 'err_cls';
                                    }
                                }
                                else {
                                    if (document.getElementById(vv).value == '-1' && IsTxtValidate == 'false') {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Required';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    if (arrDetail[j].indexOf('maxSize[') != -1) {
                        var arrDet = arrDetail[j].split('maxSize[');
                        var arrDet1 = arrDet[1].split(']');

                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();

                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;
                                    if (document.getElementById(vv).value.length > parseInt(arrDet1[0])) {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    if (arrDetail[j].indexOf('minSize[') != -1) {
                        var arrDet = arrDetail[j].split('minSize[');
                        var arrDet1 = arrDet[1].split(']');

                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();

                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;
                                    if (document.getElementById(vv).value.length < parseInt(arrDet1[0])) {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    if (arrDetail[j].indexOf('custom[integer]') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;
                                    if (document.getElementById(vv).value.toString().indexOf('a') != -1 || document.getElementById(vv).value.toString().indexOf('b') != -1) {
                                        //alert('invalid because of alphabets');
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }
                    //for Patterns pan[ ]
                    var regexp1 = new RegExp("/[A-Z]{3}[CPHFATBLJG][a-z]\d{4}[A-Z]/i");
                    if (arrDetail[j].indexOf('pan[') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    if (/[a-z]{3}[cphfatbljg][a-z]\d{4}[a-z]/i.test(document.getElementById(vv).value) == false && document.getElementById(vv).value != 'PANNOTAVBL') {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    //for Patterns tan[ ]
                    var regexp1 = new RegExp("/[A-Z]{4}\d{5}[A-Z]/i");
                    if (arrDetail[j].indexOf('tan[') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    if (/[A-Z]{4}\d{5}[A-Z]/i.test(document.getElementById(vv).value) == false) {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    //For Date Format:
                    var regexp1 = new RegExp("/(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}/i");
                    if (arrDetail[j].indexOf('DateFormat[]') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    if (/(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}/i.test(document.getElementById(vv).value) == false) {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                    }
                                    else {
                                        var arrDate = document.getElementById(vv).value.toString().split('/');
                                        if ((parseInt(arrDate[2]) < 1900)) {
                                            IsValidate = 'false';
                                            document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                        }
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }
                }
            }

            if (IsValidate == 'true')
                document.getElementById('hdnValidate').value = 'false';
            else {
                document.getElementById('hdnValidate').value = 'true';
            }

            if (IsValidate == 'false') {
                IsFormValidate_Float = 'false';
                return false;
            } else {
                setTimeout(hideErrPopups, 100);
                IsFormValidate_Float = 'true';
                return true;
            }
        }
        else {
            IsFormValidate_Float = 'true';
            document.getElementById('hdnValidate').value = 'false';
            setTimeout(hideErrPopups, 100);

            return true;
        }
    }
    catch (e) {
        alert(e);
    }
}

function moveVal_Float() {
    var IsTxtValidate = 'true';
    $(document).ready(function () {
        //$("#<%=GridViewFlaoting.ClientID %>").find("input[type=text][id*=txtAmount]").each(function () {
        //alert('doc-ready');
        $("input[type=text]").each(function () {
            if ($(this).val() == '0') {
                IsTxtValidate = 'false';
            }
        });
        //        $("#<%=GridViewFlaoting.ClientID %>").find("input[type=text][id*=txtC3]").each(function () {
        //            alert('asd');
        //            alert($(this).val());
        //        })
    });
    

    try {
        if (document.getElementById('hdnValidations_Detail').value != '') {
            var tmpMsg = '';
            var varMsg = '';
            var IsValidate = 'true';
            var arrMain = new Array();
            var arrDetail = new Array();
            var arrMains = new Array();
            var vv = new String();

            arrMain = document.getElementById('hdnValidations_Detail').value.split('~');
            var arrMain2 = new Array();

            var cntReq = 0;

            var IsNull = 0;
            var cnter = 2;

            for (var i = 0; i < arrMain.length; i++) {
                arrDetail = arrMain[i].split('_');
                for (var j = 0; j < arrDetail.length; j++) {
                    if (arrDetail[j].indexOf('required') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;

                                if (vv.indexOf('_txtC') != -1) {
                                    if (document.getElementById(vv).value == '') {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Required';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                        document.getElementById(vv).className = 'err_cls';
                                    }
                                }
                                else {
                                    if (document.getElementById(vv).value == '-1' && IsTxtValidate == 'true') {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Required';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    if (arrDetail[j].indexOf('maxSize[') != -1) {
                        var arrDet = arrDetail[j].split('maxSize[');
                        var arrDet1 = arrDet[1].split(']');

                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();

                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;
                                    if (document.getElementById(vv).value.length > parseInt(arrDet1[0])) {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    if (arrDetail[j].indexOf('minSize[') != -1) {
                        var arrDet = arrDetail[j].split('minSize[');
                        var arrDet1 = arrDet[1].split(']');

                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();

                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;
                                    if (document.getElementById(vv).value.length < parseInt(arrDet1[0])) {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    if (arrDetail[j].indexOf('custom[integer]') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;
                                    if (document.getElementById(vv).value.toString().indexOf('a') != -1 || document.getElementById(vv).value.toString().indexOf('b') != -1) {
                                        //alert('invalid because of alphabets');
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }
                    //for Patterns pan[ ]
                    var regexp1 = new RegExp("/[A-Z]{3}[CPHFATBLJG][a-z]\d{4}[A-Z]/i");
                    if (arrDetail[j].indexOf('pan[') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    if (/[a-z]{3}[cphfatbljg][a-z]\d{4}[a-z]/i.test(document.getElementById(vv).value) == false && document.getElementById(vv).value != 'PANNOTAVBL') {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    //for Patterns tan[ ]
                    var regexp1 = new RegExp("/[A-Z]{4}\d{5}[A-Z]/i");
                    if (arrDetail[j].indexOf('tan[') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    if (/[A-Z]{4}\d{5}[A-Z]/i.test(document.getElementById(vv).value) == false) {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }

                    //For Date Format:
                    var regexp1 = new RegExp("/(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}/i");
                    if (arrDetail[j].indexOf('DateFormat[]') != -1) {
                        IsNull = 0;
                        cnter = 2;

                        while (IsNull == 0) {
                            var vv = 'GridViewFlaoting_ctl0' + cnter + '_txtC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) == null)
                                vv = 'GridViewFlaoting_ctl0' + cnter + '_ddC' + (parseInt(arrDetail[0]) + 1).toString();
                            if (document.getElementById(vv) != null) {
                                if (document.getElementById(vv).value != '0') {
                                    if (/(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}/i.test(document.getElementById(vv).value) == false) {
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                    }
                                    else {
                                        var arrDate = document.getElementById(vv).value.toString().split('/');
                                        if ((parseInt(arrDate[2]) < 1900)) {
                                            IsValidate = 'false';
                                            document.getElementById(vv).style.borderColor = 'Red'; document.getElementById(vv).placeholder = 'Invalid Value';
                                        }
                                    }
                                }
                            }
                            else {
                                IsNull = 1;
                            }
                            cnter = cnter + 1;
                        }
                    }
                }
            }

            if (IsValidate == 'true')
                document.getElementById('hdnValidate').value = 'false';
            else {
                document.getElementById('hdnValidate').value = 'true';
            }

            if (IsValidate == 'false') {
                IsFormValidate_Float = 'false';
                return false;
            } else {
                setTimeout(hideErrPopups, 100);
                IsFormValidate_Float = 'true';
                return true;
            }
        }
        else {
            IsFormValidate_Float = 'true';
            document.getElementById('hdnValidate').value = 'false';
            setTimeout(hideErrPopups, 100);

            return true;
        }
    }
    catch (e) {
        alert(e);
    }
}

function hideErrPopups() {
    var promptClass = document.getElementsByClassName("formError");
    for (var i = 0; i < promptClass.length; i++) {
        promptClass[i].className = '';
    }
}

var validator = 0;
function getDOD(id) {
    data = document.getElementById('hdnAY').value.toString().split('-');
    vv = '04/01/' + (parseInt(data[0] - 1));
    var minDate = new Date(vv);
    var maxDate = new Date();
    var arrDate = id.value.split('/');
    var userDate = new Date(arrDate[1] + '/' + arrDate[0] + '/' + arrDate[2]);

    //to check if its a valid date with valid date format:
    try {
        if (Object.prototype.toString.call(userDate) === "[object Date]") {
            //alert('it is a date');
            if (isNaN(userDate.getTime())) {  // d.valueOf() could also work
                id.style.borderColor = 'Red';
                //alert('NAN');
               var ctrl=$(id).attr('id');
                document.getElementById(ctrl).focus();
                document.getElementById(ctrl).placeholder = 'Invalid Value';
               // alert(id);
                id.value = '';
               
                alert('Invalid Date in DOD');
            }
        }
        else {
            id.style.borderColor = 'Red';

            //
           var ctrl = $(id).attr('id');
            document.getElementById(ctrl).focus();
            document.getElementById(ctrl).placeholder = 'Invalid Value';
            id.value = '';
            //alert(id);
           
            alert('Invalid Date in DOD');
        }
    }
    catch (e) {
        alert(e);
    }
    //alert('userDate ' + userDate);
    if (userDate < minDate || userDate > maxDate) {
        //alert('userDate < minDate < maxDate');
        //alert(userDate + ' : ' + minDate + ' : ' + maxDate);
        
        id.style.borderColor = 'Red';

        //alert('Invalid Date in DOD');
        
        id.value = '';
        document.getElementById(id.id).focus();
        document.getElementById(id.id).placeholder = 'Invalid Value';
    }
}

function setValidator(id, vals) {
    var arrData = new Array();
    arrData = vals.toString().split('~');
    for (var i = 0; i < arrData.length; i++) {
        var arrData2 = arrData[i].split('_');
        if (arrData2[0] == id.value) {
            validator = arrData2[1];
        }
    }
}

function getValidator(id) {
    if (parseInt(id.value) < parseInt(validator)) {
        alert('Value cannot be lesser than ' + validator);
        id.value = '';
        id.focus();
    }
}

function setVTypeStatus(val) {

    try {
        Get_Menu_Counter();
        document.getElementById('hdnVTypeStatus').value = val;
        moveValNext1();
//        if (IsFormValidate == 'false')
//            alert_custom('Please Fill the compulsory fields', 2, 'Error Message', '', '', '', ['OK', 'Cancel']);
        //alert('isformvalidate -' + IsFormValidate);
        if (IsFormValidate != 'false') //{
            document.getElementById('btnPageMove').click();
        //}
        //alert('asd');
    }
    catch (e) { alert(e); }
}

function MinDateforAY(id) {
    var inputDate = new Date(id.value);
    var DData = new Array();
    DData = document.getElementById('hdnAY').value.split('-');
    var Date_To_Compare = new Date('01/04/' + DData[0]);

    if (inputDate > Date_To_Compare) {
        alert('Date cannot be lesser than ' + '01/04/' + DData[0]);
        id.value = '';
        id.focus();
    }
}

//Max DOB cannot exceeds the last FY
function getMaxDOB(id) {
    try {
        var arrDate = id.value.split('/');

        var DOB = new Date(arrDate[1] + '/' + arrDate[0] + '/' + arrDate[2]);
        //alert(DOB);
        var DData = new Array();
        DData = document.getElementById('hdnAY').value.split('-');
        var Date_To_Compare = new Date('03/31/' + DData[0]);
        if (DOB > Date_To_Compare) {
            alert('DOB cannot be greater than ' + '31/03/' + DData[0]);
            id.value = '';
            id.focus();
        }
    }
    catch (e) { alert(e); }
//    try {
//        var DOB = new Date(id.value);
//        //alert(document.getElementById('hdnAY').value);
//        var DData = new Array();
//        DData = document.getElementById('hdnAY').value.split('-');
//        var Date_To_Compare = new Date('31/03/' + DData[0]);
//        //alert(DOB);
//        //alert(Date_To_Compare);
//        if (DOB > Date_To_Compare) {
//            alert('DOB cannot be greater than ' + '31/03/' + DData[0]);
//            id.value = '';
//            id.focus();
//        }
//    }
//    catch (e) { alert('error is : ' + e); }
}


function getCountry_Code(id) {  //This function will get the country code against the selected country on which change its calling. And will set that value to the next textbox to it within same row only.
    try {
        var vv = new String();
        var arr = new Array();
        arr = id.id.split('_');
        document.getElementById(id.id.substring(0, id.id.lastIndexOf('_')) + '_txtC' + (parseInt(id.id.toString().substring((id.id.length - 1), (id.id.length))) + 1)).value = id.value;
    }
    catch (e) { alert(e); }
}

var ctrlToDisable = '';
function disableBelowTxts(id, txts) {
    try {
        if (id.options[id.selectedIndex].text == 'No') {
            alert('hide all');
        }
        else {
            alert('nothing to hide');
        }
        var arr = new Array();
        arr = id.id.split('_');
        var middleName;
        var middleIndx = arr[1].toString().substring(3, 5);
        for (var i = 0; i < parseInt(txts); i++) {
            if (parseInt(middleIndx) < 9)
                middleIndx = '0' + (parseInt(middleIndx) + 1 + parseInt(i)).toString();
            else
                middleIndx = (parseInt(middleIndx) + 1 + parseInt(i)).toString();
            middleName = arr[1].toString().substring(0, 3);
            middleName = middleName.toString() + middleIndx.toString();

            if (document.getElementById(arr[0] + '_' + middleName + '_txtAmount') != null)
                ctrlToDisable += arr[0] + '_' + middleName + '_txtAmount' + ',';
            else if (document.getElementById(arr[0] + '_' + middleName + '_txtReadOnly') != null)
                ctrlToDisable += arr[0] + '_' + middleName + '_txtReadOnly' + ',';
            else if (document.getElementById(arr[0] + '_' + middleName + '_ddl1') != null)
                ctrlToDisable += arr[0] + '_' + middleName + '_ddl1' + ',';
        }
        if (ctrlToDisable.length > 1)
            ctrlToDisable = ctrlToDisable.toString().substring(0, (ctrlToDisable.toString().length - 1));

        //alert('middlename : ' + middleName);
        //document.getElementById(arr[0] + '_' + middleName + '_ddl1').disabled = true;

        //document.getElementById("hdnControlHide").value = arr[0] + '_' + middleName + '_txtAmount';
    }
    catch (e) { alert(e); }
}

var ctrlName = '';
var ctrlVal = '';

function setValToBelowTxt(id) {
    try {
        // alert(id.options[id.selectedIndex].text);
        //        alert(document.getElementById(id.id).options[id.selectedIndex].text);
        //        alert(id.value);
        var arr = new Array();
        arr = id.id.split('_');

        var middleIndx = arr[1].toString().substring(3, 5);
        if (parseInt(middleIndx) < 10)
            middleIndx = '0' + (parseInt(middleIndx) + 1).toString();
        else
            middleIndx = (parseInt(middleIndx) + 1).toString();
        var middleName = arr[1].toString().substring(0, 3);
        middleName = middleName.toString() + middleIndx.toString();
        if (id.options[id.selectedIndex].text == 'Select')
            document.getElementById(arr[0] + '_' + middleName + '_txtReadOnly').value = '';
        if (id.options[id.selectedIndex].text == '54B')
            document.getElementById(arr[0] + '_' + middleName + '_txtReadOnly').value = '2012-2013';
        else
            document.getElementById(arr[0] + '_' + middleName + '_txtReadOnly').value = '2011-2012';

        ctrlName = arr[0] + '_' + middleName + '_txtReadOnly';
        ctrlVal = document.getElementById(arr[0] + '_' + middleName + '_txtReadOnly').value;
    }
    catch (e) { alert(e); }
}

function getCountryCode(id) {
    try {
        alert(id.value);
    }
    catch (e) { alert(e); }
}

function iif(target, opt, condition) {
    try {
        var vv = '';

        var $txtCtrls = new Array();
        var $txts = $('input');
        var cnt = 1;
        for (var i = 0; i < $txts.length; i++) {
            if ($txts[i].type.toString() == 'text') {
                if ($txts[i].id.toString().substr(0, $txts[i].id.toString().indexOf('_')) == 'GridViewFlaoting') {
                    $txtCtrls.push($txts[i]);
                }
            }
        }
        var arrOpt = opt.toString().split(',');
        if (condition == 'smallest')
            document.getElementById($txtCtrls[target - 1].id).value = (parseInt(document.getElementById($txtCtrls[parseInt(arrOpt[0]) - 1].id).value) < parseInt(document.getElementById($txtCtrls[parseInt(arrOpt[1]) - 1].id).value)) ? document.getElementById($txtCtrls[parseInt(arrOpt[0]) - 1].id).value : document.getElementById($txtCtrls[parseInt(arrOpt[1]) - 1].id).value;
        else if (condition == 'largest')
            document.getElementById($txtCtrls[target - 1].id).value = (parseInt(document.getElementById($txtCtrls[parseInt(arrOpt[0]) - 1].id).value) > parseInt(document.getElementById($txtCtrls[parseInt(arrOpt[1]) - 1].id).value)) ? document.getElementById($txtCtrls[parseInt(arrOpt[0]) - 1].id).value : document.getElementById($txtCtrls[parseInt(arrOpt[1]) - 1].id).value;

        //alert(vv);
    }
    catch (e) { alert(e); }
}

//new try for above function to solve issue
function iif(target, opt, condition, ctrl_ID) {
    var ctrlID = ctrl_ID.id.toString().substr(0, ctrl_ID.id.toString().lastIndexOf('_'));
    ctrlID = ctrlID.substr(ctrlID.toString().length - 2);
    //alert(ctrlID);
    try {
        var vv = '';
        var $txtCtrls = new Array();
        var $txts = $('input');
        var cnt = 1;
        for (var i = 0; i < $txts.length; i++) {
            if ($txts[i].type.toString() == 'text') {
                if ($txts[i].id.toString().substr(0, $txts[i].id.toString().indexOf('_')) == 'GridViewFlaoting') {
                    //$txts[i].id = $txts[i].id.replace('02', ctrlID);
                    $txtCtrls.push($txts[i]);
                }
            }
        }
        //alert($txtCtrls[0].id);
        var arrOpt = opt.toString().split(',');
        //alert(document.getElementById($txtCtrls[target - 1].id).value);
        //alert(document.getElementById($txtCtrls[target - 1].id).id);
        if (condition == 'smallest')
            document.getElementById($txtCtrls[target - 1].id.replace('02', ctrlID)).value = (parseInt(document.getElementById($txtCtrls[parseInt(arrOpt[0]) - 1].id.replace('02', ctrlID)).value) < parseInt(document.getElementById($txtCtrls[parseInt(arrOpt[1]) - 1].id.replace('02', ctrlID)).value)) ? document.getElementById($txtCtrls[parseInt(arrOpt[0]) - 1].id.replace('02', ctrlID)).value : document.getElementById($txtCtrls[parseInt(arrOpt[1]) - 1].id.replace('02', ctrlID)).value;
        else if (condition == 'largest')
            document.getElementById($txtCtrls[target - 1].id.replace('02', ctrlID)).value = (parseInt(document.getElementById($txtCtrls[parseInt(arrOpt[0]) - 1].id.replace('02', ctrlID)).value) > parseInt(document.getElementById($txtCtrls[parseInt(arrOpt[1]) - 1].id.replace('02', ctrlID)).value)) ? document.getElementById($txtCtrls[parseInt(arrOpt[0]) - 1].id.replace('02', ctrlID)).value : document.getElementById($txtCtrls[parseInt(arrOpt[1]) - 1].id.replace('02', ctrlID)).value;
        //alert('$txtCtrls[target - 1].id : ' + $txtCtrls[target - 1].id);
        //        alert($txtCtrls[target - 1].id);
        //        alert(document.getElementById($txtCtrls[target - 1].id).id);
        //        alert(document.getElementById($txtCtrls[target - 1].id).value);
        //        document.getElementById($txtCtrls[target - 1].id).value = 'testing';
        //        document.getElementById('GridViewFlaoting_ctl03_txtC6').value = 'hello';
        //        $txtCtrls[target - 1].value = '1210';
        //        document.write('target: ' + $txtCtrls[target - 1].id.replace('02', ctrlID));
        //        document.write('<BR/>');
        //        for (var j = 0; j < $txtCtrls.length; j++) {
        //            document.write($txtCtrls[j].id);
        //            document.write('<BR/>');
        //        }
        //alert(vv);
    }
    catch (e) { alert(e); }
}

function callSvc3() {
    //alert(dateOfImprovement + '~' + amtImprovement)
    $.ajax({
        type: "POST",
        url: "../Service_Banks.asmx/CopyDateStoreFTrans",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //data: "{ 'BSR': 0003694'}",
        success: Success3, //function (data, status) { alert(data.d); },
        error: function (request, status, error) { alert(request.responseText); }
    });
    setTimeout(setEleVal, 1100);
}

//Global Variables
var g_STDCodeLength = 0;    //STD-Phone Data Length
var element_val2 = '';

//function to validate TDS Challan
function isValidTDSChalln(val) {
    try {
        number = val.value;
        if (number <= 0 || number == "00000" || number == "0000" || number == "000" || number == "00") {
            alert('Challan Number cannot be 0');
            val.value = '';
            val.focus();
        }
    }
    catch (e) { alert(e); }
}
//function to validate bsrcode
function isValidBSR(val) {
    try {
        bsr = val.value;
        if (bsr <= 0) {
            alert('BSR Code is Not Valid');
            val.value = '';
            val.focus();
        }
    }
    catch (e) { alert(e); }
}
//function to disable below textboxes on Dropdown change
function disableControls(id) {
    try {
        var vv = new String();
        vv = id.id;

        if (id.value == 'Z' || id.value == 'B' || id.value == 'T' || id.value == 'Y') {
            
            document.getElementById(vv.substring(0, (vv.length - 7)) + '10_txtAmount').disabled = true;
            document.getElementById(vv.substring(0, (vv.length - 7)) + '11_txtAmount').disabled = true;
            document.getElementById(vv.substring(0, (vv.length - 7)) + '12_txtAmount').disabled = true;
            document.getElementById(vv.substring(0, (vv.length - 7)) + '13_txtDate').disabled = true;

            document.getElementById(vv.substring(0, (vv.length - 7)) + '10_txtAmount').value = '';
            document.getElementById(vv.substring(0, (vv.length - 7)) + '11_txtAmount').value = '';
            document.getElementById(vv.substring(0, (vv.length - 7)) + '12_txtAmount').value = '';
            document.getElementById(vv.substring(0, (vv.length - 7)) + '13_txtDate').value = '';
        }
        else {
            document.getElementById(vv.substring(0, (vv.length - 7)) + '10_txtAmount').disabled = false;
            document.getElementById(vv.substring(0, (vv.length - 7)) + '11_txtAmount').disabled = false;
            document.getElementById(vv.substring(0, (vv.length - 7)) + '12_txtAmount').disabled = false;
            document.getElementById(vv.substring(0, (vv.length - 7)) + '13_txtDate').disabled = false;
        }
        if (id.value == 'T' || id.value == 'Y') {
            document.getElementById(vv.substring(0, (vv.length - 7)) + '07_txtAmount').disabled = true;
            document.getElementById(vv.substring(0, (vv.length - 7)) + '07_txtAmount').value = '';
        }
        else {
            document.getElementById(vv.substring(0, (vv.length - 7)) + '07_txtAmount').disabled = false;
        }

        //6, 9, 10, 11, 12
        //alert(vv);
        return false;
    } catch (e) { alert(e); }
}


//Funtion To validte date based on Quarter
function validateQuarter(val) {
    try {
        var isValid = "";
        qtr = document.getElementById('hdnQtr').value
        fy = document.getElementById('hdnAY').value
        fy = fy.substring(0, fy.length - 5);
        var date = new Date();
        var yy = date.getFullYear();
        idate = val.value;
        idate = idate.split("/");
        //alert(qtr);
        if (qtr == "Q1") {
            
            if (idate[1] >= 04 && idate[1] <= 06 || yy == fy) {
                isValid = 1;
            }
            else {
                isValid = 0;
            }
        }
        else if (qtr == "Q2") {
            if (idate[1] >= 07 && idate[1] <= 09 || yy == fy) {
                isValid = 1;
            }
            else {
                isValid = 0;
            }
        }
        else if (qtr == "Q3") {
            if (idate[1] >= 10 && idate[1] <= 12 || yy == fy) {
                isValid = 1;
            }
            else {
                isValid = 0;
            }
        }
        else if (qtr == "Q4") {
            if (idate[1] >= 01 && idate[1] <= 03 || yy == fy) {
                isValid = 1;
            }
            else {
                isValid = 0;
            }
        }
        if (isValid == 0) {
            alert('Date Does Not Fall Under Selected Quarter');
            val.value = '';
            val.focus();
        }
    }
    catch (e) { alert(e); }
}


//Function To check Date Should Not Be Greater Than Last Date Of the Month
function isLastDate(val) {

    try {
        idate = val.value;
        idate = idate.split("/");
        var today = new Date();
        var fd = new Date(today.getFullYear(), today.getMonth(), 1);
        var ld = new Date(today.getFullYear(), idate[1], 0);
        var dd = ld.getDate();
        var mm = idate[1]; //today.getMonth() + 1;
        var yy = today.getFullYear();
        if (idate[0] > dd) {
            alert('Date Can Not be greater than ' + dd);
            val.value = '';
            val.focus();
        }
        if (idate[1] > 12) {
            alert('Month Can Not be greater than 12');
            val.value = '';
            val.focus();
        }

        if (idate[2] > yy) {
            alert('Year Can Not be greater than ' + yy);
            val.value = '';
            val.focus();
        }
        if (idate[0] == 00) {
            alert('Date Can Not be 00');
            val.value = '';
            val.focus();
        }
        if (idate[1] == 00) {
            alert('Month Can Not be 00');
            val.value = '';
            val.focus();
        }
        if (idate[2] == "0000") {
            alert('Month Can Not be 00');
            val.value = '';
            val.focus();
        }
    }
    catch (e) { alert(e); }
}


//following funtion is use to set dropdown as required
function ConfirmOnSave(gridname) {
    try {
        var chkd = 1;
        var myarray = [];
        TargetBaseControl = gridname;  //document.getElementById('grdstate');
        //get target child control.
        var TargetChildControl = "ddl1";
        //get all the control of the type INPUT in the base control.
        var ddl = TargetBaseControl.getElementsByTagName("select");
        for (var i = 0; i < TargetBaseControl.rows.length; i++) {
            if (TargetBaseControl.rows[i].cells[7].innerHTML == "15") {
                if (ddl[i].options[ddl[i].selectedIndex].text == "Select") {
                    chkd = 0;
                    if (chkd == 1) {
                        return true;
                    }
                    else {
                        alert('Select Value ');
                        return false;
                    }
                }

            }

        }

    }
    catch (e) { alret(e); }
}

//Following Function Allow PANNOTAVBL,PANNOTREQD

function PanforTDS(field) {
    try {
        var regex = /^[\w]{3}(p|P|c|C|h|H|f|F|a|A|t|T|b|B|l|L|j|J|g|G)[\w][\d]{4}[\w]$/;
        if (!regex.test(field.value) && field.value != 'PANNOTAVBL' && field.value != 'PANNOTREQD') {
            alert('Please enter valid pan.');
            field.value = '';
            field.focus();
            //return "Please enter valid pan."
        }
    }
    catch (e) { alert(e); }
}

// Function to get indexed cost of improvement according to date of improvement and amount of improvement
function getImprovementCost(col, col1, col2, id, constID) {
    try {

        var arrCtrlTitle = new Array();
        var mainID = 0;

        arrCtrlTitle = id.id.toString().split('_');
        mainID = arrCtrlTitle[1].substring(arrCtrlTitle[1].length - 1);
        element_name3 = 'GridViewFlaoting_ctl0' + mainID + '_txtC' + col.toString().replace('=', '').replace('-', '').replace('*', '');
        element_name4 = 'GridViewFlaoting_ctl0' + mainID + '_txtC' + col1.toString().replace('=', '').replace('-', '').replace('*', '');
        element_name = 'GridViewFlaoting_ctl0' + mainID + '_txtC' + col2.toString().replace('=', '').replace('-', '').replace('*', '');

        if (document.getElementById(element_name3) != null) {
            if (document.getElementById(element_name3).value != '' && document.getElementById(element_name4).value != '') {
                callSvc2(document.getElementById(element_name3).value, document.getElementById(element_name4).value, constID);
            }
        }
    } catch (e) { alert(e); }
}

function callSvc2(dateOfImprovement, amtImprovement, constID) {

    //alert(dateOfImprovement + '~' + amtImprovement);
    var pdata = { "DateOfImprovement": dateOfImprovement + '~' + amtImprovement + '~' + document.getElementById('hdnNameID').value + '~' + document.getElementById('hdnAY').value + '~' + constID.toString() };
    $.ajax({
        type: "POST",
        url: "../Service_Banks.asmx/getIndexedCost",
        data: JSON.stringify(pdata),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Success3, //function (data, status) { alert(data.d); },
        error: function (request, status, error) { alert(request.responseText); }
    });
    setTimeout(setEleVal, 1100);
}

function Success3(data, status) {
    try {
        //alert(data.d);
        //document.getElementById(element_val2).value = data.d;
        element_val = parseFloat(data.d);
    }
    catch (e) { alert(e); }
}

//To Hide the Row Below

function time_delay() {
    var xyzx;
    for (var v = 0; v < 10000; v++) {
        xyzx = v;
    }
    alert(xyzx);
}
function HideRows(id, Row_Indx) {
    try {
        //alert(id);
        var gridName = 'grdState';
        rows = document.getElementById(gridName).rows;
        //        for (i = 0; i < rows.length; i++) {
        //            rows[i].style.display = "none";
        //        }

        if (id.value == '2' || id.value == '0')
            rows[Row_Indx].style.display = "none";
        else
            rows[Row_Indx].removeAttribute('style');
    } catch (ex) {
        alert(ex);
    }
    return false;
}

function disableBelowTxt(id) {
    try {
        var arr = new Array();
        arr = id.id.split('_');
        spinnerElement = arr[0] + '_' + arr[1] + '_imgSpinner';
        var middleIndx = arr[1].toString().substring(3, 5);
        if (parseInt(middleIndx) < 10)
            middleIndx = '0' + (parseInt(middleIndx) + 1).toString();
        else
            middleIndx = (parseInt(middleIndx) + 1).toString();
        var middleName = arr[1].toString().substring(0, 3);
        middleName = middleName.toString() + middleIndx.toString();
        document.getElementById(arr[0] + '_' + middleName + '_txtAmount').disabled = true;
        document.getElementById("hdnControlHide").value = arr[0] + '_' + middleName + '_txtAmount';
    }
    catch (e) { alert(e); }
}

function getConstVal(NameID, constID) {
    var pdata = { "NameID": NameID, "ConstID": constID };
    $.ajax({
        type: "POST",
        url: "../Service_Banks.asmx/fetchConstIDVal",
        data: JSON.stringify(pdata),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //data: "{ 'BSR': 0003694'}",
        success: Success2, //function (data, status) { alert(data.d); },
        error: function (request, status, error) { //alert(request.responseText); 
        }
    });
}

function Success2(data, status) {
    try {
        element_val = data.d;
        if (data.d.toString().indexOf('-') != -1)
            document.getElementById('divAmt').innerHTML = data.d + ' amount as Refund';
        else
            document.getElementById('divAmt').innerHTML = data.d + ' amount payable';

        //alert(element_val);
    }
    catch (e) { alert(e); }
}

//function to set Number Max Limit
function maxLimits(id, limit) {
    try {
        var vv = parseFloat(id.value);
        if (vv > limit) {
            alert('Cannot Enter an amount greater than ' + limit);
            id.value = '';
            id.focus();
        }
    }
    catch (e) {
        alert(e);
    }
}

//function to set Number Max Limit
function minLimits(id, limit) {
    try {
        var vv = parseFloat(id.value);
        if (vv < limit) {
            alert('Cannot Enter an amount less than ' + limit);
            id.value = '';
            id.focus();
        }
    }
    catch (e) {
        alert(e);
    }
}

//function for set first letter capital of given string
function capitalize(el) {
    var s = el.value;
    el.value = s.substring(0, 1).toUpperCase() + s.substring(1);
}
//function for validating bank account number
function ValidBankAccNo(dt) {
    var str = dt.value; //    document.getElementById(dt).value;
    var patt = new RegExp("/^[A-Za-z0-9]{1,20}$/");
    var res = patt.test(str);

    if (res = false) {
        document.getElementById("DivBank").innerHTML = "Invalid Bank Account No";
    }
    else {
        document.getElementById("DivBank").innerHTML = "";
    }
}
//function for validate MobileNo
function ValidMobileNo(dt) {

    alert(dt);
    var str = dt.value; //    document.getElementById(dt).value;
    var patt = new RegExp("[1-9]{1}[0-9]{9}");
    var res = patt.test(str);
    if (dt.value.substring(0, 1) == '0')
        res = false;
    if (res == false) {
        document.getElementById("DivMob").innerHTML = "Invalid Mobile No";
    }
    else {
        document.getElementById("DivMob").innerHTML = "";
    }
    //document.getElementById("demo").innerHTML = res;
}
function ValidMobileNo2(dt) {


    var str = dt.value; //    document.getElementById(dt).value;
    var patt = new RegExp("[1-9]{1}[0-9]{9}");
    var res = patt.test(str);

    if (res = false) {
        document.getElementById("DivMob2").innerHTML = "Invalid Mobile No";
    }
    else {
        document.getElementById("DivMob2").innerHTML = "";
    }
    //document.getElementById("demo").innerHTML = res;
}
//capitalize_Words   
function capWords(str) {
    var words = this.value.split(" ");
    alert('jk');
    for (var i = 0; i < words.length; i++) {
        var testwd = words[i];
        var firLet = testwd.substr(0, 1);
        var rest = testwd.substr(1, testwd.length - 1)
        words[i] = firLet.toUpperCase() + rest
    }
    str.value = words.join(" ");
    //document.write(words.join(" "));
}
function toTitleCase(str) {
    return str.replace(/\w\S*/g, function (txt) { return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase(); });
}
//function to validate Bank A/c Number
function validateBankAcNo(id) {
    try {
        var val = new String();

        val = id.value;
        var IsValid = 1;

        if (val.substring(0, 1) == '/' || val.substring(0, 1) == '-') {
            IsValid = 0;
        }

        if (val.indexOf('1') == -1 && val.indexOf('2') == -1 && val.indexOf('3') == -1 && val.indexOf('4') == -1 && val.indexOf('5') == -1 && val.indexOf('6') == -1 && val.indexOf('7') == -1 && val.indexOf('8') == -1 && val.indexOf('9') == -1 && val.indexOf('0') == -1)
            IsValid = 0;

        if (val.indexOf('/-') != -1)        // / and - cannot come together
            IsValid = 0;
        var cnt = 0;
        for (var i = 0; i < val.length; i++) {
            if (val.charAt(i) == '0')
                cnt = cnt + 1;
        }
        if (cnt == val.length)
            IsValid = 0;




        //        var matches = val.match('1');
        //        alert(matches);
        //        if (matches != null) {
        //            alert('number');
        //        }

        //val = id.value;
        if (IsValid != 1) {
            alert('Invalid A/c Number');
            id.value = '';
        }
    }
    catch (e) {
        alert(e);
    }
}


//function to prevent any special characther to type with exceptions

function IsSplChar(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    //alert(charCode);
    if (charCode == 44 || charCode == 46 || charCode == 63 || charCode == 60 || charCode == 62 || charCode == 126 || charCode == 33 || charCode == 64 || charCode == 35 || charCode == 36 || charCode == 37 || charCode == 94 || charCode == 38 || charCode == 40 || charCode == 41 || charCode == 42 || charCode == 95 || charCode == 96) {
        return false;
    }

    return true;
    //    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
    //        alert('Value Should Be Numeric!!');
    //        return false;
    //    }
    //    return true;
}
//function for validate ifsc code
function validateIFSC(dt) {
    try {
        // alert(dt.value.length);
        if (dt.value.length < 11) {

            document.getElementById("DivIFSC").innerHTML = "Invalid IFSC Code";
            document.getElementById("hdnIsIFSC").value = "false";
            return false;
        }
        else {
            var Url = "[A-Za-z]{4}[0][A-Z0-9]{6}";
            var tempUrl = dt.value;
            var matchURL = tempUrl.match(Url);
            if (matchURL == null) {
                document.getElementById("DivIFSC").innerHTML = "Invalid IFSC Code";
                document.getElementById("hdnIsIFSC").value = "false";
                return false;
            }
            else {
                document.getElementById("DivIFSC").innerHTML = "";
                document.getElementById("hdnIsIFSC").value = "true";
                return true;
            }

        }
    }
    catch (e) {
        alert(e);
    }
}
//function for validate pin
function validatePIN(dt) {
    try {
         alert(dt.value.length);
        if (dt.value.length < 6) {
            document.getElementById("Divpin").innerHTML = "Invalid PIN";

        }
        else {
            document.getElementById("Divpin").innerHTML = "";
        }
    }
    catch (e) {
        alert(e);
    }
}
//function for validate aadhar No.
function validateAadharNo(dt) {
    try {
        // alert( dt.value.length);
        if (dt.value.length < 12) {
            document.getElementById("DivAadhar").innerHTML = "Invalid Aadhar No";

        }
        else {
            document.getElementById("DivAadhar").innerHTML = "";
        }
    }
    catch (e) {
        alert(e);
    }
}
//function for date to validate a date not larger than than first day of the AY (e.g: 2014-2015: date cannot be lesser than 01-04-2014)
function validateAY_DOB(dt, ddmmyy) {
    try {

        var vv = dt.value;
        var top = txt.offsetTop;
        var modalWindow;
        if (ddmmyy == true) {

            var arr = new Array();
            arr = dt.value.toString().split('/');
            vv = arr[1] + '/' + arr[0] + '/' + arr[2];

        }
        var vv_validate = new Number();
        vv_validate = 1;
        if (parseInt(arr[1]) > 12 || parseInt(arr[0]) < 1 || parseInt(arr[1]) < 1) {
            vv_validate = 0;
        }
        else if (parseInt(arr[2]) < 1901) {
            vv_validate = 0;
        }
        else {
            if (parseInt(arr[1]) == 1 || parseInt(arr[1]) == 3 || parseInt(arr[1]) == 5 || parseInt(arr[1]) == 7 || parseInt(arr[1]) == 8 || parseInt(arr[1]) == 10 || parseInt(arr[1]) == 12) {
                if (parseInt(arr[0]) > 31) {
                    vv_validate = 0;
                }
            }
            else if (parseInt(arr[1]) == 4 || parseInt(arr[1]) == 6 || parseInt(arr[1]) == 9 || parseInt(arr[1]) == 11) {
                if (parseInt(arr[0]) > 30) {
                    vv_validate = 0;
                }
            }
            else if (parseInt(arr[1]) == 2) {
                if ((parseInt(arr[2]) % 4) == 0) {
                    if (parseInt(arr[0]) > 29) {
                        vv_validate = 0;
                    }
                }
                else {
                    if (parseInt(arr[0]) > 28) {
                        vv_validate = 0;
                    }
                }
            }
        }
        if (vv_validate == 0) {
            // alert('Invalid Date');
            // this.style.bordercolor ='red';
            dt.style.borderColor = 'red';
            // document.getElementById("errorOrganizer1").innerHTML = "Invalid Date";
            modalWindow = document.createElement('div');
            modalWindow.style.position = 'fixed';

            modalWindow.setAttribute("vertical-align", "middle");
            modalWindow.innerHTML = '<p>This field is required</p>';
            modalWindow.style.left = "250px";

            modalWindow.style.top = txt.offsetTop + "px";
            modalWindow.style.width = "200px";
            modalWindow.style.height = "40px";
            modalWindow.style.backgroundImage = "url(images/new.png)";
            modalWindow.style.color = "white";

            var grd = document.getElementById("grdState");
            document.getElementById("grdState").appendChild(modalWindow);
            validation.count = validation.count + 38;
            dt.value = '';
            return false;
        }
        else {
            dt.style.borderColor = '#cccccc';
            //            document.getElementById("errorOrganizer1").innerHTML = "";
            modalWindow = document.createElement('div');
            modalWindow.style.position = 'fixed';

            modalWindow.setAttribute("vertical-align", "middle");
            modalWindow.innerHTML = '<p>This field is required</p>';
            modalWindow.style.left = "250px";

            modalWindow.style.top = txt.offsetTop + "px";
            modalWindow.style.width = "200px";
            modalWindow.style.height = "40px";
            modalWindow.style.backgroundImage = "url(images/new.png)";
            modalWindow.style.color = "white";

            var grd = document.getElementById("grdState");
            document.getElementById("grdState").appendChild(modalWindow);
            validation.count = validation.count + 38;
        }

        var d1 = new Date();
        var d2 = new Date(vv);

        if (d2 > d1) {
            //alert('Date Cannot be greater than Today');
            //            document.getElementById("errorOrganizer1").innerHTML = "Date Cannot be greater than Today";
            modalWindow = document.createElement('div');
            modalWindow.style.position = 'fixed';

            modalWindow.setAttribute("vertical-align", "middle");
            modalWindow.innerHTML = '<p>This field is required</p>';
            modalWindow.style.left = "250px";

            modalWindow.style.top = txt.offsetTop + "px";
            modalWindow.style.width = "200px";
            modalWindow.style.height = "40px";
            modalWindow.style.backgroundImage = "url(images/new.png)";
            modalWindow.style.color = "white";

            var grd = document.getElementById("grdState");
            document.getElementById("grdState").appendChild(modalWindow);
            validation.count = validation.count + 38;
            dt.value = '';
            return false;
        }
        else {
            var data = new Array();
            data = document.getElementById('hdnAY').value.toString().split('-');

            vv = '04/01/' + (parseInt(data[0]));
            var d3 = new Date(vv);
            if (d2 > d3) {
                // alert(data[0]);
                // alert('Date cannot be larger than 01/04/' + (parseInt(data[0])));
                //                document.getElementById("errorOrganizer1").innerHTML = 'Date cannot be larger than 01/04/' + (parseInt(data[0]));
                modalWindow = document.createElement('div');
                modalWindow.style.position = 'fixed';

                modalWindow.setAttribute("vertical-align", "middle");
                modalWindow.innerHTML = '<p>This field is required</p>';
                modalWindow.style.left = "250px";

                modalWindow.style.top = txt.offsetTop + "px";
                modalWindow.style.width = "200px";
                modalWindow.style.height = "40px";
                modalWindow.style.backgroundImage = "url(images/new.png)";
                modalWindow.style.color = "white";

                var grd = document.getElementById("grdState");
                document.getElementById("grdState").appendChild(modalWindow);
                validation.count = validation.count + 38;
                dt.value = '';
                return false;
            }
            else {
                dt.style.borderColor = '#cccccc';
                //document.getElementById("errorOrganizer1").innerHTML = "";
                modalWindow = document.createElement('div');
                modalWindow.style.position = 'fixed';

                modalWindow.setAttribute("vertical-align", "middle");
                modalWindow.innerHTML = '<p>This field is required</p>';
                modalWindow.style.left = "250px";

                modalWindow.style.top = txt.offsetTop + "px";
                modalWindow.style.width = "200px";
                modalWindow.style.height = "40px";
                modalWindow.style.backgroundImage = "url(images/new.png)";
                modalWindow.style.color = "white";

                var grd = document.getElementById("grdState");
                document.getElementById("grdState").appendChild(modalWindow);
                validation.count = validation.count + 38;
            }
        }
        //document.getElementById("errorOrganizer1").style.display = "none";
        return true;
    }
    catch (e) {
        //alert(e);

        err1.innerHTML = e;
    }
}
//function for show err msg when save button cliclked
var IsFormValidate = 'true';
function moveValNext1() {
    try {
        //alert(document.getElementById('hdnValidations').value);
        if (document.getElementById('hdnValidations').value != '') {
            //alert(document.getElementById('ddlSelect').selectedIndex);
            var tmpMsg = '';
            var varMsg = '';
            var IsValidate = 'true';
            var arrMain = new Array();
            var arrDetail = new Array();
            var arrMains = new Array();
            //alert(document.getElementById('hdnValidations').value);
            var vv = new String();
            //vv.replace(
            //arrMains = document.getElementById('hdnValidations').value;
            arrMains = document.getElementById('hdnValidations').value.split('$');
            //            alert(arrMains[parseInt(document.getElementById('ddlSelect').selectedIndex)]);
            //            alert(document.getElementById('ddlSelect').selectedIndex);
            if (arrMains != '') {
                arrMain = arrMains[parseInt(document.getElementById('ddlSelect').selectedIndex)].split('~');

                var arrMain2 = new Array();
                var cntReq = 0;
                for (var i = 0; i < arrMain.length; i++) {

                    arrDetail = arrMain[i].split('_');
                    for (var j = 0; j < arrDetail.length; j++) {
                        if (arrDetail[j].indexOf('required') != -1) {
                            var vv = 'grdState_ctl0' + (parseInt(i) + 2).toString() + '_ddl1';
                            if (document.getElementById(vv) == null)
                                vv = 'grdState_ctl0' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if (document.getElementById(vv) == null)
                                vv = 'grdState_ctl0' + (parseInt(i) + 2).toString() + '_txtReadOnly';


                            if ((parseInt(arrDetail[j]) + 2) > 9) {
                                vv = 'grdState_ctl' + (parseInt(i) + 2).toString() + '_ddl1';
                                if (document.getElementById(vv) == null)
                                    vv = 'grdState_ctl' + (parseInt(i) + 2).toString() + '_txtAmount';
                                if (document.getElementById(vv) == null)
                                    vv = 'grdState_ctl' + (parseInt(i) + 2).toString() + '_txtReadOnly';
                            }

                            if (document.getElementById(vv) != null) {
                                tmpMsg = tmpMsg + '~' + document.getElementById(vv).value;
                                if (vv.indexOf('_txtAmount') != -1) {
                                    if (document.getElementById(vv).value == '') {
                                        cntReq = cntReq + 1;
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red';
                                        document.getElementById(vv).focus();
                                        document.getElementById(vv).placeholder = 'Required';
                                        //document.getElementById('grdState_ctl0' + (parseInt(i) + 2).toString() + '_divErr').style.display = 'block';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                                else if (vv.indexOf('_ddl1') != -1) {
                                    if (document.getElementById(vv).value == '-1') {
                                        cntReq = cntReq + 1;
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red';
                                        document.getElementById(vv).value = '';
                                        document.getElementById(vv).focus();
                                        //document.getElementById(vv).placeholder = 'Invalid Value';
                                        //document.getElementById('grdState_ctl0' + (parseInt(i) + 2).toString() + '_divErr').style.display = 'block';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                                else {
                                    if (document.getElementById(vv).value == '') {
                                        cntReq = cntReq + 1;
                                        IsValidate = 'false';
                                        document.getElementById(vv).style.borderColor = 'Red';
                                        document.getElementById(vv).value = '';
                                        document.getElementById(vv).focus();
                                        document.getElementById(vv).placeholder = 'Invalid Value';
                                        //document.getElementById('grdState_ctl0' + (parseInt(i) + 2).toString() + '_divErr').style.display = 'block';
                                        varMsg += '<tr><td>' + arrDetail[j] + '</td></tr>';
                                    }
                                }
                            }
                        }
                        //alert('isvalidate : ' + IsValidate);
                        //for Patterns pan[ ]
                        var regexp1 = new RegExp("/[A-Z]{3}[CPHFATBLJG][a-z]\d{4}[A-Z]/i");
                        if (arrDetail[j].indexOf('pan[') != -1) {
                            vv = 'grdState_ctl0' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if ((parseInt(i) + 2) > 9)
                                vv = 'grdState_ctl' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if (document.getElementById(vv) != null) {
                                if (/[a-z]{3}[cphfatbljg][a-z]\d{4}[a-z]/i.test(document.getElementById(vv).value) == false && document.getElementById(vv).value != 'PANNOTAVBL') {
                                    IsValidate = 'false';
                                    //alert('grdState_ctl' + (parseInt(i) + 2).toString() + '_divErr');
                                    document.getElementById(vv).style.borderColor = 'Red';
                                    document.getElementById(vv).value = '';
                                    document.getElementById(vv).focus();
                                    document.getElementById(vv).placeholder = 'Invalid Value';
                                    //document.getElementById('grdState_ctl0' + (parseInt(i) + 2).toString() + '_divErr').style.display = 'block';
                                }
                            }
                        }

                        //For Date Format:
                        var regexp1 = new RegExp("/(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}/i");
                        if (arrDetail[j].indexOf('DateFormat[]') != -1) {
                            vv = 'grdState_ctl0' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if ((parseInt(i) + 2) > 9)
                                vv = 'grdState_ctl' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if (document.getElementById(vv) != null) {
                                if (/(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}/i.test(document.getElementById(vv).value) == false && document.getElementById(vv).value != 'PANNOTAVBL') {
                                    IsValidate = 'false';
                                    document.getElementById(vv).style.borderColor = 'Red';
                                    document.getElementById(vv).value = '';
                                    document.getElementById(vv).focus();
                                    document.getElementById(vv).placeholder = 'Invalid Value';

                                    //document.getElementById('grdState_ctl0' + (parseInt(i) + 2).toString() + '_divErr').style.display = 'block';
                                }
                            }
                        }

                        //for Patterns Email
                        var regexp1 = new RegExp("/\S+@\S+\.\S+/");
                        if (arrDetail[j].indexOf('email') != -1) {
                            vv = 'grdState_ctl0' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if ((parseInt(i) + 2) > 9)
                                vv = 'grdState_ctl' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if (document.getElementById(vv) != null) {
                                if (/\S+@\S+\.\S+/.test(document.getElementById(vv).value) == false) {
                                    IsValidate = 'false';
                                    //alert('grdState_ctl' + (parseInt(i) + 2).toString() + '_divErr');
                                    document.getElementById(vv).style.borderColor = 'Red';
                                    document.getElementById(vv).value = '';
                                    document.getElementById(vv).focus();
                                    document.getElementById(vv).placeholder = 'Invalid Value';
                                    //document.getElementById('grdState_ctl0' + (parseInt(i) + 2).toString() + '_divErr').style.display = 'block';
                                }
                            }
                        }
                        var elmLength = new Number();

                        //for Max Length
                        if (arrDetail[j].indexOf('maxSize') != -1) {
                            vv = 'grdState_ctl0' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if ((parseInt(i) + 2) > 9)
                                vv = 'grdState_ctl' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if (document.getElementById(vv) != null) {
                                var arrDt = arrDetail[j].split('maxSize[');
                                arrDt = arrDt[1].split(']');
                                elmLength = parseInt(arrDt[0]);
                                if (document.getElementById(vv).value.length > elmLength && document.getElementById(vv).value != '') {
                                    IsValidate = 'false';
                                    //alert('grdState_ctl' + (parseInt(i) + 2).toString() + '_divErr');
                                    document.getElementById(vv).style.borderColor = 'Red';
                                    document.getElementById(vv).value = '';
                                    document.getElementById(vv).focus();
                                    document.getElementById(vv).placeholder = 'Invalid Value';
                                    //document.getElementById('grdState_ctl0' + (parseInt(i) + 2).toString() + '_divErr').style.display = 'block';
                                }
                            }
                        }

                        //for Min Length
                        if (arrDetail[j].indexOf('minSize') != -1) {
                            vv = 'grdState_ctl0' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if ((parseInt(i) + 2) > 9)
                                vv = 'grdState_ctl' + (parseInt(i) + 2).toString() + '_txtAmount';
                            if (document.getElementById(vv) != null) {
                                var arrDt = arrDetail[j].split('minSize[');
                                arrDt = arrDt[1].split(']');
                                elmLength = parseInt(arrDt[0]);
                                if (document.getElementById(vv).value.length < elmLength && document.getElementById(vv).value!='') {
                                    IsValidate = 'false';
                                    //alert('grdState_ctl' + (parseInt(i) + 2).toString() + '_divErr');
                                    document.getElementById(vv).style.borderColor = 'Red';
                                    document.getElementById(vv).value = '';
                                    document.getElementById(vv).focus();
                                    document.getElementById(vv).placeholder = 'Invalid Value';
                                    //document.getElementById('grdState_ctl0' + (parseInt(i) + 2).toString() + '_divErr').style.display = 'block';
                                }
                            }
                        }



                    }
                }
            }
            else {
                IsValidate = 'true';
            }
            
            if (IsValidate == 'false') {
                IsFormValidate = 'false';
                // validateIt();

                //ShowErrMsgfor106();
                // document.getElementById("Err106").innerHTML = varMsg;
                //alert('val of hdnvtype1 : ' + document.getElementById('hdnVType1').value);
                if (document.getElementById('hdnVType1').value.indexOf('Main.aspx') == -1) {
                    //alert('inside');
                    //document.getElementById('btnErrPopup').click();
                    //saveAssessee();
//                    $(document).ready(function ($) {
//                        $('#Submenu2_aProfile').click();
//                    });
                }
                return false;

            } else {
                IsFormValidate = 'true';
                return true;
            }
        }
        else {
            IsFormValidate = 'true';
            return true;
        }
    }
    catch (e) {
        alert(e);
    }
}

//function for date to validate a date not larger than today and not lesser than first day of the AY (e.g: 2014-2015: date cannot be lesser than 01-04-2014)
function validateAY_Date(dt, ddmmyy) {
    try {

        var vv = dt.value;
        
        if (ddmmyy == true) {
            
            var arr = new Array();
            arr = dt.value.toString().split('/'); //alert(arr.length);
            
            if (arr.length == 3) {
                vv = arr[1] + '/' + arr[0] + '/' + arr[2];


                var d1 = new Date();
                var d2 = new Date(vv);

                if (d2 > d1) {
                    // alert('Date Cannot be greater than Today');
                    ShowErrMsgforDate();
                    dt.value = '';
                    return false;
                }
                else {
                    var data = new Array();

                    data = document.getElementById('hdnAY').value.toString().split('-');

                    vv = '04/01/' + (parseInt(data[0]) - 1);
                    var d3 = new Date(vv);
                    if (d2 < d3) {
                        alert_custom('Date cannot be smaller than 01/04/' + (parseInt(data[0]) - 1), 1, 'Error', '', '', '', ['OK'],'100','100px');                        
                        ShowErrMsgforDate2();
                        dt.value = '';
                        return false;
                    }
                }
            }
            else {
                //alert('invalid date');
                ShowErrMsgforDate3();
                dt.value = '';
                return false;
            }
            return true;
        }
    }
    catch (e) { alert(e); }
}
function ShowErrMsgforDate() {
    //$("#divMsg.abc").text("Value Should Be Numeric!!");
    $("#divDate").dialog({
        title: "Error Message",
        width: 'auto',
        height: 'auto',
        minHeight: '0',





        modal: true
        //buttons: {
        //Cancel: function () {
        //     $(this).dialog('close');
        //   }
        // }
    });
}
function ShowErrMsgforDate2() {
    //$("#divMsg.abc").text("Value Should Be Numeric!!");
    $("#divDate2").dialog({
        title: "Error Message",
        width: 'auto',
        height: 'auto',
        minHeight: '0',





        modal: true
        //buttons: {
        //Cancel: function () {
        //     $(this).dialog('close');
        //   }
        // }
    });
}
function ShowErrMsgforDate3() {
    //$("#divMsg.abc").text("Value Should Be Numeric!!");
    $("#divDate3").dialog({
        title: "Error Message",
        width: 'auto',
        height: 'auto',
        minHeight: '0',





        modal: true
        //buttons: {
        //Cancel: function () {
        //     $(this).dialog('close');
        //   }
        // }
    });
}
//function to set the length for the Phone after STD Code
function getPhoneLength(id) {
    try {
        if (g_STDCodeLength == 0) {
            if (id.value != '') {
                alert('Please Enter the STD Code First!');
                //document.getElementById("divStd").innerHTML = "Please Enter the STD Code First!";
                id.value = '';
            }
        }
        else {
            if (id.value.length != g_STDCodeLength) {
                alert('Phone Length should be : ' + g_STDCodeLength);
                //document.getElementById("divStd").innerHTML = "Phone Length should be : " + g_STDCodeLength;
                id.value = '';
                //id.focus();
            }
        }
        //document.getElementById("divStd").innerHTML = "";
    }
    catch (e) {
        alert(e);
    }
}


//function to set the length for the Phone after STD Code
function setPhoneLength(id) {
    g_STDCodeLength = 10 - parseInt(id.value.length);
    //alert(g_STDCodeLength);
}


//function to remove extra 0's from beginning

function removeZeroes(id) {
    if (id.value.length > 1) {
        var vv = new String();
        removeZeroesRes(id);
    }
}

function removeZeroesRes(id) {
    if (id.value.substring(0, 1) == '0') {
        id.value = id.value.substring(1)
        removeZeroesRes(id);
    }
}

//function to be used within window close event in order to manage the session of the user accordingly
function HandleClose() {
    alert("Killing the session on the server!!");
    PageMethods.AbandonSession();
}

function movePage(val) {
    try {
        //alert(val);
       
        moveValNext1();
        if (IsFormValidate != 'false') {
            document.getElementById('hdnVType').value = val;
            document.cookie = "vtype=" + val;

            $(document).ready(function () {
                var pDataVType = { "vtype": val };
                //alert(val);
                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(pDataVType),
                    url: "../Service_Banks.asmx/setVType",
                    success: successVType,
                    failure: failVType
                });
            });
            document.getElementById('btnPageMove').click();
        }
        //alert('asd');
    }
    catch (e) { alert(e); }
}
function successVType(response) {

}
function failVType(ff) {
    alert(ff);
}

function getDeductedYear(id) {
    try {
        var data = new Array();
        data = document.getElementById('hdnAY').value.toString().split('-');
        if (parseInt(id.value) < 2000) {
            alert('Invalid Year');
            id.value = '';
            id.focus();
        }
        else if (parseInt(id.value) > (parseInt(data[0]) - 1)) {
            alert('Year cannot be greater than AY');
            id.value = '';
            id.focus();
        }
        //id.value = document.getElementById('hdnAY').value;
    }
    catch (e) { alert(e); }
}


//function for setting Due Date and "Section Under which return is being files:

function setDatenSection(id) {
    //alert(id.value);
    var arr = new Array();
    arr = id.value.split('-');
    //alert('31/07/' + arr[0]);
    document.getElementById('txtDueDate').value = '31/07/' + arr[0];
    if (parseInt(arr[0]) < 2015)
        document.getElementById('ddlWhichSection').selectedIndex = 1;
    else
        document.getElementById('ddlWhichSection').selectedIndex = 0;

}


//function convert the PAN into upper case:

function setUpper(id) {
    try {
        //alert(id);
        id.value = id.value.toUpperCase();
    }
    catch (e) { alert(e); }
}

//function convert the PAN into upper case:

function setUpperFirst(id) {
    try {
        id.value = id.value.charAt(0).toUpperCase();
    }
    catch (e) { alert(e); }
}

//function to show alert on future date

function isFutureDate(val) {//alert(val.value);
    try {
        idate = val.value;
        var today = new Date().getTime(),
            idate = idate.split("/");
        idate = new Date(idate[2], idate[1] - 1, idate[0]).getTime();
        if ((today - idate) < 0) {
            alert('Date cannot be greater than Today!!');
            val.value = '';
            val.focus();
            return false;
        }
    }
    catch (e) { alert(e); }
}

//function to get grid according to tab (similar to dropdown change as before):

function btnclick() {
    alert('abc');
    document.getElementById('btnSaveMasterData').click();
}

function btnCont_Click() {
    try {
        //alert('btnCont_Click');
        setTimeout(moveValNext, 10);
    }
    catch (e) { alert(e); }
}

function btnBack_Click() {
    setTimeout(moveValPrev, 10);
}

function moveValPrev() {
    var cnt = parseInt(document.getElementById('ddlSelect').selectedIndex) - 1;
    getTabbedGrid(cnt);
}

function moveValNext() {
    try {
        //alert('document.getElementById(hdnValidations).value) : ' + document.getElementById('hdnValidations').value);
        if (document.getElementById('hdnValidations').value != '') {
            //alert(document.getElementById('hdnValidations').value);
            //alert('3');
            var IsValidate = 'true';
            var arrMain = new Array();
            var arrDetail = new Array();
            var arrMains = new Array();
            //alert(document.getElementById('hdnValidations').value);
            arrMains = document.getElementById('hdnValidations').value.split('$');
            //alert(document.getElementById('ddlSelect').selectedIndex);
            //alert('asd');
            //        alert('selected val : ' + document.getElementById('ddlSelect').value);
            //        alert(arrMains.length);
            if (parseInt(document.getElementById('ddlSelect').selectedIndex) > arrMain.length)
                arrMain = arrMains[parseInt(document.getElementById('ddlSelect').selectedIndex)].split('~');
            //alert('asd1');
            //alert(arrMains[parseInt(document.getElementById('ddlSelect').selectedIndex)]);
            //alert(arrMains[0]);
            for (var i = 0; i < arrMain.length; i++) {
                arrDetail = arrMain[i].split('_');
                for (var j = 0; j < arrDetail.length; j++) {
                    if (arrDetail[j].indexOf('required') != -1) {

                        var vv = 'grdState_ctl0' + (parseInt(arrDetail[0]) + 2).toString() + '_ddl1';
                        if ((parseInt(arrDetail[0]) + 2) > 9)
                            vv = 'grdState_ctl' + (parseInt(arrDetail[0]) + 2).toString() + '_ddl1';

                        if (document.getElementById(vv) != null) {
                            if (document.getElementById(vv).value.indexOf('select') != -1) {
                                IsValidate = 'false';
                            }
                        }
                        else {
                            vv = 'grdState_ctl0' + (parseInt(arrDetail[0]) + 2).toString() + '_txtAmount';
                            if ((parseInt(arrDetail[0]) + 2) > 9)
                                vv = 'grdState_ctl' + (parseInt(arrDetail[0]) + 2).toString() + '_txtAmount';
                            if (document.getElementById(vv) != null) {
                                //alert(document.getElementById(vv).value);
                                if (document.getElementById(vv).value == '') {
                                    //alert(arrDetail[j]);
                                    IsValidate = 'false';
                                }
                            }
                        }
                    }   //if
                    
                    //for Patterns pan[ ]
                    var regexp1 = new RegExp("/[A-Z]{3}[CPHFATBLJG][a-z]\d{4}[A-Z]/i");
                    if (arrDetail[j].indexOf('pan[') != -1) {
                        alert('for pan');
                        vv = 'grdState_ctl0' + (parseInt(arrDetail[0]) + 2).toString() + '_txtAmount';
                        if ((parseInt(arrDetail[0]) + 2) > 9)
                            vv = 'grdState_ctl' + (parseInt(arrDetail[0]) + 2).toString() + '_txtAmount';
                        if (document.getElementById(vv) != null) {
                            if (/[a-z]{3}[cphfatbljg][a-z]\d{4}[a-z]/i.test(document.getElementById(vv).value) == false && document.getElementById(vv).value != 'PANNOTAVBL') {
                                IsValidate = 'false';
                                alert('error : ' + vv);
                            }
                        }
                    }

                    //for Patterns DateFormat[ ]
                    if (arrDetail[j].indexOf('DateFormat[]') != -1) {
                        //alert('5')
                        regexp1 = new RegExp("/^\d{2}\/\d{2}\/\d{4}$/");
                        vv = 'grdState_ctl0' + (parseInt(arrDetail[0]) + 2).toString() + '_txtDate';
                        if ((parseInt(arrDetail[0]) + 2) > 9) {
                            //alert('6')
                            vv = 'grdState_ctl' + (parseInt(arrDetail[0]) + 2).toString() + '_txtDate';
                        }
                        if (document.getElementById(vv) != null) {
                            //alert('7')
                            if (/([0-9]{2})\/([0-9]{2})\/([0-9]{4})/.test(document.getElementById(vv).value) == false) {
                                {
                                    //alert('8')
                                   
                                    IsValidate = 'false';
                                    //alert('date-format-false');
                                }
                            }
                        }
                    }
                    //alert(IsValidate);
                    //for Patterns maxSize[ ]
                    //                if (arrDetail[j].indexOf('minSize[') != -1) {
                    //                    var arrSizing = arrDetail[j].split('minSize[');
                    //                    var arrSizing2 = arrSizing[1].split(']');
                    //                    var length_limit = parseInt(arrSizing2[0]);
                    //                    vv = 'grdState_ctl0' + (parseInt(arrDetail[0]) + 2).toString() + '_txtAmount';
                    //                    if (document.getElementById(vv) != null) {
                    //                        if (document.getElementById(vv).value.length < length_limit) {
                    //                            IsValidate = 'false';
                    //                            //alert('minSize-format-false');
                    //                            alert(document.getElementById(vv).value.length);
                    //                            alert(length_limit);
                    //                            alert(arrDetail[j]);
                    //                        }
                    //                    }
                    //                }



                }    //if
            } //for arrDetail
        }
        else {
            //alert('no validation here');
            IsValidate = 'true';
        }
        //alert('IsValidate : ' + IsValidate);
        if (IsValidate == 'true') {
            
            //btnclick();
            // alert(IsValidate);
            IsFormValidate = 'true';
            var cnt = parseInt(document.getElementById('ddlSelect').value) + 1;
            
            //alert(cnt);
            //alert(document
            getTabbedGrid(cnt);
        }
        else {
            var cnt = parseInt(document.getElementById('ddlSelect').value) + 1;
            
            //alert(cnt);
            //alert(document
            getTabbedGrid(cnt);
            IsFormValidate = 'false';
        }
        
        //document.getElementById('hdnValidations').value = '';
    }
    catch (e) { alert('error is : ' + e); }
}

function getTabbedGrid(val) {
    //alert(val);
    //btnclick();
    moveValNext1();
    //alert('IsFormValidate : ' + IsFormValidate);
    if (IsFormValidate != 'false') {
        try {
            //alert('move on');
            //alert('A');
            //alert(val);
            //alert(id.id);
            //var inpObj = document.getElementById("grdState$ctl03$txtAmount");
            //        if (inpObj.checkValidity() == true) {
            //alert('try');
            //alert('17');
            if (document.getElementById('aTab_0') != null) {
                document.getElementById('aTab_0').removeAttribute('class');
                // alert('14');
                document.getElementById('aTab_1').removeAttribute('class');
                // alert('15');
            }
            document.getElementById('hdnValidate').value = "false";
            // alert('16');
            // document.getElementById('aTab_1').className = 'border_bot_new1 active_new1 ';
            //document.getElementById('aTab_1').removeAttribute('class');
            //document.getElementById(id.id).attr

            document.getElementById('hdnTabbed').value = val;
            document.getElementById('hdnTabbedIndx').value = document.getElementById('ddlSelect').selectedIndex;
            //alert(document.getElementById('ddlSelect').selectedIndex + ' ~ ' + document.getElementById('hdnTabCount').value);
            //alert(document.getElementById('ddlSelect').selectedIndex + ' ~ ' + document.getElementById('ddlSelect').length);
            //if (document.getElementById('ddlSelect').selectedIndex == document.getElementById('hdnTabCount').value && document.getElementById('hdnProject').value == 'vt') {

            //if (document.getElementById('ddlSelect').selectedIndex == (parseInt(document.getElementById('hdnTabCount').value) - 1) && document.getElementById('hdnProject').value == 'vt') {
//            if (document.getElementById('ddlSelect').selectedIndex == (parseInt(document.getElementById('ddlSelect').length) - 2) || (document.getElementById('ddlSelect').selectedIndex == (parseInt(document.getElementById('ddlSelect').length) - 1)) && document.getElementById('hdnProject').value == 'vt') {
//                //alert('inside');
//                setTimeout(showSaveButton, 1200);
            //            }

            //To give the condition that Continue/Back/Tab is pressed:
            document.getElementById('hdnSet_Tab').value = 'true';
            document.getElementById('ddlSelect').onchange();
            //        }
        }
        catch (e) {
            alert(e);
        }
    }
    else {
        //alert('not validated');
    }
    //document.form1.submit();
}

function showSaveButton() {
    //alert(document.getElementById('btnSaveMasterData'));
//    if (document.getElementById('btnSaveMasterData') != null) {
//        document.getElementById('btnSaveMasterData').style.display = 'block';
//    }
//    if (document.getElementById('btnContinueMaster') != null)
//        document.getElementById('btnContinueMaster').style.display = 'none';

    document.getElementById('btnContinue').style.display = 'block';
}

// Function to sum up the Column values for the Float Grid as per rules:

var ID_Reqd = '';
var indx_Reqd = '';
function getReqByJQuery() {
    var $txts = $('input');

    //alert($txts.length);
    $txts.each(function (indx, elm) {
        if (elm.id.toString().substr(0, elm.id.toString().indexOf('_')) == 'GridViewFlaoting')
            alert(elm.value);
    });
}
function getRequired(element, indx, array) {
    if (element.id == ID_Reqd)
        array[(indx + indx_Reqd)].value = element.value;
    //alert(array[(indx + indx_Reqd)].id);
    //alert(element.value);
    //if (indx == (indx + indx_Reqd))

    //alert(indx);
}
function getSums(indx, id) {
    try {
        ID_Reqd = id.id;
        indx_Reqd = indx;
        //var txts=document.getelementbyclass
        var txts = document.getElementsByTagName('input');
        var arrTxt = new Array();
        arrTxt = Array.prototype.slice.call(txts);
        //alert(arrTxt.length);
        arrTxt.forEach(getRequired);
        getReqByJQuery();
    }
    catch (e) { alert(e); }
}
function getSum_Col(cols, id) {
    
}

function getSum(cols, id) {
    try {
        //alert(document.getElementById('GridViewFlaoting_ctl02_txtC13').value);
        var arrCtrlTitle = new Array();
        var mainID = 0;

        arrCtrlTitle = id.id.toString().split('_');
        mainID = arrCtrlTitle[1].substring(arrCtrlTitle[1].length - 1);
        var arrCols = new Array();
        var tot = 0;
        arrCols = cols.toString().split(',');
        var element_name;
        //alert(arrCols.length);
        //alert(document.getElementById('GridViewFlaoting_ctl0' + mainID + '_txtC' + arrCols[0].toString().replace('=', '').replace('-', '').replace('*', '')).value);
        //    alert(arrCols[2]);
        var ValToUse = 0;
        for (var i = 0; i < arrCols.length; i++) {
            element_name = 'GridViewFlaoting_ctl0' + mainID + '_txtC' + arrCols[i].toString().replace('=', '').replace('-', '').replace('*', '');
            //alert(element_name);
            //var cc = new String();
//            alert(document.getElementById(element_name).value);
//            alert(arrCols[i]);
            if (document.getElementById(element_name) != null) {
                if (document.getElementById(element_name).value == '')
                    ValToUse = 0;
                else
                    ValToUse = parseInt(document.getElementById(element_name).value);

                if (arrCols[i].charAt(0) != '=') {
                    if (arrCols[i].charAt(0) == '-')
                        tot = tot - parseInt(ValToUse);
                    else if (arrCols[i].charAt(0) == '*')
                        tot = tot * parseInt(ValToUse);
                    else// if (arrCols[i].charAt(0) == '+')
                        tot = tot + parseInt(ValToUse);
                    //alert(tot.toString());

                }
                else if (arrCols[i].charAt(0) == '=') {
                if (tot == 0)
                    document.getElementById(element_name).value = '';
                else
                    document.getElementById(element_name).value = tot.toString();
                }
            }
        }
    } catch (e) { alert(e); }
}

//--This function is used for show popup --

$(document).ready(function () {
    //$('#dialog').dialog(); 
    $('#lbtnChange').click(function () {
        $('#pnlEmpPop').css({
            "display": "block",
            "height": "250",
            "width": "430",
            "top": "200px",
            "margin-left": "50%",
            "z-index": "1001"

        })
        $('#overlay').fadeIn('fast');
    });
});


$(document).ready(function () {
    $('#btnPopClose').click(function () {
        $('#pnlEmpPop').css({
            "display": "none"
        })
        location.reload(true);
    });
});


// new popup (in red) by Nishu:

$("[id*=btnPop]").live("click", function () {
    $("#dialog").dialog({
        title: "Popup Testin22g",
        buttons: {
            Close: function () {
                $(this).dialog('close');
            }
        }
    });
    return false;
});


//submeu for mobile view:

$(document).ready(function () {

    $("#divass").click(function () {
        $("#divassdet").slideToggle();
    });

});

// remove border from grid:

$(document).ready(function () {
    $('#grdState').css({
        "border": "0", "border-color": "white", "border-bottom-color": "#c1dBFA"
    })

    $('#grdState th').css({ "text-align": "left" })
    $('grdState th').removeClass('text-right');

});





//---------------------------------------------------------------------------------------------------------------------

//// following is for textbox tooltips in grid (grdstate etc):

//jQuery(document).ready(function ($) {


//    $("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").each(function () {
//        $("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").hover(function () {
//            $(this).tooltip();
//        });

//    });

//    $("#<%=GridViewDetails.ClientID %>").find("input[type=text][id*=txtAmount]").each(function () {
//        $("#<%=GridViewDetails.ClientID %>").find("input[type=text][id*=txtAmount]").hover(function () {
//            $(this).tooltip();
//        });

//    });



//});
//On UpdatePanel Refresh
//$(document).ready(function ($) {
//    var prm = Sys.WebForms.PageRequestManager.getInstance();
//    if (prm != null) {
//        prm.add_endRequest(function (sender, e) {
//            if (sender._postBackSettings.panelsToUpdate != null) {

//                $("#<%=grdState.ClientID %>").find("input[type=text][id*=txtAmount]").hover(function () {
//                    $(this).tooltip();
//                });



//            }
//        });
//    };
//});

//On UpdatePanel Refresh
//$(document).ready(function ($) {
//    var prm = Sys.WebForms.PageRequestManager.getInstance();
//    if (prm != null) {
//        prm.add_endRequest(function (sender, e) {
//            if (sender._postBackSettings.panelsToUpdate != null) {

//                $("#<%=GridViewDetails.ClientID %>").find("input[type=text][id*=txtAmount]").hover(function () {
//                    $(this).tooltip();
//                });



//            }
//        });
//    };
//});

// remove image from sitemap: this is regarding site map path when we place it at left position

//   $(document).ready(function () {
//   $("#SiteMapPath1").find("img").remove();

//----------------------------------------------------------------------------------------------------------------------------------
//call webservice for t4 grid
//var TextBoxName = '';
//var TextVal = '';
//function callSvcforT4(vals,id) {
//    var pdata = { "ConstantId": vals + '~' + id.value};
//    $.ajax({
//        type: "POST",
//        url: "../Service_Banks.asmx/CheckT4Data",
//        data: JSON.stringify(pdata),
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: Success1,
//        error: function (request, status, error) { alert(request.responseText); }
//    });
//    
//}
//function setTextBox() {
//    try {
//        //        alert('element val : ' + element_val);
//        //        alert(element_name);
//        document.getElementById(TextBoxName).disabled = true;
//    }
//    catch (e) {
//        alert(e);
//        //setTimeout(setEleVal, 200);
//    }
//}
//function Success1(data, status) {
//    try {
//        TextVal = data.d;
//      }
//        alert(TextVal);
//    }
//    catch (e) { alert(e); }
//}
var element_name = '';
var element_val = '';

//local system:

function callSvc1(vals) {
    var vv = vals.id;
    vv = vv.substr(0, parseInt(vv.lastIndexOf('_') - 1));
    var arr = new Array();
    arr = vals.id.split('_');
    //alert(arr[1]);
    //vv = vv + (parseInt(arr[1].substr(arr[1].length - 1)) + 1);
    vv = vv + (parseInt(arr[1].substr(arr[1].length - 1)));
    //vv = vv + '_' + vals.id.substr(vals.id.length - 1);
    vv = vv + '_txtC' + (parseInt(vals.id.substr(vals.id.length - 1)) + 1).toString();
    element_name = vv;
    //document.getElementById(element_name).value = '1111';
    var pdata = { "BSR": vals.value };
    $.ajax({
        type: "POST",
        url: "../Service_Banks.asmx/fetchData",
        data: JSON.stringify(pdata),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        //data: "{ 'BSR': 0003694'}",
        success: Success, //function (data, status) { alert(data.d); },
        error: function (request, status, error) { alert(request.responseText); }
    });
    setTimeout(setEleVal, 1100);
}

function callSvc_IFSC(vals) {
    var vv = vals.id;
    vv = vv.substr(0, parseInt(vv.lastIndexOf('_') - 1));
    var arr = new Array();
    arr = vals.id.split('_');
    vv = vv + (parseInt(arr[1].substr(arr[1].length - 1)));
    vv = vv + '_txtC' + (parseInt(vals.id.substr(vals.id.length - 1)) + 1).toString();
    element_name = vv;
    var pdata = { "IFSC": vals.value };
    $.ajax({
        type: "POST",
        url: "../Service_Banks.asmx/fetchDataByIFSC",
        data: JSON.stringify(pdata),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Success,
        error: function (request, status, error) { alert(request.responseText); }
    });
    setTimeout(setEleVal, 1100);
}


// for server:

//                function callSvc1(vals) {
//                    var vv = vals.id;
//                    vv = vv.substr(0, parseInt(vv.lastIndexOf('_')));
//                    var arr = new Array();
//                    arr = vals.id.split('_');
//                    var vv1 = new Number();
//                    vv1 = parseInt(vals.id.substr(vals.id.length - 1)) + 1;
//                    vv = vv + '_txtC' + vv1.toString();
//                    element_name = vv;
//                    var pdata = { "BSR": vals.value };
//                    $.ajax({
//                        type: "POST",
//                        url: "../Service_Banks.asmx/fetchData",
//                        data: JSON.stringify(pdata),
//                        contentType: "application/json; charset=utf-8",
//                        dataType: "json",
//                        //data: "{ 'BSR': 0003694'}",
//                        success: Success, //function (data, status) { alert(data.d); },
//                        error: function (request, status, error) { alert(request.responseText); }
//                    });
//                    setTimeout(setEleVal, 1100);
//                }

function setEleVal() {
    try {
        document.getElementById(element_name).value = element_val;
    }
    catch (e) {
        alert(e);
    }
}
function Success(data, status) {
    try {
        element_val = data.d;
    }
    catch (e) { alert(e); }
}

function IsNoEntry(id) {
    id.blur();
    return false;
}
function isNumberKey_withMinus(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode < 48 || charCode > 57) {
        if (charCode == 45)
            return true;
        else
            return false;
    }
    return true;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode < 48 || charCode > 57) {
        return false;
    }
    return true;
}

function ShowErrMsg() {
    jQuery(document).ready(function ($) {
        $.noConflict(true);
        $("#divErrMsg").dialog({
            title: "Error Message",
            width: 'auto',
            height: 'auto',
            minHeight: '0',
            modal: true
        });
    });
}

function validateIt() {
    $("#divValidate").dialog({
        title: "Confirmation",
        width: 'auto',
        height: 'auto',
        minHeight: '0',


        buttons: {
            OK: function () {
                if (document.getElementById('hdnNew').value == 'false')
                    window.location = "";


            },
            Close: function () {
                $(this).dialog('close');
            }
        },


        modal: true
        //buttons: {
        //Cancel: function () {
        //     $(this).dialog('close');
        //   }
        // }
    });
}
function ShowErrMsgfor106() {
    //$("#divMsg.abc").text("Value Should Be Numeric!!");
    $("#divDate3").dialog({
        title: "Error Message",
        width: 'auto',
        height: 'auto',
        minHeight: '0',

        buttons: {
            OK: function () {
                //                if (document.getElementById('hdnNew').value == 'false')
                //                    window.location = "";


            },
            Close: function () {
                $(this).dialog('close');
            }
        },



        modal: true
        //buttons: {
        //Cancel: function () {
        //     $(this).dialog('close');
        //   }
        // }
    });
}
function fieldMaxLimit(id, limit) {
    if (id.value.length != limit) {
        //alert('This Field Value should be of ' + limit + ' digits');
        $("#divMaxlimit").dialog({
            title: "Error",
            width: 'auto',
            height: 'auto',
            minHeight: '0',


            buttons: {
                OK: function () {
                    if (document.getElementById('hdnNew').value == 'false')
                        window.location = "";


                },
                Close: function () {
                    $(this).dialog('close');
                }
            },


            modal: true
            //buttons: {
            //Cancel: function () {
            //     $(this).dialog('close');
            //   }
            // }
        });
        if (limit == 5) {
            if (id.value.length > 5) {
                //id.value = id.value.substring(5, (id.value.lengh));
                id.value = id.value.substring(0, limit);
            }
        }
        else {
            if (id.value.length > limit)
                id.value = id.value.substring(0, limit);
        }
        id.value = '';
        return false;
    }
    return true;
}

function dateCompare(dt) {
    try {
        var d1 = new Date();
        var d2 = new Date(dt.value);
        if (d2 > d1) {
            //            alert('Date Cannot be greater than Today');
            document.getElementById("errorOrganizer1").innerHTML = "Date Cannot be greater than Today";
            dt.value = '';
            return false;
        }
        return true;
    }
    catch (e) { alert(e); }
}

function isNegativeKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    var numKey = new Number();
    numKey = parseInt(charCode);
    if (numKey < 48 || numKey > 57)
        return false;
    else
        return true;
}

function IsValidated(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    //alert(charCode);
    var numKey = new Number();
    numKey = parseInt(charCode);
    if ((numKey < 48 || numKey > 57) && numKey != 45)
        return false;
    else
        return true;
}



//------------------------------------------------------------------------------------------

// For Removing Grid Rows:

//for local:

function sel(id) {
    try {
        //alert(id.id);
        var vv = new String();

        vv = id.id.toString();
        var aa = new Array();
        aa = vv.split('_');
        //vv.substr(1, vv.length);
        document.getElementById('hdnGRowSel').value = aa[1].substring(3);
        //alert(document.getElementById('hdnGRowSel').value);
        //alert(aa[2]);
    }
    catch (e) { alert(e); }
}

//for server:

//                function sel(id) {
//                    try {
//                        //alert(id.id);
//                        var vv = new String();

//                        vv = id.id.toString();
//                        var aa = new Array();
//                        aa = vv.split('_');
//                        vv.substr(1, vv.length);
//                        var vv = new String();
//                        vv = aa[1];
//                        vv = vv.substring(vv.length - 1, vv.length);
//                        aa[2].substring(aa[2].length - 2, aa[2].length - 1);
//                        document.getElementById('hdnGRowSel').value = vv; // aa[2].substring(aa[2].length - 2, aa[2].length - 1);
//                        //alert(document.getElementById('hdnGRowSel').value);
//                        //alert(document.getElementById('hdnGRowSel').value);
//                        //alert(aa[2]);
//                    }
//                    catch (e) { alert(e); }
//                }


function get() {
    try {
        Service_Banks.HelloWorld(abc);
        //Service_Banks.callService("HelloWorld", abc);
    }
    catch (e) { alert(e); }
}
function abc(vals) {
    alert(vals);
}

//-----------------------------------------------------------------------------------------------------------------------



function callPopup() {
    document.getElementById('btnPopup').click();
    document.getElementById('pnlEmpPop').style.display = 'block';
    return false;
}
function closePop() {
    document.getElementById('pnlEmpPop').style.display = 'none';
}
function valRange(id) {
    alert(id.value);
}

function setTheme(val) {
    //alert(val)
    try {
        document.getElementById('hdnTheme').value = val;
        document.getElementById('form1').submit();
        //document.form1.submit();
    }
    catch (e) { alert(e); }
}

//function validateIt() {
//    if (confirm('Are you sure you want to remove the selected record?')) {
//        //alert(document.getElementById('hdnGRowSel').value);
//        //document.getElementById('hdnGRowSel').value = '';
//    }
//    else {
//        document.getElementById('hdnGRowSel').value = '';
//    }
//}

function setTooltip(id) {
    //alert(document.getElementById(id.id));
    //alert(id.id);
    id.id.setsetAttribute('tooltip', 'Enter: Heavy Vehicle or Light Vehicle');
    //document.getElementById(id.id).att
}
//validate date and check whether it is future date for 106

function validateAY_DOB1(dt, ddmmyy) {
    //    modalWindow = document.createElement('div');
    try {

        var vv = dt.value;
        //alert(ddmmyy);
        var top = dt.offsetTop;
        var modalWindow;
        if (ddmmyy == true) {

            var arr = new Array();
            arr = dt.value.toString().split('/');
            vv = arr[1] + '/' + arr[0] + '/' + arr[2];


        }

        var vv_validate = new Number();
        vv_validate = 1;
        if (parseInt(arr[1]) > 12 || parseInt(arr[0]) < 1 || parseInt(arr[1]) < 1) {
            vv_validate = 0;

        }
        else if (parseInt(arr[2]) < 1901) {
            vv_validate = 0;
        }
        else {
            if (parseInt(arr[1]) == 1 || parseInt(arr[1]) == 3 || parseInt(arr[1]) == 5 || parseInt(arr[1]) == 7 || parseInt(arr[1]) == 8 || parseInt(arr[1]) == 10 || parseInt(arr[1]) == 12) {
                if (parseInt(arr[0]) > 31) {
                    vv_validate = 0;
                }
            }
            else if (parseInt(arr[1]) == 4 || parseInt(arr[1]) == 6 || parseInt(arr[1]) == 9 || parseInt(arr[1]) == 11) {
                if (parseInt(arr[0]) > 30) {
                    vv_validate = 0;
                }
            }
            else if (parseInt(arr[1]) == 2) {
                if ((parseInt(arr[2]) % 4) == 0) {
                    if (parseInt(arr[0]) > 29) {
                        vv_validate = 0;
                    }
                }
                else {
                    if (parseInt(arr[0]) > 28) {
                        vv_validate = 0;
                    }
                }
            }
        }

        if (vv_validate == 0) {
            // alert('Invalid Date');
            // this.style.bordercolor ='red';
            dt.style.borderColor = 'red';
            // document.getElementById("errorOrganizer1").innerHTML = "Invalid Date";
            //            modalWindow = document.createElement('div');
            //            modalWindow.style.border = "2px solid black";
            //            modalWindow.style.borderRadius = "10px";
            //            modalWindow.style.boxShadow = "#B3B3B3 4px 4px 4px";
            //            modalWindow.style.paddingBottom = "34px";
            //            modalWindow.style.paddingTop = "8px";
            //            modalWindow.style.position = 'fixed';
            //            modalWindow.style.paddingLeft = "25px";
            //            modalWindow.style.backgroundColor = "white";

            //            modalWindow.setAttribute("vertical-align", "middle");
            //            modalWindow.innerHTML = '<p>Invalid Date</p>';
            //modalWindow.style.left = "250px";

            // modalWindow.style.top = dt.offsetTop + "px";
            //            modalWindow.style.width = "137px";
            //            modalWindow.style.height = "0px";
            //            modalWindow.style.left = "82%";
            //            modalWindow.style.top = "43%";
            //modalWindow.style.backgroundImage = "url(images/new.png)";
            //modalWindow.style.color = "red";

            //            var grd = document.getElementById("grdState");
            //            document.getElementById("grdState").appendChild(modalWindow);
            // validation.count = validation.count + 38;
            document.getElementById("newdiv").style.display = "block";
            document.getElementById("val_errors").innerHTML = "Invalid Date - valerrors";
            dt.value = '';
            return false;
        }
        else {

            dt.style.borderColor = '#cccccc';
            //            document.getElementById("errorOrganizer1").innerHTML = "";

            //            modalWindow = document.createElement('div');

            //            modalWindow.style.position = 'relative';

            //            modalWindow.setAttribute("vertical-align", "middle");
            //            modalWindow.innerHTML = '';
            // modalWindow.style.left = "250px";

            // modalWindow.style.top = dt.offsetTop + "px";
            // modalWindow.style.width = "200px";
            // modalWindow.style.height = "40px";
            // modalWindow.style.backgroundImage = "url(~/images/new.png)";

            //modalWindow.style.color = "red";

            //var grd = document.getElementById("grdState");
            //document.getElementById("grdState").appendChild(modalWindow);
            // alert(vv_validate);
            // validation.count = validation.count + 38;

        }

        var d1 = new Date();
        var d2 = new Date(vv);

        if (d2 > d1) {

            // alert('Date Cannot be greater than Today');
            //            document.getElementById("errorOrganizer1").innerHTML = "Date Cannot be greater than Today";

            //modalWindow = document.createElement('div');
            //            modalWindow.style.border = "2px solid black";
            //            modalWindow.style.borderRadius = "10px";
            //            modalWindow.style.boxShadow = "#B3B3B3 4px 4px 4px";
            //            modalWindow.style.paddingBottom = "55px";
            //            modalWindow.style.paddingTop = "8px";
            //            modalWindow.style.position = 'fixed';
            //            modalWindow.style.paddingLeft = "8px";
            //            modalWindow.style.backgroundColor = "white";
            //modalWindow.style.position = 'relative';
            // alert(d2);
            //            modalWindow.setAttribute("vertical-align", "middle");
            //            modalWindow.innerHTML = '<p>Date Cannot be greater than Today</p>';
            // modalWindow.style.left = "750px";
            //  var val=   '<%= dt.ClientID %>';
            // modalWindow.style.top =val.offsetTop + "px";


            //            modalWindow.style.width = "240px";
            //            modalWindow.style.height = "0px";
            //            modalWindow.style.left = "83%";
            //            modalWindow.style.top = "50%";
            // modalWindow.style.backgroundImage = "url(images/new.png)";
            //modalWindow.style.color = "red";


            //            modalWindow.style.backgroundcolor = "gray";

            // var grd = document.getElementById("grdState");
            //document.getElementById("grdState").appendChild(modalWindow);
            // validation.count = validation.count + 38;
            // dt.value = '';
            document.getElementById("newdiv").style.display = "block";
            document.getElementById("val_errors").innerHTML = "Date Cannot be greater than Today";
            return false;
        }
        else {
            var data = new Array();
            data = document.getElementById('hdnAY').value.toString().split('-');

            vv = '04/01/' + (parseInt(data[0]));
            var d3 = new Date(vv);
            if (d2 > d3) {
                // alert(data[0]);
                // alert('Date cannot be larger than 01/04/' + (parseInt(data[0])));
                //                document.getElementById("errorOrganizer1").innerHTML = 'Date cannot be larger than 01/04/' + (parseInt(data[0]));
                //                modalWindow = document.createElement('div');
                //                modalWindow.style.border = "2px solid black";
                //                modalWindow.style.borderRadius = "10px";
                //                modalWindow.style.boxShadow = "#B3B3B3 4px 4px 4px";
                //                modalWindow.style.paddingBottom = "53px";
                //                modalWindow.style.paddingTop = "8px";
                //                modalWindow.style.position = 'fixed';
                //                modalWindow.style.paddingLeft = "8px";
                //                modalWindow.style.backgroundColor = "white";
                //                
                //                modalWindow.setAttribute("vertical-align", "middle");
                //                modalWindow.innerHTML = 'Date cannot be larger than 01/04/' + (parseInt(data[0]));
                //                modalWindow.style.left = "250px";

                //modalWindow.style.top = dt.offsetTop + "px";
                //                modalWindow.style.width = "255px";
                //                modalWindow.style.height = "0px";
                //                modalWindow.style.left = "83%";
                //                modalWindow.style.top = "60%";
                //                // modalWindow.style.backgroundImage = "url(images/new.png)";
                //                modalWindow.style.color = "red";

                //var grd = document.getElementById("grdState");
                //document.getElementById("grdState").appendChild(modalWindow);
                // validation.count = validation.count + 38;
                document.getElementById("newdiv").style.display = "block";
                document.getElementById("val_errors").innerHTML = 'Date cannot be larger than 01/04/' + (parseInt(data[0]));
                dt.value = '';
                return false;
            }
            else {
                dt.style.borderColor = '#cccccc';
                //document.getElementById("errorOrganizer1").innerHTML = "";
                //                modalWindow = document.createElement('div');
                //                modalWindow.style.position = 'fixed';

                //                modalWindow.setAttribute("vertical-align", "middle");
                //                modalWindow.innerHTML = '';
                //                modalWindow.style.left = "250px";

                //                modalWindow.style.top = dt.offsetTop + "px";
                //                modalWindow.style.width = "200px";
                //                modalWindow.style.height = "40px";
                // modalWindow.style.backgroundImage = "url(images/new.png)";
                //modalWindow.style.color = "white";
                document.getElementById("newdiv").style.display = "none";
                //                var grd = document.getElementById("grdState");
                //                document.getElementById("grdState").appendChild(modalWindow);
                // validation.count = validation.count + 38;
            }
        }
        //document.getElementById("errorOrganizer1").style.display = "none";
        return true;
    }
    catch (e) {
        //alert(e);

        err1.innerHTML = e;
    }
}

function setDDSelection(id) {
    try {
        alert(id);
        document.getElementById('hdnDDListSelection').value = id.value;
        window.location = 'salary.aspx?vtype=3002&ml=' + id.value;

    }
    catch (e) { alert(e); }
}

function showPopup_Control(val) {
    //alert(val);
    try {
        if (val == '1') {
            document.getElementById('pnlEmpPop_Control').style.display = 'block';
            document.getElementById('btnPop_Control').click();
        }
        else if (val == '2') {
            document.getElementById('<%= pnlImportDeductee.ClientID %>').style.display = 'block';
            document.getElementById('<%= btnPop_Control_DedImp.ClientID %>').click();
        }

        //document.getElementById('pnlEmpPop_Control').removeAttribute('style');
        //alert('ss');
    }
    catch (e) { alert(e); }
}

//tds popup import excel add by nishu 10/4/2015

$("[id*=btnImport]").live("click", function () {
    $("#pnlImportDeductee").dialog({
        title: "Import Excel",
        buttons: {
            Close: function () {
                $(this).dialog('close');
            }
        }
    });
    return false;
});


//following funtion is use to set dropdown as required
//function ValidateDropDown(gridname) {
//    try {
//        var flag = true;
//        var dropdowns = new Array(); //Create array to hold all the dropdown lists.
//        var labels = new Array();
//        //var gridview = document.getElementById('<%=grdState.ClientID %>'); //GridView1 is the id of ur gridview.
//        //alert(gridview);
//        dropdowns = gridname.getElementsByTagName('select'); //Get all dropdown lists contained in GridView1.
//        //labels = gridname.getElementsByTagName('span');
//        //alert(labels[0].innerHTML);
//        //alert(dropdowns.length);
//        for (var i = 0; i < dropdowns.length; i++) {

//            if (dropdowns.item(i).value == '0') //If dropdown has no selected value
//            {
//                if (dropdowns.item(i).hasAttribute("required")) {
//                    //alert(dropdowns.item(i));
//                    //var particular = labels[i].innerHTML;
//                    //alert(particular);
//                    var cnt = i + 1;
//                    alert('Please Select Values From DropDown....!');
//                    dropdowns[i].focus();
//                    break; //break the loop as there is no need to check further.
//                }
//            }
//        }
//        return true;
//    }
//    catch (ex) { alert(ex); }




