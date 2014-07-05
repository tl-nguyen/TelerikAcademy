var scope = game || {};

(function (scope){
    var Snake;

    Snake = (function () {
        function Snake() {
            this.direction = "right";
            this.body = [];

            create_snake.call(this);
        }

        Snake.prototype.move = function () {
            var headX = this.body[0].x,
                headY = this.body[0].y,
                tail = this.body.pop();

            if (this.direction === "right") {
                headX += 1;
            } else if (this.direction  === "left") {
                headX -= 1;
            } else if (this.direction  === "up") {
                headY -= 1;
            } else if (this.direction  === "down") {
                headY += 1;
            }

            tail.x = headX;
            tail.y = headY;

            this.body.unshift(tail);
        };

        Snake.prototype.isCollided = function(x, y) {
            var headX = this.body[0].x,
                headY = this.body[0].y;

            return headX === x && headY === y;
        };

        Snake.prototype.isCollidedItself = function() {
            for (var i = 1, len = this.body.length; i < len; i += 1) {
                if (this.isCollided(this.body[i].x, this.body[i].y)) {
                    return true;
                }
            }

            return false;
        };

        function create_snake() {
            var length = 5, //initial length
                i;

            for(i = length - 1; i>=0; i -= 1)
            {
                this.body.push({x: i, y:0});
            }
        }

        return Snake;
    }());

    scope.Snake = Snake;

}(scope));