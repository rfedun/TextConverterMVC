///<reference path="../jquery-2.2.3.js" />

function GetConvertedText() {    
    $.ajax({        
        type: "POST",
        url: "/api/textconverter",
        data: $('form').serialize(),
        success: function (data) {
            $('#converted_text').text(data);
        }
    });
}

$().ready(function () {    
    $('#autoconverting').click(function() {
        var thisCheck = $(this);
        if (thisCheck.is(':checked')) {
            $('.input-text-area').bind('input propertychanged', function () {
                GetConvertedText();
            })
        }
        else {
            $('.input-text-area').unbind('input propertychanged');
        }
    })
});
