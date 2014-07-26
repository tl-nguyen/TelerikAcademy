define(['q', 'jquery', 'underscore'], function (Q, $, _) {

    var getJSON = function (url, headers) {
        var deferred = Q.defer(),
            options = {};

        if (headers) {
            addHeadersToOptions(options, headers);
        }

        options.url = url;
        options.type = 'GET';
        options.contentType = 'application/json';

        options.success = function (data) {
            deferred.resolve(data);
        };

        options.error = function (error) {
            deferred.reject(error);
        };

        $.ajax(options);

        return deferred.promise;
    };

    var postJSON = function (url, data, headers) {
        var deferred = Q.defer(),
            options = {};

        if (headers) {
            addHeadersToOptions(options, headers);
        }

        options.url = url;
        options.data = JSON.stringify(data);
        options.type = 'POST';
        options.contentType = 'application/json';

        options.success = function (data) {
            deferred.resolve(data);
        };

        options.error = function (error) {
            deferred.reject(error);
        };

        $.ajax(options);

        return deferred.promise;
    };

    function addHeadersToOptions(options, headers) {
        var newKey;

        _.each(headers, function (value, key) {
            newKey = standardToJqueryHeaderKey(key);
            options[newKey] = value;
        });

        return options;
    }

    function standardToJqueryHeaderKey(key) {
        return (key.substring(0, 1).toLowerCase() + key.substring(1)).replace('-', '');
    }

    return {
        get: getJSON,
        post: postJSON
    }

});