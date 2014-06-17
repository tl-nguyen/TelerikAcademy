(function () {
	'use strict';
	
	var str = "hello";
	var num = 123;
	var floatNum = 31.2;
	var boolVal = true;
	var obj = {
		arr: arr
	};
	var arr = [1, 2, "2", obj];
	
	myConsole.appendToConsole([
		">>>>>Task 03: ",
		typeof(str), 
		typeof(num), 
		typeof(floatNum), 
		typeof(boolVal), 
		typeof(obj), 
		typeof(arr)
	]);
	
}());