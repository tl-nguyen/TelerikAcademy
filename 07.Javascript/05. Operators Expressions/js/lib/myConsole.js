var myConsole = {
	appendToConsole : function (title, els) {
		var console = document.getElementById('console'),
			i,
			len;
		
		console.innerHTML += '<h2>' + title + '</h2>';
		for (i = 0, len = els.length; i < len; i += 1) {
			console.innerHTML += '<div>' + els[i] + '</div>';
		}
		
	}
};