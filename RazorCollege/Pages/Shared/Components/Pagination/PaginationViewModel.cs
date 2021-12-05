using System.Collections.Generic;

namespace RazorCollege.Pages.Shared.Components.Pagination
{
    public class PaginationViewModel
    {
        public IPaginatedList List {get; set;}
        public Dictionary<string,string> RouteData {get; set;}

    }
}