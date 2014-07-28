define(['mustache'], function (Mustache) {

    var loadLoginForm = function () {
        return '<label for="nickname">Enter your nickname: </label>' +
                '<input type="text" id="nickname"/>' +
                '<button id="enterRoomBtn">Enter</button>';

    };

    var loadChatUI = function (data, nickname) {

        var template =
                '<h1>Hello ' + nickname + '</h1>' +
                '<button id="logoutBtn">Log Out</button>' +
                '<ul id="chats">' +
                    '{{#.}}' +
                        '<li class="chat-message"><strong>{{by}} </strong>: "{{text}}"</li>' +
                    '{{/.}}' +
                '</ul>' +
                '<label for="message">Say Something: </label>' +
                '<input type="text" id="message">' +
                '<button id="sendBtn">SEND</button>';

        return Mustache.render(template, data);
    };

    return {
        loginForm: loadLoginForm,
        chatUI: loadChatUI
    }
});