(function () {
    'use strict';

	require.config({
		paths: {
			"handlebars": "libs/handlebars.min",
            "controls": "controls",
            "comboBox": "comboBox",
            "data": "data"
		},
        shim: {
            'handlebars': {
                exports: 'Handlebars'
            }
        }
	});

	require(["data", "controls"], function (data, controls) {

        var comboBox = new controls.ComboBox({people: data}),
            comboBox2 = new controls.ComboBox({people: data}),
            template = document.getElementById("comboBoxTemplate").innerHTML,
            container, container2, title, frag;

        frag = document.createDocumentFragment();
        title = document.createElement('h2');
        container = comboBox.render(template, 'person-item');
        container2 = comboBox2.render(template, 'person-item');

        title.innerText = 'Combo1';
        frag.appendChild(title.cloneNode(true));
        frag.appendChild(container);

        title.innerText = 'Combo2';
        frag.appendChild(title.cloneNode(true));
        frag.appendChild(container2);

        document.body.appendChild(frag);

	});

}());