(function () {
	'use strict';
	
	var obj = {
		point: {
			x: 12,
			y: 1
		},
		msg: 'hello'
	};
	
	var result;
	
	function deepCopy(obj) {
		var res = {};
		
		if (typeof obj !== 'object') {
			return res = obj;
		}
		
		for (var prop in obj) {
			res[prop] = deepCopy(obj[prop]);
		}
		
		return res;
	}
	
	result = deepCopy(obj);
	
	myConsole.appendToConsole('Task 03:', [
		result.msg
	]);
}());