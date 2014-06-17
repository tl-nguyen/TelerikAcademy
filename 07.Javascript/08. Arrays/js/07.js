(function () {
	'use strict';
	var nums = [23, 1, 2, 32, 21];
	
	function binarySearch(items, value){

		var startIndex  = 0,
			stopIndex   = items.length - 1,
			middle      = Math.floor((stopIndex + startIndex)/2);

		while(items[middle] != value && startIndex < stopIndex){

			//adjust search area
			if (value < items[middle]){
				stopIndex = middle - 1;
			} else if (value > items[middle]){
				startIndex = middle + 1;
			}

			//recalculate middle
			middle = Math.floor((stopIndex + startIndex)/2);
		}

		//make sure it's the right value
		return (items[middle] != value) ? -1 : middle;
	}
	
	myConsole.appendToConsole('Task 07:', ['index of number 32 is ' + binarySearch(nums, 32)]);
}());