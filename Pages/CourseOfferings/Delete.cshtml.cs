using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_CourseOfferings
{
    public class DeleteModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DeleteModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CourseOffering CourseOffering { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseoffering = await _context.CourseOfferings.FirstOrDefaultAsync(m => m.Id == id);

            if (courseoffering == null)
            {
                return NotFound();
            }
            else
            {
                CourseOffering = courseoffering;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseoffering = await _context.CourseOfferings.FindAsync(id);
            if (courseoffering != null)
            {
                CourseOffering = courseoffering;
                _context.CourseOfferings.Remove(CourseOffering);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
