(function () {

    var Person = (function (){
        function Person(fname, lname) {
            this.fname = fname;
            this.lname = lname;
        }

        Person.prototype.fullName = function () {
            return this.fname + ' ' + this.lname;
        };

        return Person;
    }());

    var people = [
            new Person('Gosho', 'Peshov'),
            new Person('Pesho', 'Goshov'),
            new Person('Maria', 'Georgieva'),
            new Person('Ivan', 'Petrov'),
            new Person('Pesho', 'Mikov'),
            new Person('Ivaylo', 'Petrov')
        ],
        commonFname,
        commonLname;

    console.log('---------- Task 07 -----------');

    commonFname = _.chain(people)
        .groupBy('fname')
        .sortBy(function (people) {
            return people.length * (-1);
        })
        .first()
        .map(function (person) {
            return person.fname;
        })
        .first()
        .value();

    commonLname = _.chain(people)
        .groupBy('lname')
        .sortBy(function (people) {
            return people.length * (-1);
        })
        .first()
        .map(function (person) {
            return person.lname;
        })
        .first()
        .value();

    console.log('common first name : ' + commonFname);
    console.log('common last name : ' + commonLname)
}());