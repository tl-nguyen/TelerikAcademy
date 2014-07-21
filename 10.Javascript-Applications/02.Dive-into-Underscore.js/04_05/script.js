(function () {

    var Animal = (function (){
        function Animal(species, legs) {
            this.species = species;
            this.legs = legs;
        }

        Animal.prototype.toString = function () {
            return this.species + ' ' + this.legs;
        };

        return Animal;
    }());

    var animals = [
        new Animal('Gosho', 4),
        new Animal('Pesho', 2),
        new Animal('Maria', 18),
        new Animal('Gosho', 4),
        new Animal('Gosho', 4),
        new Animal('Ivan', 100),
        new Animal('Gosho', 4),
        new Animal('Gosho', 4),
        new Animal('Pesho', 2),
        new Animal('Maria', 18),
        new Animal('Pesho', 2),
        new Animal('Gosho', 4),
        new Animal('Pesho', 2),
        new Animal('Ivan', 100),
        new Animal('Ivan', 100),
        new Animal('Pesho', 2),
        new Animal('Pesho', 2),
        new Animal('Maria', 18),
        new Animal('Maria', 18),
    ];

    console.log('---------- Task 04 -----------');

    _.chain(animals)
        .groupBy('species')
        .sortBy(function(animals){
            return animals[0].legs;
        })
        .each(function (animals) {
            console.log(animals.toString());
        });

    console.log('---------- Task 05 -----------');

    var totalLegs = 0;

    _.chain(animals)
        .each(function (animal) {
            totalLegs += animal.legs;
        });

    console.log('total legs : ' + totalLegs);
}());