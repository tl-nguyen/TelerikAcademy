(function () {
	'use strict';
	
	var input = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";
	
	function removeTags(text) {
        return text.replace(/<(.*?)>/g, '');
    }
	
	myConsole.appendToConsole('Task 06:', [
		removeTags(input)
	]);
}());