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
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<CourseOffering> CourseOffering { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CourseOffering = await _context.CourseOfferings
      .Include(c => c.Course)
        .Include(c => c.DiplomaYearSection)
            .ThenInclude(c => c.DiplomaYear)
                .ThenInclude(c => c.Diploma)
        .Include(c => c.Instructor)
        .Include(c => c.Semester)
        .OrderByDescending(c => c.Semester.StartDate) 
        .ThenBy(c => c.DiplomaYearSection.DiplomaYear.Diploma.Title) 
        .ThenBy(c => c.DiplomaYearSection.DiplomaYear.Title) 
        .ThenBy(c => c.DiplomaYearSection.Title) 
        .ThenBy(c => c.Course.CourseCode) 
        .ToListAsync();
        }
    }
}
