(function () {

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    function getRandomColor() {
        return "rgb(" +
            getRandomInt(0, 255) + "," +
            getRandomInt(0, 255) + "," +
            getRandomInt(0, 255) + ")";
    }

    function generateDiv() {
        var width = 40;
        var height = 40;

        var borderRadius = 25;
        var borderWidth = 2;

        var div = document.createElement('div');
        var strong = document.createElement('strong');
        var strongContent = document.createTextNode('DIV');

        strong.appendChild(strongContent);
        div.appendChild(strong);

        div.style.position = 'absolute';
        div.style.textAlign = 'center';
        div.style.margin = 150 + 'px';
        div.style.width = width + 'px';
        div.style.height = height + 'px';
        div.style.backgroundColor = getRandomColor();
        div.style.border = borderWidth + 'px solid ' + getRandomColor();
        div.style.borderRadius = borderRadius + 'px';

        document.body.appendChild(div);
    }

    function rotateDivs () {
        for(i = 0; i < 5; i++) {
            allDivs[i].style.left = Math.cos(angle + 2 * Math.PI / allDivs.length * i)/radius * 3000 + 'px';
            allDivs[i].style.top = Math.sin(angle + 2 * Math.PI / allDivs.length * i)/radius * 3000 + 'px';
        }

        angle = angle + 0.15;

        setTimeout(rotateDivs, 100);
    }

    var i = 0;

    for(i = 0; i < 5; i++) {
        generateDiv();
    }

    var allDivs = document.querySelectorAll('div');
    var angle = 0;
    var radius = 50;
    rotateDivs();
}());