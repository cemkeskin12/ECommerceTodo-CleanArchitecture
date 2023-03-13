$(document).ready(function () {
    if ($.fn.themePluginSectionScroll) {
        $('body').themePluginSectionScroll();
    }

    if ( $(window).width() <= '575' ) {
        if ( $.fn.hoverIntent ) {
            $('.product-27').hover(function () {
                var $this = $(this);
                    animDistance = $this.find('.product-body').outerHeight() + $this.find('.ratings-container').outerHeight();
    
                $this.find('.product-body').css('transform', 'translateY('+ - animDistance +'px)');
            }, function () {
                var $this = $(this);
    
                $this.find('.product-body').css('transform', 'translateY(0)');
            });
        }
     
    } else {
        if ( $.fn.hoverIntent ) {
            $('.product-27').hoverIntent(function () {
                var $this = $(this),
                    animDistance = ( $this.find('.product-body').outerHeight() + $this.find('.product-footer').outerHeight());
    
                $this.find('.product-body').css('transform', 'translateY('+ - animDistance +'px)');
    
            }, function () {
                var $this = $(this);
    
                $this.find('.product-body').css('transform', 'translateY(0)');
            });
        }
    }   

    var $scrollTop = $('#scroll-top');

    $scrollTop.on('click', function (e) {
        var $item = $('.section-scroll-nav .list.list-unstyled').find('li'),
             $active = $item.eq(0),
             $length = $item.length;

        $active.addClass('active');

        for (var i = $length ; i > 0 ; i--) {
            var $dot = $item.eq(i); 

            $dot.hasClass('active') ? $dot.removeClass('active') : '';
        }
    });
});
