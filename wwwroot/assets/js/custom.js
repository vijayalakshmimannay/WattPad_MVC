(function($) {
    'use strict';
    
    //mean-menu
    $('.mean-menu').meanmenu({
        meanScreenWidth: "991"
    });

    //sticky
    $(window).scroll(function(){
        if($(this).scrollTop() > 100){
            $('.navbar-area').addClass('sticky')
        } else{
            $('.navbar-area').removeClass('sticky')
        }
    });

    // Others Option For Responsive JS
	$(".others-option-for-responsive .dot-menu").on("click", function(){
		$(".others-option-for-responsive .container .container").toggleClass("active");
	});

    //hero slider
    $('.hero-slider').owlCarousel({
        loop:true,
        margin:0,
        nav:false,
        dots:true,
        items:1,
        autoplay:true,
        smartSpeed: 1000,
        autoplayHoverpause:true,
    });

    //future-slider
    $('.future-slider').owlCarousel({
        loop:true,
        margin:20,
        nav:false,
        dots:true,
        items:4,
        smartSpeed: 500,
        responsive:{
            0:{
                items:1, 
            },
            768:{
                items:2,
            },
            992:{
                items:3,
            },
            1200:{
                items:4,
            },
                
        }
    });

    //*biography-slider
    $('.biography-slider').owlCarousel({
        loop:true,
        margin:0,
        nav:false,
        dots:false,
        items:1,
        autoplay: true,
        smartSpeed: 500,
    });

    //testimonial-slider
    $('.testimonial-slider').owlCarousel({
        loop:true,
        margin:20,
        nav:false,
        dots:true,
        autoplay:true,
        smartSpeed: 500,
        autoplayHoverpause:true,
        responsive:{
            0:{
                items:1, 
            },
            768:{
                items:2,
            },
            992:{
                items:3,
            },
            1200:{
                items:3,
            },
                
        }
    });

    //testimonial-slider 2
    $('.testimonial-slider2').owlCarousel({
        loop:true,
        margin:20,
        nav:false,
        dots:true,
        autoplay:true,
        smartSpeed: 500,
        autoplayHoverpause:true,
        responsive:{
            0:{
                items:1, 
            },
            768:{
                items:1,
            },
            992:{
                items:3,
            },
            1200:{
                items:2,
            },
                
        }
    });

    //Events-slider
    $('.events-slider').owlCarousel({
        loop:true,
        margin:20,
        nav:false,
        dots:true,
        autoplay:true,
        smartSpeed: 500,
        autoplayHoverpause:true,
        responsive:{
            0:{
                items:1, 
            },
            768:{
                items:1,
            },
            1200:{
                items:2,
            },
                
        }
    });

    // Main Slider
    $('.main-slider').owlCarousel({
        loop:true,
        margin:0,
        nav:true,
        dots:false,
        items:1,
        autoplay:true,
        smartSpeed: 1000,
        autoplayHoverpause:true,
        navText: [
            '<i class="ri-arrow-left-line"></i>', 
            '<i class="ri-arrow-right-line"></i>',  
        ],
    });

    //Odometer js
    $('.odometer').appear(function(e) {
        var odo = $(".odometer");
        odo.each(function() {
            var countNumber = $(this).attr("data-count");
            $(this).html(countNumber);
        });
    });

    //popup
    $(document).ready(function() {
        $('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
            disableOn: 100,
            type: 'iframe',
            mainClass: 'mfp-fade',
            removalDelay: 160,
            preloader: false,
            fixedContentPos: false
        });
    });

    //Animation
    new WOW().init();

    //AOS animation
    AOS.init({
        disable: function() {
          var maxWidth = 991;
          return window.innerWidth < maxWidth;
        }
    });

    // Go to Top
    $(window).on('scroll', function(){
    var scrolled = $(window).scrollTop();
    if (scrolled > 300) $('.go-top').addClass('active');
    if (scrolled < 300) $('.go-top').removeClass('active');
    });

    // Count Time 
	function makeTimer() {
		var endTime = new Date("September 20, 2024 17:00:00 PDT");			
		var endTime = (Date.parse(endTime)) / 1000;
		var now = new Date();
		var now = (Date.parse(now) / 1000);
		var timeLeft = endTime - now;
		var days = Math.floor(timeLeft / 86400); 
		var hours = Math.floor((timeLeft - (days * 86400)) / 3600);
		var minutes = Math.floor((timeLeft - (days * 86400) - (hours * 3600 )) / 60);
		var seconds = Math.floor((timeLeft - (days * 86400) - (hours * 3600) - (minutes * 60)));
		if (hours < "10") { hours = "0" + hours; }
		if (minutes < "10") { minutes = "0" + minutes; }
		if (seconds < "10") { seconds = "0" + seconds; }
		$("#days").html(days + "<span>Days</span>");
		$("#hours").html(hours + "<span>Hours</span>");
		$("#minutes").html(minutes + "<span>Minutes</span>");
		$("#seconds").html(seconds + "<span>Seconds</span>");
	}
	setInterval(function() { makeTimer(); }, 0);

    // Preloader JS
	$(window).on('load',function(){
		$(".preloader").fadeOut(500);
	});

    // Search Popup JS
	$('.close-btn').on('click',function() {
		$('.search-overlay').fadeOut();
		$('.search-btn').show();
		$('.close-btn').removeClass('active');
	});
	$('.search-btn').on('click',function() {
		$(this).hide();
		$('.search-overlay').fadeIn();
		$('.close-btn').addClass('active');
	})

    // Click Event
    $('.go-top').on('click', function() {
        $("html, body").animate({ scrollTop: "0" },  500);
    });  

    // Subscribe form JS
    $(".newsletter-form").validator().on("submit", function (event) {
        if (event.isDefaultPrevented()) {
        // handle the invalid form...
            formErrorSub();
            submitMSGSub(false, "Please enter your email correctly.");
        } else {
            // everything looks good!
            event.preventDefault();
        }
    });
    function callbackFunction (resp) {
        if (resp.result === "success") {
            formSuccessSub();
        }
        else {
            formErrorSub();
        }
    }
    function formSuccessSub(){
        $(".newsletter-form")[0].reset();
        submitMSGSub(true, "Thank you for subscribing!");
        setTimeout(function() {
            $("#validator-newsletter, #validator-newsletter-2").addClass('hide');
        }, 4000)
    }
    function formErrorSub(){
        $(".newsletter-form").addClass("animated shake");
        setTimeout(function() {
            $(".newsletter-form").removeClass("animated shake");
        }, 1000)
    }
    function submitMSGSub(valid, msg){
        if(valid){
            var msgClasses = "validation-success";
        } else {
            var msgClasses = "validation-danger";
        }
        $("#validator-newsletter, #validator-newsletter-2").removeClass().addClass(msgClasses).text(msg);
    }

    // AJAX MailChimp JS
    $(".newsletter-form").ajaxChimp({
        url: "https://Envy Theme.us20.list-manage.com/subscribe/post?u=60e1ffe2e8a68ce1204cd39a5&amp;id=42d6d188d9", // Your url MailChimp
        callback: callbackFunction
    });

})(jQuery);