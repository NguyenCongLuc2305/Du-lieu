

function getProjectbyID(proid) {

    $.ajax({
        type: "GET",
        url: "/Project/Details/" + proid,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result.project_id != null) {
                var myDate = new Date(973875600000);
                $("#project_id").html(result.project_id);
                $("#name").html(result.name);
                $("#teacher_id").html(result.teacher_id);
                $("#student_id").html(result.student_id);
                $('#teacherName').html(result.teacher.name);
                $("#studentName").html(result.student.name);
                $('#start').html(myDate.toLocaleDateString("Vietnam"));
                $('#end').html(myDate.toLocaleDateString("Vietnam"));

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

var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#project").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Project/listName",
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
                $("#project").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#project").val(ui.item.label);

                return false;
            }
        })
            .autocomplete("instance")._renderItem = function (ul, item) {
                return $("<li>")
                    .append("<div>" + item.label + "</div>")
                    .appendTo(ul)

            };
    }
}
common.init();




function GetStudentNamebyId() {
    var stdid = $('#student_id').val();
    $.ajax({
        type: "get",
        url: "/project/GetStudentNamebyId/" + stdid,
        contenttype: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            $("#studentName").val(result);
        },
    });
};


function GetTeacherNamebyId() {
    var stdid = $('#teacher_id').val();
    $.ajax({
        type: "get",
        url: "/project/GetTeacherNamebyId/" + stdid,
        contenttype: "application/json;charset=utf-8",
        datatype: "json",
        success: function (result) {
            console.log(result);
            $("#teacherName").val(result);
        },
    });
};