using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace RazorCollege.Pages.Shared.Components.Pagination
{
    public class PaginationViewComponent : ViewComponent
    {
        public PaginationViewComponent() {}
        public IViewComponentResult Invoke(IPaginatedList values)
        {
            return View(
                "Default", 
                new PaginationViewModel () 
                {
                    List = values,
                    RouteData = null
                }
            );
        }
    }
}



