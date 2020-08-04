
$("#btnAdd").click(function () {
    var tbody = $("#tblCustomer > TBODY")[0];
    var row = tbody.insertRow(-1); 
    var cell = $(row.insertCell(-1));
    cell.html($(".angajat option:selected").text());

    cell = $(row.insertCell(-1));
    var btn = $("<input />");
    btn.attr("type", "button");
    btn.attr("onclick", "Remove(this)");
    btn.val("Sterge");
    cell.append(btn);
     
    cell = $(row.insertCell(-1));
    cell.html($(".angajat").val()).addClass("hide");
});
 

$("body").on("click", "#btnAddUtilaje", function () {
    var tablebody = $("#tblUtilaje > TBODY")[0];
    var rand = tablebody.insertRow(-1);
    var cell = $(rand.insertCell(-1));
    cell.html($(".utilaj option:selected").text());

    cell = $(rand.insertCell(-1));
    var btn = $("<input />");
    btn.attr("type", "button");
    btn.attr("onclick", "Delete(this)");
    btn.val("Sterge");
    cell.append(btn);

    cell = $(rand.insertCell(-1));
    cell.html($(".utilaj").val()).addClass("hide");

});

function Delete(button) {
    var row = $(button).closest("TR");
    var nume = $("TD", row).eq(0).html();
    if (confirm("Vrei sa scoti utilajul de pe santier")) {
        var table = $("#tblUtilaje")[0];
        table.deleteRow(row[0].rowIndex);
    }
}

function Remove(button) {
    var row = $(button).closest("TR");
    var nume = $("TD", row).eq(0).html();
    if (confirm("Vrei sa stergi angajatul de pe santier")) {
        var table = $("#tblCustomer")[0];
        table.deleteRow(row[0].rowIndex);
    }
};