define([], function () {
    var Student;

    Student = (function() {
        function Student(data) {
            this.name = data.name;
            this.exam = data.exam;
            this.homework = data.homework;
            this.attendance = data.attendance;
            this.teamwork = data.teamwork;
            this.bonus = data.bonus;
            this.totalScore = 0;
        };

        return Student;
    }());

    return Student;
});