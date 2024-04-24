using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_Semesters
{
    public class CreateModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        //dependency injection
        public CreateModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");
            
            return Page();
        }

        [BindProperty]
        public Semester Semester { get; set; } = default!;

        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)

            {   
                ViewData["AcademicYearId"] = new SelectList(_context.AcademicYears, "Id", "Title");
                return Page();
            }

            _context.Semesters.Add(Semester);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
