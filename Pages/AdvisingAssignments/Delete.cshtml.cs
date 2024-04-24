using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_AdvisingAssignments
{
    public class DeleteModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DeleteModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
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

            var advisingassignment = await _context.AdvisingAssignments.FirstOrDefaultAsync(m => m.Id == id);

            if (advisingassignment == null)
            {
                return NotFound();
            }
            else
            {
                AdvisingAssignment = advisingassignment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisingassignment = await _context.AdvisingAssignments.FindAsync(id);
            if (advisingassignment != null)
            {
                AdvisingAssignment = advisingassignment;
                _context.AdvisingAssignments.Remove(AdvisingAssignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
