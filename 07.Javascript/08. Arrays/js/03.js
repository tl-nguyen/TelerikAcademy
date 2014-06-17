(function () {
	'use strict';
	
	var els = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1],
		maxLen = 0,
		currentLen = 0,
		maxIndex = 0,
		currentIndex = 0,
		result = '',
		i, len;
	
	for (i = 0, len = els.length; i < len - 1; i += 1) {
		currentLen++;
		
		if (els[i] !== els[i + 1]) {
			
			if (currentLen > maxLen) {
				maxLen = currentLen;
				maxIndex = currentIndex;	
			}
			
			currentIndex = i + 1;
			currentLen = 0;
		}
	}
	
	for (i = maxIndex, len = maxIndex + maxLen; i < len; i += 1) {
		if (i === len - 1) { 
			result += els[i];
			continue;
		}
		
		result += els[i] + ', ';
	} 
	
	myConsole.appendToConsole('Task 03:', [
		'{' +  result + '}'
	]);
}());