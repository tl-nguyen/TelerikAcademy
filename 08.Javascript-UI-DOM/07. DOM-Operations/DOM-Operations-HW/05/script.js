(function () {
    var treeView = document.getElementById('treeview');

    makeTreeView(treeView);

    function makeTreeView(treeView) {
        var allLis = treeView.getElementsByTagName('li');

        for (var i = 0, len = allLis.length; i < len; i += 1) {
            if (allLis[i].parentNode !== treeView) {
                allLis[i].style.display = 'none';
                allLis[i].addEventListener('click', addEventHandler, false);
            } else {
                allLis[i].addEventListener('click', addEventHandler, false);
            }
        }

        function addEventHandler(e) {
            e.preventDefault();
            e.stopPropagation();

            var childNodes = this.getElementsByTagName('li');

            if (childNodes) {

                for (var i = 0; i < childNodes.length; i += 1) {
                    if (childNodes[i].style.display === 'none') {
                        childNodes[i].style.display = 'block';
                    } else {
                        childNodes[i].style.display = 'none';
                    }
                }

            }
        }
    }

}());