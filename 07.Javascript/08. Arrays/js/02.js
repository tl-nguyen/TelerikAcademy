(function () {
	'use strict';
	
	var arr1 = ['h', 'e', 'l', 'l', 'o'],
		arr2 = ['t', 'h', 'e', 'r', 'e'],
		isBigger,
		result = 'equal to',
		i, len = arr1.length <= arr2.length ? arr1.length : arr2.length;
	
	for (i = 0; i < len; i += 1) {
		if (arr1[i] === arr2[i]) { continue; }
		
		if (arr1[i] > arr2[i]) {
			isBigger = true;
			break;
		}
		
		if (arr1[i] < arr2[i]) {
			isBigger = false;
			break;
		} 
	}
	
	if (isBigger) { result = 'bigger than'; }
	else if (!isBigger) { result = 'smaller than'; }
	
	myConsole.appendToConsole('Task 01:', [
		'arr1 is ' + result + ' arr2'
	]);
}());