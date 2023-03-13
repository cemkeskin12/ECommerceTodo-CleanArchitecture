
/*
Plugin Name:    Animated Headlines
Written by:     Codyhouse - (https://codyhouse.co/demo/animated-headlines/index.html)
*/
jQuery(document).ready(function($) {
    //set animation timing
    var animationDelay = 3000,
        //letters effect
        lettersDelay = 50;

    initHeadline();

    function initHeadline() {
        //insert <i> element for each letter of a changing word
        singleLetters($('.word-rotator.letters').find('b'));
        //initialise headline animation

        // $('.word-rotator').each(function() {
        //     var $this = $(this);

        //     var defer_rotate = (function() {
        //         var deferred = $.Deferred();
        //         if ( ! $this.closest('.appear-animate').length ) {
        //             deferred.resolve();
        //         } else {
        //             var $appearItem = $this.closest('.appear-animate'),
        //                 time = 0,
        //                 options = $appearItem.attr('data-appear-options');

        //             if (typeof options == 'string') {
        //                 options = JSON.parse(options.replace(/'/g,'"').replace(';',''));
        //             }

        //             time += ( undefined == options.delay ? 0 : options.delay );
        //             time += ( undefined == options.duration ? 1500 : options.duration );

        //             $appearItem.appear(function() {
        //                 setTimeout(function() {
        //                     deferred.resolve();
        //                 }, time )
        //             });
        //         }
        //         return deferred.promise();
        //     })();
        //     $.when(defer_rotate).done(function(e) {
        //         animateHeadline($this);
        //     });
        // })

        animateHeadline($('.word-rotator'));
    }

    function singleLetters($words) {
        $words.each(function() {
            var word = $(this),
                letters = word.text().split(''),
                selected = word.hasClass('is-visible');
            for (i in letters) {
                letters[i] = (selected) ? '<i class="in">' + letters[i] + '</i>' : '<i>' + letters[i] + '</i>';
            }
            var newLetters = letters.join('');
            word.html(newLetters).css('opacity', 1);
        });
    }

    function animateHeadline($headlines) {
        var duration = animationDelay;
        $headlines.each(function() {
            var headline = $(this);

            if (!headline.hasClass('type')) {
                //assign to .word-rotator-words the width of its longest word
                var words = headline.find('.word-rotator-words b'),
                    width = 0;
                words.each(function() {
                    var wordWidth = $(this).outerWidth();
                    if (wordWidth > width) width = wordWidth;
                });
                headline.find('.word-rotator-words').css('width', width);
            };

            //trigger animation
            setTimeout(function() {
                hideWord(headline.find('.is-visible').eq(0))
            }, duration);
        });
    }

    function hideWord($word) {
        var nextWord = takeNext($word);

        var bool = ($word.children('i').length >= nextWord.children('i').length) ? true : false;
        hideLetter($word.find('i').eq(0), $word, bool, lettersDelay);
        showLetter(nextWord.find('i').eq(0), nextWord, bool, lettersDelay);
    }

    function hideLetter($letter, $word, $bool, $duration) {
        $letter.removeClass('in').addClass('out');

        if (!$letter.is(':last-child')) {
            setTimeout(function() {
                hideLetter($letter.next(), $word, $bool, $duration);
            }, $duration);
        } else if ($bool) {
            setTimeout(function() {
                hideWord(takeNext($word))
            }, animationDelay);
        }
    }

    function showLetter($letter, $word, $bool, $duration) {
        $letter.addClass('in').removeClass('out');

        if (!$letter.is(':last-child')) {
            setTimeout(function() {
                showLetter($letter.next(), $word, $bool, $duration);
            }, $duration);
        } else {
            if (!$bool) {
                setTimeout(function() {
                    hideWord($word)
                }, animationDelay)
            }

            $word.closest('.word-rotator-words').stop( true, true ).animate({
                width: $word.outerWidth()
            });
        }
    }

    function takeNext($word) {
        return (!$word.is(':last-child')) ? $word.next() : $word.parent().children().eq(0);
    }

    function takePrev($word) {
        return (!$word.is(':first-child')) ? $word.prev() : $word.parent().children().last();
    }
});