using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_DiplomaYears
{
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<DiplomaYear> DiplomaYear { get;set; } = default!;

        public async Task OnGetAsync()
        {
            
             DiplomaYear = await _context.DiplomaYears
                .Include(d => d.Diploma)
                //order by diploma title 
                .OrderBy(d => d.Diploma.Title)
               //then by year title
                .ThenBy(d => d.Title)
                .ToListAsync();
        }
    }
}
