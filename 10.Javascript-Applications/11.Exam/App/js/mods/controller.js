define(['jquery', 'underscore', 'persister', 'ui'], function ($, _, Persister, ui) {

    var Controller, context;

    function logoutFirstWarn() {
        var warning = $('#warning').html('LOG OUT FIRST');
        warning.fadeIn(500);
        warning.fadeOut(1000);
    }

    function loginFirstWarn() {
        var warning = $('#warning').html('LOG IN FIRST');
        warning.fadeIn(500);
        warning.fadeOut(1000);
    }

    function usernameInvalid() {
        var warning = $('#warning').html('Username should be >= 6 and <= 40');
        warning.fadeIn(500);
        warning.fadeOut(2000);
    }

    Controller = (function () {
        function Controller(rootUrl, selector) {

            if(!rootUrl || !selector) {
                throw new Error('rootUrl | selector must be setted');
            }

            this.persister = new Persister(rootUrl);
            this.selector = selector;
            this.attachUIEventHandlers();
        }

        Controller.prototype.loadPostsUI = function (ctx) {
            context = ctx;

            var wrapper, postsUIHtml, headHthml, self;
            self = this;

            wrapper = $(this.selector);
            var byUsername = ctx.params['username'],
                byPattern = ctx.params['pattern'];

//            if (byUsername && byPattern) {
//                context.redirect('#/post/pattern/' + byPattern + '/' + byUsername);
//            }

            this.persister.post.getPosts(byUsername)
                .then(function (data) {
                    postsUIHtml = $('<div id="posts">').html(ui.loadPostsUI(data));
                    if (self.persister.isUserLoggedIn()) {
                        headHthml = ui.loadHomeUI({username: self.persister.username()});
                        wrapper.html(headHthml);
                        wrapper.append(postsUIHtml);
                    } else {
                        wrapper.html(postsUIHtml);
                    }

                    //jquery way doesn't work properly with this hack
//                chatDiv.scrollTop(chatDiv.height());
                    var scroller = document.getElementById('posts');
                    scroller.scrollTop = scroller.scrollHeight;

                }, function (error) {
                    console.log(error);
                });
        };

        Controller.prototype.loadPostsByPatternUI = function (ctx) {
            context = ctx;

            var wrapper, postsUIHtml, headHthml, self;
            self = this;

            wrapper = $(this.selector);
            var byPattern = ctx.params['pattern'],
                byUsername = ctx.params['username'];

            byPattern.replace(' ', '%20');

            this.persister.post.getPatternPosts(byPattern, byUsername)
                .then(function (data) {
                    postsUIHtml = $('<div id="posts">').html(ui.loadPostsUI(data, byPattern));
                    if (self.persister.isUserLoggedIn()) {
                        headHthml = ui.loadHomeUI({username: self.persister.username()});
                        wrapper.html(headHthml);
                        wrapper.append(postsUIHtml);
                    } else {
                        wrapper.html(postsUIHtml);
                    }

                    //jquery way doesn't work properly with this hack
//                chatDiv.scrollTop(chatDiv.height());
                    var scroller = document.getElementById('posts');
                    scroller.scrollTop = scroller.scrollHeight;

                }, function (error) {
                    console.log(error);
                });
        };

        Controller.prototype.loadLoginUI = function (ctx) {
            context = ctx;

            if (this.persister.isUserLoggedIn()) {
                logoutFirstWarn();
                return;
            }

            var wrapper, loginUIHtml;

            wrapper = $(this.selector);
            loginUIHtml = ui.loadLoginUI;

            wrapper.html(loginUIHtml);
        };

        Controller.prototype.loadRegisterUI = function (ctx) {
            context = ctx;

            if (this.persister.isUserLoggedIn()) {
                logoutFirstWarn();
                return;
            }

            var wrapper, registerUIHtml;

            wrapper = $(this.selector);
            registerUIHtml = ui.loadRegisterUI();

            wrapper.html(registerUIHtml);
        };

        Controller.prototype.loadCreatePostUI = function (ctx) {
            context = ctx;

            if (!this.persister.isUserLoggedIn()) {
                loginFirstWarn();
                ctx.redirect('#/login');
                return;
            }

            var wrapper, createPostUIHtml, headHthml;

            wrapper = $(this.selector);
            createPostUIHtml = $('<div id="registerForm">').html(ui.loadCreatePostUI());

            headHthml = ui.loadHomeUI({username: this.persister.username()});
            wrapper.html(headHthml);
            wrapper.append(createPostUIHtml);
        };

        Controller.prototype.loadHomeUI = function (ctx) {
            context = ctx;

            var wrapper, homeUIHtml, user;

            if(this.persister.isUserLoggedIn()) {
                user = {
                    username: this.persister.username()
                };
            }

            wrapper = $(this.selector);

            homeUIHtml = ui.loadHomeUI(user);

            wrapper.html(homeUIHtml);
        };

        Controller.prototype.attachUIEventHandlers = function () {
            var wrapper = $(this.selector),
                self = this;

            wrapper.on('click', '#loginBtn', function () {
                var user = {
                    username: $(self.selector + " #username").val(),
                    password: $(self.selector + " #password").val()
                };

                self.persister.user.login(user)
                    .then(function (){
                        context.redirect('#/');
                    },function (error) {
                        console.log(error);
                    });
            });

            wrapper.on('click', '#registerBtn', function () {
                var user = {
                    username: $(self.selector + " #username").val(),
                    password: $(self.selector + " #password").val()
                };

                if(user.username.length < 6 || user.username.length > 40) {
                    usernameInvalid();
                    return;
                }
                self.persister.user.register(user)
                    .then(function (data){
                        context.redirect('#/login');
                    }, function (error) {
                        console.log(error);
                    });
            });

            wrapper.on('click', '#createPostBtn', function () {
                var post = {
                    title: $(self.selector + " #title").val(),
                    body: $(self.selector + " #body").val()
                };

                self.persister.post.createPost(post)
                    .then(function (data){
                        context.redirect('#/posts');
                    }, function (error) {
                        console.log(error);
                    });
            });

            wrapper.on('click', '#logoutBtn', function () {
                self.persister.user.logout()
                    .then(function (data){
                        console.log(data);
                        context.redirect('#/posts');
                    }, function (error) {
                        console.log(error);
                    });
            });

            wrapper.on('click', '#searchBtn', function () {
                var pattern = $(self.selector + ' #pattern').val();
                context.redirect('#/posts/pattern/' + pattern);
            });
        };



        return Controller;
    }());

    return Controller;

});