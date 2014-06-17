(function () {
	'use strict';
	
	var divsCount = function () {
		return document.getElementsByTagName('div').length;
	}
	
	myConsole.appendToConsole('Task 04:', [
		divsCount()
	]);
}());