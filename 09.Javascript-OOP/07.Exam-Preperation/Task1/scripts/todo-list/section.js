define(['todo-list/item'], function(Item) {
    'use strict';

    var Section;

    Section = (function() {
        function Section(title) {
            this.title = title;
            this.items = [];
        }

        Section.prototype = {
            add: function (item) {
                if (!(item instanceof Item)) {
                    throw {
                        message: 'the parameter is not of type Item'
                    }
                }

                this.items.push(item.getData());

                return this;
            },

            getData: function () {
                return {
                    title: this.title,
                    items: this.items
                }
            }
        };

        return Section;
    }());

    return Section;
});