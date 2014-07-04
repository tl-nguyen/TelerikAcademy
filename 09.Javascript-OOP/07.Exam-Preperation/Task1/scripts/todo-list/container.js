define(['todo-list/section'], function(Section) {
    'use strict';
    var Container;

    Container = (function() {
        function Container() {
            this.sections = [];
        }

        Container.prototype = {
            add: function (section) {
                if (!(section instanceof Section)) {
                    throw {
                        message: 'the parameter is not Section type'
                    }
                }

                this.sections.push(section);

                return this;
            },

            getData: function () {
                return this.sections;
            }
        };

        return Container;
    }());

    return Container;
});