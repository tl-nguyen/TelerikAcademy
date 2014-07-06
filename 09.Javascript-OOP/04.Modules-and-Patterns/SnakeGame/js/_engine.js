'use strict';

var game = game || {};

(function (scope) {
    var Engine;

    Engine = (function () {
        var snake,
            food,
            score,
            gameOver;

        function Engine(canvasId) {
            this.canvas = document.getElementById(canvasId);
            this.ctx = this.canvas.getContext("2d");
            this.width = this.canvas.width;
            this.height = this.canvas.height;
            this.cellWidth = 20;

            eventListenerSetup.call(this);
        }

        Engine.prototype.init = function () {
            gameOver = false;
            snake = new scope.Snake();
            food = new scope.Food();
            score = 0;

            moveFoodToNewPosition.call(this);

            gameLoop.call(this);
        };

        function gameLoop() {
            if (!gameOver) {
                drawGame.call(this);
                drawSnake.call(this);
                drawFood.call(this);
                drawScore.call(this);

                snake.move();

                handleCollision.call(this);

                setTimeout(gameLoop.bind(this), 1000 /  (15 +  score));
            }
        }

        function handleCollision() {
            if (snake.isCollidedItself()) {
                gameOver = true;
            }

            if (snake.body[0].x < 0 || snake.body[0].x > (this.width - this.cellWidth) / this.cellWidth ||
                snake.body[0].y < 0 || snake.body[0].y > (this.height - this.cellWidth) / this.cellWidth) {
                gameOver = true;
            }

            if (snake.isCollided(food.x, food.y)) {
                var tail = {
                    x: food.x,
                    y: food.y
                };

                snake.body.push(tail);
                moveFoodToNewPosition.call(this);
                score += 1;
            }
        }

        function moveFoodToNewPosition() {
            var x, y;

            x = Math.floor(Math.random() * (this.width - this.cellWidth) / this.cellWidth);
            y = Math.floor(Math.random() * (this.height - this.cellWidth) / this.cellWidth);

            food.setPosition(x, y);
        }

        function drawGame() {
            this.ctx.fillStyle = "#ccc";
            this.ctx.fillRect(0, 0, this.width, this.height);
            this.ctx.strokeStyle = "black";
            this.ctx.strokeRect(0, 0, this.width, this.height);
        }

        function drawScore() {
            this.ctx.font= "20px Georgia";
            this.ctx.fillText("Score: " + score, 10, this.height - 10);
        }

        function drawCell(x, y) {
            this.ctx.fillStyle = "black";
            this.ctx.fillRect(x * this.cellWidth, y * this.cellWidth, this.cellWidth, this.cellWidth);
            this.ctx.strokeStyle = "white";
            this.ctx.strokeRect(x * this.cellWidth, y * this.cellWidth, this.cellWidth, this.cellWidth);
        }

        function drawSnake() {
            for(var i = 0, len = snake.body.length; i < len; i += 1) {
                var snakeBodyCell = snake.body[i];

                drawCell.call(this, snakeBodyCell.x, snakeBodyCell.y);
            }
        }

        function drawFood() {
            drawCell.call(this, food.x, food.y);
        }

        function eventListenerSetup() {
            var self = this;
            document.addEventListener('keydown', function(e){
                var key = e.which;

                if (key === 37 && snake.direction !== "right") {
                    snake.direction = "left";
                } else if(key === 38 && snake.direction !== "down") {
                    snake.direction = "up";
                } else if(key === 39 && snake.direction !== "left") {
                    snake.direction = "right";
                } else if(key === 40 && snake.direction !== "up") {
                    snake.direction = "down";
                }

                if (gameOver) {
                    self.init();
                }
            });
        }

        return Engine;
    }());

    scope.Engine = Engine;

}(game));