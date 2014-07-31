(function () {
    'use strict';

    require.config({
        paths: {
            mocha: 'libs/mocha',
            chai: 'libs/chai',
            //libs
            underscore: '../App/js/libs/underscore',
            q: '../App/js/libs/q',
            jquery: '../App/js/libs/jquery',
            mustache: '../App/js/libs/mustache',
            sammy: '../App/js/libs/sammy',
            cryptoJS: '../App/js/libs/sha1',
            //modules for tests
            controller: '../App/js/mods/controller',
            persister: '../App/js/mods/persister',
            httpReq: '../App/js/mods/httpReq',
            ui: '../App/js/mods/ui'
        },
        shim: {
            'mocha': {
                exports: 'mocha'
            },
            underscore: {
                exports: '_'
            }
        }
    });

    require(['mocha', 'controller'], function(mocha){
        mocha.setup('bdd');

        require(['specs/controller.tests', 'specs/persister.tests', 'specs/httpReq.tests', 'specs/ui.tests'], function() {
            mocha.run();
        });

    });

}());