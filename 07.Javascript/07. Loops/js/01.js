(function () {
	'use strict';
	
	var n = 100,
		result = '',
		i;
	
	for (i = 1; i <= n; i ++) {
		result += i + ' ';
	}
	
	myConsole.appendToConsole('Task 01:', [result]);
}());