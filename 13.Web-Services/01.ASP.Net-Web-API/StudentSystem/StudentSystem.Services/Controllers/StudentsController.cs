namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.Data.Repositories;
    using StudentSystem.Model;
    using StudentSystem.Services.Models;

    public class StudentsController : ApiController
    {
        private IRepository<Student> students;

        public StudentsController()
            : this(new Repository<Student>())
        {
        }

        public StudentsController(IRepository<Student> students)
        {
            this.students = students;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var students = this.students.All().Select(StudentModel.FromStudent);
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

            this.students.Add(newStudent);
            this.students.SaveChanges();

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

            var existingStudent = this.students.All().FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("Such student doesn't exist");
            }

            existingStudent.Name = student.Name;
            this.students.SaveChanges();

            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.students.All().FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("Such student doesn't exist");
            }

            this.students.Delete(existingStudent);
            this.students.SaveChanges();

            return Ok();
        }
    }
}
