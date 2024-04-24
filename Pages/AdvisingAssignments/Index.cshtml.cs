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
    public class IndexModel : PageModel
    {
        private readonly NSCCCourseMapContext _context;

        public IndexModel(NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<AdvisingAssignment> AdvisingAssignment { get;set; } = default!;

        public async Task OnGetAsync()
        {

               
    AdvisingAssignment = await _context.AdvisingAssignments
        .Include(a => a.DiplomaYearSection)
            .ThenInclude(a => a.DiplomaYear)
            .ThenInclude(a => a.Diploma)
        .Include(a => a.Instructor)
        .OrderBy(a => a.DiplomaYearSection.DiplomaYear.Diploma.Title)
            .ThenByDescending(a => a.DiplomaYearSection.DiplomaYear.Title)
            .ThenBy(a => a.DiplomaYearSection.Title)
        .ToListAsync();

    //filter out duplicate combinations
    AdvisingAssignment = AdvisingAssignment
        .GroupBy(a => new { DiplomaTitle = a.DiplomaYearSection.DiplomaYear.Diploma.Title, 
                            YearTitle = a.DiplomaYearSection.DiplomaYear.Title,
                            SectionTitle = a.DiplomaYearSection.Title })
        .Select(g => g.First())
        .ToList();
                
                
                 
        }
    }
}
