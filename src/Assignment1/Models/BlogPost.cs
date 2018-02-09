using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        //[ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Posted { get; set; }

       // public ICollection<Comment> Comment { get; set; }


    }
}
