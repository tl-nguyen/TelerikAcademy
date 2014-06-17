(function () {
	'use strict';
	
	var x = 2,
		y = -1,
		isWithinCircle = x > -1 && x < 3 && y > -1 && y < 3,
		isOutOfRec = x > 6 || x < -1 || y > 1 || y < -1;
		
	myConsole.appendToConsole('Task 09:', ['(' + x + ',' + y +') is within circle ((1,1),3) and out of rec (1,-1,6,2): ' + (isWithinCircle && isOutOfRec)]);
}());