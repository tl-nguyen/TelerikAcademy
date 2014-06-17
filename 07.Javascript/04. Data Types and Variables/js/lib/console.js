var myConsole = {
	appendToConsole : function (els) {
		var console = document.getElementById('console'),
			i,
			len;
		
		for (i = 0, len = els.length; i < len; i += 1) {
			console.innerHTML += '<div>' + els[i] + '</div>';
		}
		
	}
};