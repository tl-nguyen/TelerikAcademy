(function () {
	'use strict';
	
	var sentence = 'Write a function that finds all the occurrences of word in a text';
	
    var occurencesCount = function (sentence, word, caseSensitive) {
        var regExp = new RegExp('\\b' + word + '\\b', 'g' + (caseSensitive ? '' : 'i')),
			match = sentence.match(regExp);

        return match ? match.length : -1;
    }
	
	myConsole.appendToConsole('Task 03:', [
		occurencesCount(sentence, 'a')
	]);
}());