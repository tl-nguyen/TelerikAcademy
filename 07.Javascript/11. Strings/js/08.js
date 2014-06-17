(function () {
	'use strict';
	
	var input = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>'
	
	function hrefToUrl(input) {
		return input.replace(/<a href="(.*?)">(.*?)<\/a>/g, '[URL=$1]$2[/URL]');
	}
	
	myConsole.appendToConsole('Task 08:', [
		hrefToUrl(input)
	]);
}());