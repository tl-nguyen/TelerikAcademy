define(['mustache'], function (Mustache) {

    var loadHomeUI = function (data) {
        var template = '<div id="headDiv">' +
                            '{{#username}}' +
                                '<p>Hello {{username}}</p>' +
                                '<button id="logoutBtn">Log Out</button>' +
                            '{{/username}}' +
                            '{{^username}}' +
                                '<p>Hello Guest</p>' +
                                '<a href="#/login">Log In</a>' +
                            '{{/username}}' +

                        '</div>';
        return Mustache.render(template, data);
    };

    var loadPostsUI = function (data, byPattern) {
        var template;
        if (byPattern) {
            template = '<h1>Posts</h1>' +
                        '<ul>' +
                            '{{#.}}' +
                                '<li class="post">' +
                                '<strong>"{{title}}" by <a href="#/posts/pattern/'+ byPattern + '/{{user.username}}">{{user.username}}</a> </strong> <br />"{{body}}"' +
                                '</li>' +
                            '{{/.}}' +
                        '</ul>' +
                        '<label for="pattern">Search Pattern</label>' +
                        '<input type="text" id="pattern"/>' +
                        '<button id="searchBtn">Search</button>';
        } else {
            template = '<h1>Posts</h1>' +
                        '<ul>' +
                            '{{#.}}' +
                            '<li class="post">' +
                                '<strong>"{{title}}" by <a href="#/posts/{{user.username}}">{{user.username}}</a> </strong> <br />"{{body}}"' +
                            '</li>' +
                            '{{/.}}' +
                        '</ul>' +
                        '<label for="pattern">Search Pattern</label>' +
                        '<input type="text" id="pattern"/>' +
                        '<button id="searchBtn">Search</button>';
        }


        return Mustache.render(template, data);
    };

    var loadLoginUI = function () {
         return '<div id="loginForm"> ' +
                    '<h1>Login</h1>' +
                    '<label for="username">Username</label>' +
                    '<input type="text" id="username"/>' +
                    '<label for="password">Password</label>' +
                    '<input type="password" id="password"/>' +
                    '<button id="loginBtn">Login</button>' +
                '</div>';
    };

    var loadRegisterUI = function () {
        return '<h1>Register</h1>' +
                '<label for="username">Username</label>' +
                '<input type="text" id="username"/>' +
                '<label for="password">Password</label>' +
                '<input type="password" id="password"/>' +
                '<button id="registerBtn">Register</button>';
    };

    var loadCreatePostUI = function () {
        return '<div id="createPostForm">' +
            '       <h1>Create Post</h1>' +
                    '<label for="title">Title</label>' +
                    '<input type="text" id="title"/>' +
                    '<label for="body">Body</label>' +
                    '<input type="text" id="body"/>' +
                    '<button id="createPostBtn">Create Post</button>' +
                '</div>';
    };

    return {
        loadPostsUI: loadPostsUI,
        loadLoginUI: loadLoginUI,
        loadRegisterUI: loadRegisterUI,
        loadCreatePostUI: loadCreatePostUI,
        loadHomeUI: loadHomeUI
    }
});