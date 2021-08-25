"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/RealTimeData").build();


connection.on("AddOrder", function (order) {
    order = JSON.parse(order);
    var ordersTable = $("#ordertbl")
    if (ordersTable != undefined) {
        ordersTable.prepend("<tr id='"
            + order.Id +
            "'><th><span class='badge badge-secondary'>New</span></th><td>"
            + order.DateTime +
            "</td><td><input id='check" + order.Id + "' class='check-box' disabled='disabled' type='checkbox' /></td><td><a class='btn btn-info' href='Orders/Details/" + order.Id + "'>Details</a></td></tr>")
        if (order.Paid) {
            $("#check" + order.Id).attr('checked', 'checked')
        }
    }
    var notificationsLenght = parseInt($("#notification").text());
    $("#notification").text(notificationsLenght + 1);

    $("#notification").removeAttr("style");
    $.Toast("New Order #" + order.Id, "There Is New Order With Id #" + order.Id + "<a target='_blank' class='btn btn-info' href='/Orders/Details/" + order.Id + "'>Details</a>", "success", {
        has_icon: true,
        has_close_btn: true,
        stack: true,
        fullscreen: false,
        timeout: 10000,
        sticky: false,
        has_progress: true,
        rtl: false,
    })

    let src = '../audio/iphone_tweet.mp3';
    let audio = new Audio(src);
    audio.play();
});

connection.start().then(function () {
}).catch(function (err) {
    return console.error(err.toString());
});

