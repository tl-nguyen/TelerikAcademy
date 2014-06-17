(function () {
	'use strict';
	
	var els = [1, 2, 3, 2, 3, 5, 2];
	
	var biggerThanNeighbors = function (arr, pos) {
		if (pos > (arr.length - 1) || pos < 1) {
			return -1;
		}
		
		return arr[pos] > arr[pos - 1] && arr[pos] > arr[pos + 1];
	};
	
	var firstBiggerThanNeighbors = function (arr) {
		var i, len;
		
		for (i = 1, len = arr.length; i < len - 1; i += 1) {
			if (biggerThanNeighbors(arr, i)) {
				return i;
			}
		}
		
		return -1;
	}
	
	myConsole.appendToConsole('Task 03:', [
		firstBiggerThanNeighbors(els)
	]);
}());