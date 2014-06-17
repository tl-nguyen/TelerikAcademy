(function () {
	'use strict';
	
	var input = '((a+b)*4)*(/5-d)';
	
	function checkBrackets(input) {
		var isCorrect = 0;
		
		for (var i = 0, len = input.length; i < len; i += 1) {
			if (isCorrect < 0) { return false; }
			if (input[i] === '(') { isCorrect += 1; }
			else if (input[i] === ')') { isCorrect -= 1; }
		}
		
		if (isCorrect === 0 ) { return true; }
		return false;
	}
	
	myConsole.appendToConsole('Task 02:', [
		checkBrackets(input)
	]);
}());