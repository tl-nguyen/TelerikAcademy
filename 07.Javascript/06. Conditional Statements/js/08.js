(function () {
	'use strict';
	
	var ones = ['zero', 'one', 'two', 'three', 'four', 'five', 
			  	'six', 'seven', 'eight', 'nine', 'ten', 'eleven',
			   	'twelve'],
		others = ['one', 'twen', 'third', 'four', 'fif', 'six',
				 'seven', 'eight', 'nine'],
		input = 999,
		result;
	if (input >= 0 && input < 13) {
		result = ones[input];
	}
	
	if (input >= 13 && input < 20) {
		result = (others[(input % 10) - 1]) + 'teen';
	}
	
	if (input >= 20 && input < 100) {
		result = others[parseInt(input / 10) - 1] + 'ty ';
		result += input % 10 !== 0 ? ones[input % 10] : '';
	}
	
	if (input >= 100 && input < 1000) {
		result = ones[parseInt(input / 100)] + ' hundred and ';
		
		if ((parseInt(input / 10) % 10) !== 0) {
			result += others[(parseInt(input / 10) % 10) - 1] + 'ty ';
		}
		
		result += input % 10 !== 0 ? ones[input % 10] : '';
	}
	myConsole.appendToConsole('Task 08:', [result]);
}());