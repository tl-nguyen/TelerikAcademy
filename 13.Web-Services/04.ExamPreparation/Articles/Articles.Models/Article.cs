﻿namespace Articles.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        private ICollection<Tag> tags;
        private ICollection<Like> likes;
        private ICollection<Comment> comments;

        public Article()
        {
            this.tags = new HashSet<Tag>();
            this.likes = new HashSet<Like>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags 
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}