using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Models
{
    public class User 
    {
        public int UserId { get; set; }
        //[ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }
        public string Password { get; set; }

       // public virtual ICollection<BlogPost> BlogPost { get; set; }



    }
}
