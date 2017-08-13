
using System.Linq;

using System.Web.Mvc;
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
        
        public ActionResult Create()
        {
            var viewModel= new ConcertFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
    }
}