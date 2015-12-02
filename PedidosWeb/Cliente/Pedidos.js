$(document).ready(function () {
    $("#MainContent_txtPrecoProduto").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
    $("#MainContent_txtQuantidadeProduto").maskMoney({ allowNegative: true, thousands: '', decimal: ',', affixesStay: false, precision: 3 });    
    $("#MainContent_txtDataEntrega").mask('00/00/0000');
});

var prm = Sys.WebForms.PageRequestManager.getInstance();

prm.add_endRequest(function () {
    $(document).ready(function () {
        $("#MainContent_txtPrecoProduto").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });
        $("#MainContent_txtQuantidadeProduto").maskMoney({ allowNegative: true, thousands: '', decimal: ',', affixesStay: false, precision: 3 });        
        $("#MainContent_txtDataEntrega").mask('00/00/0000');
    });
});