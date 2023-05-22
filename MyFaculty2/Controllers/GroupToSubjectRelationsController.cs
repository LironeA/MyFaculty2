using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFaculty2.Models;

namespace MyFaculty2.Controllers
{
    public class GroupToSubjectRelationsController : Controller
    {
        private readonly MyFacultyDbContext _context;

        public GroupToSubjectRelationsController(MyFacultyDbContext context)
        {
            _context = context;
        }

        // GET: GroupToSubjectRelations
        public async Task<IActionResult> Index()
        {
            var myFacultyDbContext = _context.GroupToSubjectRelations.Include(g => g.IdNavigation).Include(g => g.Subject);
            return View(await myFacultyDbContext.ToListAsync());
        }

        // GET: GroupToSubjectRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GroupToSubjectRelations == null)
            {
                return NotFound();
            }

            var groupToSubjectRelation = await _context.GroupToSubjectRelations
                .Include(g => g.IdNavigation)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupToSubjectRelation == null)
            {
                return NotFound();
            }

            return View(groupToSubjectRelation);
        }

        // GET: GroupToSubjectRelations/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Groups, "Id", "Id");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
            return View();
        }

        // POST: GroupToSubjectRelations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupId,SubjectId")] GroupToSubjectRelation groupToSubjectRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupToSubjectRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Groups, "Id", "Id", groupToSubjectRelation.Id);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", groupToSubjectRelation.SubjectId);
            return View(groupToSubjectRelation);
        }

        // GET: GroupToSubjectRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GroupToSubjectRelations == null)
            {
                return NotFound();
            }

            var groupToSubjectRelation = await _context.GroupToSubjectRelations.FindAsync(id);
            if (groupToSubjectRelation == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Groups, "Id", "Id", groupToSubjectRelation.Id);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", groupToSubjectRelation.SubjectId);
            return View(groupToSubjectRelation);
        }

        // POST: GroupToSubjectRelations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupId,SubjectId")] GroupToSubjectRelation groupToSubjectRelation)
        {
            if (id != groupToSubjectRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupToSubjectRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupToSubjectRelationExists(groupToSubjectRelation.Id))
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
            ViewData["Id"] = new SelectList(_context.Groups, "Id", "Id", groupToSubjectRelation.Id);
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id", groupToSubjectRelation.SubjectId);
            return View(groupToSubjectRelation);
        }

        // GET: GroupToSubjectRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GroupToSubjectRelations == null)
            {
                return NotFound();
            }

            var groupToSubjectRelation = await _context.GroupToSubjectRelations
                .Include(g => g.IdNavigation)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupToSubjectRelation == null)
            {
                return NotFound();
            }

            return View(groupToSubjectRelation);
        }

        // POST: GroupToSubjectRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GroupToSubjectRelations == null)
            {
                return Problem("Entity set 'MyFacultyDbContext.GroupToSubjectRelations'  is null.");
            }
            var groupToSubjectRelation = await _context.GroupToSubjectRelations.FindAsync(id);
            if (groupToSubjectRelation != null)
            {
                _context.GroupToSubjectRelations.Remove(groupToSubjectRelation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupToSubjectRelationExists(int id)
        {
          return (_context.GroupToSubjectRelations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
