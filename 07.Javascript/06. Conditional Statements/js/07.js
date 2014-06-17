(function () {
	'use strict';
	var nums = [23, 1, 2, 32, 21],
		max = nums[0],
		i, len;
	
	for (i = 1, len = nums.length; i < len; i += 1) {
		if (max < nums[i]) {
			max = nums[i];
		}
	}
	
	myConsole.appendToConsole('Task 07:', ['max of ' + nums + ' => ' + max]);
}());