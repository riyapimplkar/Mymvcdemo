$(document).ready(function () {
    getRegistrationList();
    getRegisterbyID();
    RedirectDetails();
});




    var Savereg = function () {
    var name = $("#txtname").val();
    var mobile_no = $("#txtnumber").val();
    var email = $("#txtemail").val();
    var address = $("#txtAdd").val();
    var model = { Name: name, Mobile_No:mobile_no,Email:email, Address: address };
    $.ajax({
        url: "/mvcdemo/Savereg",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/Json;charsel=utf-8",
        dataType: "Json",
        success: function (response) {
            alert("Successfull");
        }
    })
}


var getRegistrationList = function () {
    debugger;
    $.ajax({
        url: "/mvcdemo/getRegistrationList",
        method: "Post",
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblregistrations tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.srno +
                    "</td><td>" + elementValue.Id +
                    "</td><td>" + elementValue.Name +
                    "</td><td>" + elementValue.Mobile_No +
                    "</td><td>" + elementValue.Email +
                    "</td><td>" + elementValue.Address + "</td><td><input type='button' value='Delete' onclick='deleteRegistration(" + elementValue.Id + ")'class='btn btn-danger'/> &nbsp <input type='button' value='Edit' onclick='getRegisterbyID(" + elementValue.Id + ")' class='btn btn-success'/> &nbsp <input type='button' value='RedirectDetails' onclick='Details(" + elementValue.Id + ")'class='btn btn-info'/></td ></tr >";

            });
            $("#tblregistrations tbody").append(html);
        }
    });

}
var deleteRegistration = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/mvcdemo/deleteRegistration",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        success: function (response) {
            alert(response.model);


        }
    });

}

var getRegisterbyID = function (Id) {
    debugger;
    model = { Id: Id }
    $.ajax({
        url: "/mvcdemo/getRegisterbyID",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        success: function (response) {
            $("#hdnid").val(response.model.Id);
            $("#txtname").val(response.model.Name);
            $("#txtnumber").val(response.model.Mobile_No);
            $("#txtemail").val(response.model.Email);
            $("#txtAdd").val(response.model.Address);

        }
    });

}

var Details = function (Id) {
    window.location.href = "/mvcdemo/DetailsIndex?Id=" + Id;
}

var RedirectDetails = function () {
    var Id = $("#hdnid").val();
    model = { Id: Id }
    $.ajax({
        url: "/mvcdemo/getRegisterbyID",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        dataType: "Json",
        success: function (response) {
            $("#hdnid").text(response.model.Id);
            $("#txtname").text(response.model.Name);
            $("#txtnumber").text(response.model.Mobile_No);
            $("#txtemail").text(response.model.Email);
            $("#txtAdd").text(response.model.Address);

        }
    });

}