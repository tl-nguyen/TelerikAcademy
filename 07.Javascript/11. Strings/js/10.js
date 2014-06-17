(function () {
	'use strict';
	
	var input = 'blabla balbla ballab fdsaf abba lamal cool';
	
	function palindromesExtract(input) {
		var reg = /\w+/g,
			matches = input.match(reg),
			palindromes = [];
		
		for (var i = 0; i < matches.length; i += 1) {
			if (isPalindrome(matches[i])) {
				palindromes.push(matches[i]);
			}
		}
		
		return palindromes;
	}
	
	function isPalindrome(str) {
        for (var i = 0; i < parseInt(str.length / 2, 10); i++) {
			if (str[i] !== str[str.length - 1 - i]) {
				return false;
			}   
		}
		
        return true;
    }
	
	myConsole.appendToConsole('Task 10:', [
		palindromesExtract(input)
	]);
}());