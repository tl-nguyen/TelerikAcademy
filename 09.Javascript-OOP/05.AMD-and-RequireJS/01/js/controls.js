define(["handlebars"], function (Handlebars) {
    'use strict';

    var selected = null;

    var ComboBox = (function () {
        var ComboBox = function (data) {
            this.data = data;
        };

        ComboBox.prototype = {
            render: function (templateString) {
                var template,
                    resultHTML,
                    container;

                template = Handlebars.compile(templateString);

                resultHTML = template(this.data);

                container = document.createElement('div');
                container.innerHTML = resultHTML;

                return container;
            }
        };

        return ComboBox;
    }());

    var handlerSetup = function (el, comboBoxItemClass) {
        var items = el.getElementsByClassName(comboBoxItemClass);

        for (var i = 0, len =  items.length; i < len; i += 1) {
            //initial set first item to display only
            if (i === 0) {
                items[i].style.display = 'block';
                selected = items[i];
            } else {
                items[i].style.display = 'none';
            }

            items[i].addEventListener('click', function () {
                if (selected === this) {
                    selected = null;
                    revealAll();
                } else if (selected === null) {
                    selected = this;
                    hideOthers(selected);
                }
            })
        }

        function revealAll() {
            for (var i = 0, len = items.length; i < len; i += 1) {
                items[i].style.display = 'block';
            }
        }

        function hideOthers(selectedItem) {
            for (var i = 0, len = items.length; i < len; i += 1) {
                if (items[i] === selectedItem) {
                    continue;
                }

                items[i].style.display = 'none';
            }
        }
    };

    return {
        ComboBox: ComboBox,
        handlerSetup: handlerSetup
    }
});