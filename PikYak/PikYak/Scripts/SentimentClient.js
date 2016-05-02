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

            document.getElementById('sentiment').innerHTML = data.result.sentiment;
            document.getElementById('confidence').innerHTML = data.result.confidence + '%';
            $("#kindBar").css("width", data.result.confidence);
        }

        function error(err) {
            console.log(err);


        }


        // Update UI with results 
    });


});