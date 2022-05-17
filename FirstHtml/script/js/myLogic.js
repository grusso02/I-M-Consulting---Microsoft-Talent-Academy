"use strict";

/* $(document).ready(function() {
    alert("Page is loaded, document ready");
    console.log( "ready!" );
}); */

function ViewRegione() {
    //alert("Page is loaded");
    var divReg = document.getElementById("divRegione");
    divReg.style.visibility = "visible";

    var divPro = document.getElementById("divProvincia")
    divPro.style.visibility = "hidden";

    var divCom = document.getElementById("divComune");
    divCom.style.visibility = "hidden";
}