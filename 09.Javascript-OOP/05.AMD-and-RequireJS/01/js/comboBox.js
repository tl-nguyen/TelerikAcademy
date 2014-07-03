define(['handlebars'], function (Handlebars) {
    'use strict';

    var id = 0,
        selected = [];

    var ComboBox = function (data) {
        this.data = data;
        id += 1;
        this.id = id;
        selected[this.id] = null;
    };

    ComboBox.prototype.render = function (templateString, itemClass) {
        var template,
            resultHTML,
            container;

        template = Handlebars.compile(templateString);

        resultHTML = template(this.data);

        container = document.createElement('div');
        container.innerHTML = resultHTML;

        eventhandlingSetup(container, itemClass, this.id);

        return container;
    };

    var eventhandlingSetup = function (container, comboBoxItemClass, comboId) {
        var items = container.getElementsByClassName(comboBoxItemClass);

        for (var i = 0, len =  items.length; i < len; i += 1) {
            //initial set first item to display only
            if (i === 0) {
                items[i].style.display = 'block';
                selected[comboId] = items[i];
            } else {
                items[i].style.display = 'none';
            }

            items[i].addEventListener('click', function () {
                if (selected[comboId] === this) {
                    selected[comboId] = null;
                    revealAll();
                } else if (selected[comboId] === null) {
                    selected[comboId] = this;
                    hideOthers(selected[comboId]);
                }
            });
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

    return ComboBox;
});