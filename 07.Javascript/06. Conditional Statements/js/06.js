(function () {
	'use strict';
	
	var a = 1,
		b = -5,
		c = 6,
		d = b * b - 4 * a * c;

	myConsole.appendToConsole('Task 06:', [
		'first root = ' + (-b + Math.sqrt(d)) / (2 * a),
		'second root = ' + (-b - Math.sqrt(d)) / (2 * a)
	]);
}());