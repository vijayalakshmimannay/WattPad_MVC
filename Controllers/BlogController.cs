using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WattPad.Models;
using WattPad.Repository;

namespace WattPad.Controllers
{
    public class BlogController : Controller
    {
        IBlogRL blogRL;



        public BlogController(IBlogRL blogRL)
        {
            this.blogRL = blogRL;
        }
       

        [HttpGet]
        public IActionResult AddBlog()
        {


            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(BlogModel blog)
        {
            if (ModelState.IsValid)
            {
                blogRL.AddBlog(blog);
                //return RedirectToAction("Employee/Login");
            }
            return View(blog);
        }


        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            List<BlogModel> blogmodel = new List<BlogModel>();

            var bloglist = blogRL.GetAllBlogs();
            //ViewBag.model = meetingroomlist;
            //int MeetingRoom_Id = ViewBag.model.MeetingRoom_Id;  

            return View(bloglist);

        }
        [HttpGet]
        public IActionResult GetAllBlogsbyId(int Id)
        {
            List<BlogModel> blogmodel = new List<BlogModel>();

            var bloglist = blogRL.GetAllBlogsbyId(Id);
            ViewBag.Model = bloglist;
            //ViewBag.model = meetingroomlist;
            //int MeetingRoom_Id = ViewBag.model.MeetingRoom_Id;  

            return View(bloglist);

        }

        [HttpGet]
        public ActionResult EditBlog(int Id)
        {
            var bloglist = blogRL.GetAllBlogsbyId(Id);
            ViewBag.Model = bloglist;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBlog([Bind] BlogModel blog)
        {
            if (ModelState.IsValid)
            {
                var result = blogRL.UpdateBlog(blog);
                if (result != null)
                {
                    return RedirectToAction("GetAllBlogs");
                }
                else
                {
                    return RedirectToAction("AddBlog");
                }
            }
            return View(blog);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var bloglist = blogRL.GetAllBlogs();
            ViewBag.Model = bloglist;
            return View();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBlog([Bind] BlogModel blog)
        {
            if (ModelState.IsValid)
            {
                var result = blogRL.Delete(blog);
                if (result != null)
                {
                    return RedirectToAction("GetAllBlogs");
                }
                else
                {
                    return RedirectToAction("AddBlog");
                }
            }
            return View(blog);
        }
    }
}
