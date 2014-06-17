(function () {
	'use strict';
	
	var num = 2567;
	
	var reverseDigit = function (num) {
		var result = 0;
		
		while (num > 0) {
			if (result === 0) {
				result += (num % 10);
			} else {
				result = (result * 10) + (num % 10);
			}
			
			num = parseInt(num / 10, 10);
		}
		
		return result;
	};
	
	myConsole.appendToConsole('Task 02:', [
		reverseDigit(num)
	]);
}());