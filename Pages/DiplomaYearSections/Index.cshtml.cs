using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_DiplomaYearSections
{
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaYearSection> DiplomaYearSections { get;set; } = default!;

        public async Task OnGetAsync()
        {

        DiplomaYearSections = await _context.DiplomaYearSections
        .Include(dys => dys.DiplomaYear)
            .ThenInclude(dy => dy.Diploma)
        .Include(dys => dys.AcademicYear)
        .OrderByDescending(dys => dys.AcademicYear.Title) //order by AcademicYear descending
        .ThenBy(dys => dys.DiplomaYear.Diploma.Title)      //then by Diploma title alphabetically
        .ThenBy(dys => dys.DiplomaYear.Title)              //then by DiplomaYear ascending within the title
        .ThenBy(dys => dys.Title)                           //then by Title ascending
        .ToListAsync();
    
        }
    }
}
