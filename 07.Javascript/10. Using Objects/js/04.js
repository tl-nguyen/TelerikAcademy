(function () {
	'use strict';
	
	var obj = {
		point: {
			x: 12,
			y: 1
		},
		msg: 'hello'
	};
	
	function hasProperty(obj, prop) {
		return obj.hasOwnProperty(prop);
	}
	
	myConsole.appendToConsole('Task 04:', [
		hasProperty(obj, 'msg')
	]);
}());