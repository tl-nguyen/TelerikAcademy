(function () {
	'use strict';
	var num = 1732,
		len = String(num).length,
		thirdIsSeven = String(num).charAt(len - 3) === '7';
	
	myConsole.appendToConsole('Task 04:', ['The third digit of ' + num + ' is 7 ? ' + thirdIsSeven]);
}());