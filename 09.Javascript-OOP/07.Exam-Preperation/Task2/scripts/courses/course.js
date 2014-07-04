define(['courses/student'], function (Student) {
    'use strict';

    var Course;

    Course = (function (){
        var Course = function (title, courseTotalScoreFormula) {

            this.title = title;
            this.totalScore = courseTotalScoreFormula;
            this.students = [];
            this.studentsResults = [];
        };

        var sortByExam = function () {
            this.studentsResults.sort(function (stud1, stud2) {
                return stud2.student.exam - stud1.student.exam;
            });
        };

        var sortByTotal = function () {
            this.studentsResults.sort(function (stud1, stud2) {
                return stud2.totalScore - stud1.totalScore;
            });
        };

        Course.prototype = {
            addStudent: function (student) {
                if (!(student instanceof Student)) {
                    throw {
                        message: 'the param is not Student type'
                    }
                }

                this.students.push(student);

                return this;
            },

            calculateResults: function () {
                var currentStudent;

                for (var i = 0, len = this.students.length; i < len; i += 1) {
                    currentStudent = {
                        student: this.students[i],
                        totalScore: this.totalScore(this.students[i])
                    };

                    this.studentsResults.push(currentStudent);
                }

                return this;
            },

            getTopStudentsByExam: function (studentCount) {
                var topStudentsByExam = [];
                sortByExam.call(this);

                for (var i = 0; i < studentCount; i += 1) {
                    topStudentsByExam.push(this.studentsResults[i]);
                }

                return topStudentsByExam;
            },

            getTopStudentsByTotalScore: function (studentCount) {
                var topStudentsByTotal = [];
                sortByTotal.call(this);

                for (var i = 0; i < studentCount; i += 1) {
                    topStudentsByTotal.push(this.studentsResults[i]);
                }

                return topStudentsByTotal;
            }
        };

        return Course;
    }());

    return Course;
});