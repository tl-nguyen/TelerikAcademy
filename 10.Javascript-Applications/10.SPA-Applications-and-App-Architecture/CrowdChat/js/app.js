(function () {
    'use strict';

    require.config({
        paths: {
            underscore: 'libs/underscore',
            q: 'libs/q',
            jquery: 'libs/jquery',
            mustache: 'libs/mustache',
            sammy: 'libs/sammy',
            httpReq: 'mods/httpReq',
            routes: 'mods/routes',
            persisters: 'mods/persisters',
            controllers: 'mods/controllers',
            ui: 'mods/ui'
        },
        shim: {
            underscore: {
                exports: '_'
            }
        }
    });

    require(['routes'], function (routes) {

        routes.load();

    });

}());