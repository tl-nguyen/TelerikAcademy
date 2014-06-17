(function () {
	'use strict';
	
	var n = 100,
		result = '',
		i;
	
	for (i = 1; i <= n; i ++) {
		if (i % 3 === 0 && i % 7 === 0 ) { continue; }
		result += i + ' ';
	}
	
	myConsole.appendToConsole('Task 02:', [result]);
}());