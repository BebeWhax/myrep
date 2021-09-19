// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(
    function () {
        $("#save").click(
            function (url) {
                sendAjaxForm('ajax_edit_form', url);
                return false;
            }
        );
    }
);

postQuery = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                $('#main').html(res);
            },
            error: function (err) {
                console.log(err);
            }
        })
        return false;
    } catch (ex) {
        console.log(ex);
    }
}

jQueryAjaxEdit = form => {
    try {
        $.ajax({

            type: 'GET',
            url: form.action,
            data: { "item.Id": $("#item.Id").val() },
            contentType: false,
            processData: false,
            success: function (res) {
                $('#main').html(res);
            },
            error: function (err) {
                console.log(err);
            }
        });
        return false;
    } catch (ex) {
        console.log(ex);
    }
}
getRequest = (url) => {
    try {
        $.ajax({
            type: 'GET',
            url: url,
            contentType: false,
            processData: false,
            success: function (res) {
                $('#main').html(res);
            },
            error: function (err) {
                console.log(err);
            }

        });
        return false;
    } catch (ex) {
        console.log(ex);
    }
}
function sendAjaxForm(ajax_form, url) {
    $.ajax({
        url: url,
        type: "POST",
        dataType: "html",
        data: $("#" + ajax_form).serialize(),
        success: function (response) {
            result = $.parseJSON(response);
            $('#main').html(response);
        },
        error: function (response) {
            $('#main').html(response);
        }
    });
}