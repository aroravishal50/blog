using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Assignment1.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment1.Controllers
{

    public class Home : Controller
    {

        private Assignment1DataContext _Assignment1DataContext;
        int login;
        public Home(Assignment1DataContext context)
        {
           // generalOrAdmin = 0;s
            _Assignment1DataContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {

           /* if (login == 0)
            {
                HttpContext.Session.SetString("RoleId", "2");
            }*/
             
            return View(_Assignment1DataContext.BlogPosts.ToList());
            /* var blogs = (from b in _Assignment1DataContext.BlogPosts select b.Title).SelectMany(2,3);

             for(int i=0; i<2; i++)
             {

                     HttpContext.Session.SetString("blogsId" + i, Convert.ToString(blogs.SelectMany()));



             }*/
        }
        [HttpPost]
        [ActionName("DisplayFullBlogPost")]

        public IActionResult DisplayFullBlogPostPost(BlogPost bp)
        {
            
            Comment comments = new Comment();
         
              comments.BlogPostId = Convert.ToInt16(HttpContext.Session.GetString("BlogPostId"));
              comments.Content = Request.Form["Comment"];
              comments.UserId = Convert.ToInt16(HttpContext.Session.GetString("UserId"));
              _Assignment1DataContext.Comments.Add(comments);
              _Assignment1DataContext.SaveChanges();




            return RedirectToAction("DisplayFullBlogPost");
        }
        [HttpGet]
        public IActionResult DisplayFullBlogPost(int id)
        {
            String comment_s = "";
            Comment comments = new Comment();
            var display = (from b in _Assignment1DataContext.BlogPosts where id == b.BlogPostId select b ).FirstOrDefault();
            var displayFLE = (from u in _Assignment1DataContext.Users where u.UserId == display.UserId select u).FirstOrDefault();
            var displayComments = (from c in _Assignment1DataContext.Comments where c.BlogPostId == id select c).ToList();
                HttpContext.Session.SetString("Title", display.Title);
                HttpContext.Session.SetString("Content", display.Content);
                HttpContext.Session.SetString("Posted Value", Convert.ToString(display.Posted));
                HttpContext.Session.SetString("EmailAddress", displayFLE.EmailAddress);
                HttpContext.Session.SetString("FirstName", displayFLE.FirstName);
                HttpContext.Session.SetString("LastName", displayFLE.LastName);
            HttpContext.Session.SetString("BlogPostId", Convert.ToString(id));
            /*  comments.BlogPostId = id;
              comments.Content = "Hellooooo0o";
              comments.UserId = Convert.ToInt16(HttpContext.Session.GetString("UserId"));
              _Assignment1DataContext.Comments.Add(comments);
              _Assignment1DataContext.SaveChanges();*/



            foreach (var comm in displayComments)
            {
                
                 comment_s = Convert.ToString(comm.Content)+"x01"+comment_s;
            }
            HttpContext.Session.SetString("AllComments", comment_s);
            // HttpContext.Session.SetString("Role", userAuth.Role.Name);*/
            return View(_Assignment1DataContext.BlogPosts.ToList());
           
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        public IActionResult RegisterPost(User user)
        {
            _Assignment1DataContext.Users.Add(user);
            _Assignment1DataContext.SaveChanges();
            return RedirectToAction("Login");
           
        }
        [HttpPost]
        [ActionName("Login")]
        public IActionResult LoginPost()
        {
            int login = -1;
            String email = Request.Form["EmailAddress"];
            String password = Request.Form["Password"];

            var userAuth = (from u in _Assignment1DataContext.Users join r in _Assignment1DataContext.Roles on u.RoleId equals r.RoleId where u.EmailAddress == email && u.Password == password select u).FirstOrDefault();
             
            if (userAuth!=null)
            { 
                login = 0;
                HttpContext.Session.SetString("UserId", Convert.ToString(userAuth.UserId));
                HttpContext.Session.SetString("RoleId", Convert.ToString(userAuth.RoleId));
                HttpContext.Session.SetString("FName", Convert.ToString(userAuth.FirstName));

                HttpContext.Session.SetString("LName", Convert.ToString(userAuth.LastName));

                HttpContext.Session.SetString("UserIsLoggedIn", Convert.ToString(login));

                /*HttpContext.Session.SetString("FirstName", userAuth.FirstName);
                HttpContext.Session.SetString("LastName", userAuth.LastName);
                HttpContext.Session.SetString("EmailAddress", email);
                HttpContext.Session.SetString("Password", password);
                HttpContext.Session.SetString("RoleId", Convert.ToString(userAuth.RoleId));
                HttpContext.Session.SetString("Role", roleAuth.Name);

                // HttpContext.Session.SetString("Role", userAuth.Role.Name);*/

                return RedirectToAction("Index");

            }
            else
            {
                login = 1;
                return RedirectToAction("Login");

            }

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddBlogPost")]
        public IActionResult AddBlog(BlogPost bp)
        {
          /*  User user = new User();
            Role role = new Role();
            //bp.User.Role = null;
            /*HttpContext.Session.GetString("UserId");
            HttpContext.Session.GetString("LastName");
            HttpContext.Session.GetString("EmailAddress");
            HttpContext.Session.GetString("Password");
            HttpContext.Session.GetString("Role");
            user.FirstName = HttpContext.Session.GetString("FirstName");
            user.LastName = HttpContext.Session.GetString("LastName");
            user.EmailAddress = HttpContext.Session.GetString("EmailAddress"); ;
            user.Password = HttpContext.Session.GetString("Password");
            user.UserId = Convert.ToInt16(HttpContext.Session.GetString("UserId"));
            role.RoleId = Convert.ToInt16(HttpContext.Session.GetString("RoleId"));
            role.Name = "1";
            bp.User.Role = role;
            bp.User = user;*/
            bp.UserId = Convert.ToInt16(HttpContext.Session.GetString("UserId"));

            _Assignment1DataContext.BlogPosts.Add(bp);
            _Assignment1DataContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddBlogPost()
        {
            return View();
        }


        [HttpPost]
        [ActionName("EditBlogPost")]
        public IActionResult EditBlogPost(BlogPost bp,int id)
        {
            /* var updateBlog = (from b in _Assignment1DataContext.BlogPosts where b.BlogPostId == id select b).FirstOrDefault();
             updateBlog.Content = Request.Form["Content"];
             updateBlog.Title = Request.Form["Title"];
             updateBlog.Posted = Convert.ToDateTime(Request.Form["Posted"]);*/
            // bp.Content = updateBlog.Content;
            //bp.Title = updateBlog.Title;
            //bp.Posted = Convert.ToDateTime(updateBlog.Posted);
            // bp.BlogPostId = id;
             bp.UserId = Convert.ToInt16(HttpContext.Session.GetString("UserId"));
            // _Assignment1DataContext.BlogPosts.Update(bp);
            bp.BlogPostId = id;
            
            _Assignment1DataContext.BlogPosts.Update(bp);
            _Assignment1DataContext.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditBlogPost(String title, String content, String posted)
        {
            return View();
        }


    }
}
