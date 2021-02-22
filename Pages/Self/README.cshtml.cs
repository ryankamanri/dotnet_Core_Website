using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Self
{
    public class ReadmeModel : PageModel
    {
        public PageResult OnGet()
        {
            return Page();
        }
    }
}
