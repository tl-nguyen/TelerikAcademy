var game = game || {};

(function (scope){
    var Food;

    Food = (function () {
        function Food() {
            this.x = 0;
            this.y = 0;
        }

        Food.prototype.setPosition = function (x, y) {
            this.x = x;
            this.y = y;
        };

        return Food;
    }());

    scope.Food = Food;

}(game));