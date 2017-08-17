using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using MusicHub.Models;


namespace MusicHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context= new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingConcerts = _context.Concerts
                .Include(g=>g.Artist)
                .Include(g=>g.Genre)
                .Where(g=>g.DateTime>DateTime.Now);
            return View(upcomingConcerts);
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