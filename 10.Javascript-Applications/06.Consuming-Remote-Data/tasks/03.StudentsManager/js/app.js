(function () {
    'use strict';

    require.config({
        paths: {
            'underscore': 'libs/underscore',
            'q': 'libs/q',
            'jquery': 'libs/jquery',
            'httpReq': 'mods/httpReq',
            'studentsManager': 'mods/studentsManager'
        },
        shim: {
            'underscore': {
                exports: '_'
            }
        }
    });

    require(['studentsManager'], function (StudentsManager) {

        new StudentsManager('http://localhost:3000/students', 'manager');

    });

}());