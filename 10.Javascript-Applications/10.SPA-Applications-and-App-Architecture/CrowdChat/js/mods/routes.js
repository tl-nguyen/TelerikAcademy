define(['sammy', 'controllers'], function (sammy, controllers) {
    var app, url, selector, controller;

    url = 'http://crowd-chat.herokuapp.com/';
    selector = '#main-content';


    app = sammy(selector, function () {
        controller = controllers.get(url, selector);

        this.get("#/login", function (ctx) {
            controller.loadLoginUI(ctx);
        });
        this.get("#/chat", function (ctx) {
            controller.loadChatUI(ctx);
        });
    });

    return {
        load: function () {
            app.run('#/login');
        }
    }
});