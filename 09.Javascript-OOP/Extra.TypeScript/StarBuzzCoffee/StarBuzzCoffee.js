var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var StarBuzzCoffee;
(function (StarBuzzCoffee) {
    var Beverage = (function () {
        function Beverage() {
            this._description = 'Unknown Beverage';
        }
        Beverage.prototype.getDescription = function () {
            return this._description;
        };

        Beverage.prototype.cost = function () {
            return 0;
        };
        return Beverage;
    })();
    StarBuzzCoffee.Beverage = Beverage;

    var CondimentDecorator = (function (_super) {
        __extends(CondimentDecorator, _super);
        function CondimentDecorator() {
            _super.apply(this, arguments);
        }
        CondimentDecorator.prototype.getDescription = function () {
            return this._description;
        };
        return CondimentDecorator;
    })(Beverage);
    StarBuzzCoffee.CondimentDecorator = CondimentDecorator;

    var DarkRoast = (function (_super) {
        __extends(DarkRoast, _super);
        function DarkRoast() {
            _super.call(this);
            this._description = "Dark Roast Coffee";
        }
        DarkRoast.prototype.cost = function () {
            return 1.05;
        };
        return DarkRoast;
    })(Beverage);
    StarBuzzCoffee.DarkRoast = DarkRoast;

    var Decaf = (function (_super) {
        __extends(Decaf, _super);
        function Decaf() {
            _super.call(this);
            this._description = "Decaf Coffee";
        }
        Decaf.prototype.cost = function () {
            return 1.05;
        };
        return Decaf;
    })(Beverage);
    StarBuzzCoffee.Decaf = Decaf;

    var Espresso = (function (_super) {
        __extends(Espresso, _super);
        function Espresso() {
            _super.call(this);
            this._description = "Espresso";
        }
        Espresso.prototype.cost = function () {
            return 1.99;
        };
        return Espresso;
    })(Beverage);
    StarBuzzCoffee.Espresso = Espresso;

    var HouseBlend = (function (_super) {
        __extends(HouseBlend, _super);
        function HouseBlend() {
            _super.call(this);
            this._description = "Espresso";
        }
        HouseBlend.prototype.cost = function () {
            return 1.99;
        };
        return HouseBlend;
    })(Beverage);
    StarBuzzCoffee.HouseBlend = HouseBlend;

    var Milk = (function (_super) {
        __extends(Milk, _super);
        function Milk(beverage) {
            _super.call(this);
            this._beverage = beverage;
        }
        Milk.prototype.getDescription = function () {
            return this._beverage.getDescription() + ", Milk";
        };

        Milk.prototype.cost = function () {
            return .10 + this._beverage.cost();
        };
        return Milk;
    })(CondimentDecorator);
    StarBuzzCoffee.Milk = Milk;

    var Mocha = (function (_super) {
        __extends(Mocha, _super);
        function Mocha(beverage) {
            _super.call(this);
            this._beverage = beverage;
        }
        Mocha.prototype.getDescription = function () {
            return this._beverage.getDescription() + ", Mocha";
        };

        Mocha.prototype.cost = function () {
            return .10 + this._beverage.cost();
        };
        return Mocha;
    })(CondimentDecorator);
    StarBuzzCoffee.Mocha = Mocha;

    var Soy = (function (_super) {
        __extends(Soy, _super);
        function Soy(beverage) {
            _super.call(this);
            this._beverage = beverage;
        }
        Soy.prototype.getDescription = function () {
            return this._beverage.getDescription() + ", Soy";
        };

        Soy.prototype.cost = function () {
            return .10 + this._beverage.cost();
        };
        return Soy;
    })(CondimentDecorator);
    StarBuzzCoffee.Soy = Soy;

    var Whip = (function (_super) {
        __extends(Whip, _super);
        function Whip(beverage) {
            _super.call(this);
            this._beverage = beverage;
        }
        Whip.prototype.getDescription = function () {
            return this._beverage.getDescription() + ", Whip";
        };

        Whip.prototype.cost = function () {
            return .10 + this._beverage.cost();
        };
        return Whip;
    })(CondimentDecorator);
    StarBuzzCoffee.Whip = Whip;
})(StarBuzzCoffee || (StarBuzzCoffee = {}));
//# sourceMappingURL=StarBuzzCoffee.js.map
