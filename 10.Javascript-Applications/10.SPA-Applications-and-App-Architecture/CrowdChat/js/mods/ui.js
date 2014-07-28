define(['mustache'], function (Mustache) {

    var loadLoginForm = function () {
        return '<label for="nickname">Enter your nickname: </label>' +
                '<input type="text" id="nickname"/>' +
                '<button id="enterRoomBtn">Enter</button>';

    };

    var loadChatHeader = function (nickname) {
        return '<h1>Hello ' + nickname + '</h1>' +
                '<button id="logoutBtn">Log Out</button>';
    };

    var loadChatUI = function (data) {
        var template =
                '<ul>' +
                    '{{#.}}' +
                        '<li class="chat-message"><strong>{{by}} </strong>: "{{text}}"</li>' +
                    '{{/.}}' +
                '</ul>';

        return Mustache.render(template, data);
    };

    var loadSendForm = function () {
        return '<label for="message">Say Something: </label>' +
                '<input type="text" id="message">' +
                '<button id="sendBtn">SEND</button>';
    };

    return {
        loginForm: loadLoginForm,
        chatUI: loadChatUI,
        sendForm: loadSendForm,
        chatHead: loadChatHeader
    }
});