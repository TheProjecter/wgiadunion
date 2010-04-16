//**************************************************
function breakout_of_frame() {
    if (top.location != location) {
        top.location.href = "../Login.aspx";
    }
}

function refresh() {
    window.location = window.location;
}

function refreshopener() {
    if (window.opener != null)
        window.opener.location = window.opener.location;
}

function OpenWindow(url, width, height, scroll) {
    var top = ((window.screen.availHeight - height) / 2);
    var left = ((window.screen.availWidth - width) / 2);
    var params;
    if (scroll != null && scroll != "") {
        params = "top=" + top + ",left=" + left + ",toolbar=no,menubar=no,scrollbars=yes, resizable=no,location=no, status=no,width=" + width + ",height=" + height + "px";
    }
    else {
        params = "top=" + top + ",left=" + left + ",toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no,width=" + width + ",height=" + height + "px";
    }
    window.open(url, 'newwindow', params);
}

function CheckAll(obj, grid) {
    var tb = document.getElementById(grid);
    var isIE = window.ActiveXObject ? true : false;
   
    for (var i = 1; i < tb.rows.length; i++) {
        var tr = tb.rows[i];
        if (isIE) {
            tr.childNodes[0].childNodes[0].checked = obj.checked;
        }
        else {

            tr.childNodes[1].childNodes[1].checked = obj.checked;
        }
    }

}


function ShowOrHidden(objid) {
    var obj = $(objid);

    if (obj.style.display == "none") {
        obj.style.display = "block";
    }
    else if (obj.style.display == "block") {
        obj.style.display = "none";
    }
}

function ShowObj(objid) {
    $(objid).style.display = "block";
}

function HiddenObj(objid) {
    $(objid).style.display = "none";
}

function PrintContent() {
    window.parent.allFrame.cols = "0,0,*";
    $("PrintDIV").style.display = "block";
    $("ButtonControl").style.display = 'none';
    window.print();
    window.parent.allFrame.cols = "200,10,*";
    $("ButtonControl").style.display = 'block';
}

function printpreview() {
    window.parent.allFrame.cols = "0,0,*";
    $("ButtonControl").style.display = 'none';
    $("WebBrowser").execwb(7, 1);
    window.parent.allFrame.cols = "200,10,*";
    $("ButtonControl").style.display = 'block';

}

function isValidDate(dateStr) {
    var matchArray = dateStr.match(/^[0-9]+-[0-1][0-9]-[0-3][0-9]$/)
    if (matchArray == null) {
        alert("Invalid date: " + dateStr);
        return false;
    }
    return true;
}

//**************************************************