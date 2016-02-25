$(document).ready( function() {



	/*----------------------------/
	/* HERO UNIT
	/*---------------------------*/

	if($('#carousel-hero-animated').length > 0) {
			$('#carousel-hero-animated').carousel({
				interval: 4000
			})
			.on( 'slide.bs.carousel', function(slide) {
			$(this).find('.item .hero-right img').removeClass('bounceOutRight');
			$(this).find('.item.active .hero-right img').addClass('bounceOutRight');
		});
	}


	// indicate mobile browser
	var ua = navigator.userAgent,
	isMobileWebkit = /WebKit/.test(ua) && /Mobile/.test(ua);

	if (isMobileWebkit) {
		$('html').addClass('mobile');
	}

});

