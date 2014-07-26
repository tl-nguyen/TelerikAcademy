(function () {
    'use strict';

    require.config({
        paths: {
            'underscore': 'libs/underscore',
            'q': 'libs/q',
            'jquery': 'libs/jquery',
            'twitterFetcher': 'libs/twitterFetcher',
            'twitF': 'mods/twitF'
        },
        shim: {
            'underscore': {
                exports: '_'
            },
            'twitterFetcher': {
                exports: 'twitterFetcher'
            }
        }
    });

    require(['mods/twitF', 'jquery'], function (TwitF, $) {
        var myTweets, userId, elementId;

        userId = '345690956013633536';
        elementId = 'tweets';
        myTweets = new TwitF(userId);

        myTweets.fetch(elementId, 10);

        $('#fetchBtn').on('click', function () {
            myTweets.userId = $('#userId').val();
            myTweets.fetch(elementId, 10);
        });

    });

}());