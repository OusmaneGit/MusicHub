
using System.Linq;

using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MusicHub.Models;
using MusicHub.ViewModels;

namespace MusicHub.Controllers
{
    public class ConcertsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConcertsController()
        {
            _context= new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel= new ConcertFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(ConcertFormViewModel viewModel)
        {
            //var artist = _context.Users.Single(u => u.Id == artistId);
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);

            }
            var concert= new Concert
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };
            _context.Concerts.Add(concert);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        
    }
}