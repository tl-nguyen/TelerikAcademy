define(['sammy', 'controllers'], function (sammy, controllers) {
    var app, url, selector, controller;

    url = 'http://crowd-chat.herokuapp.com/';
    selector = '#main-content';

    controller = controllers.get(url, selector);

    app = sammy(selector, function () {
        this.get("#/login", controller.loadLoginUI.bind(controller));
        this.get("#/chat", controller.loadChatUI.bind(controller));
    });

    return {
        load: function () {
            app.run('#/login');
        }
    }
});