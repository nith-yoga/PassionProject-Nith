using Microsoft.AspNetCore.Mvc;
using PassionProject_Nith.Data;
using Microsoft.EntityFrameworkCore;
using PassionProject_Nith.Models;

namespace PassionProject_Nith.Controllers
{
    public class ArtistsPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistsPageController(ApplicationDbContext context)
        {
            _context = context;
        }

       // GET: ArtistsPage
       public async Task<IActionResult> Index()
        {
            return View(await _context.Artists.ToListAsync());
        }

        // sortOrder Function
        [HttpGet("artists/index")]
        public IActionResult Index(string sortOrder)
        {
            var artists = _context.Artists.AsQueryable();

            if (sortOrder == "name")
            {
                artists = artists.OrderBy(a => a.ArtistName);
            }

            return View(artists.ToList());
        }

        // GET: Artists/Details
        public IActionResult Details(int id)
        {
            var artist = _context.Artists
                .Include(a => a.Albums)
                .FirstOrDefault(a => a.ArtistId == id);

            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // GET: Artists/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Artists/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ArtistName,ArtistBio")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Log the ModelState errors for debugging
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    Console.WriteLine($"Key: {entry.Key}, Error: {error.ErrorMessage}");
                }
            }
            return View(artist);
        }

        // GET: Artists/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ArtistId,ArtistName,ArtistBio")] Artist artist)
        {
            if (id != artist.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }

        // GET: Artists/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        // POST: Artists/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
