var movingShapes = (function () {
    var WIDTH = 50,
        HEIGHT = 50,
        div = document.createElement('div'),
        _movingType;

    function styleThisDiv(div) {
        if (_movingType === 'ellipse') {
            div.style.borderRadius = WIDTH / 2 + 'px';
        }

        div.innerText = _movingType;
        div.style.width = WIDTH + 'px';
        div.style.height = HEIGHT + 'px';
        div.style.backgroundColor = getRandomColor();
        div.style.color = getRandomColor();
        div.style.borderColor = getRandomColor();
        div.style.borderStyle = 'solid';
        div.style.borderWidth = '1px';
        div.style.textAlign = 'center';
        div.style.position = 'absolute';
        div.style.left = getRandomNumber(window.innerWidth - WIDTH * 10) + WIDTH + 'px';
        div.style.top = getRandomNumber(window.innerHeight - HEIGHT * 10) + HEIGHT + 'px';
    }

    function add(movingType) {
        var currentDiv = div.cloneNode(true);

        _movingType = movingType;

        styleThisDiv(currentDiv);

        if (movingType === 'rect') {
            rectMovement(currentDiv);
        } else if (movingType === 'ellipse') {
            ellipseMovement(currentDiv);
        } else {
            alert('no such movement as ' + movingType);
        }

        document.body.appendChild(currentDiv);
    }

    function rectMovement(currentDiv) {
        var MOVESIZE = getRandomNumber(200) + 100,
            MAXSPEED = 30,
            minHorizontal = extractVal(currentDiv.style.left),
            maxHorizontal = extractVal(currentDiv.style.left) + MOVESIZE,
            minVertical = extractVal(currentDiv.style.top),
            maxVertical = extractVal(currentDiv.style.top) + MOVESIZE,
            directions = {
                left: {
                    x: -(getRandomNumber(MAXSPEED)),
                    y: 0
                },
                up: {
                    x: 0,
                    y: -(getRandomNumber(MAXSPEED))
                },
                right: {
                    x: getRandomNumber(MAXSPEED),
                    y: 0
                },
                down: {
                    x: 0,
                    y: getRandomNumber(MAXSPEED)
                }
            },
            currentDirection = directions.right;

        rectMove();

        function rectMove() {
            if (currentDirection === directions.right && extractVal(currentDiv.style.left) >= maxHorizontal) {
                currentDiv.style.left = maxHorizontal + 'px';

                directions.down.y = getRandomNumber(MAXSPEED);
                currentDirection = directions.down;
            }

            if (currentDirection === directions.down && extractVal(currentDiv.style.top) >= maxVertical) {
                currentDiv.style.top = maxVertical + 'px';

                directions.left.x = -(getRandomNumber(MAXSPEED));
                currentDirection = directions.left;
            }

            if (currentDirection === directions.left && extractVal(currentDiv.style.left) <= minHorizontal) {
                currentDiv.style.left = minHorizontal + 'px';

                directions.up.y = -(getRandomNumber(MAXSPEED));
                currentDirection = directions.up;
            }

            if (currentDirection === directions.up && extractVal(currentDiv.style.top) <= minVertical) {
                currentDiv.style.top = minVertical + 'px';

                directions.right.x = getRandomNumber(MAXSPEED);
                currentDirection = directions.right;
            }

            currentDiv.style.left = extractVal(currentDiv.style.left) + currentDirection.x + 'px';
            currentDiv.style.top = extractVal(currentDiv.style.top) + currentDirection.y + 'px';

            setTimeout(function() {
                rectMove();
            }, 1000 / 60);
        }
    }

    function ellipseMovement(currentDiv) {
        var RADIUS = getRandomNumber(100) + 100,
            centerX = extractVal(currentDiv.style.left) + WIDTH / 2 + RADIUS,
            centerY = extractVal(currentDiv.style.top) + HEIGHT / 2 + RADIUS,
            angle = 0;

        ellipseMove();

        function ellipseMove() {
            angle += getRandomNumber(11) / (getRandomNumber(100) + 50);

            currentDiv.style.left = centerX + RADIUS * Math.cos(angle) + 'px';
            currentDiv.style.top = centerY +  RADIUS * Math.sin(angle) + 'px';

            setTimeout(function() {
                ellipseMove();
            }, 1000/60);
        }

    }

    function extractVal(value) {
        return parseInt(value.split('px')[0]);
    }

    function getRandomColor() {
        return 'rgb(' + getRandomNumber(255) + ', ' +
            getRandomNumber(255) + ', ' +
            getRandomNumber(255) + ')';
    }

    function getRandomNumber(max) {
        return Math.floor(Math.random() * max) + 1;
    }

    return {
        add: add
    }
}());