﻿using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApplication.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            Comments = new HashSet<Comment>();
            Created = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }

        [Required(ErrorMessage = "This is my customized error message for the title")]
        public string Title { get; set; }

        public string Slug { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        public string MediaUrl { get; set; }

        public bool Published { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}