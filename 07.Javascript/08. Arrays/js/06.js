(function () {
	'use strict';
	
	var els = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3],
		maxLen = 0,
		currentLen = 0,
		maxIndex = 0,
		currentIndex = 0,
		i, len;
	
	els.sort(function (a, b) {
		return a - b;	
	});
	
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
	
	myConsole.appendToConsole('Task 03:', [
		els[maxIndex] + ' (' + maxLen + ' times)'
	]);
}());