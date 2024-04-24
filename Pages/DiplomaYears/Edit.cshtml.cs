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

namespace nscccoursemap_tillyjay.Pages_DiplomaYears
{
    public class EditModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public EditModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiplomaYear DiplomaYear { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diplomayear =  await _context.DiplomaYears.FirstOrDefaultAsync(m => m.Id == id);
            if (diplomayear == null)
            {
                return NotFound();
            }
            DiplomaYear = diplomayear;
           ViewData["DiplomaId"] = new SelectList(_context.Diplomas, "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["DiplomaId"] = new SelectList(_context.Diplomas, "Id", "Title");
                return Page();
            }

            _context.Attach(DiplomaYear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiplomaYearExists(DiplomaYear.Id))
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

        private bool DiplomaYearExists(int id)
        {
            return _context.DiplomaYears.Any(e => e.Id == id);
        }
    }
}
