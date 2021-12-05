using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorCollege.Data;
using RazorCollege.Models;

namespace RazorCollege.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly RazorCollege.Data.SchoolContext _context;
        public CreateModel(RazorCollege.Data.SchoolContext context)
        {
            _context = context;
        }
        public string SortParam { get; set; }
        public string CurrentFilter { get; set; }
        public int DisplayedPageNo { get; set; }
        // any field can be exposed if it is a URL parameter and a Page Handler parameter
        // here, the parameter, if any, is obtained via the parameter sortOrder
        public IActionResult OnGet(string sortOrder, string currentFilter, int? pageIndex)
        {
            SortParam = sortOrder;
            DisplayedPageNo = pageIndex ?? 1;
            CurrentFilter = currentFilter; // added for filtering
            System.Console.WriteLine($"in Create OnGetAsync, SortParam = {SortParam}");
            System.Console.WriteLine($"in Create OnGetAsync, DisplayedPageNo = {DisplayedPageNo}");
            System.Console.WriteLine($"in Create OnGetAsync, CurrentFilter = {CurrentFilter}");
            return Page();
        }
        /*[BindProperty] public Student Student { get; set; }*/
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        [BindProperty] public StudentVM StudentVM { get; set; }
        public async Task<IActionResult> OnPostAsync(string sortOrder, string currentFilter, int? pageIndex)
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");*/

            /* The scaffolded OnPostAsync code for the Create page is vulnerable to overposting. So Replace the above
            with the following code. */
            /*var emptyStudent = new Student();
            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();*/

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            
            //string sortP =  String.IsNullOrEmpty(SortParam) ? "" : "?sortOrder=" + SortParam;
            // SET UP SO THAT SORT ORDER IS PRESERVED, BUT NOT FILTER OR PAGINATION
            SortParam = sortOrder;
            DisplayedPageNo = pageIndex ?? 1;
            CurrentFilter = currentFilter; // added for filtering
            System.Console.WriteLine($"in Create OnPostAsync, sortParam = {SortParam}");
            System.Console.WriteLine($"in Create OnPostAsync, DisplayedPageNo = {DisplayedPageNo}");
            System.Console.WriteLine($"in Create OnPostAsync, CurrentFilter = {CurrentFilter}");
            string sortP =  String.IsNullOrEmpty(SortParam) ? "?sortOrder=LastName" : "?sortOrder=" + SortParam;
            //sortP = sortP + "&pageIndex=" + DisplayedPageNo;
            //return RedirectToPage("./Index"); // this returns to base page
            return Redirect("../Students" + sortP);
        }
    }
}
