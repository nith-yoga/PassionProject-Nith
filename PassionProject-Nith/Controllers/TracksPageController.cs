﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PassionProject_Nith.Data;
using PassionProject_Nith.Models;

namespace PassionProject_Nith.Controllers
{
    public class TracksPageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TracksPageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TracksPage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tracks.ToListAsync());
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            var albums = _context.Albums.ToList();
            ViewBag.AlbumSelectList = new SelectList(albums, "AlbumId", "AlbumTitle");
            return View();
        }

        // POST: Tracks/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("TrackTitle,TrackLength,AlbumId")] Track track)
        {

            if (ModelState.IsValid)
            {
                _context.Add(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Log ModelState errors for debugging
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    Console.WriteLine($"Key: {entry.Key}, Error: {error.ErrorMessage}");
                }
            }
            var albums = await _context.Albums.ToListAsync();
            ViewBag.AlbumSelectList = new SelectList(albums, "AlbumId", "AlbumTitle");

            return View(track);
        }

        //GET: Tracks/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        //POST: Tracks/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("TrackId,TrackTitle,TrackLength,AlbumId")] Track track)
        {
            if (id != track.TrackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(track);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Log ModelState errors for debugging
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    Console.WriteLine($"Key: {entry.Key}, Error: {error.ErrorMessage}");
                }
            }
            return View(track);
        }

        // GET: Tracks/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _context.Tracks.FirstOrDefaultAsync(m => m.TrackId == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
