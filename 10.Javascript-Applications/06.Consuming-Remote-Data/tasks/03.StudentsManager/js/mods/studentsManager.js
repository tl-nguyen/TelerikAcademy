define(['httpReq', 'jquery', 'underscore'], function (HttpReq, $, _) {
    var StudentsManager;

    StudentsManager = (function (){
        var httpReq,wrapper,self;

        function StudentsManager (url, domId) {
            self = this;
            httpReq = new HttpReq(url);
            wrapper = $('#' + domId);
            addBtnHandler();

            this.getAllStudents();

        }

        StudentsManager.prototype.getAllStudents = function () {
            httpReq.get()
                .then(function (data) {
                    visualizeStudents(data);
                })
                .then(function () {
                    removeBtnHandler();
                });
        };

        StudentsManager.prototype.removeStudent = function (id) {
            httpReq.remove(id)
                .then(function (data) {
                    console.log(data);
                });
        };

        StudentsManager.prototype.addStudent = function (data) {
            httpReq.post(data)
                .then(function (data) {
                    console.log(data);
                    self.getAllStudents();
                })
        };

        function visualizeStudents(students) {
            wrapper.empty();

            var studentEl = $('<div class="student">'),
                info = $('<p>'),
                button = $('<button>');


            _.each(students, function (student) {
                info.html('<p><strong>Name</strong>: ' + student.name + '</p><p><strong>Grade:</strong> ' + student.grade + '</p>');
                button.attr('data-id', student.id);
                button.text('Delete');

                studentEl.append(info);
                studentEl.append(button);

                wrapper.append(studentEl.clone());
            });
        }

        function removeBtnHandler() {
            var deleteBtns = $('.student button');
            _.each(deleteBtns, function (button) {
                $(button).on('click', function () {
                    self.removeStudent($(button).attr('data-id'));
                    self.getAllStudents();
                });
            });
        }

        function addBtnHandler() {
            var addBtn = $('#addBtn');
            addBtn.on('click', function () {
                var name = $('#name').val(),
                    grade = $('#grade').val();

                self.addStudent({name: name, grade: grade});
            });
        }

        return StudentsManager;
    }());

    return StudentsManager;
});