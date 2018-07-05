$(document).ready(function () {

    $("#inv").change(function () {
        alert("Changed");
    });

    $(".myLink").click(function (e) {
        e.preventDefault();
        $.ajax({

            url: $(this).attr("href"), // comma here instead of semicolon   
            success: function () {
                alert("Value Added");  // or any other indication if you want to show
            }

        });
    });
});

$("asdf").click(function () {

    e.preventDefault();
    $.ajax({

        url: $(this).attr("href"), // comma here instead of semicolon   
        success: function () {
            alert("Value Added");  // or any other indication if you want to show
        }

    });

});

function addToCart()
{
    
}