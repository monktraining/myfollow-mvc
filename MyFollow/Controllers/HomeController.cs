using System.Web.Mvc;
using MyFollow.Models;

namespace MyFollow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(ApplicationUser user)
        {
            MyFollowContext db = new MyFollowContext();
            db.Users.Add(user);
            db.SaveChanges();
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
    }
}