"use strict";

const text = '[ { "idRegione":"1", "nomeProvincia":"Perugia", "comuni":["Gubbio","Foligno"]}, { "idRegione":"1", "nomeProvincia":"Terni", "comuni":["Narni","Otricoli"]}, { "idRegione":"2", "nomeProvincia":"Roma", "comuni":["Grottaferrata","Fiumicino"]}, { "idRegione":"2", "nomeProvincia":"Viterbo", "comuni":["Vetralla","Tarquinia"]}, { "idRegione":"3", "nomeProvincia":"Livorno", "comuni":["Piombino","Cecina"]}, { "idRegione":"4", "nomeProvincia":"Ancona", "comuni":["Numana","Sirolo"]}, { "idRegione":"4", "nomeProvincia":"Ascoli Piceno", "comuni":["San Benedetto Del Tronto","Grottammare"]} ]';
const myArr = JSON.parse(text);

function showRegione() {
    var divReg = document.getElementById("divRegion");
    divReg.style.visibility = "visible";

    var divPro = document.getElementById("divProvince")
    divPro.style.visibility = "hidden";

    var divCom = document.getElementById("divTown");
    divCom.style.visibility = "hidden";

    var divBut = document.getElementById("divBut");
    divBut.style.visibility = "hidden";
}

function removeAllOptions(selectBox) {
    if (selectBox.options.length > 1) {
        while (selectBox.options.length > 1)
            selectBox.remove(1);
    }
}

function getProvince() {
    removeAllOptions(document.getElementById("province"));
    removeAllOptions(document.getElementById("town"));

    for (let i = 0; i < myArr.length; ++i) {
        if (document.getElementById("region").value == myArr[i].idRegione) {
            if (document.getElementById("divProvince").style.visibility == "hidden")
                document.getElementById("divProvince").style.visibility = "visible";
            let newoption = document.createElement("option");
            newoption.textContent = myArr[i].nomeProvincia;
            document.getElementById("province").add(newoption);
        }
    }
}

function getTown() {
    removeAllOptions(document.getElementById("town"));

    for (let i = 0; i < myArr.length; ++i) {
        if (document.getElementById("province").value == myArr[i].nomeProvincia) {
            if (document.getElementById("divTown").style.visibility == "hidden")
                document.getElementById("divTown").style.visibility = "visible";
            for (let j = 0; j < myArr[i].comuni.length; ++j) {
                let newoption = document.createElement("option");
                newoption.textContent = myArr[i].comuni[j];
                document.getElementById("town").add(newoption);
            }
        }
    }
}

function getButton() {
    if (document.getElementById("divBut").style.visibility == "hidden")
        document.getElementById("divBut").style.visibility = "visible";
}