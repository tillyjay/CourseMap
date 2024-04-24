using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_DiplomaYears
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
        ViewData["DiplomaId"] = new SelectList(_context.Diplomas, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public DiplomaYear DiplomaYear { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["DiplomaId"] = new SelectList(_context.Diplomas, "Id", "Title");
                return Page();
            }

            _context.DiplomaYears.Add(DiplomaYear);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
