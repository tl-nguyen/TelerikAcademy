(function () {
	'use strict';
	
	var nums = [22, 100, 31, 122, 0, -2, 12],
		result = '',
		max = nums[0],
		min = nums[0],
		i, len;
	
	for (i = 1, len = nums.length; i <= len; i ++) {
		if (max < nums[i]) {
			max = nums[i];
		}
		else if (min > nums[i]) {
			min = nums[i];
		}
	}
	
	myConsole.appendToConsole('Task 03:', [
		'max = ' + max,
		'min = ' + min
	]);
}());