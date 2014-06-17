(function () {
	'use strict';
	
	var els = [12, 3, 123, 22, 12, 11, 0, -23, -1],
		sortedEls;
	
	sortedEls = selectionSort(els);
	
	function selectionSort(items) {
		var len = items.length,
			min, i, j;

		for (i=0; i < len; i++) {

			//set minimum to this position
			min = i;

			//check the rest of the array to see if anything is smaller
			for (j= i + 1; j < len; j += 1) {
				if (items[j] < items[min]) {
					min = j;
				}
			}

			//if the minimum isn't in the position, swap it
			if (i != min) {
				swap(items, i, min);
			}
		}

		return items;
	}
	
	function swap(items, firstIndex, secondIndex) {
		var temp = items[firstIndex];
		items[firstIndex] = items[secondIndex];
		items[secondIndex] = temp;
	}
	
	myConsole.appendToConsole('Task 05:', [sortedEls]);
}());