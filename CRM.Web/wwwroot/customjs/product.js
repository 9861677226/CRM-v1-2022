
$(document).ready(function () {
    loadData();
    getMaxID();
    getAllCompany();
    
});


function loadData() {

    $.ajax({
        url: "/Product/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            console.log(result);
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.ProductId + '</td>';
                html += '<td>' + item.CompanyName + '</td>';
                html += '<td>' + item.CategoryName + '</td>';
                html += '<td>' + item.ProductName + '</td>';
                html += '<td>' + item.ProductDesc + '</td>';
                html += '<td>' + item.ProductMRP + '</td>';
                html += '<td>' + item.Stock + '</td>';
                html += '<td>' + item.FinYear + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.ProductId + ')">Edit</a> | <a href="#" onclick="Delete(' + item.ProductId + ')">Delete</a></td>';
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
    var ProductObj = {
        ProductId: $('#ProductId').val(),
        CompanyId: $('#ddlCompany').val(),
        CategoryId: $('#ddlCategory').val(),
        ProductName: $('#ProductName').val(),
        ProductDesc: $('#ProductDesc').val(),
        ProductMRP: $('#ProductMRP').val(),
        Stock: $('#Stock').val(),
        FinYear: $('#ddlFinYr').val()
    };
    $.ajax({
        url: "/Product/Add",
        data: JSON.stringify(ProductObj),
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


function getbyID(ProductID) {
    $('#ProductId').css('border-color', 'lightgrey');
    $('#ProductName').css('border-color', 'lightgrey');
    $('#ProductDesc').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Product/GetbyID/" + ProductID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ProductId').val(result.ProductId);
            $('#ddlCompany').val(result.CompanyId);
            $('#ProductName').val(result.ProductName);
            $('#ProductDesc').val(result.ProductDesc);


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
        url: "/Product/GetMaxID",
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ProductId').val(result);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function getAllCompany() {

    $.ajax({
        url: "/Product/CompanyList",
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

function getAllFinYear() {
    debugger;

    $.ajax({
        url: "/Product/FinYear",
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var items = '<option value="0">--Select Company--</option>';
            $.each(result, function (key, item) {
                items += "<option value='" + item + "'>" + item + "</option>";
            });
            $("#ddlFinYr").html(items)
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function getAllCategory() {
    var CompanyId = $('#ddlCompany').val();
    $.ajax({
        url: "/Product/CategoryList/" + CompanyId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var items = '<option value="0">--Select Category--</option>';
            $.each(result, function (key, item) {
                items += "<option value='" + item.CategoryId + "'>" + item.CategoryName + "</option>";
            });
            $("#ddlCategory").html(items)
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
    var ProductObj = {
        ProductId: $('#ProductId').val(),
        CompanyId: $('#ddlCompany').val(),
        ProductName: $('#ProductName').val(),
        ProductDesc: $('#ProductDesc').val(),

    };
    $.ajax({
        url: "/Product/Update",
        data: JSON.stringify(ProductObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#ProductId').val("");
            $('#ddlCompany').val("0");
            $('#ProductName').val("");
            $('#ProductDesc').val("");

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
            url: "/Product/Delete/" + ID,
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
    $('#ProductName').val("");
    $('#ProductDesc').val("");
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
    if ($('#ProductName').val().trim() == "") {
        $('#ProductName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ProductName').css('border-color', 'lightgrey');
    }
    if ($('#ProductDesc').val().trim() == "") {
        $('#ProductDesc').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ProductDesc').css('border-color', 'lightgrey');
    }

    return isValid;
}