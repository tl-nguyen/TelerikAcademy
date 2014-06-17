(function () {
	'use strict';
	var num1 = 4,
		num2 = 3;
	
	if (num1 > num2) {
		num1 += num2;
		num2 = num1 - num2;
		num1 = num1 - num2;
	}
	
	myConsole.appendToConsole('Task 01:', [
		'num1 = ' + num1,
		'num2 = ' + num2
	]);
}());