(function () {
    'use strict';

    require.config({
        baseUrl: '/10.SPA-Applications-and-App-Architecture/',
        paths: {
            'mocha': 'CrowdChatTests/libs/mocha',
            'chai': 'CrowdChatTests/libs/chai',
            'controllers': 'CrowdChat/js/mods/controllers',
            'persisters': 'CrowdChat/js/mods/persisters',
            'httpReq': 'CrowdChat/js/mods/httpReq',
            'ui': 'CrowdChat/js/mods/ui'
        },
        shim: {
            'underscore': {
                exports: '_'
            },
            'mocha': {
                exports: 'mocha'
            }
        }
    });

    require(['mocha'], function(mocha){

        mocha.setup('bdd');

        require(['specs/controllers.tests', 'specs/persisters.tests', 'specs/httpReq.tests', 'specs/ui.tests'], function() {
            mocha.run();
        });

    });

}());