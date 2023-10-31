using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RaviRazorPageMovieApp.Data;
using RaviRazorPageMovieApp.Models;

namespace RaviRazorPageMovieApp.Pages.Actors
{
    public class DetailsModel : PageModel
    {
        private readonly RaviRazorPageMovieApp.Data.RaviRazorPageMovieAppContext _context;

        public DetailsModel(RaviRazorPageMovieApp.Data.RaviRazorPageMovieAppContext context)
        {
            _context = context;
        }

      public Actor Actor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Actors == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors.FirstOrDefaultAsync(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }
            else 
            {
                Actor = actor;
            }
            return Page();
        }
    }
}
