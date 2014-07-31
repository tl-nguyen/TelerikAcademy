(function () {
    'use strict';

    require.config({
        paths: {
            underscore: 'libs/underscore',
            q: 'libs/q',
            jquery: 'libs/jquery',
            mustache: 'libs/mustache',
            sammy: 'libs/sammy',
            cryptoJS: 'libs/sha1',
            httpReq: 'mods/httpReq',
            routes: 'mods/routes',
            persister: 'mods/persister',
            controller: 'mods/controller',
            ui: 'mods/ui'
        },
        shim: {
            underscore: {
                exports: '_'
            },
            cryptoJS: {
                exports: 'CryptoJS'
            }
        }
    });

    require(['routes', 'cryptoJS'], function (routes) {

        routes.load();

    });

}());