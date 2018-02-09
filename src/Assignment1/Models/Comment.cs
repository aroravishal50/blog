using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Content { get; set; }


    }
}
