////backTop
//var back = $('#back-top');
//$(window).scroll(function () {
//    if ($(this).scrollTop() > 130) {
//        back.show();
//    } else {
//        back.hide();
//    }
//});
//back.on('click', function () {
//    $('html,body').animate({scrollTop: 0}, 2000);
//});


// Check distance to top and display back-to-top.
$(window).scroll(function () {
    if ($(this).scrollTop() > 800) {
        $('#back-top').addClass('show-back-top');
    } else {
        $('#back-top').removeClass('show-back-top');
    }
});

// Click event to scroll to top.
$('#back-top').click(function () {
    $('html, body').animate({ scrollTop: 0 }, 800);
    return false;
});


