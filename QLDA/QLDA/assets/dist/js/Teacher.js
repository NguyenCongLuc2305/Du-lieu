function getbyIDtch(tcid) {

    $.ajax({
        type: "GET",
        url: "/Teacher/Details/" +tcid,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result.teacher_id != null) {
                var myDate = new Date(973875600000);
                $("#teacherid").html(result.teacher_id);
                $("#name").html(result.name);
                $("#address").html(result.address);
                $('#image').attr('src', result.image);
                $('#gender').html(result.gender);
                $('#faculty').html(result.faculty);
                $('#phone').html(result.phone);
                $('#subject').html(result.subject);
                $('#education').html(result.education);
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
var common = {
    init: function () {
        common.registerEvent();
    },
    registerEvent: function () {
        $("#teacher").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Teacher/listName",
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
                $("#teacher").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#teacher").val(ui.item.label);

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

