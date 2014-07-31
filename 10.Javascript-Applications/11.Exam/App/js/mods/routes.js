define(['sammy', 'controller'], function (sammy, Controller) {
    var app, url, selector, controller;

    url = 'http://jsapps.bgcoder.com/';
    selector = '#main-content';

    controller = new Controller(url, selector);

    app = sammy(selector, function () {
        this.get("#/", controller.loadHomeUI.bind(controller));
        this.get("#/posts", controller.loadPostsUI.bind(controller));
        this.get("#/posts/:username", controller.loadPostsUI.bind(controller));
        this.get("#/posts/pattern/:pattern", controller.loadPostsByPatternUI.bind(controller));
        this.get("#/posts/pattern/:pattern/:username", controller.loadPostsByPatternUI.bind(controller));
        this.get("#/post/create", controller.loadCreatePostUI.bind(controller));
        this.get('#/login', controller.loadLoginUI.bind(controller));
        this.get('#/register', controller.loadRegisterUI.bind(controller));
    });

    return {
        load: function () {
            app.run('#/');
        }
    }
});