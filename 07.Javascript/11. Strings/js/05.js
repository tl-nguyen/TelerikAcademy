(function () {
	'use strict';
	
	var input = 'hello    world   bla';
	
	function whitespaceReplace(text) {
        return text.replace(/ /g, '&nbsp;')
    }
	
	myConsole.appendToConsole('Task 05:', [
		whitespaceReplace(input)
	]);
}());