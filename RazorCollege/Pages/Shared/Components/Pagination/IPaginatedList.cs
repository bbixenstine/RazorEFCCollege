using System.Collections;

namespace RazorCollege.Pages.Shared.Components.Pagination
{
    public interface IPaginatedList : IList
    {
        int CurrentPage { get; }
        int TotalPages { get; }
        int TotalItems { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}