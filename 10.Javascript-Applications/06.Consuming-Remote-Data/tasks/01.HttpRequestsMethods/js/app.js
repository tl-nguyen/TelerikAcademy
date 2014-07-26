(function () {
    'use strict';

    require.config({
        paths: {
            'underscore': 'libs/underscore',
            'q': 'libs/q',
            'jquery': 'libs/jquery',
            'httpReq': 'mods/httpReq'
        },
        shim: {
            'underscore': {
                exports: '_'
            }
        }
    });

    require(['httpReq'], function (httpReq) {
        //testing the http request methods, the headers are optional

        var url = 'http://localhost:3000/students',
            postData = {
                name: 'testStud',
                grade: 10
            };

        httpReq.get(url, {'Accept': 'application/json'})
            .then(function (data) {
                console.log(data);
            });

        httpReq.post(url, postData, {'Accept': 'application/json'})
            .then(function (data) {
                console.log(data);
            });
    });

}());