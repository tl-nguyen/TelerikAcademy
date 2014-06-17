(function () {
	'use strict';
	
	var num1 = 123,
		num2 = 2.4,
		num3 = 12,
		max;
	
	if (num1 > num2) {
		max = num1;
		
		if (num3 > max) {
			max = num3;
		}
	}
	
	myConsole.appendToConsole('Task 03:', [num1 + ', ' + num2 + ', ' + num3 + ' => max = ' + max]);
}());