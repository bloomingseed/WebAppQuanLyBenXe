/*$(document).ready(function(){
    $("#toggle-button").click(function () {
        $("#toggle").toggleClass(function () {
            return 'shownangcao';
        });
    });
});*/
$(document).ready(function () {
	$(".none-bg").each(function () {
		detectBg($(this));
	});

	function detectBg(sezione) {
		$(window).scroll(function () {
			var finestra = $(window).scrollTop();
			var sezCurr = sezione.offset().top;
			var sezNext = sezione.next().offset().top;

			if (finestra >= sezCurr && finestra < sezNext) {
				$('.menu__link').css("color", "#ebebeb");
			}
			else {
				$('.menu__link').css("color", "#1c1c1c");
			}
		});
	}
	$("#toogle-button").click(function () {
		$("#toogle").toggleClass("shownangcao", 5000);
	});
	$("#button-find").click(function () {
		//
		var resHolder = $("#result-holder");
		if (resHolder[0].hasChildNodes) {
			resHolder.empty();
		}
		searchBusesAjax();
	});
	$("#data-grid tr").click(function () { updateSelectedRow(this, 1); });
	$("#vtd-data-grid tr").click(function () { updateSelectedRow(this, 0); });
	$("#xk-data-grid tr").click(function () { updateSelectedRow(this, 2); });
	registerQtv0EventHandlers()
	registerQtv1EventHandlers()
	registerQtv2EventHandlers()
});

//get required buses from server
function searchBusesAjax() {
	//
	var diemDi = $("#input-start").val(),
		diemDen = $("#input-stop").val(),
		khoiHanh = $("#input-date").val(),
		args = {
			DiemDi: diemDi,
			DiemDen: diemDen,
			NgayKhoiHanh: khoiHanh
		};
	if ($("#toogle").hasClass("shownangcao")) {
		
		var nhaXe = $("#input-bus").val(),
			soGhe = $("#input-type").val(),
			tg = $("#input-interval").val(),
			giaVe = $("#input-cost").val();
		args.TenNhaXe = nhaXe;
		args.SoGhe = soGhe;
		args.ThoiGianDiChuyenMax = tg;
		args.GiaVeMax = giaVe;
	}

	$.ajax({
		type: 'post',
		dataType: 'json',
		url: '/Home/Search',
		data: args,
		success: (response) => {
			renderXeKhachJson(response);
			$("#result-holder")[0].scrollIntoView(true);
		},
		error: (response) => {
			console.log("Error: " + response);
		}
	});
}

//
function updateSelectedRow(row, start) {
	//debugger;
		let selectedRow = $(".selected-row");
		if (selectedRow.length != 0) {
			selectedRow.toggleClass("selected-row")
			let selectedCols = selectedRow.find("input")
			for (let i = start; i < selectedCols.length; ++i)
				selectedCols[i].setAttribute("readonly","")

		}
	selectedRow = $(row);
	selectedRow.toggleClass("selected-row")
	let selectedCols = selectedRow.find("input")
	for (let i = start; i < selectedCols.length; ++i)
		selectedCols[i].removeAttribute("readonly")
}

//render the returned xe khach json object
function renderXeKhachJson(jsonArray) {
	var jResHolder = $("#result-holder")
	if (jsonArray.length == undefined) {
		jResHolder.append($("<div class='text-info'></div>").html("Không tìm thấy xe khách như yêu cầu"))
		return
	}	
	var elHtml = '<div class="col-sm-12 col-md-12 col-lg-12 col-xl-12"></div>'
		+ '<div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 d-sm-flex justify-content-sm-center align-items-sm-center"></div>'
		+ '<div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 text-dark d-sm-flex justify-content-sm-center"></div>'
		+ '<div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6"></div>'
		+ '<div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4"></div>'
		+ '<div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4"></div>'
		+ '<div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4"></div>'
		+ '<div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4"></div>'
		+ '<div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4"></div>'
		+ '<div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4"></div>'
		+ '<div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 d-xl-flex justify-content-xl-end"></div>',
		ctnerHtml = "<div class = 'row border'></div>";
	for (let xeKhach of jsonArray) {
		
		var curr = $(ctnerHtml),
			elArr = $.parseHTML(elHtml);
		var i = 0;

		var worker = $('<h3 class="d-sm-flex justify-content-sm-center"></h3>').html(xeKhach.maXeKhach);
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Nhà xe: &nbsp;")
			.append($('<a></a>').attr("href", "/home/nhaxe?id=" + xeKhach.maNhaXe)
				.append($('<h6 class="d-sm-flex justify-content-sm-center align-items-sm-center"></h6>').html(xeKhach.tenNhaXe)));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Tên tài xế: &nbsp;")
			.append($("<a></a>").html(xeKhach.tenTaiXe).attr("href", "/home/taixe?id=" + xeKhach.maTaiXe));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Loại xe: &nbsp;")
			.append($('<span style="font-size: 16px"></span>').html(""+xeKhach.soGhe+" chỗ"));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Điểm đón khách: &nbsp;")
			.append($('<span style="font-size: 16px"></span>').html(xeKhach.diemXuatPhat));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Thời gian di chuyển &nbsp;")
			.append($('<span style="font-size: 16px"></span>').html(formatTime(xeKhach.thoiGianDiChuyen)));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Điểm trả khách: &nbsp;")
			.append($('<span style="font-size: 16px"></span>').html(xeKhach.diemDungXe));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Thời điểm đón khách: &nbsp;")
			.append($('<span style="font-size: 16px"></span>').html(formatDateTime(xeKhach.thoiDiemDi)));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Thời điểm trả khách: &nbsp;")
			.append($('<span style="font-size: 16px"></span>').html(formatDateTime(xeKhach.thoiDiemDen)));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Giá vé: &nbsp;").append($('<span style="font-size: 16px"></span>').html(xeKhach.giaVe));
		$(elArr[i++]).append(worker);

		worker = $(elArr[i]).html("Số điện thoại nhà xe: &nbsp;").append($('<span style="font-size: 13px"></span>').html(xeKhach.sdtNhaXe));
		$(elArr[i++]).append(worker);

		//curr.append(elArr);
		//resHolder.append(curr);
		jResHolder.append(curr.append(elArr));
	}
}

function formatDate (dateString) {
	var dateElms = dateString.split('-');
	return `${dateElms[2]}/${dateElms[1]}/${dateElms[0]}`;
}

function formatTime(timeString) {
	var timeElms = timeString.split(':');
	return `${timeElms[0]} giờ ${timeElms[1]} phút`;
}

function formatDateTime(dateTimeString) {
	var dateTimeArr = dateTimeString.split('T');
	return `${formatTime(dateTimeArr[1])}, ngày ${formatDate(dateTimeArr[0])}`
}
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
	if (document.body.scrollTop > 80 || document.documentElement.scrollTop > 80) {
		document.getElementById("navbar").style.backgroundColor = "White";
		document.getElementById("logo").style.fontSize = "25px";
		activitybg();
	} else {
		document.getElementById("navbar").style.backgroundColor = "none !important";
		document.getElementById("logo").style.fontSize = "35px";
		nonebg();
	}
}
function nonebg() {
	$("#navbar").removeClass("is-visible").addClass("is-hidden");
}
function activitybg() {
	$("#navbar").removeClass("is-hidden").addClass("is-visible");
}