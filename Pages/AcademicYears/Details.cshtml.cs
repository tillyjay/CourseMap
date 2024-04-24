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
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public AcademicYear AcademicYear { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicyear = await _context
                                        .AcademicYears
                                        .Include(ay => ay.Semesters.OrderBy(s => s.StartDate))
                                        .Include(ay => ay.DiplomaYearSections)
                                            .ThenInclude(dys => dys.AdvisingAssignment)
                                                .ThenInclude(aa => aa.Instructor)
                                        .Include(ay => ay.DiplomaYearSections)
                                            .ThenInclude(dys => dys.DiplomaYear)
                                                .ThenInclude(dy => dy.Diploma)
                                        .FirstOrDefaultAsync(m => m.Id == id);
          
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
    }
}
