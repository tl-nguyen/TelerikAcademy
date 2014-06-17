(function () {
	'use strict';
	
	var num = 11234;
	
	var lastDigitToWord = function (num) {
		var digits = ['zero', 'one', 'two', 'three', 'four',
					  'five', 'six', 'seven', 'eight', 'nine'];
		
		return digits[num % 10];
	};
	
	myConsole.appendToConsole('Task 01:', [
		lastDigitToWord(num)
	]);
}());