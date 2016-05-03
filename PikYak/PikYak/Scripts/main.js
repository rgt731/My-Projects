

$(document).ready(function () {
    //starts materialize up??
    $.material.init()


    //If someones browser supports geolocation do this
    if (navigator.geolocation) {
        //calls function success 
        navigator.geolocation.getCurrentPosition(success, error);
    }
    else {
        // browser doesn't support geolocation 
    }


    function success(position) {
        //gets Id lat and long and assigns them to the current position for indiviudals latitude and longitude
        document.getElementById("lat").innerHTML = position.coords.latitude;
        document.getElementById("long").innerHTML = position.coords.longitude; 
    }


        function error (err) {
            console.log(err.message);
              }
})