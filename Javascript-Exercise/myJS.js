function loadData() {
    let now = new Date().toLocaleDateString();
    document.getElementById("engDate").value = now;
}

function convertDateToItFormat(str) {
    var engDate;
    if (str.indexOf("-") > -1) {
        engDate = str.split("-");
    } else if (str.indexOf("/") > -1) {
        engDate = str.split("/");
    } else {
        alert("Wrong Format!");
    }
 
    [engDate[0], engDate[1]] = [engDate[1], engDate[0]]; // Just a swap
    engDate = engDate.join("-");
    document.getElementById("itDate").innerHTML = engDate;

    let a = new Date();
}