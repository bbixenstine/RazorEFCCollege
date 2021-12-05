using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorCollege.Models
{
    public static class PagnStatic
    {
        public static int PageSize;
        static PagnStatic()
        {
            PageSize = 3;
        }

    }
}