using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorCollege.Data;
using RazorCollege.Models;

namespace RazorCollege.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly RazorCollege.Data.SchoolContext _context;

        public EditModel(RazorCollege.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty] public Student Student { get; set; }
        public string CurrentFilter { get; set; }
        public string SortParam { get; set; }
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
            System.Console.WriteLine($"in Edit OnGetAsync, SortParam = {SortParam}");
            System.Console.WriteLine($"in Edit OnGetAsync, CurrentFilter = {CurrentFilter}");
            System.Console.WriteLine($"in Edit OnGetAsync, DisplayedPageNo = {DisplayedPageNo}");
            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            // When you don't have to include related data, FindAsync is more efficient.
            Student = await _context.Students.FindAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        /*public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Student).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }*/
        public async Task<IActionResult> OnPostAsync(int id, string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            SortParam = sortOrder;
            CurrentFilter = currentFilter; // added for filtering
            DisplayedPageNo = pageIndex ?? 1;
            System.Console.WriteLine($"in Edit OnPostAsync, SortParam = {SortParam}");
            System.Console.WriteLine($"in Edit OnPostAsync, CurrentFilter = {CurrentFilter}");
            System.Console.WriteLine($"in Edit OnPostAsync, DisplayedPageNo = {DisplayedPageNo}");
            // Request.Form WORKS, NOT USING BINDPROPERTY
            var name = Request.Form["Student.LastName"];
            System.Console.WriteLine($"in Edit OnPostAsync, name = {name}");
            var studentToUpdate = await _context.Students.FindAsync(id);
            if (studentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "student",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                string sortP =  String.IsNullOrEmpty(SortParam) ? "?sortOrder=LastName" : "?sortOrder=" + SortParam;
                sortP = sortP + "&pageIndex=" + DisplayedPageNo;
                sortP = String.IsNullOrEmpty(CurrentFilter) ? sortP : sortP + "&currentFilter=" + CurrentFilter;
                //return RedirectToPage("./Index"); // this returns to base page
                // the below returns to https://localhost:5001/Students/Index?sortOrder=ID, but that works the same 
                // as https://localhost:5001/Students?sortOrder=ID
                return Redirect("../Index" + sortP);
            }
            return Page();
        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
