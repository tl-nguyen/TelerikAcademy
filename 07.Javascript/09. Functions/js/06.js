(function () {
	'use strict';
	
	var els = [1, 2, 3, 2, 3, 5, 2];
	
	var biggerThanNeighbors = function (arr, pos) {
		if (pos > (arr.length - 1) || pos < 1) {
			return -1;
		}
		
		return arr[pos] > arr[pos - 1] && arr[pos] > arr[pos + 1];
	};
	
	myConsole.appendToConsole('Task 03:', [
		biggerThanNeighbors(els, 2)
	]);
}());