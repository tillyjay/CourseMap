using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_CoursePrerequisites
{
    public class IndexModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public IndexModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public IList<CoursePrerequisite> CoursePrerequisite { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CoursePrerequisite = await _context.CoursePrerequisites
                .Include(c => c.Course)
                .Include(c => c.Prerequisite)
                .OrderBy(cp => cp.Course.CourseCode)
                .ThenBy(cp => cp.Prerequisite.CourseCode)
                .ToListAsync();
        }
    }
}
