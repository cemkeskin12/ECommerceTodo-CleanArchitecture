// Demo 30 Js file
$(document).ready(function () {
    'use strict';

    // Notification

    $('.notify-action a').on('click', function() {
    	$('.notification').slideUp(400);
    });

    // Parallax

    window.addEventListener('scroll', function() {
        var parallax = $('.bg-parallax')[0];
        var y = ( parallax.offsetTop - this.window.pageYOffset ) * 300 / parallax.offsetTop + 50;;
        $(parallax).css("background-position-y", y + '%');
    });
});