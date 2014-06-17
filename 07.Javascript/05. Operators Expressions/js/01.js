(function () {
	'use strict';
	var num = 2,
		str = num + ' is ' + (num % 2 === 0 ? 'even' : 'odd');
	
	myConsole.appendToConsole('Task 01:', [str]);
}());