var ContactPage = function () {

    return {
        
    	//Basic Map
        initMap: function () {
			var map;
			$(document).ready(function(){
			  map = new GMaps({
				div: '#map',
				scrollwheel: false,
				lat: 43.853820,
				lng: -79.338293
			  });
			  
			  var marker = map.addMarker({
			      lat: 43.853820,
			      lng: -79.338293,
	            title: 'Tweebaa Inc.'
		       });
			});
        },

        //Panorama Map
        initPanorama: function () {
		    var panorama;
		    $(document).ready(function(){
		      panorama = GMaps.createPanorama({
		        el: '#panorama',
		        lat : 40.748866,
		        lng : -73.988366
		      });
		    });
		}        

    };
}();