define(['courses/student'], function (Student) {
    var Course;

    Course = (function () {
        function Course(title, formula) {
            this.title = title;
            this.formula = formula;
            this.students = [];
        }

        Course.prototype.addStudent = function (student) {
            if (!(student instanceof Student)) {
                throw new Error('student is not an instance of Student');
            }

            this.students.push(student);
        };

        Course.prototype.calculateResults = function () {
            for (var i = 0; i < this.students.length; i += 1) {
                this.students[i].totalScore = this.formula(this.students[i]);
            }
        };

        Course.prototype.getTopStudentsByExam = function (numberOfTop) {
            sortBy.call(this, 'exam');

            return getTop.call(this, numberOfTop);
        };

        Course.prototype.getTopStudentsByTotalScore = function (numberOfTop) {
            sortBy.call(this, 'totalScore');

            return getTop.call(this, numberOfTop);
        };
        
        var getTop = function (numberOfTop) {
            var topStudents = [];

            if (!(numberOfTop >= 0 && numberOfTop < this.students.length)) {
                throw new Error('numberOfTop must be >= 0 and < number of students');
            }

            for (var i = 0; i < numberOfTop; i += 1) {
                topStudents.push(this.students[i]);
            }

            return topStudents;
        };

        var sortBy = function (type) {
            this.students.sort(function (student1, student2) {
                return student2[type] - student1[type];
            });
        };

        return Course;
    }());

    return Course;
});