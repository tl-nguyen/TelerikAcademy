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

    public class CoursesController : ApiController
    {
        private IRepository<Course> courses;

        public CoursesController()
            : this(new Repository<Course>())
        {
        }

        public CoursesController(IRepository<Course> courses)
        {
            this.courses = courses;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.courses.All().Select(CourseModel.FromCourse);
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

            this.courses.Add(newCourse);
            this.courses.SaveChanges();

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

            var existingCourse = this.courses.All().FirstOrDefault(s => s.Id == id);
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

            this.courses.SaveChanges();

            return Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingCourse = this.courses.All().FirstOrDefault(s => s.Id == id);
            if (existingCourse == null)
            {
                return BadRequest("Such student doesn't exist");
            }

            this.courses.Delete(existingCourse);
            this.courses.SaveChanges();

            return Ok();
        }
    }
}
