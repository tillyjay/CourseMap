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
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public AdvisingAssignment AdvisingAssignment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisingassignment = await _context.AdvisingAssignments
                                                    .Include(a => a.DiplomaYearSection)
                                                        .ThenInclude(dys => dys.DiplomaYear)
                                                            .ThenInclude(dy => dy.Diploma)
                                                    .Include(a => a.Instructor)
                                                    .FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
