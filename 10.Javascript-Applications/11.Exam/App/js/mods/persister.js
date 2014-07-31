define(['httpReq', 'cryptoJS'], function (httpReq, CryptoJS) {

    var MainPersister, UserPersister, username, sessionKey;

    username = localStorage.getItem("username");
    sessionKey = localStorage.getItem("sessionKey");

    function saveUserData(userData) {
        localStorage.setItem("username", userData.username);
        localStorage.setItem("sessionKey", userData.sessionKey);
        username = userData.username;
        sessionKey = userData.sessionKey;
    }
    function clearUserData() {
        localStorage.removeItem("username");
        localStorage.removeItem("sessionKey");
        username = null;
        sessionKey = null;
    }

    MainPersister = (function () {
        function MainPersister(rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(rootUrl);
            this.post = new PostsPersister(rootUrl);
        }

        MainPersister.prototype.isUserLoggedIn = function () {
            var isLoggedIn;

            isLoggedIn = (username != null) && (sessionKey != null);

            return isLoggedIn;
        };

        MainPersister.prototype.username = function () {
            return username;
        };

        return MainPersister;
    }());

    PostsPersister = (function () {
        function PostsPersister(rootUrl) {

            if(!rootUrl) {
                throw new Error('rootUrl must be setted');
            }

            this.rootUrl = rootUrl + 'post';
        }

        PostsPersister.prototype.getPosts = function (username) {
            var url = this.rootUrl;

            if(username) {
                url += '?user=' + username;
            }
            return httpReq.getJSON(url);
        };

        PostsPersister.prototype.getPatternPosts = function (pattern, username) {
            var url = this.rootUrl + '?pattern=' + pattern;

            if(username) {
                url += '&user=' + username;
            }

            return httpReq.getJSON(url);
        };

        PostsPersister.prototype.createPost = function (post) {
            return httpReq.postJSON(this.rootUrl, post, sessionKey);
        };

        return PostsPersister;
    }());

    UserPersister = (function () {
        function UserPersister(rootUrl) {
            this.rootUrl = rootUrl;
        }

        UserPersister.prototype.login = function (user) {
            var url, userData;

            url = this.rootUrl + 'auth';

            userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            return httpReq.postJSON(url, userData)
                .then(function (data) {
                    saveUserData(data);
                });
        };

        UserPersister.prototype.register = function (user) {
            var url, userData;

            url = this.rootUrl + 'user';

            userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.username + user.password).toString()
            };

            return httpReq.postJSON(url, userData);
        };

        UserPersister.prototype.logout = function () {
            var url;

            url = this.rootUrl + 'user';

            console.log(sessionKey);

            return httpReq.putJSON(url, true, sessionKey)
                .then(function () {
                    clearUserData();
                });
        };

        return UserPersister;
    }());

    return MainPersister;

});