/*$(document).ready(function(){
    $("#toggle-button").click(function () {
        $("#toggle").toggleClass(function () {
            return 'shownangcao';
        });
    });
});*/
$(document).ready(function () {
	$("#toggle-button").click(function () {
		$("#toggle").toggleClass("shownangcao", 5000);
	});
});
(function ($) {

	"use strict";

	var fullHeight = function () {

		$('.js-fullheight').css('height', $(window).height());
		$(window).resize(function () {
			$('.js-fullheight').css('height', $(window).height());
		});

	};
	fullHeight();

	$('#sidebarCollapse').on('click', function () {
		$('#sidebar').toggleClass('active');
	});

})(jQuery);