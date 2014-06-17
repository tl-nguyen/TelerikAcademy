(function () {
	'use strict';
	
	var x = 3,
		y = -1,
		isWithinCircle = x < 5 && x > -5 && y < 5 && y > -5;
	
	myConsole.appendToConsole('Task 06:', ['(' + x + ',' + y + ') is within circle (0,5) : ' + isWithinCircle]);
}());