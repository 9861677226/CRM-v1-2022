
$(document).ready(function () {
    loadData();
    getMaxID();
});

 
function loadData() {
   
    $.ajax({
        url: "/Company/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            console.log(result);
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.CompanyId + '</td>';
                html += '<td>' + item.CompanyName + '</td>';
                html += '<td>' + item.CompanyDesc + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.CompanyId + ')">Edit</a> | <a href="#" onclick="Delete(' + item.CompanyId + ')">Delete</a></td>';
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
    var companyObj = {
        CompanyId: $('#CompanyId').val(),
        CompanyName: $('#CompanyName').val(),
        CompanyDesc: $('#CompanyDesc').val()
    };
    $.ajax({
        url: "/Company/Add",
        data: JSON.stringify(companyObj),
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


function getbyID(CompanyID) {
    $('#CompanyId').css('border-color', 'lightgrey');
    $('#CompanyName').css('border-color', 'lightgrey');
    $('#CompanyDesc').css('border-color', 'lightgrey');
  
    $.ajax({
        url: "/Company/GetbyID/" + CompanyID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CompanyId').val(result.CompanyId);
            $('#CompanyName').val(result.CompanyName);
            $('#CompanyDesc').val(result.CompanyDesc);
           

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
        url: "/Company/GetMaxID",
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#CompanyId').val(result);
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
    var companyObj = {
        CompanyId: $('#CompanyId').val(),
        CompanyName: $('#CompanyName').val(),
        CompanyDesc: $('#CompanyDesc').val(),
        
    };
    $.ajax({
        url: "/Company/Update",
        data: JSON.stringify(companyObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#CompanyId').val("");
            $('#CompanyName').val("");
            $('#CompanyDesc').val("");
           
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
            url: "/Company/Delete/" + ID,
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
    $('#CompanyName').val("");
    $('#CompanyDesc').val("");
    $('#myModal').modal('hide');
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    getMaxID();
   
}

function validate() {
    var isValid = true;
    if ($('#CompanyName').val().trim() == "") {
        $('#CompanyName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CompanyName').css('border-color', 'lightgrey');
    }
    if ($('#CompanyDesc').val().trim() == "") {
        $('#CompanyDesc').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#CompanyDesc').css('border-color', 'lightgrey');
    }
   
    return isValid;
}