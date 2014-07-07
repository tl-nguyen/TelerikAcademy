module StarBuzzCoffee {

    export interface IBeverage {
        getDescription(): string;
        cost(): number;
    }

    export class Beverage implements IBeverage{
        _description: string = 'Unknown Beverage';

        constructor() {}

        getDescription(): string {
            return this._description;
        }

        cost(): number {
            return 0;
        }
    }

    export class CondimentDecorator extends Beverage {

        public getDescription(): string {
            return this._description;

        }
    }

    export class DarkRoast extends Beverage {

        constructor() {
            super();
            this._description = "Dark Roast Coffee";
        }

        public cost(): number {
            return 1.05;
        }
    }

    export class Decaf extends Beverage {

        constructor() {
            super();
            this._description = "Decaf Coffee";
        }

        public cost(): number {
            return 1.05;
        }
    }

    export class Espresso extends Beverage {

        constructor () {
            super();
            this._description = "Espresso";
        }

        public cost(): number {
            return 1.99;
        }
    }

    export class HouseBlend extends Beverage {

        constructor() {
            super();
            this._description = "Espresso";
        }

        public cost(): number {
            return 1.99;
        }
    }

    export class Milk extends CondimentDecorator {
        _beverage:Beverage;

        constructor(beverage: Beverage) {
            super();
            this._beverage = beverage;
        }

        public getDescription(): string {
            return this._beverage.getDescription() + ", Milk";
        }

        public cost(): number {
            return .10 + this._beverage.cost();
        }
    }

    export class Mocha extends CondimentDecorator {
        _beverage: Beverage;

        constructor(beverage: Beverage) {
            super();
            this._beverage = beverage;
        }

        public getDescription(): string {
            return this._beverage.getDescription() + ", Mocha";
        }

        public cost():number {
            return .10 + this._beverage.cost();
        }
    }

    export class Soy extends CondimentDecorator {
        _beverage:Beverage;

        constructor(beverage:Beverage) {
            super();
            this._beverage = beverage;
        }

        public getDescription():string {
            return this._beverage.getDescription() + ", Soy";
        }

        public cost():number {
            return .10 + this._beverage.cost();
        }
    }

    export class Whip extends CondimentDecorator {
        _beverage:Beverage;

        constructor(beverage:Beverage) {
            super();
            this._beverage = beverage;
        }

        public getDescription():string {
            return this._beverage.getDescription() + ", Whip";
        }

        public cost():number {
            return .10 + this._beverage.cost();
        }
    }
}