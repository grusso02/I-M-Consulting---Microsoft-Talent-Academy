function takeDate() {
    const input = prompt("Insert English Date");
    document.getElementById("ItalianDate").innerHTML = input;

    var engDate;
    if (input.match(/-/g).length == 2) {
        engDate = input.split("-");
    } else if (input.match().length == 2) {
        engDate = input.split("/");
    } else {
        engDate = "Errore!";
    }

    [engDate[0], engDate[1]] = [engDate[1], engDate[0]]; // Just a swap
    let engDate2 = engDate.join("-");
    document.getElementById("EnglishDate").innerHTML = engDate2;
}