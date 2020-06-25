//trang thai ben xe
function createTtBenXe() {
    var args = getTtBenXe()
    $.ajax({
        type: 'post',
        dataType: "json",
        url: '/qtv1/createTtBenXe',
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
function updateTtBenXe() {
    var args = getTtBenXe()
    $.ajax({
        type: 'post',
        dataType: "json",
        url: '/qtv1/updateTtBenXe',
        data: {
            qtv: args,
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
function deleteTtBenXe() {
    var args = getTtBenXe()
    $.ajax({
        type: 'post',
        dataType: "json",
        url: '/qtv1/deleteTtBenXe',
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
function getTtBenXe() {
    var fields = $(".selected-row").find("input")
    var i = 0
    var tt = {
        Stt: fields[i++].value,
        MaXeKhach: fields[i++].value,
        MaViTri: fields[i++].value,
        GioNhapBen: fields[i++].value
    }
    return {
        tt
    }
}
function bindTtBenXe() {
    $("#create-ttbx").click(createTtBenXe)
    $("#update-ttbx").click(updateTtBenXe)
    $("#delete-ttbx").click(deleteTtBenXe)
}

//lich su vao ra
function createLsVaoRa() {
    var args = getLsVaoRa()
    $.ajax({
        type: 'post',
        dataType: "json",
        url: '/qtv1/createLsVaoRa',
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
    var ls = {
        Stt: fields[i++].value,
        MaXeKhach: fields[i++].value,
        MaViTri: fields[i++].value,
        VaoBen: fields[i++].checked,
        ThoiDiem: fields[i++].value
    }
    return {
        ls
    }
}
function bindLsVaoRa() {
    $("#create-lsvr").click(createLsVaoRa)
}

function registerQtv1EventHandlers() {
    bindTtBenXe()
    bindLsVaoRa()
}

function getViTriDo() {
    var fields = $(".selected-row").find("input")
    var i = 0
    var ViTriDo = {
        MaViTri: fields[i++].value
    }
    return {
        ViTriDo
    }
}