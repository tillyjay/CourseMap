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

namespace nscccoursemap_tillyjay.Pages_AdvisingAssignments
{
    public class EditModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public EditModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AdvisingAssignment AdvisingAssignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisingassignment =  await _context.AdvisingAssignments.FirstOrDefaultAsync(m => m.Id == id);
            if (advisingassignment == null)
            {
                return NotFound();
            }
            AdvisingAssignment = advisingassignment;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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

            _context.Attach(AdvisingAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisingAssignmentExists(AdvisingAssignment.Id))
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

        private bool AdvisingAssignmentExists(int id)
        {
            return _context.AdvisingAssignments.Any(e => e.Id == id);
        }
    }
}
