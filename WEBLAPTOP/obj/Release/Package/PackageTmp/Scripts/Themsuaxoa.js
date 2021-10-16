function them() {
    $('#tenSP').val('');
    $('#Hinhanh').val('');
    $('#Giaban').val('');
    $('#btnAdd').val('show');
    $('#myModal').modal("show");//hien thi table
    $('.modal-title').html('Thêm thông tin');//them thong tin
    $('#btnUpdate').hide();
}
//
function _add() {
    var obj = {
       tenSP: $('#tensp').val(),
        Hinhanh: $('#Hinhanh').val(),
        Giaban: $('#Giaban').val(),
     
    }
    $.ajax({
        url: "/Admin/Sanpham/create",
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            // $('#myModal').modal('hide');

            location.reload();//load lai trang
            alert("Đã thêm thành công");
            //window.location = data.action;

        },
        error: function (errmessage) {
            alert(errmessage.responseText);
        }
    });
}
function getbymaSP(masp)
{
    $.ajax({
        type: 'POST',
        url: '/Sanpham/get',
        dataType: 'json',
        data: {
            maSP: masp
        },
        success: function (data) {
            $('#maSP').val(data.dt.maSP);
            $('#tenSP').val(data.dt.tenSP);
            $('#Hinhanh').val(data.dt.Hinhanh);
            $('#Giaban').val(data.dt.Giaban);
           

            //
            $('#myModal').modal('show');
            $('#btnAdd').hide();
            $('.modal-title').html('Sửa sản phẩm');
            $('#btnUpdate').show();
        },
        error: function (data) {

            showmessage("Error:", data.message);
        },

    });
}
function edit() {
    var obj = {
        //MASP: $('#masp').val(),
        tenSP: $('#tenSP').val(),
        Hinhanh: $('#Hinhanh').val(),
        Giaban: $('#Giaban').val(),
   
    }
    $.ajax({
        url: '/Sanpham/edit',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Đã sửa thành công");
            location.reload();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
//xoa
function xoa(masp) {
    var cf = confirm("Bạn có muốn xóa không ?");
    if (cf) {
        $.ajax({
            type: "post",
            url: '/Sanpham/delete',
            datatype: "json",
            data: {
                masp: masp,//controler
            },
            success: function (data) {
                location.reload();
                //alert(data.dt.id);
                alert(" Xóa thành công.");

            },
            error: function (data) {
                alert("Không thể xóa");
                showmessage("Error:", data.message);
            },
        });
    }
}
