(function () {
	'use strict';
	
	var arr = [12, 3, 3, 12, 123, 22, 12, 0, 0, 22, 123, 22, 12, 11, 0];
	
	var occurencesCount = function (arr, num) {
		function isTheSame(el) {
			return el === num;
		}
		
		return arr.filter(isTheSame).length;
	}
	
	myConsole.appendToConsole('Task 05:', [occurencesCount(arr, 22)]);
}());