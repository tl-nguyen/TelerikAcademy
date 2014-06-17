(function () {
	'use strict';
	
	var persons = [
		{ firstname : 'Gosho', lastname: 'Petrov', age: 32 },
		{ firstname : 'Grigor', lastname: 'Ivan', age: 81 },
		{ firstname : 'Pesho', lastname: 'Gosho', age: 21 },
		{ firstname : 'Grigor', lastname: 'Grigorov', age: 32 }
	]
	
	function group(persons, prop) {
        var result = {};

        persons.forEach(function (person) {
            var value = person[prop];
			
			result[value] = result[value] || [];
			
            result[value].push(person);
        });

        return result;
	}
	
	myConsole.appendToConsole('Task 06:', [
		JSON.stringify(group(persons, 'firstname'))
	]);
}());