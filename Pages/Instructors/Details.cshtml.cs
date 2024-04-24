using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_Instructors
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Instructor Instructor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                                            .Include(i => i.AdvisingAssignments)
                                                .ThenInclude(a => a.DiplomaYearSection)
                                                    .ThenInclude(d => d.DiplomaYear)
                                                        .ThenInclude(d => d.Diploma)
                                            .Include(i => i.AdvisingAssignments)
                                                .ThenInclude(a => a.DiplomaYearSection)
                                                    .ThenInclude(d => d.AcademicYear)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            if (instructor == null)
            {
                return NotFound();
            }
            else
            {
                Instructor = instructor;
            }
            return Page();
        }
    }
}
