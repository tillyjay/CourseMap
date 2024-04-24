using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nscccoursemap_tillyjay.Data;
using nscccoursemap_tillyjay.Models;

namespace nscccoursemap_tillyjay.Pages_Courses
{
    public class DetailsModel : PageModel
    {
        private readonly nscccoursemap_tillyjay.Data.NSCCCourseMapContext _context;

        public DetailsModel(nscccoursemap_tillyjay.Data.NSCCCourseMapContext context)
        {
            _context = context;
        }

        public Course Course { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
                     //1.	Details page Add a section that lists the list of Pre-requisite courses and the
                     // list of courses for which the course is a prerequisite.
            var course = await _context.Courses
                               .Include(c => c.Prerequisites)
                                    .ThenInclude(cp => cp.Prerequisite)
                                .Include(c => c.IsPrerequisiteFor)
                                    .ThenInclude(cp => cp.Course)
                                .FirstOrDefaultAsync(m => m.Id == id);
                           
                    
            if (course == null)
            {
                return NotFound();
            }
            else
            {
                Course = course;
            }
            return Page();
        }
    }
}
