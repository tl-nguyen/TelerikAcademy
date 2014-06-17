(function () {
	'use strict';
	
	var nums = new Array(20),
		i, len;
	
	for (i = 0, len = nums.length; i < len; i += 1) {
		nums[i] = i * 5;
	}
	
	myConsole.appendToConsole('Task 01:', [nums]);
}());