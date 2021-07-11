
function getbyID(stdid) {

    $.ajax({
        type: "GET",
        url: "/Student/Details/" + stdid,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result.student_id != null){
       
                var myDate = new Date(973875600000);   

                $("#studentid").html(result.student_id);
                $("#name").html(result.name);
                $("#address").html(result.address);
                $("#email").html(result.email);
                $('#image').attr('src', result.image);
                $("#_class").html(result._class);
                $('#gender').html(result.gender);
                $('#faculty').html(result.faculty);
                $('#phone').html(result.phone);
                $('#age').html(myDate.toLocaleDateString("Vietnam"));
   

                $('#detail').modal('show'); 
            }
            else {
                alert("khong co du lieu");
            }
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function getFaculty() {
    var faculty = $('#faculty').val()

    if (faculty == "") {
        var html = '';
    html += '<option>Chọn lớp</option>';
        $('#_class').html(html);
       
    } else if (faculty == 'CNTT') {
        var html = '';
        html += '<option>Chọn lớp</option>';
        html += '<option>Công nghệ thông tin K17A</option>';
        html += '<option>Công nghệ thông tin K17B</option>';
        html += '<option>Công nghệ thông tin K17C</option>';
        html += '<option>Công nghệ thông tin K17D</option>';
        html += '<option>Công nghệ thông tin K17E</option>';
        html += '<option>Công nghệ thông tin K17H</option>';
        $('#_class').html(html);
    } else if (faculty == 'TDH') {
        var html = '';
        html += '<option>Chọn lớp</option>';
        html += '<option>Tự động hóa K17A</option>';
        html += '<option>Tự động hóa K17B</option>';
        html += '<option>Tự động hóa K17C</option>';
        html += '<option>Tự động hóa K17D</option>';
        html += '<option>Tự động hóa K17E</option>';
        html += '<option>Tự động hóa K17H</option>';
        $('#_class').html(html);
    } else if (faculty == 'TTDPT') {
        var html = '';
        html += '<option>Chọn lớp</option>';
        html += '<option>TT đa phương tiện K17A</option>';
        html += '<option>TT đa phương tiện K17B</option>';
        html += '<option>TT đa phương tiện K17C</option>';
        html += '<option>TT đa phương tiện K17D</option>';
        html += '<option>TT đa phương tiện K17E</option>';
        html += '<option>TT đa phương tiện K17H</option>';
        $('#_class').html(html);
    } else if (faculty == 'QTVP') {
        var html = '';
        html += '<option>Chọn lớp</option>';
        html += '<option>Quản trị văn phòng K17A</option>';
        html += '<option>Quản trị văn phòng K17B</option>';
        html += '<option>Quản trị văn phòng K17C</option>';
        html += '<option>Quản trị văn phòng K17D</option>';
        html += '<option>Quản trị văn phòng K17E</option>';
        html += '<option>Quản trị văn phòng K17H</option>';
        $('#_class').html(html);
    }
}


// upload image

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#blah')
                .attr('src', e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

//list name

var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#txtkeyword").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Student/listName",
                    dataType: "json",
                    data: {
                        q: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtkeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtkeyword").val(ui.item.label);

                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<div>" + item.label + "</div>")
                    .appendTo(ul);
            };
    }
}
common.init();