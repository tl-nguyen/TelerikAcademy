define(['jquery', 'q'], function ($, Q) {
    var getJSON = function (url) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (err) {
                deferred.reject(err);
            }
        });

        return deferred.promise;
    };

    var postJSON = function (url, data) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (data) {
                deferred.resolve(data);
            },
            error: function (err) {
                deferred.reject(err);
            }
        });

        return deferred.promise;
    };

    return {
        getJSON: getJSON,
        postJSON: postJSON
    }
});