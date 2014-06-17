(function () {
	'use strict';
	
	var els = [3, 2, 3, 4, 2, 2, 4],
		maxLen = 0,
		currentLen = 0,
		maxIndex = 0,
		currentIndex = 0,
		result = '',
		i, len;
	
	for (i = 0, len = els.length; i < len - 1; i += 1) {
		currentLen++;
		
		if (els[i] + 1 !== els[i + 1]) {
			
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
	
	myConsole.appendToConsole('Task 04:', [
		'{' +  result + '}'
	]);
}());