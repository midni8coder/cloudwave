
function SearchMoviesByName(control) {
    var query = $("#searchBox").val();
    if (query == "") {
        alert("Enter some text and hit Search button");
        return;
    }
    $("#SearchButton").text('Searching').attr('disabled','disabled');
    var url = window.location.href + "Home/GetMoviesByName";
    $.ajax({
        data: { query: query },
        method: 'GET',
        url: url,
        success: function (data) {
            if (data != "") {
                $('#divSearchResults').empty();
                $('#divSearchResults').html(data).show();
            }
            $("#SearchButton").text('Search').removeAttr('disabled');
        },
        error: function (a, b, c) {
            $("#SearchButton").text('Search').removeAttr('disabled');
        }
    });
}

function GetMovieDetailsByID(id) {
    var url = window.location.href + "Home/GetMovieDetailsByID?id=" + id;
    window.open(url, "_blank");
}