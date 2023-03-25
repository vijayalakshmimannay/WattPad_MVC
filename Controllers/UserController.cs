using Microsoft.AspNetCore.Mvc;
using System;
using WattPad.Models;
using WattPad.Repository;

namespace WattPad.Controllers
{
    public class UserController : Controller
    {
        IUserRL UserRL;
        public UserController(IUserRL userRL)
        {
            this.UserRL = userRL;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult AddUser()
        {


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser([Bind] UserModel user)
        {
            if (ModelState.IsValid)
            {
                UserRL.AddUser(user);
                //return RedirectToAction("Employee/Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Login([Bind] LoginModel loginModel)
        {
            string message = string.Empty;
            if (ModelState.IsValid)
            {
                var result = UserRL.UserLogin(loginModel);

                if (result != null)
                {
                    message = "Username and/or password is correct.";
                    Console.WriteLine(message);
                    return RedirectToAction("Blog/GetAllBlogs");

                }
                else
                {
                    return RedirectToAction("Login");
                }


            }
            return null;
        }

        public IActionResult home()
        {
            return View();
        }
        
    }
}
