using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCollege.Data;
using RazorCollege.Models;

namespace RazorCollege.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly RazorCollege.Data.SchoolContext _context;
        public DetailsModel(RazorCollege.Data.SchoolContext context)
        {
            _context = context;
        }
        public Student Student { get; set; }
        public string SortParam { get; set; }
        public string CurrentFilter { get; set; }
        public int DisplayedPageNo { get; set; }
        // any field can be exposed if it is a URL parameter and a Page Handler parameter
        // here, the parameter, if any, is obtained via the parameter sortOrder
        public async Task<IActionResult> OnGetAsync(int? id, string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            if (id == null)
            {
                return NotFound();
            }
            SortParam = sortOrder;
            CurrentFilter = currentFilter; // added for filtering
            DisplayedPageNo = pageIndex ?? 1;
            System.Console.WriteLine($"in Details OnGetAsync, SortParam = {SortParam}");
            System.Console.WriteLine($"in Details OnGetAsync, CurrentFilter = {CurrentFilter}");
            System.Console.WriteLine($"in Details OnGetAsync, DisplayedPageNo = {DisplayedPageNo}");
            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            System.Console.WriteLine("for Student with ID = {0}, Student.Enrollment count = {1}",
                Student.ID, Student.Enrollments.Count);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
