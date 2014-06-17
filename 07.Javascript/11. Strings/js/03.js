(function () {
	'use strict';
	
	var input = 'We are living in an yellow submarine. We don\'t have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days';
	
	function subStringCount(input, substr) {
		var subCount = 0,
			matchedIndex = 0;
		
		input = input.toLowerCase();
		
		for (var i = 0, len = input.length; i < len; ) {
			
			matchedIndex = input.indexOf(substr, i);
			
			if (matchedIndex >= 0) {
				i = matchedIndex + 1;
				subCount += 1;
			} else {
				break;
			}
		}
		
		return subCount;
	}
	
	myConsole.appendToConsole('Task 03:', [
		subStringCount(input, 'in')
	]);
}());