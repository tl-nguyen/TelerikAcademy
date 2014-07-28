define(['persisters', 'ui', 'underscore'], function (persisters, ui, _) {
    var Controller, context, chatInterVal;

    function fetchPosts() {
        var self = this,
            wrapper = $(this.selector);

        this.persister.chatRoom.getPosts()
            .then(function (data) {
                var chatUIHtml;

                data = data.slice(-30);

                data = _.chain(data)
                    .map(function (chat) {
                        //remove stupid &nbsp; hack
                        while(chat.text.indexOf('&nbsp;') >= 0) {
                            chat.text = chat.text.replace('&nbsp;', ' ');
                        }

                        return chat;
                    })
                    .reverse()
                    .value();

                chatUIHtml = ui.chatUI(data, self.persister.nickname());
                wrapper.html(chatUIHtml);
            }, function (error) {
                console.log(error);
            });
    }

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

            fetchPosts.call(this);
            chatInterVal = setInterval(fetchPosts.bind(this), 15000);
        };

        Controller.prototype.loadLoginUI = function (ctx) {
            var loginFormHtml;

            context = ctx;
            clearInterval(chatInterVal);

            if(this.persister.isUserLoggedIn()) {
                ctx.redirect('#/chat');
            }

            loginFormHtml = ui.loginForm();

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