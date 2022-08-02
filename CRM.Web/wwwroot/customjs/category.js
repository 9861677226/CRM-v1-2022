
$(document).ready(function () {
    loadData();
    getMaxID();
    getAllCompany();
    $("#ddlCompany").select2();
});


function loadData() {

    $.ajax({
        url: "/Category/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            console.log(result);
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.CategoryId + '</td>';
                html += '<td>' + item.CompanyName + '</td>';
                html += '<td>' + item.CategoryName + '</td>';
                html += '<td>' + item.CategoryDesc + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.CategoryId + ')">Edit</a> | <a href="#" onclick="Delete(' + item.CategoryId + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var CategoryObj = {
        CategoryId: $('#CategoryId').val(),
        CompanyId: $('#ddlCompany').val(),
        CategoryName: $('#CategoryName').val(),
        CategoryDesc: $('#CategoryDesc').val()
    };
    $.ajax({
        url: "/Category/Add",
        data: JSON.stringify(CategoryObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function getbyID(CategoryID) {
    $('#CategoryId').css('border-color', 'lightgrey');
    $('#CategoryName').css('border-color', 'lightgrey');
    $('#CategoryDesc').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Category/GetbyID/" + CategoryID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CategoryId').val(result.CategoryId);
            $('#ddlCompany').val(result.CompanyId);
            $('#CategoryName').val(result.CategoryName);
            $('#CategoryDesc').val(result.CategoryDesc);


            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function getMaxID() {

    $.ajax({
        url: "/Category/GetMaxID",
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CategoryId').val(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function getAllCompany() {

    $.ajax({
        url: "/Category/CompanyList",
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var items = '<option value="0">--Select Company--</option>';
            $.each(result, function (key, item) {
                items += "<option value='" + item.CompanyId + "'>" + item.CompanyName + "</option>";
            });
            $("#ddlCompany").html(items)
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var CategoryObj = {
        CategoryId: $('#CategoryId').val(),
        CompanyId: $('#ddlCompany').val(),
        CategoryName: $('#CategoryName').val(),
        CategoryDesc: $('#CategoryDesc').val(),

    };
    $.ajax({
        url: "/Category/Update",
        data: JSON.stringify(CategoryObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#CategoryId').val("");
            $('#ddlCompany').val("0");
            $('#CategoryName').val("");
            $('#CategoryDesc').val("");

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function Delete(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Category/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function clearTextBox() {
    $('#CategoryName').val("");
    $('#CategoryDesc').val("");
    $('#ddlCompany').val("0");
    $('#myModal').modal('hide');
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    getMaxID();
    getAllCompany();

}

function validate() {
    var isValid = true;
    if ($('#ddlCompany').val().trim() == "0") {
        $('#ddlCompany').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ddlCompany').css('border-color', 'lightgrey');
    }
    if ($('#CategoryName').val().trim() == "") {
        $('#CategoryName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CategoryName').css('border-color', 'lightgrey');
    }
    if ($('#CategoryDesc').val().trim() == "") {
        $('#CategoryDesc').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CategoryDesc').css('border-color', 'lightgrey');
    }

    return isValid;
}