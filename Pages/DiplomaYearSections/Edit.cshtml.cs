using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_DiplomaYearSections
{
    public class EditModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public EditModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiplomaYearSection DiplomaYearSection { get; set; } = default!;

public async Task<IActionResult> OnGetAsync(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var diplomaYearSection = await _context.DiplomaYearSections.FirstOrDefaultAsync(m => m.Id == id);
    if (diplomaYearSection == null)
    {
        return NotFound();
    }

    DiplomaYearSection = diplomaYearSection;
    ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");

    var diplomaYearsQuery = _context.DiplomaYears
        .Include(dy => dy.Diploma)
        .Select(dy => new { dy.Id, FullDiplomaTitle = $"{dy.Diploma.Title} - {dy.Title}" });

    var diplomaYearsList = await diplomaYearsQuery.ToListAsync();

    var orderedDiplomaYearsList = diplomaYearsList.OrderBy(dy => dy.FullDiplomaTitle).ToList();

    ViewData["DiplomaYearId"] = new SelectList(orderedDiplomaYearsList, "Id", "FullDiplomaTitle", DiplomaYearSection.DiplomaYearId);
    return Page();
}

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
            ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");

            var diplomaYearsQuery = _context.DiplomaYears
            .Include(dy => dy.Diploma)
            .Select(dy => new { dy.Id, FullDiplomaTitle = $"{dy.Diploma.Title} - {dy.Title}" });

        var diplomaYearsList = await diplomaYearsQuery.ToListAsync();

        var orderedDiplomaYearsList = diplomaYearsList.OrderBy(dy => dy.FullDiplomaTitle).ToList();

            ViewData["DiplomaYearId"] = new SelectList(orderedDiplomaYearsList, "Id", "FullDiplomaTitle", DiplomaYearSection.DiplomaYearId);
                return Page();
            }

            _context.Attach(DiplomaYearSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomaYearSectionExists(DiplomaYearSection.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DiplomaYearSectionExists(int id)
        {
            return _context.DiplomaYearSections.Any(e => e.Id == id);
        }
    }
}