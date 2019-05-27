function SalvarWlanTestVerification() {

    debugger;

    //Pedidos
    var sn = $("#SN").val();
    

    var token = $('input[name=__RequestVerificationToken]').val();
    var tokenadr = $('form[action="/WlanTest/WlanTestVerification"]input[name="__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;

    //Gravar dados

    debugger;
    var url = "/WlanTest/WlanTestVerification";
    $.ajax({
        url: url,
        type: "POST",
        datatype: "json",
        headers: headersadr,
        data: { WlanTestVerificationId: 0, SN: sn, __RequestVerificationToken: token },
        success: function (data) {
            if (data.Resultado > 0) {

                ListaDados(data.Resultado);
               
            }
        },
        failure: function (errMsg) {
            alert(errMsg);
        }


    });
}
