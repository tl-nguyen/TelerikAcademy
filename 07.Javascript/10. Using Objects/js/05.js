(function () {
	'use strict';
	
	var persons = [
		{ firstname : 'Gosho', lastname: 'Petrov', age: 32 },
		{ firstname : 'Bay', lastname: 'Ivan', age: 81 },
		{ firstname : 'Pesho', lastname: 'Kulev', age: 21 },
		{ firstname : 'Grigor', lastname: 'Grigorov', age: 16 }
	],
		youngest;
	
	var youngestPerson = function (persons) {
		var min = persons[0].age,
			minIndex = 0,
			i, len;
		
		for (i = 1, len = persons.length; i < len; i += 1) {
			if (persons[i].age < min) {
				min = persons[i].age;
				minIndex = i;
			}
		}
		
		return persons[minIndex];
	};	
		
	youngest = youngestPerson(persons); 
	
	myConsole.appendToConsole('Task 05:', [
		youngest.firstname + ' ' + youngest.lastname
	]);
}());