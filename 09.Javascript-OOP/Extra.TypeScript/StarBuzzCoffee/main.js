var beverage = new StarBuzzCoffee.Espresso();

console.log(beverage.getDescription() + ' $' + beverage.cost());

var beverage2 = new StarBuzzCoffee.HouseBlend();

beverage2 = new StarBuzzCoffee.Soy(beverage2);
beverage2 = new StarBuzzCoffee.Mocha(beverage2);

console.log(beverage2.getDescription() + ' $' + beverage2.cost());
//# sourceMappingURL=main.js.map
