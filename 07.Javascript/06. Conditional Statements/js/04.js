(function () {
	'use strict';
	
	var n = [12, 2, 13];
	
	function swap(i, j) {
        var t = n[i]
        n[i] = n[j]
        n[j] = t
    }
	
    if (n[0] < n[1]) {
		if (n[1] < n[2]) { 
			swap(0, 2); 
		} 
        else if (n[0] < n[2]) { 
			swap(0, 1); 
			swap(1, 2); 
		}
        else {
			swap(0, 1);
		}
	}
        
    else {
		if (n[0] < n[2]) {
			swap(0, 1);
			swap(0, 2);
		}
		else if (n[1] < n[2]) {
			swap(1, 2);
		} 
	}
	
	myConsole.appendToConsole('Task 04:', [n]);
}());