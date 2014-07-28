(function () {
    'use strict';

    require.config({
        paths: {
            mocha: 'libs/mocha',
            chai: 'libs/chai',
            //libs
            underscore: '../CrowdChat/js/libs/underscore',
            q: '../CrowdChat/js/libs/q',
            jquery: '../CrowdChat/js/libs/jquery',
            mustache: '../CrowdChat/js/libs/mustache',
            sammy: '../CrowdChat/js/libs/sammy',
            //modules for tests
            controllers: '../CrowdChat/js/mods/controllers',
            persisters: '../CrowdChat/js/mods/persisters',
            httpReq: '../CrowdChat/js/mods/httpReq',
            ui: '../CrowdChat/js/mods/ui'
        },
        shim: {
            'mocha': {
                exports: 'mocha'
            }
        }
    });

    require(['mocha', 'controllers'], function(mocha, c){

        mocha.setup('bdd');

        require(['specs/controllers.tests', 'specs/persisters.tests', 'specs/httpReq.tests', 'specs/ui.tests'], function() {
            mocha.run();
        });

    });

}());