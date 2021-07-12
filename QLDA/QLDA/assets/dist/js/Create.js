var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#teacher_id").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Project/listNameTeacher",
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
                $("#teacher_id").val(ui.item.label);
                GetTeacherNamebyId();
                return false;
            },
            select: function (event, ui) {
                $("#teacher_id").val(ui.item.label);

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

var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#student_id").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Project/listNameStudent",
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
                $("#student_id").val(ui.item.label);
                GetStudentNamebyId();
                return false;
            },
            select: function (event, ui) {
                $("#student_id").val(ui.item.label);
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