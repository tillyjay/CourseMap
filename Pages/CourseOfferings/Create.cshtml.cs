using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_CourseOfferings
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
        ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
        ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name");
        ViewData["InstructorId"] = new SelectList(_context.Instructors
                .Select(i => new
                {
                    Id = i.Id,
                    FullName = $"{i.FirstName} {i.LastName}"
                }), "Id", "FullName");
        ViewData["DiplomaYearSectionId"] = new SelectList(_context.DiplomaYearSections
                .Select(d => new
                {
                    Id = d.Id,
                    Title = $"{d.DiplomaYear.Diploma.Title} {d.DiplomaYear.Title} {d.Title}"
                }), "Id", "Title");
            return Page();
        }

  
        [BindProperty]
        public CourseOffering CourseOffering { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "CourseCode");
                ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name");
                ViewData["InstructorId"] = new SelectList(_context.Instructors
                    .Select(i => new
                    {
                        Id = i.Id,
                        FullName = $"{i.FirstName} {i.LastName}"
                    }), "Id", "FullName");
                ViewData["DiplomaYearSectionId"] = new SelectList(_context.DiplomaYearSections
                    .Select(d => new
                    {
                        Id = d.Id,
                        Title = $"{d.DiplomaYear.Diploma.Title} {d.DiplomaYear.Title} {d.Title}"
                    }), "Id", "Title");

                return Page();
            }

            _context.CourseOfferings.Add(CourseOffering);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
