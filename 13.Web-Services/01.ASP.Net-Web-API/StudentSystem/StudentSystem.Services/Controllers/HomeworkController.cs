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

    public class HomeworkController : ApiController
    {
        private IStudentSystemData data;

        public HomeworkController()
            : this(new StudentSystemData())
        {
        }

        public HomeworkController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var homeworks = this.data.Homeworks.All().Select(HomeworkModel.FromHomework);
            return Ok(homeworks);
        }

        [HttpPost]
        public IHttpActionResult Add(HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newHomework = new Homework
            {
                Content = homework.Content,
                TimeSent = homework.TimeSent
            };

            this.data.Homeworks.Add(newHomework);
            this.data.SaveChanges();

            homework.Id = newHomework.Id;

            return Ok(homework);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, HomeworkModel homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingHomework = this.data.Homeworks.All().FirstOrDefault(s => s.Id == id);
            if (existingHomework == null)
            {
                return BadRequest("Such course doesn't exist");
            }

            if (homework.Content != null)
            {
                existingHomework.Content = homework.Content;
            }

            this.data.SaveChanges();

            return Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingHomework = this.data.Homeworks.All().FirstOrDefault(s => s.Id == id);
            if (existingHomework == null)
            {
                return BadRequest("Such student doesn't exist");
            }

            this.data.Homeworks.Delete(existingHomework);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
