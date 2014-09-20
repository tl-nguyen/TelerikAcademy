namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Model;
    using StudentSystem.Services.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentSystemData())
        {
        }

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var students = this.data.Students.All().Select(StudentModel.FromStudent);
            return Ok(students);
        }

        [HttpPost]
        public IHttpActionResult Add(StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = new Student
            {
                Name = student.Name,
                Number = student.Number
            };

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();

            student.Id = newStudent.Id;

            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = this.data.Students.All().FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("Such student doesn't exist");
            }

            existingStudent.Name = student.Name;
            this.data.SaveChanges();

            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.data.Students.All().FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("Such student doesn't exist");
            }

            this.data.Students.Delete(existingStudent);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCourse(int id, int courseId)
        {
            var student = this.data.Students.All().FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return BadRequest("No such student in the system");
            }

            var course = this.data.Courses.All().FirstOrDefault(c => c.Id == courseId);

            if (course == null)
            {
                return BadRequest("No such course in the system");
            }

            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            student.Courses.Add(course);

            this.data.SaveChanges();

            return Ok();
        }
    }
}
