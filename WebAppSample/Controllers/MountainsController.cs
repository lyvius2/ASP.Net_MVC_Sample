using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppSample.Data;
using WebAppSample.Models;

namespace WebAppSample.Controllers
{
    public class MountainsController : Controller
    {
        private readonly MvcMountainContext _context;

        public MountainsController(MvcMountainContext context)
        {
            _context = context;
        }

        // GET: Mountains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mountain.ToListAsync());
        }

        // GET: Mountains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mountain = await _context.Mountain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mountain == null)
            {
                return NotFound();
            }

            return View(mountain);
        }

        // GET: Mountains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mountains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MountainName,ClimbmingDate,Comment,Height,Complete,RegDate,UpdDate")] Mountain mountain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mountain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mountain);
        }

        // GET: Mountains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mountain = await _context.Mountain.FindAsync(id);
            if (mountain == null)
            {
                return NotFound();
            }
            return View(mountain);
        }

        // POST: Mountains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MountainName,ClimbmingDate,Comment,Height,Complete,RegDate,UpdDate")] Mountain mountain)
        {
            if (id != mountain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mountain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MountainExists(mountain.Id))
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
            return View(mountain);
        }

        // GET: Mountains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mountain = await _context.Mountain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mountain == null)
            {
                return NotFound();
            }

            return View(mountain);
        }

        // POST: Mountains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mountain = await _context.Mountain.FindAsync(id);
            _context.Mountain.Remove(mountain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MountainExists(int id)
        {
            return _context.Mountain.Any(e => e.Id == id);
        }
    }
}
