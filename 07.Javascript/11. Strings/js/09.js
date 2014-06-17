(function () {
	'use strict';
	
	var input = 'hello cool@gmail.com, blbla@com.com';
	
	function emailExtract(input) {
		var reg = /\w+@\w+\.\w+/g,
			matches = input.match(reg);
		
		return matches;
	}
	
	myConsole.appendToConsole('Task 09:', [
		emailExtract(input)
	]);
}());