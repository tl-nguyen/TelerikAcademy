define(['httpReq'], function (httpReq) {
    var nickname = localStorage.getItem("nickname");

    function saveNickName(inputNickname) {
        inputNickname = inputNickname !== '' ? inputNickname : 'Anonymous';
        localStorage.setItem("nickname", inputNickname);
        nickname = inputNickname;
    }

    function clearNickName() {
        localStorage.removeItem("nickname");
        nickname = null;
    }

    var MainPersister = (function () {
        function MainPersister(rootUrl) {
            this.rootUrl = rootUrl;
            this.chatRoom = new ChatRoomPersister(this.rootUrl);
        }

        MainPersister.prototype.isUserLoggedIn = function () {
            return nickname != null;
        };

        MainPersister.prototype.nickname = function () {
            return nickname;
        };

        return MainPersister;
    }());

    var ChatRoomPersister = (function () {
        function ChatRoomPersister(rootUrl) {
            this.rootUrl = rootUrl + 'posts';
        }

        ChatRoomPersister.prototype.loggedIn = function (nickname) {
            saveNickName(nickname);
        };

        ChatRoomPersister.prototype.loggedOut = function () {
            clearNickName();
        };

        ChatRoomPersister.prototype.getPosts = function () {
            return httpReq.getJSON(this.rootUrl);
        };

        ChatRoomPersister.prototype.sendPost = function (data) {
            return httpReq.postJSON(this.rootUrl, data);
        };

        return ChatRoomPersister;
    }());

    return {
        get: function (url) {
            return new MainPersister(url);
        }
    }

});