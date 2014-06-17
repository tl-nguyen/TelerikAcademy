(function () {
	'use strict';
	
	var winProps = [],
		docProps = [],
		navProps = [];
	
	for (var prop in window) {
		winProps.push(prop);
	}
	
	for (var prop in document) {
		docProps.push(prop);
	}
	
	for (var prop in navigator) {
		navProps.push(prop);
	}
	
	winProps.sort();
	docProps.sort();
	navProps.sort();
	
	
	myConsole.appendToConsole('Task 04:', [
		'window: "' + winProps.shift() + '" - "' + winProps.pop() +'"',
		'document: "' + docProps.shift() + '" - "' + docProps.pop() +'"',
		'navigator: "' + navProps.shift() + '" - "' + navProps.pop() +'"',
	]);
}());