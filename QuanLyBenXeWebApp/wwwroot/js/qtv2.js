
//tai xe
function createTaiXe() {
	var args = getTaiXe()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv2/createtaixe',
		data: args,
		success: function (response) {
			if (response[0] === "redirect")
				window.location = response[1]
			else {
				let txt = "";
				for (let msg of response)
					txt += msg + "<br />";
				$(".validation-summary").html(txt)
			}
		},
		error: function (response) {
			let txt = "";
			for (let msg of response)
				txt += msg + "\n";
			alert(txt)
		}
	})
}
function updateTaiXe() {
	var args = getTaiXe()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv2/updatetaixe',
		data: args,
		success: function (response) {
			if (response[0] === "redirect")
				window.location = response[1]
			else {
				let txt = "";
				for (let msg of response)
					txt += msg + "<br />";
				$(".validation-summary").html(txt)
			}
		},
		error: function (response) {
			let txt = "";
			for (let msg of response)
				txt += msg + "\n";
			alert(txt)
		}
	})
}
function deleteTaiXe() {
	var args = getTaiXe()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv2/deletetaixe',
		data: args,
		success: function (response) {
			if (response[0] === "redirect")
				window.location = response[1]
			else {
				let txt = "";
				for (let msg of response)
					txt += msg + "<br />";
				$(".validation-summary").html(txt)
			}
		},
		error: function (response) {
			let txt = "";
			for (let msg of response)
				txt += msg + "\n";
			alert(txt)
		}
	})
}
function getTaiXe() {
	var fields = $(".selected-row").find("input")
	var i = 0
	var taiXe = {
		MaTaiXe: fields[i++].value,
		HoDem: fields[i++].value,
		Ten: fields[i++].value,
		GioiTinh: fields[i++].checked,
		NoiSinh: fields[i++].value,
		Sdt: fields[i++].value
	}
	return {
		taiXe
	}
}
function bindTaiXe() {
	$("#create-tx").click(createTaiXe)
	$("#update-tx").click(updateTaiXe)
	$("#delete-tx").click(deleteTaiXe)
}


//xe khach
function createXeKhach() {
	var args = getXeKhach()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv2/createxekhach',
		data: args,
		success: function (response) {
			if (response[0] === "redirect")
				window.location = response[1]
			else {
				let txt = "";
				for (let msg of response)
					txt += msg + "<br />";
				$(".validation-summary").html(txt)
			}
		},
		error: function (response) {
			let txt = "";
			for (let msg of response)
				txt += msg + "\n";
			alert(txt)
		}
	})
}
function updateXeKhach() {
	var args = getXeKhach()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv2/updatexekhach',
		data: args,
		success: function (response) {
			if (response[0] === "redirect")
				window.location = response[1]
			else {
				let txt = "";
				for (let msg of response)
					txt += msg + "<br />";
				$(".validation-summary").html(txt)
			}
		},
		error: function (response) {
			let txt = "";
			for (let msg of response)
				txt += msg + "\n";
			alert(txt)
		}
	})
}
function deleteXeKhach() {
	var args = getXeKhach()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv2/deletexekhach',
		data: args,
		success: function (response) {
			if (response[0] === "redirect")
				window.location = response[1]
			else {
				let txt = "";
				for (let msg of response)
					txt += msg + "<br />";
				$(".validation-summary").html(txt)
			}
		},
		error: function (response) {
			let txt = "";
			for (let msg of response)
				txt += msg + "\n";
			alert(txt)
		}
	})
}
function getXeKhach() {
	var fields = $(".selected-row").find("input")
	var i = 0
	var xeKhach = {
		MaXeKhach: fields[i++].value,
		MaNhaXe: fields[i++].value,
		MaTaiXe: fields[i++].value,
		BienSoXe: fields[i++].value,
		SoGhe: fields[i++].value,
		GiaVe: fields[i++].value
	}
	return {
		xeKhach
	}
}
function bindXeKhach() {
	$("#create-xk").click(createXeKhach)
	$("#update-xk").click(updateXeKhach)
	$("#delete-xk").click(deleteXeKhach)
}

function registerQtv2EventHandlers() {
	bindTaiXe()
	bindXeKhach()
}