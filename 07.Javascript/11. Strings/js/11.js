(function () {
	'use strict';
	
	function stringFormat(str) {
        var selfArguments = arguments;

        return str.replace(/\{(\d+)\}/g, function(match, p1) {
            return selfArguments[+p1 + 1];
        });
    }
	
	myConsole.appendToConsole('Task 11:', [
		stringFormat('{0}, {1}!', 'blaaa', 'fdafsafd')
	]);
}());