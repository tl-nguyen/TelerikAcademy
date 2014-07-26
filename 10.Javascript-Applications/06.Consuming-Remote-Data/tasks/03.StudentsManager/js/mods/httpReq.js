define(['q', 'jquery'], function (Q, $) {

    var HttpReq;

    HttpReq = (function () {
        var url;
        function HttpReq(inputUrl) {
            url = inputUrl || 'http://localhost:3000/students';
        }

        HttpReq.prototype.get = function () {
            var deferred = Q.defer(),
                options = {};

            options.url = url;
            options.type = 'GET';
            options.contentType = 'application/json';

            options.success = function (data) {
                deferred.resolve(data.students);
            };

            options.error = function (error) {
                deferred.reject(error);
            };

            $.ajax(options);

            return deferred.promise;
        };

        HttpReq.prototype.post = function (data) {
            var deferred = Q.defer(),
                options = {};

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

        HttpReq.prototype.remove = function (param) {
            var deferred = Q.defer(),
                options = {};

            options.url = url + '/' + param;
            options.type = 'DELETE';
//            options.type = 'POST';
//            options.data = {_method: 'delete'};
            options.success = function (data) {
                deferred.resolve(data);
            };

            options.error = function (error) {
                deferred.reject(error);
            };

            $.ajax(options);

            return deferred.promise;
        };

        return HttpReq;
    }());

    return HttpReq;
});