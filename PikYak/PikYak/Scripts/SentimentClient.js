$(document).ready(function () {

    $('#yakMessage').keyup(function () {

        // Extract text from textarea 
        var text = $('#yakMessage').val();
        console.log(text);

        // Send Messafe to API
        $.ajax({
            url: 'https://community-sentiment.p.mashape.com/text/',
            type: 'POST',
            data: { "txt": text },
            dataType: 'json',
            success: function (data) { success(data); },
            error: function (err) { error(err); },
            beforeSend: function (xhr) {
                xhr.setRequestHeader('X-Mashape-Key', 'J1X1QY5eqlmshw0YH4DZauiMYtrCp1q4DarjsnaIOjcJpl5LRN')
            }


        });

        event.preventDefault();

        function success(data) {
            console.log(data);
            document.getElementById('sentimentWord').innerHTML = data.result.sentiment;
            document.getElementById('sentiment').value = data.result.sentiment;
            document.getElementById('confidence').value = data.result.confidence;
            $("#kindBar").css("width", data.result.confidence + "%");
            $("#sentiment").get(data.result.sentiment);
            $("#confidence").get(data.result.confidence);
            if (data.result.sentiment == "Negative" ) {
                $('#submit').css("visibility", "hidden");
            }
            if (data.result.sentiment != "Negative") {
                $('#submit').css("visibility", "visible");
            }
        }

        function error(err) {
            console.log(err);


        }

        // Update UI with results 
    });


});