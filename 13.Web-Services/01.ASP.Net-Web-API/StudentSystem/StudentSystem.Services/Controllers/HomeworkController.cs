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

    public class HomeworkController : ApiController
    {
        private IRepository<Homework> homeworks;

        public HomeworkController()
            : this(new Repository<Homework>())
        {
        }

        public HomeworkController(IRepository<Homework> homeworks)
        {
            this.homeworks = homeworks;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var homeworks = this.homeworks.All().Select(HomeworkModel.FromHomework);
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

            this.homeworks.Add(newHomework);
            this.homeworks.SaveChanges();

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

            var existingHomework = this.homeworks.All().FirstOrDefault(s => s.Id == id);
            if (existingHomework == null)
            {
                return BadRequest("Such course doesn't exist");
            }

            if (homework.Content != null)
            {
                existingHomework.Content = homework.Content;
            }

            this.homeworks.SaveChanges();

            return Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingHomework = this.homeworks.All().FirstOrDefault(s => s.Id == id);
            if (existingHomework == null)
            {
                return BadRequest("Such student doesn't exist");
            }

            this.homeworks.Delete(existingHomework);
            this.homeworks.SaveChanges();

            return Ok();
        }
    }
}
