using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Models
{
    public class Role
    {

        public int RoleId { get; set; }
        public string Name { get; set; }
       // public ICollection<User> User { get; set; }
    }
}
