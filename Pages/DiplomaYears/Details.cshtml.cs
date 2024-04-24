using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_DiplomaYears
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public DiplomaYear DiplomaYear { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diplomaYear = await _context.DiplomaYears
                                .Include(dy => dy.Diploma) 
                                .Include(dy => dy.DiplomaYearSections)
                                    .ThenInclude(dys => dys.CourseOfferings)
                                        .ThenInclude(co => co.Course)
                                .Include(dy => dy.DiplomaYearSections)
                                    .ThenInclude(dys => dys.CourseOfferings)
                                        .ThenInclude(co => co.Semester)
                                .Include(dy => dy.DiplomaYearSections)
                                    .ThenInclude(dys => dys.AdvisingAssignment)
                                        .ThenInclude(aa => aa.Instructor)

                                .FirstOrDefaultAsync(m => m.Id == id);
            if (diplomaYear == null)
            {
                return NotFound();
            }
                    DiplomaYear = diplomaYear;
            return Page();
        }
    }
}
