function getObj(objId) {
	return document.all ? document.all[objId] : document.getElementById(objId);
}


function newWin(url,width,height)
{
	window.open (url, "_blank", "height="+ height +", width="+ width +", toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no, top="+(screen.availHeight-height)/2+", left="+(screen.availWidth-width)/2);
}



function OpenWin(url)
{
	window.open (url, "_blank", "height=200, width=400, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no");
}

function CloseWin()
{
	window.close();
}

function ctlent(eventobject)
{
	if(event.ctrlKey && window.event.keyCode==13)
		this.document.myform.submit();
}

//Ñ¡Ôñ
function SelectAllItems() {
    var selAll = document.getElementById("chkSelAll");
    var selItems = $("input[name=chkID]");
    if (selAll.checked) {
        if (selItems != null)
            for (i = 0; i < selItems.length; i++) {
                if (!selItems[i].disabled)
                    selItems[i].checked = true;
            }
    }
    else {
        if (selItems != null)
            for (i = 0; i < selItems.length; i++)
                selItems[i].checked = false;
    }
}

