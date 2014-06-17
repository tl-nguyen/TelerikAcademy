(function () {
	'use strict';
	var num = 19,
		mask = 1 << 3,
		bitThree = (num & mask ) >> 3;
	
	myConsole.appendToConsole('Task 05:', ['Bit three of ' + num + ' = ' + bitThree]);
}());