(function () {

    var Student = (function (){
        function Student(fname, lname, age, mark) {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
            this.mark = mark;
        }

        Student.prototype.fullName = function () {
            return this.fname + ' ' + this.lname;
        };

        return Student;
    }());

    var students = [
        new Student('Gosho', 'Peshov', 11, 98),
        new Student('Pesho', 'Goshov', 15, 50),
        new Student('Maria', 'Georgieva', 18, 87),
        new Student('Ivan', 'Petrov', 25, 49),
        new Student('Doncho', 'Mikov', 24, 88),
        new Student('Ivaylo', 'Kenov', 20, 88)
    ];

    console.log('---------- Task 01 -----------');

    _.chain(students)
        .filter(function (student) {
            return student.fname.toLowerCase() < student.lname.toLowerCase();
        })
        .sortBy(function (student) {
            return student.fullName();
        })
        .each(function (student) {
            console.log(student.fullName());
        });

    console.log('---------- Task 02 -----------');

    _.chain(students)
        .filter(function (student) {
            return 18 <= student.age && student.age <= 24;
        })
        .map(function (student) {
            return [
                student.fname,
                student.lname
            ];
        })
        .each(function (student) {
            console.log(student);
        });

    console.log('---------- Task 03 -----------');

    _.chain(students)
        .sortBy(function (student) {
            return student.mark * (-1);
        })
        .first()
        .each(function (student) {
            console.log(student);
        });
}());