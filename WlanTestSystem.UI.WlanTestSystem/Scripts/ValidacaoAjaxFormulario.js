var isError = false;
function OnBeginMethod() {
    $("#labelAjaxStatus").text("Loading ....");
    $("#labelAjaxStatus").css("color", "pink");
}

function OnFailtureMethod(error) {
    $("#labelAjaxStatus").text("Sorry, an error occured." + error.responseText);
    $("#labelAjaxStatus").css("color", "red");
    isError = true;
}

function OnSuccessMethod(data) {
    $("#labelAjaxStatus").text("Processed the data Successfully!");
    $("#labelAjaxStatus").css("color", "green");
    $("#SN").val('');
    
   
}

function OnCompleteMethod(data, status) {
    if (!isError) {
        $("#labelAjaxStatus").text("Request completed! " );
        $("#labelAjaxStatus").css("color", "yellon");
        
    }
}

function ContarDados() {
    $.ajax({
        url: '@Url.Action("ContarRegistros", "WlanTest")',
        success: function (Total) {
            $("#divCount").html(Total);
        }
    });
}

