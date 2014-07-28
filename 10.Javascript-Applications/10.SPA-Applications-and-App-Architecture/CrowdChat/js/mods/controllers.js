define(['persisters', 'ui', 'underscore'], function (persisters, ui, _) {
    var Controller, context, chatInterVal;

    function fetchPosts() {
        var wrapper = $(this.selector);

        this.persister.chatRoom.getPosts()
            .then(function (data) {
                var chatUIHtml, chatDiv;

                data = data.slice(-30);

                data = _.chain(data)
                    .map(function (chat) {
                        //remove stupid &nbsp; hack
                        while(chat.text.indexOf('&nbsp;') >= 0 ||
                                chat.by.indexOf('&nbsp;') >= 0) {

                            chat.text = chat.text.replace('&nbsp;', ' ');
                            chat.by = chat.by.replace('&nbsp;', ' ');
                        }

                        return chat;
                    })
                    .reverse()
                    .value();

                chatUIHtml = ui.chatUI(data);
                wrapper.find('#chats').remove();
                chatDiv = $('<div id="chats">').html(chatUIHtml);
                wrapper.find('#chatHead').append(chatDiv);
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

            var wrapper = $(this.selector),
                chatHead = $('<div id="chatHead">')
                    .html(ui.chatHead(this.persister.nickname())),
                sendForm = $('<div id="sendForm">')
                    .html(ui.sendForm());

            wrapper.html(chatHead);
            wrapper.append(sendForm);

            fetchPosts.call(this);
            chatInterVal = setInterval(fetchPosts.bind(this), 3000);
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
                        fetchPosts.call(self);
                        wrapper.find('#message').val('');
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