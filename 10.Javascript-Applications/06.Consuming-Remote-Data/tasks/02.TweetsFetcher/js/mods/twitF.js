define(['twitterFetcher', 'jquery'], function (twitterFetcher, $) {
    var TwitF;

    TwitF = (function () {
        function TwitF(inputUserId) {
            this.userId = inputUserId;
        }

        TwitF.prototype.fetch = function (domElementId, numberOfTweets) {
            twitterFetcher.fetch(this.userId, domElementId, numberOfTweets, true);
        };

        return TwitF;
    }());

    return TwitF;
});