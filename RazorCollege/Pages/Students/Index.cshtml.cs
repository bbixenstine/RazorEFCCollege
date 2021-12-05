using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options; // required for IOptions
using RazorCollege.Data;
using RazorCollege.Models;
using Microsoft.AspNetCore.Mvc.Rendering; // required for SelectListItem

namespace RazorCollege.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly RazorCollege.Data.SchoolContext _context;
        // added for pagination
        private readonly IConfiguration Configuration;
        private readonly MvcOptions _mvcOptions;

        public IndexModel(RazorCollege.Data.SchoolContext context, IConfiguration configuration, 
                IOptions<MvcOptions> mvcOptions)
        {
            _context = context;
            Configuration = configuration;
            _mvcOptions = mvcOptions.Value;
        }
        /*public IList<Student> Student { get;set; }
        public async Task OnGetAsync()
        {
            //Student = await _context.Students.ToListAsync();
            Student = await _context.Students
                .OrderBy(x => x.LastName) // need to specify the order if going to limit the number of rows taken
                .Take(_mvcOptions.MaxModelBindingCollectionSize)
                .ToListAsync();
        }*/
        // code to introduce simple sorting based on name or date
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string IDSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentSortDescription { get; set; }
        public int StudentCount { get; set; }
        public int StudentIQCount { get; set; }
        public int DisplayedPageNo { get; set; }

        public string CurSort { get; set; }
        //public IList<Student> Students { get; set; }
        // change to use PaginatedList -- defines an instance of a paginated Student List
        public List<SelectListItem> pgSizeOptions => Enumerable.Range(1, 10).Concat(Enumerable.Range(3, 10).Select(x => x * 5)).ToList()
        .Select(n => new SelectListItem {
            Value = n.ToString(),
            Text = n.ToString()
        }).ToList();

        [BindProperty] public string PgSize { get; set; }

        public PaginatedListPN<Student> Students { get; set; }
        //public async Task OnGetAsync(string sortOrder)
        // searchString is supplied by a text box in Index.cshtml
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            // using System;
            System.Console.WriteLine($"In OnGetAsync, sortOrder = {sortOrder}");
            System.Console.WriteLine($"In OnGetAsync, before defining, CurSort = {CurSort}");
            System.Console.WriteLine($"In OnGetAsync, before defining, IDSort = {IDSort}");
            System.Console.WriteLine($"In OnGetAsync, pageIndex = {pageIndex}");
            System.Console.WriteLine($"In OnGetAsync, CurrentSort = {CurrentSort}");
            System.Console.WriteLine($"In OnGetAsync, searchString = {searchString}");
            System.Console.WriteLine($"In OnGetAsync, currentFilter = {currentFilter}");
            CurSort = sortOrder;
            // added for pagination -- need both a searchString and currentFilter variable, so that
            // initial setting of searchString sets pageIndex to 1, but currentFilter is used to 
            // preserve the filter after it is initially set (and searchString is NOT returned, so that
            // it will be null either before or after a filter value is set)
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            //
            CurrentFilter = searchString; // added for filtering
            System.Console.WriteLine($"In OnGetAsync, after defining, CurSort = {CurSort}");
            System.Console.WriteLine($"In OnGetAsync, after defining, pageIndex = {pageIndex}");
            System.Console.WriteLine($"In OnGetAsync, after defining, CurrentFilter = {CurrentFilter}");
            // use any names you want with suffix Sort, then associate each name with a model property
            // in an <a> element with tag helper asp-route-sortOrder
            // the default order parameter is the one that looks at String.IsNullOrEmpty since sortOrder starts as null
            // and is the default option in Switch (here Name)
            if(String.IsNullOrEmpty(sortOrder)) System.Console.WriteLine("sortOrder is null or empty");
            if(!String.IsNullOrEmpty(PgSize))
                System.Console.WriteLine("in IndexModel, OnGetAsync() at onset, PgSize = {0}",
                PgSize);
            // initially, sortOrder will be empty, which means NameSort set to ND, DateSort set to Date
            // and IDSort set to ID, and NameSort set to ND
            // These values are then ready for whatever column is clicked next, to become the new sortValue
            // the parameter values are arbitrary when using a switch statement, which simply lines up the names
            /*NameSort = String.IsNullOrEmpty(sortOrder) ? "ND" : "";
            System.Console.WriteLine($"after defining, NameSort = {NameSort}");
            DateSort = sortOrder == "Date" ? "DD" : "Date";
            System.Console.WriteLine($"after defining, DateSort = {DateSort}");
            IDSort = sortOrder == "ID" ? "IDD" : "ID";
            System.Console.WriteLine($"after defining, IDSort = {IDSort}");
            IQueryable<Student> studentsIQ = from s in _context.Students
                                                select s;
            // the Switch values are set to match the definitions above
            switch (sortOrder)
            {
                case "ND":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "DD":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "ID":
                    studentsIQ = studentsIQ.OrderBy(s => s.ID);
                    break;
                case "IDD":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.ID);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }*/
            // if "regularize" the parameter values, can eliminate the switch statement, as follows -- 
            // the names MUST match the Student properties names
            NameSort = String.IsNullOrEmpty(sortOrder) ? "LastName_D" : "";
            System.Console.WriteLine($"after defining, NameSort = {NameSort}");
            DateSort = sortOrder == "EnrollmentDate" ? "EnrollmentDate_D" : "EnrollmentDate";
            System.Console.WriteLine($"after defining, DateSort = {DateSort}");
            IDSort = sortOrder == "ID" ? "ID_D" : "ID";
            System.Console.WriteLine($"after defining, IDSort = {IDSort}");
            var students = _context.Students;
            StudentCount = students.Count();
            System.Console.WriteLine($"Student count = {StudentCount}");
            /*IQueryable<Student> studentsIQ = from s in _context.Students
                                                select s; */
            IQueryable<Student> studentsIQ = from s in students
                                                select s;
            // filtering process
            // SQL Server defaults to case-insensitive. SQLite defaults to case-sensitive.
            if (!String.IsNullOrEmpty(searchString))
            {
                /*studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                                        || s.FirstMidName.Contains(searchString));*/
                // make the test explicitly case-insensitive:
                studentsIQ = studentsIQ.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                    || s.FirstMidName.ToUpper().Contains(searchString.ToUpper()));
            }
            StudentIQCount = studentsIQ.Count();
            System.Console.WriteLine("after any searchString applied, studentsIQ count =  {0}",
                StudentIQCount);
            // sort process
            bool descending = false;
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "LastName";
                CurrentSortDescription = "Sorted by " + sortOrder + " ascending";
            }
            else if (sortOrder.EndsWith("_D"))
            {
                sortOrder = sortOrder.Substring(0, sortOrder.Length - 2);
                descending = true;
            }
            if (descending)
            {
                studentsIQ = studentsIQ.OrderByDescending(e => EF.Property<object>(e, sortOrder));
                CurrentSortDescription = "Sorted by " + sortOrder + " descending";
            }
            else
            {
                studentsIQ = studentsIQ.OrderBy(e => EF.Property<object>(e, sortOrder));
                CurrentSortDescription = "Sorted by " + sortOrder + " ascending";
            }
                
            //Students = await studentsIQ.AsNoTracking().ToListAsync();
            // change to use pagination
            var pageSize = Configuration.GetValue("PageSize", 4);
            // PagnStatic.PageSize initially set to 3
            if(!String.IsNullOrEmpty(PgSize) && PgSize != "0") PagnStatic.PageSize = Int32.Parse(PgSize);
            pageSize = PagnStatic.PageSize;
            System.Console.WriteLine($"in OnGetAsync, pageSize = {pageSize}");
            DisplayedPageNo = pageIndex ?? 1;
            //if (!DisplayedPageNo.HasValue) DisplayedPageNo = 1;
            System.Console.WriteLine($"in OnGetAsync, DisplayedPageNo = {DisplayedPageNo}");
            System.Console.WriteLine("in OnGetAsync, listing students {0} to {1} of {2}",
                pageSize*(DisplayedPageNo - 1) + 1, 
                pageSize*(DisplayedPageNo) > StudentIQCount ? StudentIQCount : pageSize*(DisplayedPageNo), 
                StudentIQCount);
            Students = await PaginatedListPN<Student>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }

        public async Task OnPostUpdateAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex) // added
        {
            /*System.Console.WriteLine($"in OnPostUpdateAsync");
            if(!String.IsNullOrEmpty(PgSize))
                System.Console.WriteLine($"in OnPostUpdateAsync, PgSize = {PgSize}");
            await OnGetAsync(currentPage, PgSize);*/
            System.Console.WriteLine($"in OnPostUpdateAsync");
            System.Console.WriteLine($"in OnPostUpdateAsync, sortOrder = {sortOrder}");
            System.Console.WriteLine($"in OnPostUpdateAsync, CurSort = {CurSort}");
            System.Console.WriteLine($"in OnPostUpdateAsync, currentFilter = {currentFilter}");
            //System.Console.WriteLine($"in OnPostUpdateAsync, currentFilter = {currentFilter}");
            System.Console.WriteLine($"in OnPostUpdateAsync, CurrentFilter = {CurrentFilter}");
            System.Console.WriteLine($"in OnPostUpdateAsync, pageIndex = {pageIndex}");
            if(!String.IsNullOrEmpty(PgSize))
                System.Console.WriteLine($"in OnPostUpdateAsync, PgSize = {PgSize}");
            //await OnGetAsync(sortOrder, currentFilter, searchString, pageIndex);
            await OnGetAsync(sortOrder, currentFilter, searchString, pageIndex);
        }

    }
}
