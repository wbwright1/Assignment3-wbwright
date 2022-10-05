using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment3_wbwright.Data;
using Assignment3_wbwright.Models;

namespace Assignment3_wbwright.Controllers
{
    public class ActorPerformedInMoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActorPerformedInMoviesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetMoviePoster(int id)
        {
            var movie = await _context.ActorPerformedInMovie
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            var imageData = movie.Movie.Poster;

            return File(imageData, "image/jpg");
        }
        public async Task<IActionResult> GetActorPhoto(int id)
        {
            var actor = await _context.Actor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }
            var imageData = actor.Photo;

            return File(imageData, "image/jpg");
        }
        // GET: ActorPerformedInMovies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ActorPerformedInMovie.Include(a => a.Actor).Include(a => a.Movie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ActorPerformedInMovies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ActorPerformedInMovie == null)
            {
                return NotFound();
            }

            var actorPerformedInMovie = await _context.ActorPerformedInMovie
                .Include(a => a.Actor)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorPerformedInMovie == null)
            {
                return NotFound();
            }

            return View(actorPerformedInMovie);
        }

        // GET: ActorPerformedInMovies/Create
        public IActionResult Create()
        {
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: ActorPerformedInMovies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,ActorId")] ActorPerformedInMovie actorPerformedInMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actorPerformedInMovie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name", actorPerformedInMovie.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", actorPerformedInMovie.MovieId);
            return View(actorPerformedInMovie);
        }

        // GET: ActorPerformedInMovies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActorPerformedInMovie == null)
            {
                return NotFound();
            }

            var actorPerformedInMovie = await _context.ActorPerformedInMovie.FindAsync(id);
            if (actorPerformedInMovie == null)
            {
                return NotFound();
            }
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name", actorPerformedInMovie.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", actorPerformedInMovie.MovieId);
            return View(actorPerformedInMovie);
        }

        // POST: ActorPerformedInMovies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,ActorId")] ActorPerformedInMovie actorPerformedInMovie)
        {
            if (id != actorPerformedInMovie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actorPerformedInMovie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorPerformedInMovieExists(actorPerformedInMovie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorId"] = new SelectList(_context.Actor, "Id", "Name", actorPerformedInMovie.ActorId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", actorPerformedInMovie.MovieId);
            return View(actorPerformedInMovie);
        }

        // GET: ActorPerformedInMovies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActorPerformedInMovie == null)
            {
                return NotFound();
            }

            var actorPerformedInMovie = await _context.ActorPerformedInMovie
                .Include(a => a.Actor)
                .Include(a => a.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorPerformedInMovie == null)
            {
                return NotFound();
            }

            return View(actorPerformedInMovie);
        }

        // POST: ActorPerformedInMovies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ActorPerformedInMovie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ActorPerformedInMovie'  is null.");
            }
            var actorPerformedInMovie = await _context.ActorPerformedInMovie.FindAsync(id);
            if (actorPerformedInMovie != null)
            {
                _context.ActorPerformedInMovie.Remove(actorPerformedInMovie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorPerformedInMovieExists(int id)
        {
            return _context.ActorPerformedInMovie.Any(e => e.Id == id);
        }
    }
}
