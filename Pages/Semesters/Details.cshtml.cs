using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_Semesters
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Semester Semester { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var semester = await _context.Semesters
            .Include(s => s.AcademicYear) 
            .Include(s => s.CourseOfferings)
                .ThenInclude(co => co.Course)
            .Include(s => s.CourseOfferings)
                .ThenInclude(s => s.DiplomaYearSection)
                    .ThenInclude(dys => dys.DiplomaYear)
                        .ThenInclude(dy => dy.Diploma)
            .Include(s => s.CourseOfferings)
                .ThenInclude(co => co.DiplomaYearSection)
                    .ThenInclude(dys => dys.AdvisingAssignment)
                        .ThenInclude(aa => aa.Instructor)
            .FirstOrDefaultAsync(m => m.Id == id);  


            if (semester == null)
            {
                return NotFound();
            }
            else
            {

            semester.CourseOfferings = semester.CourseOfferings
                  .OrderBy(co => co.DiplomaYearSection.DiplomaYear.Diploma.Title)
                        .ThenBy(co => co.DiplomaYearSection.DiplomaYear.Title)
                        .ThenBy(co => co.Course.CourseCode)
                    .ToList();

            Semester = semester;

            }
            return Page();
        }
    }
}
