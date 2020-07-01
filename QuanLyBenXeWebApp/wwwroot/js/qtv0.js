//lich su giao dich

function createLsGiaoDich() {
	var args = getLsGiaoDich()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv0/createlsgiaodich',
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
function deleteLsGiaoDich() {
	var args = getLsGiaoDich()
	$.ajax({
		type: 'post',
		dataType:"json",
		url: '/qtv0/deletelsgiaodich',
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

function getLsGiaoDich() {
	var fields = $(".selected-row").find("input")
	var i = 0
	var giaoDich = {
		MaGiaoDich: fields[i++].value,
		MaNhaXe: fields[i++].value,
		NgayGiaoDich: fields[i++].value
	}
	return {
		giaoDich
	}
}
function bindLsGiaoDich() {
	$("#create-lsgd").click(createLsGiaoDich)
	$("#delete-lsgd").click(deleteLsGiaoDich)
}

//thong tin dang nhap
function createTtDangNhap() {
	var args = getTtDangNhap()
	$.ajax({
		type: 'post',
		dataType:"json",
		url: '/qtv0/createttdangnhap',
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
function updateTtDangNhap() {
	var args = getTtDangNhap()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv0/updatettdangnhap',
		data: {
			qtv: args.qtv,
			roleName: args.roleName
		},
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
function deleteTtDangNhap() {
	var args = getTtDangNhap()
	$.ajax({
		type: 'post',
		dataType:"json",
		url: '/qtv0/deletettdangnhap',
		data: args.qtv,
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
function changePassword() {
	var args = getTtDangNhap()
	$.ajax({
		type: 'post',
		dataType:"json",
		url: '/qtv0/changepassword',
		data: {
			qtv: args.qtv,
			password: args.password
		},
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
function getTtDangNhap() {
	var fields = $(".selected-row").find("input")
	var i = 0
	var  qtv = {
		Id: fields[i++].value,
		MaNhaXe: fields[i++].value,
		HoDem: fields[i++].value,
		Ten: fields[i++].value,
		GioiTinh: fields[i++].checked,
		NoiSinh: fields[i++].value,
		PhoneNumber: fields[i++].value,
		UserName: fields[i++].value
	}
	var password = fields[i++].value
	var roleName = fields[i++].value
	return {
		qtv,
		password,
		roleName
	}
}
function bindTtDangNhap() {
	$("#create-ttdn").click(createTtDangNhap)
	$("#update-ttdn").click(updateTtDangNhap)
	$("#delete-ttdn").click(deleteTtDangNhap)
	$("#changepassword").click(changePassword)
}

//lich su vao ra
function deleteLsVaoRa() {
	var args = getLsVaoRa()
	$.ajax({
		type: 'post',
		datatype:"json",
		url: '/qtv0/deleteLsVaoRa',
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

function getLsVaoRa() {
	var fields = $(".selected-row").find("input")
	var i = 0
	var vaoRa = {
		Stt: fields[i++].value,
		MaXeKhach: fields[i++].value,
		MaViTri: fields[i++].value,
		VaoBen: fields[i++].checked,
		ThoiDiem: fields[i++].value,

	}
	return {
		vaoRa
	}
}

function bindLsVaoRa() {
	$("#delete-lsvr").click(deleteLsVaoRa);
}

//vi tri do
function createViTriDo() {
	var args = getViTriDo()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv0/createViTriDo',
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
function updateViTriDo() {
	var args = getViTriDo()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv0/updateViTriDo',
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
function deleteViTriDo() {
	var args = getViTriDo()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv0/deleteViTriDo',
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
function getViTriDo() {
	debugger
	var fields = $(".selected-row").find("input")
	var i = 0
	var viTri = {
		MaViTri: fields[i++].value

	}
	return {
		viTri
	}
}
function bindViTriDo() {
	$("#create-vtd").click(createViTriDo)
	$("#update-vtd").click(updateViTriDo)
	$("#delete-vtd").click(deleteViTriDo)
}


//nha xe
function createNhaXe() {
	var args = getNhaXe()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv0/createNhaXe',
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
function updateNhaXe() {
	var args = getNhaXe()
	$.ajax({
		type: 'post',
		dataType: "json",
		url: '/qtv0/updateNhaXe',
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
function deleteNhaXe() {
	var args = getNhaXe()
	$.ajax({
		type: 'post',
		dataType:"json",
		url: '/qtv0/deleteNhaXe',
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
function getNhaXe() {
	var fields = $(".selected-row").find("input")
	var i = 0
	var nhaXe = {
		MaNhaXe: fields[i++].value,
		TenNhaXe: fields[i++].value,
		SoLuongXe: fields[i++].value,
		Sdt: fields[i++].value,
		MauBieuTuong: fields[i++].value,
		DiaChi: fields[i++].value,
		GiaoDichCuoi: fields[i++].value,

	}
	return {
		nhaXe
	}
}
function bindNhaXe() {
	$("#create-nx").click(createNhaXe)
	$("#update-nx").click(updateNhaXe)
	$("#delete-nx").click(deleteNhaXe)
}

//
function registerQtv0EventHandlers() {
	bindLsGiaoDich()
	bindTtDangNhap()
	bindLsVaoRa()
	bindViTriDo()
	bindNhaXe()
}