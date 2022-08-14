$(function () {

    "use strict";

    // Main navigation & mega menu
    // ----------------------------------------------------------------

    // Global menu variables

    var objSearch = $('.search-wrapper'),
        objLogin = $('.login-wrapper'),
        objCart = $('.cart-wrapper'),
        objMenu = $('.floating-menu'),
        objMenuLink = $('.floating-menu a'),
        $search = $('.open-search'),
        $login = $('.open-login'),
        $cart = $('.open-cart'),
        $menu = $('.open-menu'),
        $openDropdown = $('.open-dropdown'),
        $close = $('.close-menu'),
        $settingsItem = $('.nav-settings .nav-settings-list li');

    // Open/close login

    $login.on('click', function () {
        toggleOpen($(this));
        objLogin.toggleClass('open');
        closeSearch();
        closeCart();
    });

    // Open/close search bar

    $search.on('click', function () {
        toggleOpen($(this));
        objSearch.toggleClass('open');
        objSearch.find('input').focus();
        closeLogin();
        closeCart();
    });

    // Open/close cart

    $cart.on('click', function () {
        toggleOpen($(this));
        objCart.toggleClass('open');
        closeLogin();
        closeSearch();
    });

    // Settings language & currency dropdown

    $settingsItem.on('click', function () {
        var $value = $(this).closest('.nav-settings').find('.nav-settings-value');
        $value.text($(this).text());
    });


    // Mobile menu open/close

    $menu.on('click', function () {
        objMenu.addClass('expanded');
        closeSearch();
        closeLogin();
        closeCart();
    });

    // Floating menu hyperlink
    if ($('nav').hasClass('navbar-single-page')) {
        objMenuLink.on('click', function () {
            objMenu.removeClass('expanded');
        });
    }

    // Open dropdown/megamenu

    $openDropdown.on('click', function (e) {

        e.preventDefault();

        var liParent = $(this).parent().parent(),
            liDropdown = liParent.find('.navbar-dropdown');

        liParent.toggleClass('expanded');

        if (liParent.hasClass('expanded')) {
            liDropdown.slideDown();
        }
        else {
            liDropdown.slideUp();
        }
    });

    // Close menu (mobile)

    $close.on('click', function () {
        $('nav').find('.expanded').removeClass('expanded');
        $('nav').find('.navbar-dropdown').slideUp();
    });

    // Global functions

    function toggleOpen(el) {
        $(el).toggleClass('open');
    }

    function closeSearch() {
        objSearch.removeClass('open');
        $search.removeClass('open');
    }
    function closeLogin() {
        objLogin.removeClass('open');
        $login.removeClass('open');
    }
    function closeCart() {
        objCart.removeClass('open');
        $cart.removeClass('open');
    }

    // Sticky header
    // ----------------------------------------------------------------

    var navbarFixed = $('nav.navbar-fixed');

    // When reload page - check if page has offset
    if ($(document).scrollTop() > 94) {
        navbarFixed.addClass('navbar-sticked');
    }
    // Add sticky menu on scroll
    $(document).on('bind ready scroll', function () {
        var docScroll = $(document).scrollTop();
        if (docScroll >= 10) {
            navbarFixed.addClass('navbar-sticked');
        } else {
            navbarFixed.removeClass('navbar-sticked');
        }
    });

    // Tooltip
    // ----------------------------------------------------------------

    $('[data-toggle="tooltip"]').tooltip();

    // Main popup
    // ----------------------------------------------------------------

    $('.mfp-open').magnificPopup({
        type: 'inline',
        fixedContentPos: false,
        fixedBgPos: true,
        overflowY: 'hidden',
        closeBtnInside: true,
        preloader: true,
        midClick: true,
        removalDelay: 300,
        mainClass: 'my-mfp-zoom-in',
        callbacks: {
            open: function () {
                // wait on popup initalization
                // then load owl-carousel
                $('.popup-main .owl-carousel').hide();
                setTimeout(function () {
                    $('.popup-main .owl-carousel').show();
                }, 50);

            }
        }
    });

    // Main popup gallery
    // ----------------------------------------------------------------

    $('.open-popup-gallery').magnificPopup({
        delegate: 'a',
        type: 'image',
        tLoading: 'Loading image #%curr%...',
        gallery: {
            enabled: true,
            navigateByImgClick: true,
            preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
        },
        fixedContentPos: false,
        fixedBgPos: true,
        overflowY: 'auto',
        closeBtnInside: true,
        preloader: false,
        midClick: true,
        removalDelay: 300,
        mainClass: 'my-mfp-zoom-in'
    });


    // Frontpage slider
    // ----------------------------------------------------------------

    var arrowIcons = [
        '<span class="icon icon-chevron-right"></span>',
        '<span class="icon icon-chevron-left"></span>'
    ];


    $.each($(".owl-slider"), function (i, n) {

        var $n = $(n);

        $n.owlCarousel({
            autoplay: $n.data("autoplay"),
            autoplayTimeout: 6000,
            autoplayHoverPause: true,
            rtl:true,
            items: 1,
            loop: true,
            // spacing
            margin: 10,
            stagePadding: 0,
            // navigation
            nav: true,
            dots: false,
            navText: arrowIcons,
            // animation effects
            smartSpeed: 950,
            onTranslated: startAnimation,
            onTranslate: resetAnimation,
            animateIn: 'fadeIn',
            animateOut: 'fadeOut'
        });

        resetAnimation(); // reset effects all on initalization
        startAnimation(); // start animation on first slide

        function startAnimation(event) {
            // find active slide
            var activeItem = $(n).find('.owl-item.active'),
                timeDelay = 100;

            $.each(activeItem.find('.animated'), function (j, m) {
                // catch active slide
                var item = $(m);
                item.css('animation-delay', timeDelay + 'ms');
                timeDelay = timeDelay + 180;
                // add animation
                item.removeClass('fadeOut');
                item.addClass(item.data('start'));
            });
        }

        function resetAnimation(event) {
            // catch all slides
            var items = $(n).find('.owl-item');
                // for each add animation end
                $.each(items.find('.animated'), function (j, m) {
                    var item = $(m);
                    item.removeClass(item.data('start'));
                    item.addClass('fadeOut');
                });
        }
        var navHeight = $('nav').height();

        if ($(n).hasClass('owl-slider-fullscreen')) {
            $('.header-content .item').height($(window).height() - navHeight);
        }

    });


    $.each($(".owl-icons"), function (i, n) {

        $(n).owlCarousel({
            items: 6,
            loop: true,
            // spacing
            margin: 0,
            stagePadding: 0,
            // navigation
            nav: true,
            dots: false,
            navText: arrowIcons,
            // animation effects
            smartSpeed: 950,
            responsive: {
                0: {
                    items: $(n).data("icons-sm"),
                    nav: true
                },
                600: {
                    items: $(n).data("icons-md"),
                    nav: false
                },
                1000: {
                    items: $(n).data("icons-lg"),
                    nav: true,
                    loop: false
                }
            }
        });

    });

    $.each($(".owl-product-gallery"), function (i, n) {

        $(n).owlCarousel({
            items: 1,
            loop: true,
            rtl:true,
            // spacing
            margin: 0,
            stagePadding: 0,
            // navigation
            nav: true,
            dots: false,
            navText: arrowIcons,
            // animation effects
            smartSpeed: 950
        });

    });

    // Scroll to top
    // ----------------------------------------------------------------

    var $wrapper = $('.wrapper');
    $wrapper.append($("<div class='scroll-top'><i class='icon icon-chevron-up'></i></div>"));

    var $scrollbtn = $('.scroll-top');

    $(document).on('ready scroll', function () {
        var docScrollTop = $(document).scrollTop(),
            docScrollBottom = $(window).scrollTop() + $(window).height() === $(document).height();

        if (docScrollTop >= 150) {
            $scrollbtn.addClass('visible');
        } else {
            $scrollbtn.removeClass('visible');
        }
        if (docScrollBottom) {
            $scrollbtn.addClass('active');
        }
        else {
            $scrollbtn.removeClass('active');
        }
    });

    $scrollbtn.on('click', function () {
        $('html,body').animate({
            scrollTop: $('body').offset().top
        }, 1000);
        return false;
    });

    // Product color var
    // ----------------------------------------------------------------

    $.each($('.product-colors'), function (i, n) {
        var $btn = $('.color-btn');
        $btn.on('click', function () {
            $(this).parent().find($btn).removeClass('checked');
            $(this).addClass('checked');
        });
    });

    // Tabsy images
    // ----------------------------------------------------------------

    var tabsyImg = $('.tabsy .tabsy-images > div'),
        tabsyLink = $('.tabsy .tabsy-links figure');

    // apply images to parent background
    tabsyImg.each(function (i, n) {
        $(n).css('background-image', 'url(' + $(n).find('img').attr('src') + ')');
    });

    tabsyLink.on('mouseenter', function () {
        var self = $(this),
            tabID = self.attr('data-image');
        tabsyLink.removeClass('current');
        tabsyImg.removeClass('current');
        self.addClass('current');
        self.closest('.tabsy').find("#" + tabID).addClass('current');
    });




    // Add to favorites list / product list
    // ----------------------------------------------------------------

    $('.add-favorite').on('click', function () {
        $(this).toggleClass("added");
    });

    $('.info-box-addto').on('click', function () {
        $(this).toggleClass('added');
    });

    // Filters toggle functions
    // ----------------------------------------------------------------

    // Check if some filter boxes has class active
    // then show hidden filters
    $('.filters .filter-box').each(function () {
        if ($(this).hasClass('active')) {
            $(this).find('.filter-content').show();
        }
    });

    // Toggle filter function
    $('.filters .title').on('click', function (e) {
        var $this = $(this),
            $parent = $this.parent();
        $parent.toggleClass('active');

        if ($parent.hasClass('active')) {
            $parent.find('.filter-content').slideDown(300);
        }
        else {
            $parent.find('.filter-content').slideUp(200);
        }
    });

    // Update filter results - close dropdown filters
    // ----------------------------------------------------------------

    $('.filters .filter-update').on('click', function (e) {
        $(this).closest('.filter-box')
            .removeClass('active')
            .find('.filter-content').slideUp(200);
    });

    // Show hide filters (only for mobile)
    // ----------------------------------------------------------------

    $('.toggle-filters-mobile').on('click', function () {
        $('.filters').addClass('active');
    });
    $('.toggle-filters-close').on('click', function () {
        $('.filters').removeClass('active');
        $('html,body').animate({
            scrollTop: $('body').offset().top
        }, 800);
        return false;
    });


    // Strecher accordion
    // ----------------------------------------------------------------

    var $strecherItem = $('.stretcher-item');
    $strecherItem.on({
        mouseenter: function (e) {
            $(this).addClass('active');
            $(this).siblings().addClass('inactive');
        },
        mouseleave: function (e) {
            $(this).removeClass('active');
            $(this).siblings().removeClass('inactive');
        }
    });

    // Blog image caption
    // ----------------------------------------------------------------

    var $blogImage = $('.blog-post-text img');
    $blogImage.each(function () {
        var $this = $(this);
        $this.wrap('<span class="blog-image"></span>');
        if ($this.attr("alt")) {
            var caption = this.alt;
            var link = $this.attr('data');
            $this.after('<span class="caption">' + caption + '</span>');
        }
    }); 

    // Coupon code 
    // ----------------------------------------------------------------

    $(".form-coupon").hide();
    $("#couponCodeID").on('click', function () {
        if ($(this).is(":checked")) {
            $(".form-coupon").fadeIn();
        } else {
            $(".form-coupon").fadeOut();
        }
    });
     
    // Checkout login / register
    // ----------------------------------------------------------------

    var loginWrapper = $('.login-wrapper'),
        loginBtn = loginWrapper.find('.btn-login'),
        regBtn = loginWrapper.find('.btn-register'),
        signUp = loginWrapper.find('.login-block-signup'),
        signIn = loginWrapper.find('.login-block-signin');

    loginBtn.on('click', function () {
        signIn.slideDown();
        signUp.slideUp();
    });

    regBtn.on('click', function () {
        signIn.slideUp();
        signUp.slideDown();
    });

    // Range slider
    // ----------------------------------------------------------------

    $("#range-price-slider").ionRangeSlider({
        type: "double",
        min: 0,
        max: 2000,
        //grid: true,
        from: 500,
        to: 1500,
        prefix: "تومان"
        //force_edges: true
    });

    // Team members hover effect
    // ----------------------------------------------------------------

    var $member = $('.team article');
    $member.on({
        mouseenter: function (e) {
            $member.addClass('inactive');
            $(this).addClass('active');
        },
        mouseleave: function (e) {
            $member.removeClass('inactive');
            $(this).removeClass('active');
        }
    });

    // Single page navigation (scroll to)
    // ----------------------------------------------------------------

    if ($('nav').hasClass('navbar-single-page')) {

        var $singleHyperlink = $('.navigation-main a');

        $singleHyperlink.on('click', function () {

            $singleHyperlink.removeClass('current');

            $(this).addClass('current');

            $('html, body').animate({
                scrollTop: $($(this).attr('href')).offset().top - $('.navigation-main').height()
            }, 500);
            return false;
        });

        // Magnific popup scroll to content
        // ----------------------------------------------------------------

        $('.mfp-open-scrollto').on('click', function () {
            $('html,body').animate({
                scrollTop: $('.mfp-content').offset().top - 200
            }, 300);
            return false;
        });
    }

    // Easy pie chart
    // ----------------------------------------------------------------

    $('.chart').easyPieChart({
        easing: 'easeOutBounce',
        onStep: function (from, to, percent) {
            $(this.el).find('.percent').text(Math.round(percent));
        },
        barColor: '#ffdc11',
        trackColor: '#dddddd',
        lineCap: 'square',
        lineWidth: 4,
        scaleLength: 0,
        size: 80
    });

    // Hover3d
    // ----------------------------------------------------------------

    if ($(window).width() > 1200) {
        $('[data-3d]').tilt({
            glare: true,
            maxTilt: 3,
            maxGlare: 1
        });

    }

    // Set Big Text
    // ----------------------------------------------------------------

    $('.big-text').bigtext();

});

$(window).on('load', function () {

    // Set timeout for page loader

    setTimeout(function () {
        $('.page-loader').addClass('loaded');
    }, 1000);


    // Adjust height of tabsy gallery

    if ($(window).width() > 992) {
            $(window).on('resize', function () {
                //adjustTabsyHeight();
            });

            //adjustTabsyHeight();

            // Height function

            //function adjustTabsyHeight() {
            //    var navheight = $('nav').height(),
            //        icoheight = $('.owl-icons-wrapper').height();

            //    // Set tabsy height
            //    $('.tabsy-wrapper-intro .tabsy figure').css("height", $(window).height() - navheight - icoheight);

            //}
    }

});



