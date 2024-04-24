using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_AcademicYears
{
    public class DeleteModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DeleteModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AcademicYear AcademicYear { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicyear = await _context.AcademicYears.FirstOrDefaultAsync(m => m.Id == id);

            if (academicyear == null)
            {
                return NotFound();
            }
            else
            {
                AcademicYear = academicyear;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicyear = await _context.AcademicYears.FindAsync(id);
            if (academicyear != null)
            {
                AcademicYear = academicyear;
                _context.AcademicYears.Remove(AcademicYear);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
