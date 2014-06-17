(function () {
	'use strict';
	var num = 17,
		isPrime = true,
		i;
	
	for (i = 2; i < Math.sqrt(num); i++) {
		if (num % i === 0) {
			isPrime = false;
			break;
		}
	}
	
	myConsole.appendToConsole('Task 07:', [num + ' is prime ? ' + isPrime]);
}());