(function () {
	'use strict';
	
	var input = 'We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don\'t</mixcase> have <lowcase>anything</lowcase> else.'
	
	function mixCase(str) {
        var result = '';

        for (var i = 0, len = str.length; i < len; i++) {
            result += str.charAt(i)[Math.round(Math.random()) ? 'toLowerCase' : 'toUpperCase']();
		}
		
        return result
    }
	
	function textFormat(input) {
		return input.replace(/<upcase>(.*?)<\/upcase>/g, function(match, p1) {
            return p1.toUpperCase()
        }).replace(/<lowcase>(.*?)<\/lowcase>/g, function(match, p1) {
            return p1.toLowerCase()
        }).replace(/<mixcase>(.*?)<\/mixcase>/g, function(match, p1) {
            return mixCase(p1)
        })
	}
	
	myConsole.appendToConsole('Task 04:', [
		textFormat(input)
	]);
}());