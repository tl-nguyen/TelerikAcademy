(function (doc) {
    var canvas = doc.getElementById('the-canvas'),
        ctx = canvas.getContext('2d'),
        x = 0,
        y = canvas.height / 2,
        direction = {
            x: 1,
            y: 1
        };

    ctx.beginPath();
    ctx.moveTo(0, canvas.height / 2);

    function draw() {
        ctx.lineTo(x, y);
        ctx.stroke();

        if (isTheEnd()) {
            direction = newDirection();
        }

        x += direction.x;
        y += direction.y;
    }

    function newDirection() {
        if (direction.x === 1 && direction.y === 1) {
            return {
                x: 1,
                y: -1
            };
        }
        if (direction.x === 1 && direction.y === -1) {
            return {
                x: -1,
                y: -1
            };
        }
        if (direction.x === -1 && direction.y === -1) {
            return {
                x: -1,
                y: 1
            };
        }
        if (direction.x === -1 && direction.y === 1) {
            return {
                x: 1,
                y: 1
            };
        }
    }

    function isTheEnd() {
        return x >= canvas.width || y >= canvas.height ||
            x < 0 || y < 0;
    }

    setInterval(draw, 1);

}(document));