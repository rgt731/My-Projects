
$(document).ready(function () {

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(success, error);
    }
    else {
        // browser doesn't support geolocation 
    }

    function success(position) {
        document.getElementById("lat").value = position.coords.latitude;
        document.getElementById("long").value = position.coords.longitude;
        

        var mapcanvas = document.createElement('div');
        mapcanvas.id = 'mapcanvas';
        mapcanvas.style.height = '400px';
        mapcanvas.style.width = '100%';

        document.querySelector('#map').appendChild(mapcanvas);

        var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
        var myOptions = {
            zoom: 15,
            center: latlng,
            mapTypeControl: false,
            navigationControlOptions: { style: google.maps.NavigationControlStyle.SMALL },
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("mapcanvas"), myOptions);

        var marker = new google.maps.Marker({
            position: latlng,
            map: map,
            title: "You are here! (accuracy of " + position.coords.accuracy + " meter radius.)"
        });

    }

    function error(err) {
        console.log(err.message);
    }
})