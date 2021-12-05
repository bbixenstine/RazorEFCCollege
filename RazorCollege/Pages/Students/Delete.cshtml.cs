using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorCollege.Data;
using RazorCollege.Models;

namespace RazorCollege.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly RazorCollege.Data.SchoolContext _context;
        private readonly ILogger<DeleteModel> _logger; // added for logging errors
        public DeleteModel(RazorCollege.Data.SchoolContext context, ILogger<DeleteModel> logger) // second param added
        {
            _context = context;
            _logger = logger; // added for logging errors
        }
        [BindProperty] public Student Student { get; set; }
        public string ErrorMessage { get; set; } // added for logging/displaying errors
        public string SortParam { get; set; }
        public string CurrentFilter { get; set; }
        public int DisplayedPageNo { get; set; }
        // any field can be exposed if it is a URL parameter and a Page Handler parameter
        // here, the parameter, if any, is obtained via the parameter sortOrder
        public async Task<IActionResult> OnGetAsync(int? id, string sortOrder, string searchString, string currentFilter, int? pageIndex, bool? saveChangesError = false) //second param added
        {
            if (id == null)
            {
                return NotFound();
            }
            
            SortParam = sortOrder;
            CurrentFilter = currentFilter; // added for filtering
            DisplayedPageNo = pageIndex ?? 1;
            System.Console.WriteLine($"in Delete OnGetAsync, SortParam = {SortParam}");
            System.Console.WriteLine($"in Delete OnGetAsync, CurrentFilter = {CurrentFilter}");
            System.Console.WriteLine($"in Delete OnGetAsync, DisplayedPageNo = {DisplayedPageNo}");
            //Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            Student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Student == null)
            {
                return NotFound();
            }
            // added for error display
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id, string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            if (id == null)
            {
                return NotFound();
            }
            SortParam = sortOrder;
            CurrentFilter = currentFilter; // added for filtering
            DisplayedPageNo = pageIndex ?? 1;
            System.Console.WriteLine($"in Delete OnPostAsync, SortParam = {SortParam}");
            System.Console.WriteLine($"in Delete OnPostAsync, CurrentFilter = {CurrentFilter}");
            System.Console.WriteLine($"in Delete OnPostAsync, DisplayedPageNo = {DisplayedPageNo}");
            /*Student = await _context.Students.FindAsync(id);
            if (Student != null)
            {
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");*/
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            try
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                string sortP =  String.IsNullOrEmpty(SortParam) ? "" : "?sortOrder=" + SortParam;
                //return RedirectToPage("./Index"); // this returns to base page
                // the below returns to https://localhost:5001/Students/Index?sortOrder=ID, but that works the same 
                // as https://localhost:5001/Students?sortOrder=ID
                return Redirect("../Index" + sortP);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);
                /* When OnGetAsync is called by OnPostAsync via the return below, because the delete operation failed, 
                the saveChangesError parameter is true. */
                return RedirectToAction("./Delete",
                    new { id, saveChangesError = true });
            }
        }
    }
}
