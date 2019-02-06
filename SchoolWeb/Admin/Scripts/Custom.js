$(".toggle").click(function () {
   $(".toggle").toggleClass('active'),
   $("#side-nav").toggleClass('active'),
   $("#main-content").toggleClass('active')
});

$(".click").click(function(){
   $(".dropdown-user").toggleClass('active')
});


$('.sidelink').click(function(){
    $('.sidelink').css('color','');
    $('.sidelink').css('background','');
    $(this).css('color', '#fff');
    $(this).css('background','#1E282C')
})


