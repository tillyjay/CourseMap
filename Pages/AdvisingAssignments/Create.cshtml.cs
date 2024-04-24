using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_AdvisingAssignments
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
        
        ViewData["InstructorId"] = new SelectList(_context.Instructors.Select(i => new { Id = i.Id, FullName = i.FirstName + " " + i.LastName }), "Id", "FullName");


        ViewData["DiplomaYearSectionId"] = new SelectList(_context.DiplomaYearSections
            .Select(d => new
            {
                Id = d.Id,
                Title = d.DiplomaYear.Diploma.Title + " " + d.DiplomaYear.Title + " " + d.Title
            })
            .GroupBy(d => d.Title) //group by diploma title
            .Select(g => g.First()), //select the first item of each group
            "Id", "Title");
       
            
            return Page();
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

        ViewData["InstructorId"] = new SelectList(_context.Instructors.Select(i => new { Id = i.Id, FullName = i.FirstName + " " + i.LastName }), "Id", "FullName");

        ViewData["DiplomaYearSectionId"] = new SelectList(_context.DiplomaYearSections
            .Select(d => new
            {
                Id = d.Id,
                Title = d.DiplomaYear.Diploma.Title + " " + d.DiplomaYear.Title + " " + d.Title
            })
            .GroupBy(d => d.Title) //group by diploma title
            .Select(g => g.First()), //select the first item of each group
            "Id", "Title");

                return Page();
            }

            _context.AdvisingAssignments.Add(AdvisingAssignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
