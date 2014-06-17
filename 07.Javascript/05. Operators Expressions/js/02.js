(function () {
	'use strict';
	var num = 35;
	var str = num + ' ' + 
			(num % 5 === 0 && num % 7 === 0 ? 'can' : 'can\'t') + 
			' be divided by 7 and 5 at the same time';
	
	myConsole.appendToConsole('Task 02:', [str]);
}());