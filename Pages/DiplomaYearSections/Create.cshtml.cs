using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_DiplomaYearSections
{
    public class CreateModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public CreateModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

public IActionResult OnGet()
{
    ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");

    var diplomaYears = _context.DiplomaYears
        .Select(dy => new { dy.Id, FullDiplomaTitle = $"{dy.Diploma.Title} - {dy.Title}" })
        .AsEnumerable()  //switch to client evaluation
        .OrderBy(dy => dy.FullDiplomaTitle)  //order by FullDiplomaTitle in memory
        .ToList();

    ViewData["DiplomaYearId"] = new SelectList(diplomaYears, "Id", "FullDiplomaTitle");

    return Page();
}

        [BindProperty]
        public DiplomaYearSection DiplomaYearSection { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");

            var diplomaYears = _context.DiplomaYears
            .Select(dy => new { dy.Id, FullDiplomaTitle = $"{dy.Diploma.Title} - {dy.Title}" })
            .AsEnumerable()  //switch to client evaluation
            .OrderBy(dy => dy.FullDiplomaTitle)  //order by FullDiplomaTitle in memory
            .ToList();

            ViewData["DiplomaYearId"] = new SelectList(diplomaYears, "Id", "FullDiplomaTitle");
                
                return Page();
            }

            _context.DiplomaYearSections.Add(DiplomaYearSection);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
