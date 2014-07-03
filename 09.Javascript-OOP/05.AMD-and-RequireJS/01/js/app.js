(function () {
    'use strict';

	require.config({
		paths: {
			"handlebars": "libs/handlebars.min",
            "controls": "controls",
            "data": "data"
		},
        shim: {
            'handlebars': {
                exports: 'Handlebars'
            }
        }
	});

	require(["data", "controls"], function (people, controls) {

        var comboBox = new controls.ComboBox({people: people}),
            template = document.getElementById("comboBoxTemplate").innerHTML,
            container;

        container = comboBox.render(template, 'person-item');

        document.body.appendChild(container);
	});
}());