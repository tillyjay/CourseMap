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
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public CourseOffering CourseOffering { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseoffering = await _context.CourseOfferings
                                                .Include(co => co.Course)
                                                .Include(co => co.DiplomaYearSection)
                                                    .ThenInclude(dys => dys.DiplomaYear)
                                                        .ThenInclude(dy => dy.Diploma)
                                                .Include(co => co.Semester)
                                                .Include(co => co.Instructor)
                                                .FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
