(function () {
	'use strict';
	
	var str = 'sample';
	
	String.prototype.reverse = function () {
		return this.split('').reverse().join('')	
	};
	
	
	myConsole.appendToConsole('Task 01:', [
		str.reverse()
	]);
}());