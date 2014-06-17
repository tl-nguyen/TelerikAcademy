(function () {
	'use strict';
	
	var num1 = -2,
		num2 = -3,
		num3 = -1,
		negativeSign = 0;
	
	if (num1 < 0) { negativeSign += 1; }
	if (num2 < 0) { negativeSign += 1; }
	if (num3 < 0) { negativeSign += 1; }
	
	myConsole.appendToConsole('Task 02:', [
		num1 + ' * ' + num2 + ' * ' + num3 + ' => ' + (negativeSign % 2 === 1 ? '-' : '+')
	]);
}());