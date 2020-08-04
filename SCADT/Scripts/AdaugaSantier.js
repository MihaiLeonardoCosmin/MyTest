var santer = new Array();
var Angajat = new Array();
var Utilaje = new Array();



$("body").on("click", ".santierAdd", function () {
  

    var denumire = $("#Santier").val();
    var adresa = $("#Adresa").val();
    var dataInceperi = $("#DataInceperi").val();
    var termenul = $("#Termenul").val();
    var stagiu = $("#Satgiu").val();

    var santier = {};
    // Data santier
        santier.IdFirma = $("#FirmaId").val(),
        santier.Denumire = denumire;
        santier.Locatie = adresa;
        santier.DataInceperi = dataInceperi;
        santier.DataFinalizari = termenul;
        santier.Stagiu = stagiu;

    santer.push(santier);

    sessionStorage.setItem("denumire", denumire);

    $.ajax({
        type: "post",
        url: "/Santier/CreateSantier",
        data: JSON.stringify(santer),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            console.log("Yes");
        }
    });
    
});



$(".addId").click(function () {
   
 
    $("#tblCustomer TBODY TR").each(function () {
        var row = $(this);
        var customer = {};
        customer.AngajatId = row.find("TD").eq(2).html();
        customer.Firmat = $("#IdFirma").val();
        customer.Santier = $("#Santier").val();
        Angajat.push(customer);
        
    });

    $.ajax({
        type: "POST",
        url: "/Santier/AdaugaAngajati",
        data: JSON.stringify(Angajat),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            console.log("Felicitari");
        }

    });

});

$(".adaugaUtialej").click(function (){
    $("#tblUtilaje TBODY TR").each(function () {
        var row = $(this);
        var castom = {};
        castom.keyUtilaje = row.find("TD").eq(2).html();
        castom.DenumireSantier = $("#Santier").val();
        castom.DenumireFirma = $("#IdFirma").val();
        Utilaje.push(castom);
    });

    $.ajax({
        type: "POST",
        url: "/Santier/UtilajePentruSantier",
        data: JSON.stringify(Utilaje),
        contentType: "application/json charset=utf-8",
        dataType: "json",
        success: function () {
            console.log("Very nice");
        }
    });

});