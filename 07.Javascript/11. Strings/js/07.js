(function () {
	'use strict';
	
	var url = 'http://www.devbg.org/forum/index.php';
	
	function urlInfo(url) {
		var reg = /^(.*):\/\/(.*)\/(.*)/g,
			matches = reg.exec(url);
		
		return {
			protocol: matches[1],
			server: matches[2],
			resource: matches[3]
		}
	}
	
	myConsole.appendToConsole('Task 07:', [
		JSON.stringify(urlInfo(url))
	]);
}());