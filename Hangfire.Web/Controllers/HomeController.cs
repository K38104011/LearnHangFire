using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hangfire.Web.Models;
using Postal;

namespace Hangfire.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult PostComment(Comment comment)
        {
            BackgroundJob.Enqueue(() => Notify(comment));
            return RedirectToAction("Index");
        }

        public void Notify(Comment comment)
        {
            var email = new CommentNotificationEmail()
            {
                To = "phamdanghoanggiang@gmai.com",
                Username = comment.Username,
                Comment = comment.Text
            };
            email.Send();
        }
    }
}