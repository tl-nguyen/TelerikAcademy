(function () {
    'use strict';

    require.config({
        paths: {
            'underscore': "libs/underscore",
            'guessGame': "mods/guessGame",
            'gameUI': "mods/gameUI",
            'storageAPI': "mods/storageAPI"
        },
        shim: {
            'underscore': {
                exports: '_'
            }
        }
    });

    require(['guessGame'], function (GuessGame) {
        var game = new GuessGame();
        game.init();
    });

}());