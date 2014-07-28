define(['persisters', 'ui', 'underscore'], function (persisters, ui, _) {
    var Controller, context, chatInterVal;

    Controller = (function () {
        function Controller(rootUrl, selector) {
            this.persister = persisters.get(rootUrl);
            this.selector = selector;
            this.attachUIEventHandlers();
        }

        Controller.prototype.loadChatUI = function (ctx) {
            context = ctx;

            clearInterval(chatInterVal);

            if(!this.persister.isUserLoggedIn()) {
                ctx.redirect('#/login');
                return;
            }

            var self = this,
                wrapper = $(this.selector);

            fetchPosts();
            chatInterVal = setInterval(fetchPosts, 6000);

            function fetchPosts() {
                self.persister.chatRoom.getPosts()
                    .then(function (data) {
                        data = data.slice(-30);

                        data = _.chain(data)
                            .reverse()
                            .value();

                        var chatUIHtml = ui.chatUI(data, self.persister.nickname());
                        wrapper.html(chatUIHtml);
                    }, function (error) {
                        console.log(error);
                    });
            }
        };

        Controller.prototype.loadLoginUI = function (ctx) {
            context = ctx;
            clearInterval(chatInterVal);

            if(this.persister.isUserLoggedIn()) {
                ctx.redirect('#/chat');
            }

            var loginFormHtml = ui.loginForm();

            $(this.selector).html(loginFormHtml);
        };

        Controller.prototype.attachUIEventHandlers = function () {
            var wrapper = $(this.selector),
                self = this;

            wrapper.on('click', '#enterRoomBtn', function () {
                var nickname = $(self.selector + ' #nickname').val();

                self.persister.chatRoom.loggedIn(nickname);
                context.redirect('#/chat');
            });

            wrapper.on('click', '#logoutBtn', function () {
                self.persister.chatRoom.loggedOut();
                context.redirect('#/login');
            });

            wrapper.on('click', '#sendBtn', function () {
                var data = {
                    user: self.persister.nickname(),
                    text: wrapper.find('#message').val()
                };

                self.persister.chatRoom.sendPost(data)
                    .then(function () {
                        self.loadChatUI(context);
                    }, function (error) {
                        console.log(error);
                    });
            });
        };

        return Controller;
    }());

    return {
        get: function (url, selector) {
            return new Controller(url, selector);
        }
    }
});