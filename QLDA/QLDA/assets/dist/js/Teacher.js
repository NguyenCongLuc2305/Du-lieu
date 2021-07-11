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


