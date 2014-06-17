(function () {
	'use strict';
	
	var arr = [1,2,1,4,1,3,4,1,111,3,2,1,'1'];
	
	Array.prototype.remove = function (val) {
		return this.filter( function (element) {
			return element !== val;
		});
	};
	
	myConsole.appendToConsole('Task 02:', [
		arr.remove(1)
	]);
}());