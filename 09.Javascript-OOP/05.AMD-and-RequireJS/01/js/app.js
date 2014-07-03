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
        var comboBox1,
            comboBox2,
            container1,
            container2,
            frag;

        comboBox1 = new controls.ComboBox({people: data});
        container1 = comboBox1.render('comboBoxTemplate', 'person-item');

        comboBox2 = new controls.ComboBox({people: data});
        container2 = comboBox2.render('comboBoxTemplate2', 'person');

        frag = document.createDocumentFragment();
        frag.appendChild(container1);
        frag.appendChild(container2);

        document.body.appendChild(frag);
    });

}());