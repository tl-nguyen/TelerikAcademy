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

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.data.Courses.All().Select(CourseModel.FromCourse);
            return Ok(courses);
        }

        [HttpPost]
        public IHttpActionResult Add(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description
            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            course.Id = newCourse.Id;

            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCourse = this.data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (existingCourse == null)
            {
                return BadRequest("Such course doesn't exist");
            }

            if (course.Name != null)
            {
                existingCourse.Name = course.Name;
            }

            if (course.Description != null)
            {
                existingCourse.Description = course.Description;
            }

            this.data.SaveChanges();

            return Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingCourse = this.data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (existingCourse == null)
            {
                return BadRequest("Such student doesn't exist");
            }

            this.data.Courses.Delete(existingCourse);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
